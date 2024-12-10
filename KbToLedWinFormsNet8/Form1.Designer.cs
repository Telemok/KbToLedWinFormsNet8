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
			richTextBox1 = new RichTextBox();
			listBox1 = new ListBox();
			label1 = new Label();
			checkBox1 = new CheckBox();
			textBox2 = new TextBox();
			SuspendLayout();
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(12, 121);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(776, 303);
			richTextBox1.TabIndex = 1;
			richTextBox1.Text = "";
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Items.AddRange(new object[] { "Будущий список COM портов" });
			listBox1.Location = new Point(236, 9);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(184, 79);
			listBox1.TabIndex = 3;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(71, 34);
			label1.Name = "label1";
			label1.Size = new Size(125, 15);
			label1.TabIndex = 4;
			label1.Text = "Название COM порта";
			label1.Click += label1_Click;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(12, 9);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(218, 19);
			checkBox1.TabIndex = 5;
			checkBox1.Text = "Отправлять раскладку в COM порт";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(12, 31);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(53, 23);
			textBox2.TabIndex = 6;
			textBox2.Text = "COM20";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textBox2);
			Controls.Add(checkBox1);
			Controls.Add(label1);
			Controls.Add(listBox1);
			Controls.Add(richTextBox1);
			Name = "Form1";
			Text = "Программа отправки раскладки клавиатуры в COM port";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private RichTextBox richTextBox1;
		private ListBox listBox1;
		private Label label1;
		private CheckBox checkBox1;
		private TextBox textBox2;
	}
}
