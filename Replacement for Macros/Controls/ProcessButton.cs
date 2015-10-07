using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Replacement_for_Macros.Controls.Dialogs;
using Replacement_for_Macros.Utilities;

namespace Replacement_for_Macros.Controls
{
  public class ProcessButton : Button, IControlBase
  {
    public string ProcessToStart { get; set;}
    public string ProcessArguments { get; set;}
    public string WorkingDirectory { get; set; }

    public Action<string> SetTooltip { get; set; } 
    public Func<string> GetTooltip { get; set; } 

    public ProcessButton()
    {
      Click += ProcessStart;
      MouseUp += EditMouseUp;

      Width = 64;
      Height = 64;

      MovementUtility.SetupControl(this);
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
          new MenuItem("Image", ImageMenuClick),
          new MenuItem("Process Information", ProcessInfoClick), 
        });
        ContextMenu.Show(this, e.Location);
      }
    }

    private void ProcessInfoClick(object sender, EventArgs e)
    {
      var dialog = new ProcessDialog(ProcessToStart, ProcessArguments, GetTooltip(), WorkingDirectory);

      dialog.ShowDialog(this);

      if (!dialog.OKButtonClicked) return;

      ProcessToStart = dialog.Process;
      ProcessArguments = dialog.Arguments;
      WorkingDirectory = dialog.WorkingDirectory;
      SetTooltip(dialog.Tooltip);
    }

    private void ImageMenuClick(object sender, EventArgs e)
    {
      var dialog = new OpenFileDialog
      {
        Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
      };
      dialog.ShowDialog(this);

      if (dialog.FileName == string.Empty) return;

      try
      {
        BackgroundImage = Image.FromFile(dialog.FileName);
        BackgroundImageLayout = ImageLayout.Stretch;
        Invalidate();
      }
      catch (Exception)
      {
        MessageBox.Show("Invalid image file");
      }
      
    }

    private void ProcessStart(object sender, EventArgs e)
    {
      if (EditMode) return;

      if (!string.IsNullOrEmpty(ProcessToStart))
      {
        Start(ProcessToStart, ProcessArguments, WorkingDirectory);
      }
    }

    private void Start(string processToStart, string processArguments, string workingDirectory)
    {
      try
      {
        Process.Start(new ProcessStartInfo(processToStart, processArguments)
        {
          WorkingDirectory = workingDirectory
        });
      }
      catch (Exception)
      {
        MessageBox.Show("File not found", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public bool EditMode { get; set; }
    bool IControlBase._moving { get; set; }
    Point IControlBase._previousLocation { get; set; }
  }
}
