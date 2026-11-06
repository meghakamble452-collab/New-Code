using System;

namespace NEXUS;

public static class RandomExtensions0
{
	public static ulong NextULong0(this Random rng)
	{
		byte[] array = new byte[8];
		rng.NextBytes(array);
		return BitConverter.ToUInt64(array, 0);
	}

	public static ulong NextULong0(this Random rng, ulong max, bool inclusiveUpperBound = false)
	{
		return rng.NextULong0(0uL, max, inclusiveUpperBound);
	}

	public static ulong NextULong0(this Random rng, ulong min, ulong max, bool inclusiveUpperBound = false)
	{
		ulong num = max - min;
		if (inclusiveUpperBound)
		{
			if (num == ulong.MaxValue)
			{
				return rng.NextULong0();
			}
			num++;
		}
		if (num != 0)
		{
			ulong num2 = ulong.MaxValue - ulong.MaxValue % num;
			ulong num3;
			do
			{
				num3 = rng.NextULong0();
			}
			while (num3 > num2);
			return num3 % num + min;
		}
		string paramName = "Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true";
		string message = "max";
		throw new ArgumentOutOfRangeException(paramName, message);
	}

	public static long NextLong0(this Random rng)
	{
		byte[] array = new byte[8];
		rng.NextBytes(array);
		return BitConverter.ToInt64(array, 0);
	}

	public static long NextLong0(this Random rng, long max, bool inclusiveUpperBound = false)
	{
		return rng.NextLong0(long.MinValue, max, inclusiveUpperBound);
	}

	public static long NextLong0(this Random rng, long min, long max, bool inclusiveUpperBound = false)
	{
		ulong num = (ulong)(max - min);
		if (inclusiveUpperBound)
		{
			if (num == ulong.MaxValue)
			{
				return rng.NextLong0();
			}
			num++;
		}
		if (num != 0)
		{
			ulong num2 = ulong.MaxValue - ulong.MaxValue % num;
			ulong num3;
			do
			{
				num3 = rng.NextULong0();
			}
			while (num3 > num2);
			return (long)(num3 % num) + min;
		}
		string paramName = "Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true";
		string message = "max";
		throw new ArgumentOutOfRangeException(paramName, message);
	}
}
