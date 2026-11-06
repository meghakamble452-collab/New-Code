using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace APP_FRAMEWORK;

internal static class Class41
{
	internal delegate bool Delegate13(IntPtr hwnd, IntPtr lparam);

	private delegate bool Delegate14(IntPtr hWnd, IntPtr lParam);

	private delegate bool Delegate15(IntPtr hWnd, int lParam);

	internal static IDictionary<IntPtr, string> smethod_0()
	{
		return new Dictionary<IntPtr, string>();
	}

	internal static IDictionary<IntPtr, string> smethod_1(IntPtr intptr_0)
	{
		Dictionary<IntPtr, string> dictionary = new Dictionary<IntPtr, string>();
		GCHandle value = GCHandle.Alloc(dictionary);
		try
		{
			Delegate13 delegate13_ = smethod_3;
			EnumChildWindows(intptr_0, delegate13_, GCHandle.ToIntPtr(value));
			dictionary = value.Target as Dictionary<IntPtr, string>;
		}
		finally
		{
			if (value.IsAllocated)
			{
				value.Free();
			}
		}
		uint uint_ = 0u;
		GetWindowThreadProcessId(intptr_0, out uint_);
		if (uint_ != 0)
		{
			foreach (KeyValuePair<IntPtr, string> item in smethod_2((int)uint_))
			{
				dictionary[item.Key] = item.Value;
			}
		}
		return dictionary;
	}

	private static Dictionary<IntPtr, string> smethod_2(int int_0)
	{
		return new Dictionary<IntPtr, string>();
	}

	internal static bool smethod_3(IntPtr intptr_0, IntPtr intptr_1)
	{
		bool result = false;
		if (GCHandle.FromIntPtr(intptr_1).Target is Dictionary<IntPtr, string> dictionary)
		{
			int windowTextLength = GetWindowTextLength(intptr_0);
			if (windowTextLength == 0)
			{
				return true;
			}
			StringBuilder stringBuilder = new StringBuilder(windowTextLength);
			GetWindowText(intptr_0, stringBuilder, windowTextLength + 1);
			dictionary[intptr_0] = stringBuilder.ToString();
			return true;
		}
		return result;
	}

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern uint GetWindowThreadProcessId(IntPtr intptr_0, out uint uint_0);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool EnumChildWindows(IntPtr intptr_0, Delegate13 delegate13_0, IntPtr intptr_1);

	[DllImport("user32.dll")]
	private static extern bool EnumThreadWindows(int int_0, Delegate14 delegate14_0, IntPtr intptr_0);

	[DllImport("user32.dll")]
	private static extern bool EnumWindows(Delegate15 delegate15_0, int int_0);

	[DllImport("user32.dll")]
	internal static extern int GetWindowText(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_0);

	[DllImport("user32.dll")]
	private static extern int GetWindowTextLength(IntPtr intptr_0);

	[DllImport("user32.dll")]
	private static extern bool IsWindowVisible(IntPtr intptr_0);

	[DllImport("user32.dll")]
	private static extern IntPtr GetShellWindow();
}
