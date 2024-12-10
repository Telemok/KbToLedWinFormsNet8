using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbToLedWinFormsNet8
{
	class HandlerSerialPort
	{

		public static event EventHandler? SerialPortChanged;
		public static event Action<string>? EventErrorMessage;
		public static event Action<bool>? EventIsConnectedChange;
		private static SerialPort? _serialPort;
		private static bool? _lastIsConnected;
		public static bool IsConnected()
		{
			bool isConnected = _serialPort is not null;
			if (_lastIsConnected != isConnected)
			{
				_lastIsConnected = isConnected;
				EventIsConnectedChange?.Invoke(isConnected);
			}
			return isConnected;
		}
		public static void CloseConnection()
		{
			try
			{
				_serialPort?.Close();
			}
			finally { }
			_serialPort = null;
		}
		public static void InitSerialPort(string portName, int baudRate = 9600)
		{
			_serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One)
			{
				WriteTimeout = 500,
				ReadTimeout = 500
			};
			try
			{
				_serialPort.Open();
				_serialPort.DataReceived += _serialPort_DataReceived;
			}
			catch (Exception ex)
			{
				CloseConnection();

				EventErrorMessage?.Invoke($"Ошибка открытия COM-порта: {ex.Message}");
				//MessageBox.Show($"Ошибка открытия COM-порта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private static void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			EventErrorMessage?.Invoke($"DataReceived=«{e?.ToString()??"null"}».");
		}

		public static void Write(string message)
		{
			try
			{
				if (_serialPort is null)
					throw new Exception($"Не удаётся записать в серийный порт сообщение «{message}» потому, что порт null.");
				_serialPort.Write(message);
			}
			catch (Exception ex)
			{
				EventErrorMessage?.Invoke($"Ошибка записи в COM-порт: {message}");
			}
		}
	}
}
