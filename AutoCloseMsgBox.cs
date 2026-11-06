using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public static class AutoCloseMsgBox
{
	private const uint WM_CLOSE = 16u;

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	public static void Show(string text, string caption, int timeoutSeconds = 20)
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			Thread.Sleep(timeoutSeconds * 1000);
			string lpClassName = "#32770";
			IntPtr intPtr = FindWindow(lpClassName, caption);
			if (intPtr != IntPtr.Zero)
			{
				PostMessage(intPtr, 16u, IntPtr.Zero, IntPtr.Zero);
			}
		});
		thread.IsBackground = true;
		thread.Start();
		MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
	}
}
