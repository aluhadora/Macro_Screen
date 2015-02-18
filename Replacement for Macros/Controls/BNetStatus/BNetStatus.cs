using System;
using System.Drawing;
using System.Windows.Forms;
using Replacement_for_Macros.Utilities;

namespace Replacement_for_Macros.Controls.BNetStatus
{
  public partial class BNetStatus : UserControl, IControlBase
  {
    public BNetStatus()
    {
      InitializeComponent();

      if (DesignMode) return;
      BnetStatusProcess.Go(SetBNetStatusImage);

      MovementUtility.SetupControl(this);
      bnetStatusPictureBox.MouseUp += EditMouseUp;
    }

    private void SetBNetStatusImage(Image image)
    {
      if (bnetStatusPictureBox.InvokeRequired)
        bnetStatusPictureBox.Invoke(new Action<Image>(SetBNetStatusImage), image);
      else
        bnetStatusPictureBox.Image = image;
    }

    private void EditMouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right) return;
      if (!EditMode)
      {
        ContextMenu = null;
      }
      else
      {
        ContextMenu = new ContextMenu(new[]
        {
          new MenuItem("Delete", (x, y) => Parent.Controls.Remove(this)),
        });
        ContextMenu.Show(this, e.Location);
      }
    }

    public bool EditMode { get; set; }
    bool IControlBase._moving { get; set; }
    Point IControlBase._previousLocation { get; set; }
  }
}
