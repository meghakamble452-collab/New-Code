using System;
using System.Diagnostics;

internal class Class65
{
	private delegate bool Delegate5(IntPtr intptr_0, ref bool bool_0);

	private delegate bool Delegate6();

	private static readonly Delegate5 delegate5_0;

	private static readonly Delegate6 delegate6_0;

	private Process process_0;

	public bool Boolean_0
	{
		get
		{
			try
			{
				return method_1();
			}
			catch
			{
			}
			return false;
		}
	}

	static Class65()
	{
		try
		{
			string string_ = "kernel32.dll";
			string string_2 = "CheckRemoteDebuggerPresent";
			delegate5_0 = (Delegate5)Class63.smethod_0<Delegate5>(string_, string_2);
			string string_3 = "kernel32.dll";
			string string_4 = "IsDebuggerPresent";
			delegate6_0 = (Delegate6)Class63.smethod_0<Delegate6>(string_3, string_4);
		}
		catch
		{
		}
	}

	public Class65()
	{
		try
		{
			process_0 = Process.GetCurrentProcess();
		}
		catch
		{
		}
	}

	public void method_0()
	{
		if (process_0 != null)
		{
			process_0.Dispose();
		}
	}

	public bool method_1()
	{
		if (delegate6_0 != null && delegate6_0())
		{
			return true;
		}
		if (delegate5_0 != null && process_0 != null)
		{
			bool bool_ = false;
			if (delegate5_0(process_0.Handle, ref bool_) && bool_)
			{
				return true;
			}
		}
		return false;
	}
}
