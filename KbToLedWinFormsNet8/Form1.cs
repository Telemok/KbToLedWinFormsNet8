using System.Globalization;
using System.IO.Ports;


namespace KbToLedWinFormsNet8
{
	public partial class Form1 : Form
	{

		public Libs.ControlledTimer loopTimer;

		public Form1()
		{
			InitializeComponent();
			loopTimer = new(() =>
			{
				CultureInfo cultureName = ServiceKeyboardLayout.GetForegroundWindowCultureInfo();

				// ���������� ���������� ������ ������
				UpdateComPortList();

				//log(s);

				bool connected = HandlerSerialPort.IsConnected();

				if (checkBoxOrderEnableComPort.Checked)
				{
					if (!connected)
					{
						log($"Try connect COM port({this.textBoxComPortName.Text}, {int.Parse(this.textBoxBaudRate.Text)})");
						HandlerSerialPort.InitSerialPort(this.textBoxComPortName.Text, int.Parse(this.textBoxBaudRate.Text));
					}
				}
				else
				{
					if (connected)
					{
						log($"Try disconnect COM port");

						HandlerSerialPort.CloseConnection();
					}
				}
				if (connected)
				{
					string s = $"CNE={cultureName.EnglishName}\r\n";
					log($"Write COM-port: �{s.Replace("\r", "\\r").Replace("\n", "\\n")}�.");

					HandlerSerialPort.Write(s);
				}
				this.Invoke(() =>
				{
					listBoxComPorts.Enabled = !connected || !checkBoxOrderEnableComPort.Checked;
					textBoxComPortName.Enabled = !connected || !checkBoxOrderEnableComPort.Checked;
					textBoxBaudRate.Enabled = !connected || !checkBoxOrderEnableComPort.Checked;

				});

			});
			UpdateComPortList();
			loopTimer.Enabled = true;

			HandlerSerialPort.EventIsConnectedChange += HandlerSerialPort_EventIsConnectedChange;
			HandlerSerialPort.EventErrorMessage += HandlerSerialPort_EventErrorMessage; ;


		}

		private void HandlerSerialPort_EventErrorMessage(string errMsg)
		{
			log(errMsg);
		}

		private void HandlerSerialPort_EventIsConnectedChange(bool isConnected)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action<bool>(HandlerSerialPort_EventIsConnectedChange), isConnected);
				return;
			}
			this.checkBoxIsConnected.Checked = isConnected;
		}

		Queue<string> messages = [];
		void log(string s)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action<string>(log), s);
				return;
			}

			messages.Enqueue($"{DateTime.Now.Minute}:{DateTime.Now.Second}:{DateTime.Now.Millisecond} " + s);
			if (messages.Count > 10)
			{
				messages.Dequeue();
			}
			string z = string.Join("\r\n", messages);
			richTextBox1.Text = z;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InputLanguageChanged += Form1_InputLanguageChanged;
		}
		private void Form1_InputLanguageChanged(object? sender, InputLanguageChangedEventArgs e)
		{
			ServiceKeyboardLayout.TriggerChanged(e);
			loopTimer.TriggerNow();
		}



		private void Timer_Tick(object sender, EventArgs e)
		{
			UpdateComPortList();
		}

		private void UpdateComPortList()
		{
			//System.IO.

			// �������� ������ COM-������
			string[] ports = SerialPort.GetPortNames();

			// ���������� � �������� ���������� listBox1
			List<string> currentPorts = listBoxComPorts.Items.Cast<string>().ToList();
			string oldPortsStr = System.Text.Json.JsonSerializer.Serialize(currentPorts);
			string newPortsStr = System.Text.Json.JsonSerializer.Serialize(ports);

			if (!string.Equals(oldPortsStr, newPortsStr))
			//if (!ports.SequenceEqual(currentPorts))
			{
				if (this.InvokeRequired)
				{
					this.Invoke(() =>
					{//� �� �������� ����� ��������� ��������� COM ����
					 // ��������� ������ � listBox1
						listBoxComPorts.Items.Clear();
						listBoxComPorts.Items.AddRange(ports);
					});
				}
				else
				{
					listBoxComPorts.Items.Clear();
					listBoxComPorts.Items.AddRange(ports);
				}
			}
		}

		//	private Timer _timer;
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			// ��������� ������� ��� �������� �����
			//_timer.Stop();
			//_timer.Dispose();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			if (listBoxComPorts.SelectedItem != null)
			{
				string selectedItem = listBoxComPorts.SelectedItem?.ToString() ?? "�� �������";
				textBoxComPortName.Text = selectedItem;
				//MessageBox.Show($"�� �������: {selectedItem}");
			}
			else
			{
				//MessageBox.Show("������ �� �������.");
			}
		}

		private void textBoxBaudRate_TextChanged(object sender, EventArgs e)
		{
			loopTimer.TriggerNow();

		}

		private void textBoxComPortName_TextChanged(object sender, EventArgs e)
		{
			loopTimer.TriggerNow();

		}
	}
}
