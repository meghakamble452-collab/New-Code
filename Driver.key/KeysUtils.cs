using System;
using System.Collections.Generic;
using System.Text;
using Driver.intern.hook;
using Driver.util;

namespace Driver.key;

internal class KeysUtils
{
	public static string fullEditTextsLogin;

	private static int[] loginEditTextIds;

	public static string fullEditTextsAvl;

	private static int[] avlEditTextIds;

	public static List<KeyEvent> generateRandomKeyEvent(HookEvent hookEvent)
	{
		List<KeyEvent> list = new List<KeyEvent>();
		switch (hookEvent)
		{
		case HookEvent.AvlFarenquiry:
		{
			list.Add(new KeyEvent(Driver.util.Random.nextInt(15000, 30000), avlEditTextIds[0]));
			for (int l = 0; l < Driver.util.Random.nextInt(4, 6); l++)
			{
				list.Add(new KeyEvent(Driver.util.Random.nextInt(300, 2000), avlEditTextIds[0]));
			}
			list.Add(new KeyEvent(Driver.util.Random.nextInt(1000, 5000), avlEditTextIds[1]));
			for (int m = 0; m < Driver.util.Random.nextInt(4, 6); m++)
			{
				list.Add(new KeyEvent(Driver.util.Random.nextInt(200, 1000), avlEditTextIds[1]));
			}
			list.Add(new KeyEvent(Driver.util.Random.nextInt(10000, 20000), avlEditTextIds[2]));
			for (int n = 0; n < Driver.util.Random.nextInt(7, 10); n++)
			{
				list.Add(new KeyEvent(Driver.util.Random.nextInt(400, 2000), avlEditTextIds[2]));
			}
			break;
		}
		case HookEvent.Webmtoken:
		case HookEvent.ValidateUser:
		{
			list.Add(new KeyEvent(Driver.util.Random.nextInt(40, 80), loginEditTextIds[0]));
			list.Add(new KeyEvent(Driver.util.Random.nextInt(7000, 15000), loginEditTextIds[1]));
			for (int i = 0; i < Driver.util.Random.nextInt(5, 10); i++)
			{
				list.Add(new KeyEvent(Driver.util.Random.nextInt(400, 2000), loginEditTextIds[1]));
			}
			list.Add(new KeyEvent(Driver.util.Random.nextInt(7000, 15000), loginEditTextIds[2]));
			for (int j = 0; j < Driver.util.Random.nextInt(5, 10); j++)
			{
				list.Add(new KeyEvent(Driver.util.Random.nextInt(400, 2000), loginEditTextIds[2]));
			}
			list.Add(new KeyEvent(Driver.util.Random.nextInt(7000, 15000), loginEditTextIds[3]));
			for (int k = 0; k < Driver.util.Random.nextInt(5, 8); k++)
			{
				list.Add(new KeyEvent(Driver.util.Random.nextInt(400, 2000), loginEditTextIds[3]));
			}
			break;
		}
		}
		return list;
	}

	internal Tuple<Tuple<string, long>, long> getRandomKeyData(HookEvent hookEvent)
	{
		if (hookEvent == HookEvent.Universal)
		{
			return new Tuple<Tuple<string, long>, long>(new Tuple<string, long>("", 0L), 0L);
		}
		List<KeyEvent> list = generateRandomKeyEvent(hookEvent);
		StringBuilder stringBuilder = new StringBuilder();
		long num = 0L;
		foreach (KeyEvent item in list)
		{
			string[] array = new string[6] { item.key, null, null, null, null, null };
			string text = ",";
			array[1] = text;
			array[2] = item.delay.ToString();
			string text2 = ",";
			array[3] = text2;
			array[4] = item.id.ToString();
			string text3 = ";";
			array[5] = text3;
			string value = string.Concat(array);
			stringBuilder.Append(value);
			num = item.delay + long.Parse(item.key) + item.id + num;
		}
		return new Tuple<Tuple<string, long>, long>(new Tuple<string, long>(stringBuilder.ToString(), num), list.Count);
	}

	internal string getEditTextsList(HookEvent hookEvent)
	{
		string result = null;
		switch (hookEvent)
		{
		case HookEvent.Webmtoken:
		case HookEvent.ValidateUser:
			result = fullEditTextsLogin;
			break;
		case HookEvent.AvlFarenquiry:
			result = fullEditTextsAvl;
			break;
		case HookEvent.Universal:
			result = "";
			break;
		}
		return result;
	}

	static KeysUtils()
	{
		string text = "510;508;509;513;503;511;516;504;";
		fullEditTextsLogin = text;
		loginEditTextIds = new int[4] { 509, 510, 508, 509 };
		string text2 = "514;509;506;";
		fullEditTextsAvl = text2;
		avlEditTextIds = new int[3] { 509, 506, 514 };
	}
}
