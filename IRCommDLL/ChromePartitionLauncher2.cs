using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace IRCommDLL;

public class ChromePartitionLauncher2
{
	internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

	internal struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	private const string ProfilePrefix = "chrome_profile_";

	private const string GlobalMutexBase = "Global\\ChromeSliceAlloc_";

	[DllImport("user32.dll")]
	internal static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

	[DllImport("user32.dll")]
	internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	public static Rectangle AllocateChromeSlice(int cols = 5, double heightRatio = 0.6)
	{
		Rectangle wa = Screen.PrimaryScreen.WorkingArea;
		List<Rectangle> list = BuildVerticalSlices(wa, cols, heightRatio);
		Func<bool[]> func = delegate
		{
			string profilePrefix = "chrome_profile_";
			List<RECT> chromeWindowRectsForProfilePrefix = GetChromeWindowRectsForProfilePrefix(profilePrefix);
			bool[] array = new bool[cols];
			foreach (RECT item in chromeWindowRectsForProfilePrefix)
			{
				int num = item.Left + (item.Right - item.Left) / 2;
				int num2 = Math.Max(1, wa.Width / cols);
				int num3 = Math.Max(0, Math.Min(cols - 1, (num - wa.Left) / num2));
				array[num3] = true;
			}
			return array;
		};
		int[] array2 = Enumerable.Range(0, cols).Reverse().ToArray();
		int num4 = -1;
		string text = "Global\\ChromeSliceAlloc_";
		string name = text + cols;
		bool[] array3 = func();
		try
		{
			using Mutex mutex = new Mutex(initiallyOwned: false, name);
			bool flag = false;
			try
			{
				try
				{
					flag = mutex.WaitOne(TimeSpan.FromSeconds(3.0));
				}
				catch (AbandonedMutexException)
				{
					flag = true;
				}
				if (flag)
				{
					array3 = func();
				}
				int[] array4 = array2;
				int[] array5 = array4;
				int[] array6 = array5;
				foreach (int num5 in array6)
				{
					if (!array3[num5])
					{
						num4 = num5;
						break;
					}
				}
				if (num4 == -1)
				{
					num4 = array2[0];
				}
			}
			finally
			{
				if (flag)
				{
					mutex.ReleaseMutex();
				}
			}
		}
		catch
		{
			int[] array7 = array2;
			int[] array8 = array7;
			int[] array9 = array8;
			foreach (int num6 in array9)
			{
				if (!array3[num6])
				{
					num4 = num6;
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

	public static void PositionDriverToNextSlice(IWebDriver driver, int cols = 5, double heightRatio = 0.6)
	{
		Thread.Sleep(400);
		Rectangle rectangle = AllocateChromeSlice(cols, heightRatio);
		driver.Manage().Window.Position = new Point(rectangle.Left, rectangle.Top);
		driver.Manage().Window.Size = new Size(rectangle.Width, rectangle.Height);
	}

	internal static List<Rectangle> BuildVerticalSlices(Rectangle wa, int cols, double heightRatio)
	{
		List<Rectangle> list = new List<Rectangle>(cols);
		int num = Math.Max(1, wa.Width / cols);
		int height = (int)Math.Round((double)wa.Height * heightRatio);
		for (int i = 0; i < cols; i++)
		{
			int num2 = wa.Left + i * num;
			int num3 = ((i == cols - 1) ? wa.Right : (num2 + num));
			int width = Math.Max(1, num3 - num2);
			list.Add(new Rectangle(num2, wa.Top, width, height));
		}
		return list;
	}

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
						goto IL_00d0;
					}
				}
				obj3 = "";
				goto IL_00d0;
				IL_00d0:
				string text = (string)obj3;
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				string value = "--user-data-dir=";
				if (text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0 && text.IndexOf(profilePrefix, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					string value2 = "--type=";
					if (text.IndexOf(value2, StringComparison.OrdinalIgnoreCase) < 0)
					{
						pids.Add(item);
					}
				}
			}
			if (pids.Count == 0)
			{
				return rects;
			}
			EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
			{
				try
				{
					if (!IsWindowVisible(hWnd))
					{
						return true;
					}
					GetWindowThreadProcessId(hWnd, out var lpdwProcessId);
					if (lpdwProcessId == 0)
					{
						return true;
					}
					if (!pids.Contains((int)lpdwProcessId))
					{
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
				return true;
			}, IntPtr.Zero);
		}
		catch
		{
		}
		return rects;
	}
}
