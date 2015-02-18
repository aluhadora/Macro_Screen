using System;
using System.Drawing;
using System.Windows.Forms;
using Replacement_for_Macros.Controls;
using Replacement_for_Macros.Controls.BNetStatus;

namespace Replacement_for_Macros
{
  public partial class ButtonForm : Form
  {
    public ButtonForm()
    {
      InitializeComponent();
    }

    private void ButtonForm_Load(object sender, EventArgs e)
    {
      Top = 0;
      Left = 0;
      Width = Screen.PrimaryScreen.WorkingArea.Width;
      Height = Screen.PrimaryScreen.WorkingArea.Height;

      (new DefinitionProcessor()).LoadDefinition(AddControl, toolTip);

      editButton.Click -= ButtonForm_Click;
    }

    private void ButtonForm_Click(object sender, EventArgs e)
    {
      if (EditMode) return;
      if (ModifierKeys == Keys.Control) return;
      Close();
    }

    private void editButton_Click(object sender, EventArgs e)
    {
      EditMode = !EditMode;
      foreach (var control in Controls)
      {
        if (!(control is IControlBase)) continue;

        var controlBase = (IControlBase) control;
        controlBase.EditMode = EditMode;
      }

      ((IControlBase)exitButton).EditMode = false;
      ((IControlBase)editButton).EditMode = false;

      if (EditMode == false)
      {
        (new DefinitionProcessor()).WriteDefinition(Controls, control => toolTip.GetToolTip(control));
      }
    }

    public bool EditMode { get; set; }

    private void ButtonForm_MouseUp(object sender, MouseEventArgs e)
    {
      if (!EditMode) return;
      if (e.Button == MouseButtons.Left && ModifierKeys == Keys.Control)
      {
        AddProcessButton(e.Location);
      }

      ContextMenu = new ContextMenu(new[]
      {
        new MenuItem("Add a Process Button", (o, args) => AddProcessButton(e.Location)), 
        new MenuItem("Add a BNetStatus Widget", (o, args) => AddBnetStatus(e.Location)), 
      });

    }

    private void AddControl(Control control)
    {
      control.PreviewKeyDown += ControlKeyPressed;
      control.Click += ButtonForm_Click;
      Controls.Add(control);
    }

    private void AddProcessButton(Point location)
    {
      var control = new ProcessButton { Location = location, UseVisualStyleBackColor = true, EditMode = true };
      control.SetTooltip = x => toolTip.SetToolTip(control, x);
      control.GetTooltip = () => toolTip.GetToolTip(control);
      control.PreviewKeyDown += ControlKeyPressed;
      Controls.Add(control);
    }

    private void ControlKeyPressed(object sender, PreviewKeyDownEventArgs e)
    {
      var control = sender as Control;
      if (control == null) return;
      if (!(control is IControlBase)) return;
      if (!EditMode) return;

      e.IsInputKey = true;

      switch (e.KeyCode)
      {
        case Keys.Up:
          control.Top--;
          break;
        case Keys.Right:
          control.Left++;
          break;
        case Keys.Down:
          control.Top++;
          break;
        case Keys.Left:
          control.Left--;
          break;
        default:
          e.IsInputKey = false;
          break;
      }
    }

    private void AddBnetStatus(Point location)
    {
      var control = new BNetStatus { Location = location, EditMode = true };
      Controls.Add(control);
    }
  }
}
