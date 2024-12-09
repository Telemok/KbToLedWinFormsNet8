using System.Globalization;
using System.Runtime.InteropServices;

namespace KbToLedWinFormsNet8
{
	public partial class Form1 : Form
	{

    [DllImport("user32.dll")]
		public static extern IntPtr GetKeyboardLayout(uint threadId);

		[DllImport("kernel32.dll")]
		public static extern uint GetCurrentThreadId();

		Libs.ControlledTimer loopTimer;
		public Form1()
		{
			InitializeComponent();
			loopTimer = new(()=> {
				System.Diagnostics.Debug.WriteLine("timer");
				//string s = lastLanguageLayot;// System.Windows.Forms.InputLanguage.CurrentInputLanguage.LayoutName;
			//	string s = System.Windows.Forms.InputLanguage.CurrentInputLanguage.Culture.ToString();


				IntPtr layout = GetKeyboardLayout(GetCurrentThreadId());
				int languageId = layout.ToInt32() & 0xFFFF; // Извлечение идентификатора языка
				CultureInfo culture = new CultureInfo(languageId);

				string s = culture.ToString();

				log(s);
			});
			loopTimer.Enabled = true;
		}
		Queue<string> messages = [];
		void log(string s)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action<string>(log), s);
				return;
			}
		
			messages.Enqueue($"{DateTime.Now.Minute}:{DateTime.Now.Second}:{DateTime.Now.Millisecond} "+ s);
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
		string lastLanguageLayot="none";
		private void Form1_InputLanguageChanged(object? sender, InputLanguageChangedEventArgs e)
		{
			InputLanguage l = e.InputLanguage;
			lastLanguageLayot = l.LayoutName;
			loopTimer.TriggerNow();
		}
	}
}
