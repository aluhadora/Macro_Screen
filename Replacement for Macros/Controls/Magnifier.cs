using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using Replacement_for_Macros.Utilities;
using Timer = System.Windows.Forms.Timer;

namespace Replacement_for_Macros.Controls
{
  public partial class Magnifier : UserControl, IControlBase
  {
    private Timer _timer;
    private int _modifier = 1;

    public Magnifier()
    {
      InitializeComponent();

      pictureBox.MouseWheel += MouseWheeled;

      MovementUtility.SetupControl(this);
    }

    protected override void OnParentChanged(EventArgs e)
    {
      ((Form)Parent).Closing += OnClosing;
      Parent.MouseWheel += MouseWheeled;
      if (!DesignMode) SetupTimer();
    }

    #region Magnification Stuff

    private void SetupTimer()
    {
      _timer = new Timer
      {
        Interval = 100,
      };

      _timer.Tick += TickEvent;
      _timer.Start();
    }

    private void TickEvent(object sender, EventArgs e)
    {
      BeginInvoke(new Action(Tick));
    }

    private void Tick()
    {
      var width = (int)(Math.Ceiling((pictureBox.Size.Width - pictureBox.Size.Width % (double)_modifier) / _modifier));
      var height = (int)(Math.Ceiling((pictureBox.Size.Height - pictureBox.Size.Height % (double)_modifier) / _modifier));
      int x = Cursor.Position.X;
      int y = Cursor.Position.Y;

      SetImage(GetBMP(width, height, x, y));
      GC.Collect();
    }

    private Bitmap GetBMP(int width, int height, int x, int y)
    {
      var screenBMP = new Bitmap(width, height);

      using (var g = Graphics.FromImage(screenBMP))
      {
        try
        {
          g.CopyFromScreen(new Point(x - width / 2, y - height / 2), new Point(0, 0), new Size(width, height));
        }
        catch { }

        g.DrawEllipse(Pens.Black, width / 2 - 2, height / 2 - 2, 4, 4);
        screenBMP.SetPixel(width / 2, height / 2, Color.Red);
      }

      var bmp = new Bitmap(pictureBox.Size.Width - pictureBox.Size.Width % _modifier, pictureBox.Size.Height - pictureBox.Size.Height % _modifier);
      using (var g = Graphics.FromImage(bmp))
      {
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        if (_modifier < 3)
        {
          g.DrawImage(screenBMP, 0, 0, bmp.Width, bmp.Height);
        }
        else if (_modifier >= 3)
        {
          g.DrawImage(screenBMP, _modifier / 2, _modifier / 2, bmp.Width, bmp.Height);

          for (int i = 0; i < bmp.Width; i += _modifier)
          {
            g.DrawLine(new Pen(Color.Green, 1), i, 0, i, bmp.Height);
          }
          for (int j = 0; j < bmp.Height; j += _modifier)
          {
            g.DrawLine(new Pen(Color.Green, 1), 0, j, bmp.Width, j);
          }
        }
      }
      return bmp;
    }

    private void SetImage(Bitmap bmp)
    {
      if (!_timer.Enabled) return;
      var newBmp = new Bitmap(bmp);
      bmp.Dispose();
      try
      {
        if (pictureBox.InvokeRequired)
          pictureBox.Invoke(new Action<Bitmap>(SetImage), newBmp);
        else
        {
          pictureBox.Image = newBmp;
        }
      }
      catch (Exception)
      {
        _timer.Stop();
      }
    }

    private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
    {
      _timer.Stop();
      Thread.Sleep(100);
    }

    private void MouseWheeled(object sender, MouseEventArgs e)
    {
      var up = e.Delta > 0;
      if (!up && _modifier <= 1) return;
      if (up && _modifier >= 24) return;
      _modifier += up ? 1 : -1;
    }

    #endregion

    bool IControlBase.EditMode { get; set; }
    bool IControlBase._moving { get; set; }
    Point IControlBase._previousLocation { get; set; }
  }
}
