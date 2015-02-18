using System;
using System.Drawing;
using System.Windows.Forms;

namespace Replacement_for_Macros.Controls
{
  public partial class ControlBase : UserControl, IControlBase
  {
    public Point _previousLocation { get; set; }
    public bool _moving { get; set; }

    public bool EditMode { get; set; }

    public ControlBase()
    {
      InitializeComponent();

      if (DesignMode) return;

      MouseDown += ThisMouseDown;
      MouseMove += ThisMouseMove;
      MouseUp += ThisMouseUp;

      Load += Test;
    }

    private void Test(object sender, EventArgs e)
    {
      foreach (Control control in Controls)
      {
        //SetUpForControl(control);
      }
    }

    #region Moving Related Methods

    private void ThisMouseDown(object sender, MouseEventArgs e)
    {
      if (!EditMode) return;

      _previousLocation = e.Location;
      Cursor = Cursors.Hand;
      _moving = true;
    }

    private void ThisMouseMove(object sender, MouseEventArgs e)
    {
      if (!EditMode) return;

      if (!_moving) return;
      var location = Location;
      location.Offset(e.Location.X - _previousLocation.X, e.Location.Y - _previousLocation.Y);
      Location = location;
    }

    private void ThisMouseUp(object sender, MouseEventArgs e)
    {
      if (!EditMode) return;

      _moving = false;
      Cursor = Cursors.Default;
    }

    #endregion
  }
}
