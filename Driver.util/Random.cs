using System;

namespace Driver.util;

internal class Random
{
	public static System.Random RandomSystem = new System.Random();

	public static int nextInt(int min, int max)
	{
		return ChromeUser.isTest ? min : RandomSystem.Next(min, max);
	}

	public static int nextInt(int max)
	{
		return ChromeUser.isTest ? (max / 2) : RandomSystem.Next(max);
	}

	public static double nextDouble()
	{
		return ChromeUser.isTest ? 0.5 : RandomSystem.NextDouble();
	}

	public static ulong nextUnLong()
	{
		byte[] array = new byte[8];
		RandomSystem.NextBytes(array);
		if (!ChromeUser.isTest)
		{
			return BitConverter.ToUInt64(array, 0);
		}
		return 2147483647uL;
	}

	public static void nextBytes(byte[] bytes)
	{
		if (!ChromeUser.isTest)
		{
			RandomSystem.NextBytes(bytes);
		}
	}
}
