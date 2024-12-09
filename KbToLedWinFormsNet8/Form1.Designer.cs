namespace KbToLedWinFormsNet8
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
			domainUpDown1 = new DomainUpDown();
			listBox1 = new ListBox();
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
			richTextBox1.Location = new Point(12, 121);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(776, 303);
			richTextBox1.TabIndex = 1;
			richTextBox1.Text = "";
			// 
			// domainUpDown1
			// 
			domainUpDown1.Location = new Point(309, 43);
			domainUpDown1.Name = "domainUpDown1";
			domainUpDown1.Size = new Size(151, 23);
			domainUpDown1.TabIndex = 2;
			domainUpDown1.Text = "domainUpDown1";
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Items.AddRange(new object[] { "qwe", "asd", "zxc" });
			listBox1.Location = new Point(473, 12);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(86, 79);
			listBox1.TabIndex = 3;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(listBox1);
			Controls.Add(domainUpDown1);
			Controls.Add(richTextBox1);
			Controls.Add(textBox1);
			Name = "Form1";
			Text = "Form1";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private RichTextBox richTextBox1;
		protected DomainUpDown domainUpDown1;
		private ListBox listBox1;
	}
}
