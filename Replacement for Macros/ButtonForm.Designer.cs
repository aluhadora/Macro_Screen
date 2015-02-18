using Replacement_for_Macros.Controls;
using Replacement_for_Macros.Controls.Authenticator;
using Replacement_for_Macros.Controls.BNetStatus;

namespace Replacement_for_Macros
{
  partial class ButtonForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.editButton = new Replacement_for_Macros.Controls.ProcessButton();
      this.exitButton = new Replacement_for_Macros.Controls.ProcessButton();
      this.SuspendLayout();
      // 
      // editButton
      // 
      this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.editButton.BackgroundImage = global::Replacement_for_Macros.Properties.Resources._1380570647939;
      this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.editButton.Location = new System.Drawing.Point(1844, 1004);
      this.editButton.Name = "editButton";
      this.editButton.ProcessArguments = null;
      this.editButton.ProcessToStart = null;
      this.editButton.Size = new System.Drawing.Size(64, 64);
      this.editButton.TabIndex = 1;
      this.toolTip.SetToolTip(this.editButton, "Edit mode");
      this.editButton.UseVisualStyleBackColor = true;
      this.editButton.Click += new System.EventHandler(this.editButton_Click);
      // 
      // exitButton
      // 
      this.exitButton.BackgroundImage = global::Replacement_for_Macros.Properties.Resources.cancel;
      this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.exitButton.Location = new System.Drawing.Point(12, 12);
      this.exitButton.Name = "exitButton";
      this.exitButton.ProcessArguments = null;
      this.exitButton.ProcessToStart = null;
      this.exitButton.Size = new System.Drawing.Size(64, 64);
      this.exitButton.TabIndex = 0;
      this.toolTip.SetToolTip(this.exitButton, "Exit");
      this.exitButton.UseVisualStyleBackColor = true;
      // 
      // ButtonForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.HotTrack;
      this.ClientSize = new System.Drawing.Size(1920, 1080);
      this.Controls.Add(this.editButton);
      this.Controls.Add(this.exitButton);
      this.Cursor = System.Windows.Forms.Cursors.Default;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "ButtonForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Buttons";
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
      this.Load += new System.EventHandler(this.ButtonForm_Load);
      this.Click += new System.EventHandler(this.ButtonForm_Click);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonForm_MouseUp);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolTip toolTip;
    private ProcessButton exitButton;
    private ProcessButton editButton;
  }
}