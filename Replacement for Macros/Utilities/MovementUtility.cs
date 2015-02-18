using System.Windows.Forms;
using Replacement_for_Macros.Controls;

namespace Replacement_for_Macros.Utilities
{
  public static class MovementUtility
  {
    public static void SetupControl(Control control)
    {
      control.MouseDown += MouseDown;
      control.MouseMove += MouseMove;
      control.MouseUp += MouseUp;

      foreach (Control childControl in control.Controls)
      {
        childControl.MouseDown += (x, y) => MouseDown(control, y);
        childControl.MouseMove += (x, y) => MouseMove(control, y);
        childControl.MouseUp += (x, y) => MouseUp(control, y);
      }
    }

    private static void MouseDown(object sender, MouseEventArgs e)
    {
      var controlBase = (IControlBase) sender;
      var control = (Control) sender;

      if (!controlBase.EditMode) return;

      controlBase._previousLocation = e.Location;
      control.Cursor = Cursors.Hand;
      controlBase._moving = true;
    }

    private static void MouseMove(object sender, MouseEventArgs e)
    {
      var controlBase = (IControlBase)sender;
      var control = (Control)sender;

      if (!controlBase.EditMode) return;

      if (!controlBase._moving) return;
      var location = control.Location;
      location.Offset(e.Location.X - controlBase._previousLocation.X, e.Location.Y - controlBase._previousLocation.Y);
      control.Location = location;
    }

    private static void MouseUp(object sender, MouseEventArgs e)
    {
      var controlBase = (IControlBase)sender;
      var control = (Control)sender;

      if (!controlBase.EditMode) return;

      controlBase._moving = false;
      control.Cursor = Cursors.Default;
    }
  }
}
