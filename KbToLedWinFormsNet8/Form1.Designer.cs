﻿namespace KbToLedWinFormsNet8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			textBox1 = new TextBox();
			richTextBox1 = new RichTextBox();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(565, 31);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(214, 23);
			textBox1.TabIndex = 0;
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(501, 121);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(287, 303);
			richTextBox1.TabIndex = 1;
			richTextBox1.Text = "";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(richTextBox1);
			Controls.Add(textBox1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private RichTextBox richTextBox1;
	}
}