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
			listBoxComPorts = new ListBox();
			label1 = new Label();
			checkBoxOrderEnableComPort = new CheckBox();
			textBoxComPortName = new TextBox();
			checkBoxIsConnected = new CheckBox();
			textBoxBaudRate = new TextBox();
			label2 = new Label();
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
			// listBoxComPorts
			// 
			listBoxComPorts.FormattingEnabled = true;
			listBoxComPorts.ItemHeight = 15;
			listBoxComPorts.Items.AddRange(new object[] { "Будущий список COM портов" });
			listBoxComPorts.Location = new Point(236, 9);
			listBoxComPorts.Name = "listBoxComPorts";
			listBoxComPorts.Size = new Size(192, 94);
			listBoxComPorts.TabIndex = 3;
			listBoxComPorts.DoubleClick += listBox1_DoubleClick;
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
			// checkBoxOrderEnableComPort
			// 
			checkBoxOrderEnableComPort.AutoSize = true;
			checkBoxOrderEnableComPort.Checked = true;
			checkBoxOrderEnableComPort.CheckState = CheckState.Checked;
			checkBoxOrderEnableComPort.Location = new Point(12, 9);
			checkBoxOrderEnableComPort.Name = "checkBoxOrderEnableComPort";
			checkBoxOrderEnableComPort.Size = new Size(218, 19);
			checkBoxOrderEnableComPort.TabIndex = 5;
			checkBoxOrderEnableComPort.Text = "Отправлять раскладку в COM порт";
			checkBoxOrderEnableComPort.UseVisualStyleBackColor = true;
			// 
			// textBoxComPortName
			// 
			textBoxComPortName.Location = new Point(12, 31);
			textBoxComPortName.Name = "textBoxComPortName";
			textBoxComPortName.Size = new Size(53, 23);
			textBoxComPortName.TabIndex = 6;
			textBoxComPortName.Text = "COM20";
			textBoxComPortName.TextChanged += textBoxComPortName_TextChanged;
			// 
			// checkBoxIsConnected
			// 
			checkBoxIsConnected.AutoSize = true;
			checkBoxIsConnected.Enabled = false;
			checkBoxIsConnected.Location = new Point(12, 89);
			checkBoxIsConnected.Name = "checkBoxIsConnected";
			checkBoxIsConnected.Size = new Size(177, 19);
			checkBoxIsConnected.TabIndex = 7;
			checkBoxIsConnected.Text = "Подключение установлено";
			checkBoxIsConnected.UseVisualStyleBackColor = true;
			// 
			// textBoxBaudRate
			// 
			textBoxBaudRate.Location = new Point(12, 60);
			textBoxBaudRate.Name = "textBoxBaudRate";
			textBoxBaudRate.Size = new Size(53, 23);
			textBoxBaudRate.TabIndex = 8;
			textBoxBaudRate.Text = "9600";
			textBoxBaudRate.TextChanged += textBoxBaudRate_TextChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(71, 63);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.TabIndex = 9;
			label2.Text = "BaudRate";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(label2);
			Controls.Add(textBoxBaudRate);
			Controls.Add(checkBoxIsConnected);
			Controls.Add(textBoxComPortName);
			Controls.Add(checkBoxOrderEnableComPort);
			Controls.Add(label1);
			Controls.Add(listBoxComPorts);
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
		private ListBox listBoxComPorts;
		private Label label1;
		private CheckBox checkBoxOrderEnableComPort;
		private TextBox textBoxComPortName;
		private CheckBox checkBoxIsConnected;
		private TextBox textBoxBaudRate;
		private Label label2;
	}
}
