﻿namespace Replacement_for_Macros.Controls.Dialogs
{
  partial class ProcessDialog
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
      this.processTextBox = new System.Windows.Forms.TextBox();
      this.argumentTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.tooltipTextBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.dirTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // processTextBox
      // 
      this.processTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.processTextBox.Location = new System.Drawing.Point(111, 12);
      this.processTextBox.Name = "processTextBox";
      this.processTextBox.Size = new System.Drawing.Size(436, 20);
      this.processTextBox.TabIndex = 0;
      // 
      // argumentTextBox
      // 
      this.argumentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.argumentTextBox.Location = new System.Drawing.Point(111, 64);
      this.argumentTextBox.Name = "argumentTextBox";
      this.argumentTextBox.Size = new System.Drawing.Size(436, 20);
      this.argumentTextBox.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Process to Run:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Arguments:";
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.Location = new System.Drawing.Point(472, 131);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 1002;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(391, 131);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 1001;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 93);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(45, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Tool tip:";
      // 
      // tooltipTextBox
      // 
      this.tooltipTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tooltipTextBox.Location = new System.Drawing.Point(111, 90);
      this.tooltipTextBox.Name = "tooltipTextBox";
      this.tooltipTextBox.Size = new System.Drawing.Size(436, 20);
      this.tooltipTextBox.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 41);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(93, 13);
      this.label4.TabIndex = 1004;
      this.label4.Text = "Working directory:";
      // 
      // dirTextBox
      // 
      this.dirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dirTextBox.Location = new System.Drawing.Point(111, 38);
      this.dirTextBox.Name = "dirTextBox";
      this.dirTextBox.Size = new System.Drawing.Size(436, 20);
      this.dirTextBox.TabIndex = 1;
      // 
      // ProcessDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(559, 164);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.dirTextBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.tooltipTextBox);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.argumentTextBox);
      this.Controls.Add(this.processTextBox);
      this.Name = "ProcessDialog";
      this.Text = "ProcessDialog";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox processTextBox;
    private System.Windows.Forms.TextBox argumentTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tooltipTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox dirTextBox;
  }
}