namespace Replacement_for_Macros.Controls.BNetStatus
{
  partial class BNetStatus
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.bnetStatusPictureBox = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.bnetStatusPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // bnetStatusPictureBox
      // 
      this.bnetStatusPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.bnetStatusPictureBox.Image = global::Replacement_for_Macros.Properties.Resources.Circle_Blue;
      this.bnetStatusPictureBox.Location = new System.Drawing.Point(0, 0);
      this.bnetStatusPictureBox.Name = "bnetStatusPictureBox";
      this.bnetStatusPictureBox.Size = new System.Drawing.Size(64, 64);
      this.bnetStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.bnetStatusPictureBox.TabIndex = 4;
      this.bnetStatusPictureBox.TabStop = false;
      // 
      // BNetStatus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.bnetStatusPictureBox);
      this.Name = "BNetStatus";
      this.Size = new System.Drawing.Size(64, 64);
      ((System.ComponentModel.ISupportInitialize)(this.bnetStatusPictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox bnetStatusPictureBox;
  }
}
