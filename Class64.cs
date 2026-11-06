using System;
using System.Threading;

internal class Class64
{
	private delegate bool Delegate4(IntPtr intptr_0, ref bool bool_0);

	private static object object_0 = new object();

	private static Thread thread_0;

	private static long long_0;

	public static void smethod_0()
	{
		if (thread_0 != null)
		{
			return;
		}
		try
		{
			Monitor.Enter(object_0);
			if (thread_0 == null)
			{
				thread_0 = new Thread(smethod_1);
				thread_0.IsBackground = true;
				thread_0.Start(null);
			}
		}
		finally
		{
			Monitor.Exit(object_0);
		}
	}

	private static void smethod_1(object object_1)
	{
		Thread thread = object_1 as Thread;
		string variable = "COR_PROFILER";
		if (Environment.GetEnvironmentVariable(variable) == null)
		{
			string variable2 = "COR_ENABLE_PROFILING";
			if (Environment.GetEnvironmentVariable(variable2) == null)
			{
				goto IL_003e;
			}
		}
		smethod_2();
		goto IL_003e;
		IL_003e:
		try
		{
			Class65 @class = new Class65();
			Class66 class2 = new Class66();
			while (true)
			{
				if (@class.Boolean_0 || class2.Boolean_0)
				{
					smethod_2();
				}
				if (thread == null && Interlocked.Increment(ref long_0) <= 2)
				{
					thread = new Thread(smethod_1);
					thread.IsBackground = true;
					thread.Start(Thread.CurrentThread);
				}
				if (thread != null && thread.Join(1000))
				{
					thread = null;
				}
			}
		}
		catch
		{
		}
		Interlocked.Decrement(ref long_0);
	}

	internal static void smethod_2()
	{
	}
}
