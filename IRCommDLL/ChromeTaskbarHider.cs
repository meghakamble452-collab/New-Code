using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace IRCommDLL;

public class ChromeTaskbarHider
{
	internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

	private const int GWL_EXSTYLE = -20;

	private const int WS_EX_TOOLWINDOW = 128;

	private const int WS_EX_APPWINDOW = 262144;

	private const uint SWP_NOSIZE = 1u;

	private const uint SWP_NOMOVE = 2u;

	private const uint SWP_NOZORDER = 4u;

	private const uint SWP_FRAMECHANGED = 32u;

	[DllImport("user32.dll")]
	private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

	[DllImport("user32.dll")]
	private static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
	private static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll")]
	private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

	[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
	private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	private static int GetExStyle(IntPtr hWnd)
	{
		if (IntPtr.Size != 8)
		{
			return GetWindowLong32(hWnd, -20);
		}
		return (int)GetWindowLongPtr(hWnd, -20);
	}

	private static void SetExStyle(IntPtr hWnd, int exStyle)
	{
		if (IntPtr.Size == 8)
		{
			SetWindowLongPtr(hWnd, -20, new IntPtr(exStyle));
		}
		else
		{
			SetWindowLong32(hWnd, -20, exStyle);
		}
	}

	public static IntPtr FindBrowserWindowByUserDataDir(string userDataDir, int waitMs = 5000)
	{
		int num = Environment.TickCount + waitMs;
		while (Environment.TickCount < num)
		{
			string[] array = new string[5];
			string text = "brave.exe";
			array[0] = text;
			string text2 = "chrome.exe";
			array[1] = text2;
			string text3 = "msedge.exe";
			array[2] = text3;
			string text4 = "comet.exe";
			array[3] = text4;
			string text5 = "opera.exe";
			array[4] = text5;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Process process = FindProcessByCmd(array2[i], userDataDir);
				if (process != null)
				{
					IntPtr topLevelWindowForPid = GetTopLevelWindowForPid(process.Id);
					if (topLevelWindowForPid != IntPtr.Zero)
					{
						return topLevelWindowForPid;
					}
				}
			}
			Thread.Sleep(200);
		}
		return IntPtr.Zero;
	}

	private static Process FindProcessByCmd(string processName, string containsPath)
	{
		string text = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name='";
		string text2 = "'";
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(text + processName + text2))
		{
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string propertyName = "CommandLine";
				if ((item[propertyName] ?? "").ToString().IndexOf(containsPath, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					string propertyName2 = "ProcessId";
					int processId = Convert.ToInt32(item[propertyName2]);
					try
					{
						return Process.GetProcessById(processId);
					}
					catch
					{
					}
				}
			}
		}
		return null;
	}

	private static IntPtr GetTopLevelWindowForPid(int pid)
	{
		IntPtr found = IntPtr.Zero;
		EnumWindows(delegate(IntPtr h, IntPtr l)
		{
			if (!IsWindowVisible(h))
			{
				return true;
			}
			GetWindowThreadProcessId(h, out var lpdwProcessId);
			if (lpdwProcessId != pid)
			{
				return true;
			}
			found = h;
			return false;
		}, IntPtr.Zero);
		return found;
	}

	public static bool HideFromTaskbar(IntPtr hWnd)
	{
		if (hWnd == IntPtr.Zero)
		{
			return false;
		}
		int exStyle = GetExStyle(hWnd);
		exStyle &= -262145;
		exStyle |= 0x80;
		SetExStyle(hWnd, exStyle);
		return SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, 39u);
	}
}
