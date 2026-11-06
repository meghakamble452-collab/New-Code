using System;

namespace NEXUS;

public class TextUtils
{
	private static Random random = new Random();

	public static bool isEmpty(string str)
	{
		if (str != null && str.Length != 0)
		{
			return false;
		}
		return true;
	}

	public static char getRandomBigChar()
	{
		string text = "QWERTYUIOPASDFGHJKLZXCVBNM";
		char[] array = text.ToCharArray();
		return array[random.Next(array.Length)];
	}

	public static int getRandomNumber()
	{
		int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		return array[random.Next(array.Length)];
	}

	public static long getRandomNumberWithNeedLength(int lengthNumber)
	{
		int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		long num = 0L;
		for (int i = 0; i < lengthNumber; i++)
		{
			num += (long)Math.Pow(10.0, i) * array[random.Next(array.Length)];
		}
		return num;
	}

	public static string getRandomStringLowCase(int length)
	{
		char[] array = new char[length];
		string text = "abcdefghijklmnopqrstuvwxyz0123456789";
		string text2 = text;
		for (int i = 0; i < length; i++)
		{
			int num = i;
			Random random = TextUtils.random;
			int length2;
			if (i != 0)
			{
				length2 = text2.Length;
			}
			else
			{
				string text3 = "abcdefghijklmnopqrstuvwxyz";
				length2 = text3.Length;
			}
			array[num] = text2[random.Next(length2)];
		}
		return new string(array);
	}

	public static string GetRandomStringUpperCase(int length)
	{
		char[] array = new char[length];
		string text = "QAZWSXEDCRFVTGBYHNUJMIKOLP0123456789";
		string text2 = text;
		for (int i = 0; i < length; i++)
		{
			array[i] = text2[random.Next(text2.Length)];
		}
		return new string(array);
	}

	public static string getRandomStringAnyCase(int length)
	{
		char[] array = new char[length];
		string text = "qazwsxedcrfvtgbyhnujmikolpQAZWSXEDCRFVTGBYHNUJMIKOLP0123456789";
		string text2 = text;
		for (int i = 0; i < length; i++)
		{
			array[i] = text2[random.Next(text2.Length)];
		}
		return new string(array);
	}

	public static string getRandomPassword(int length)
	{
		char[] array = new char[length];
		string text = "abcdefghijklmnopqrstuvwxyz0123456789";
		string text2 = text;
		for (int i = 0; i < length; i++)
		{
			array[i] = text2[random.Next(text2.Length)];
		}
		return new string(array) + getRandomNumber();
	}

	private static int getRandomNumberWithLimitInclusive(int lower, int upper)
	{
		int[] array = new int[upper - lower + 1];
		for (int i = lower; i <= upper; i++)
		{
			array[i - lower] = i;
		}
		return array[random.Next(array.Length)];
	}
}
