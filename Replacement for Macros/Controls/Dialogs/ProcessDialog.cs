using System;
using System.Windows.Forms;

namespace Replacement_for_Macros.Controls.Dialogs
{
  public partial class ProcessDialog : Form
  {
    public bool OKButtonClicked { get; set; }

    public ProcessDialog()
    {
      InitializeComponent();

      OKButtonClicked = false;
    }

    public ProcessDialog(string process, string arguments, string tooltip, string directory) : this()
    {
      Process = process;
      Arguments = arguments;
      Tooltip = tooltip;
      WorkingDirectory = directory;
    }

    public string Process
    {
      get { return processTextBox.Text; }
      set { processTextBox.Text = value; }
    }

    public string Arguments
    {
      get { return argumentTextBox.Text; }
      set { argumentTextBox.Text = value; }
    }

    public string Tooltip
    {
      get { return tooltipTextBox.Text; }
      set { tooltipTextBox.Text = value; }
    }

    public string WorkingDirectory
    {
      get { return dirTextBox.Text; }
      set { dirTextBox.Text = value; }
    }


    private void cancelButton_Click(object sender, EventArgs e)
    {
      Hide();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      OKButtonClicked = true;
      Hide();
    }
  }
}
