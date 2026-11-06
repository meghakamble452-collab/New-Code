using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace IRCommDLL;

public class ChromePartitionLauncher
{
	internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

	internal struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	[DllImport("user32.dll")]
	internal static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

	[DllImport("user32.dll")]
	internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	internal static List<RECT> GetChromeWindowRectsForProfilePrefix(string profilePrefix)
	{
		List<RECT> rects = new List<RECT>();
		try
		{
			string queryString = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name = 'chrome.exe'";
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			HashSet<int> pids = new HashSet<int>();
			foreach (ManagementObject item2 in managementObjectCollection)
			{
				string propertyName = "ProcessId";
				object obj = item2[propertyName];
				string propertyName2 = "CommandLine";
				object obj2 = item2[propertyName2];
				if (obj == null)
				{
					continue;
				}
				int item = Convert.ToInt32(obj);
				object obj3;
				if (obj2 == null)
				{
					obj3 = null;
				}
				else
				{
					obj3 = obj2.ToString();
					if (obj3 != null)
					{
						goto IL_00cd;
					}
				}
				obj3 = "";
				goto IL_00cd;
				IL_00cd:
				string text = (string)obj3;
				if (!string.IsNullOrEmpty(text) && text.IndexOf(profilePrefix, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					pids.Add(item);
				}
			}
			if (pids.Count == 0)
			{
				return rects;
			}
			EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
			{
				bool result = false;
				try
				{
					if (!IsWindowVisible(hWnd))
					{
						result = true;
						return true;
					}
					GetWindowThreadProcessId(hWnd, out var lpdwProcessId);
					if (lpdwProcessId == 0)
					{
						result = true;
						return true;
					}
					if (!pids.Contains((int)lpdwProcessId))
					{
						result = true;
						return true;
					}
					if (GetWindowRect(hWnd, out var lpRect))
					{
						int num = lpRect.Right - lpRect.Left;
						int num2 = lpRect.Bottom - lpRect.Top;
						if (num > 50 && num2 > 50)
						{
							rects.Add(lpRect);
						}
					}
				}
				catch
				{
				}
				while (true)
				{
					int[,,] array = new int[2, 1, 5]
					{
						{ { 1465147540, -1081810318, 1844461043, -965966400, 189491886 } },
						{ { -563123584, 1073264418, 247798102, 247798101, -1843550399 } }
					};
					switch (array[1, 0, 3] ^ -1467854695 ^ -1505277490)
					{
					default:
						return result;
					case 2:
						return true;
					case 0:
						break;
					}
				}
			}, IntPtr.Zero);
		}
		catch
		{
		}
		return rects;
	}

	internal static Rectangle slices_()
	{
		string text = "chrome_profile_";
		string profilePrefix = text;
		Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
		int num = Math.Max(1, workingArea.Width / 4);
		List<Rectangle> list = new List<Rectangle>();
		for (int i = 0; i < 4; i++)
		{
			list.Add(new Rectangle(workingArea.Left + i * num, workingArea.Top, num, workingArea.Height));
		}
		List<RECT> chromeWindowRectsForProfilePrefix = GetChromeWindowRectsForProfilePrefix(profilePrefix);
		bool[] array = new bool[4];
		foreach (RECT item in chromeWindowRectsForProfilePrefix)
		{
			int num2 = item.Left + (item.Right - item.Left) / 2;
			int num3 = Math.Max(0, Math.Min(3, (num2 - workingArea.Left) / Math.Max(1, num)));
			array[num3] = true;
		}
		int[] array2 = new int[4] { 3, 2, 1, 0 };
		int num4 = -1;
		string text2 = "Global\\ChromeSliceAllocator_Mutex";
		string name = text2;
		try
		{
			using Mutex mutex = new Mutex(initiallyOwned: false, name);
			bool flag = false;
			try
			{
				flag = mutex.WaitOne(3000);
			}
			catch
			{
				flag = false;
			}
			if (flag)
			{
				List<RECT> chromeWindowRectsForProfilePrefix2 = GetChromeWindowRectsForProfilePrefix(profilePrefix);
				bool[] array3 = new bool[4];
				foreach (RECT item2 in chromeWindowRectsForProfilePrefix2)
				{
					int num5 = item2.Left + (item2.Right - item2.Left) / 2;
					int num6 = Math.Max(0, Math.Min(3, (num5 - workingArea.Left) / Math.Max(1, num)));
					array3[num6] = true;
				}
				array = array3;
			}
			int[] array4 = array2;
			int[] array5 = array4;
			int[] array6 = array5;
			foreach (int num7 in array6)
			{
				if (!array[num7])
				{
					num4 = num7;
					break;
				}
			}
			if (num4 == -1)
			{
				num4 = array2[0];
			}
			if (flag)
			{
				mutex.ReleaseMutex();
			}
		}
		catch
		{
			int[] array7 = array2;
			int[] array8 = array7;
			int[] array9 = array8;
			foreach (int num8 in array9)
			{
				if (!array[num8])
				{
					num4 = num8;
					break;
				}
			}
			if (num4 == -1)
			{
				num4 = array2[0];
			}
		}
		return list[num4];
	}
}
