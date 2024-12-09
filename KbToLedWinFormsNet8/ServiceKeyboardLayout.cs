using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KbToLedWinFormsNet8
{
    class ServiceKeyboardLayout
    {

			[DllImport("user32.dll")]
			private static extern IntPtr GetForegroundWindow();

			[DllImport("user32.dll")]
			private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);


			[DllImport("user32.dll")]
			public static extern IntPtr GetKeyboardLayout(uint threadId);

		/** Это активное окно приложения в Windows, не окно этой запущенной программы, которая будет свёрнута в tray. */
		public static IntPtr GetForegroundWindowPtr()
		{
			IntPtr foregroundWindow = GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
				throw new Exception($"Функция GetForegroundWindowPtr() вернула указатель IntPtr.Zero!");
			return foregroundWindow;
		}
		public static uint GetForegroundWindowThreadId()
		{
			IntPtr foregroundWindow = GetForegroundWindowPtr();
			uint processId;
			uint threadId = GetWindowThreadProcessId(foregroundWindow, out processId);
			return threadId;
		}

		public static IntPtr GetForegroundWindowKeyboardLayout()
		{
			uint threadId = GetForegroundWindowThreadId();
			IntPtr keyboardLayout = GetKeyboardLayout(threadId);
			return keyboardLayout;
		}
		public static CultureInfo GetForegroundWindowCultureInfo()
		{
			IntPtr layout = GetForegroundWindowKeyboardLayout();
			int languageId = layout.ToInt32() & 0xFFFF; // Извлечение идентификатора языка
			CultureInfo culture = new CultureInfo(languageId);
			return culture;
		}

	}
}
