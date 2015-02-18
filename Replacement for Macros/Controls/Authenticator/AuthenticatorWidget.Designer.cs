namespace Replacement_for_Macros.Controls.Authenticator
{
  partial class AuthenticatorWidget
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
      this.textBox = new System.Windows.Forms.TextBox();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.SuspendLayout();
      // 
      // textBox
      // 
      this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox.Enabled = false;
      this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox.Location = new System.Drawing.Point(0, 0);
      this.textBox.Name = "textBox";
      this.textBox.Size = new System.Drawing.Size(150, 38);
      this.textBox.TabIndex = 0;
      this.textBox.Text = "XXXX";
      this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.textBox.Click += new System.EventHandler(this.AuthenticatorClick);
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(0, 42);
      this.progressBar.Maximum = 29;
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(150, 19);
      this.progressBar.TabIndex = 1;
      this.progressBar.Click += new System.EventHandler(this.AuthenticatorClick);
      // 
      // AuthenticatorWidget
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.textBox);
      this.Name = "AuthenticatorWidget";
      this.Size = new System.Drawing.Size(150, 61);
      this.Load += new System.EventHandler(this.AuthenticatorWidget_Load);
      this.Click += new System.EventHandler(this.AuthenticatorClick);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox;
    private System.Windows.Forms.ProgressBar progressBar;
  }
}
