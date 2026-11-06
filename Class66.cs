using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

internal class Class66
{
	private delegate int Delegate7(IntPtr intptr_0, int int_0, ref Struct3 struct3_0, int int_1, out int int_2);

	public struct Struct3
	{
		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		public IntPtr intptr_4;

		public IntPtr intptr_5;
	}

	private static readonly Delegate7 delegate7_0;

	private Process process_0;

	public bool Boolean_0
	{
		get
		{
			try
			{
				string typeName = "System.Diagnostics.Debugger";
				object type = Type.GetType(typeName);
				if (type != null)
				{
					try
					{
						Type type2 = (Type)type;
						string name = "IsAttached";
						if ((bool)type2.InvokeMember(name, BindingFlags.GetProperty, null, null, null))
						{
							return true;
						}
					}
					catch
					{
					}
				}
				return method_1();
			}
			catch
			{
			}
			return false;
		}
	}

	static Class66()
	{
		try
		{
			string string_ = "ntdll.dll";
			string string_2 = "NtQueryInformationProcess";
			delegate7_0 = (Delegate7)Class63.smethod_0<Delegate7>(string_, string_2);
		}
		catch
		{
		}
	}

	public Class66()
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
		bool result = false;
		try
		{
			int num;
			if (delegate7_0 != null && process_0 != null)
			{
				Struct3 struct3_ = default(Struct3);
				if (delegate7_0(process_0.Handle, 0, ref struct3_, Marshal.SizeOf(struct3_), out var _) == 0)
				{
					Process processById = Process.GetProcessById(struct3_.intptr_5.ToInt32());
					if (processById != null)
					{
						string processName = processById.ProcessName;
						StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
						string value = "dnspy";
						if (processName.IndexOf(value, StringComparison.OrdinalIgnoreCase) == -1)
						{
							string value2 = "de4dot";
							if (processName.IndexOf(value2, comparisonType) == -1)
							{
								string value3 = "vsdbg";
								if (processName.IndexOf(value3, comparisonType) == -1)
								{
									string value4 = "debug";
									num = ((processName.IndexOf(value4, comparisonType) != -1) ? 1 : 0);
									goto IL_0109;
								}
							}
						}
						num = 1;
						goto IL_0109;
					}
					result = false;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0003;
			IL_0109:
			result = (byte)num != 0;
			end_IL_0003:;
		}
		catch (Exception)
		{
		}
		return result;
	}
}
