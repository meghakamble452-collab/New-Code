using System;
using System.Collections.Generic;
using System.Text;
using Driver.util;

namespace Driver.intern.touch;

internal class TouchUtils
{
	private static int COUNT_TOUCH_EVENTS = 50;

	private List<TouchEvent> generateRandomTouchEvents()
	{
		int num = (COUNT_TOUCH_EVENTS = Driver.util.Random.nextInt(35, 100));
		List<TouchEvent> list = new List<TouchEvent>(num);
		bool flag = false;
		while (list.Count != num)
		{
			int num2 = (flag ? (COUNT_TOUCH_EVENTS - list.Count) : Driver.util.Random.nextInt(4, 7));
			num2 = ((list.Count + num2 <= COUNT_TOUCH_EVENTS - 4) ? num2 : (COUNT_TOUCH_EVENTS - list.Count));
			for (int i = 0; i < num2; i++)
			{
				if (i == 0)
				{
					list.Add(new TouchEvent(2, Driver.util.Random.nextInt(3000, 20000)));
				}
				else if (i == num2 - 1)
				{
					list.Add(new TouchEvent(3, Driver.util.Random.nextInt(10, 50)));
				}
				else
				{
					list.Add(new TouchEvent(1, Driver.util.Random.nextInt(10, 30)));
				}
			}
			if (list.Count > num - 7)
			{
				flag = true;
			}
		}
		return list;
	}

	internal Tuple<Tuple<string, long>, long> getRandomTouchData()
	{
		List<TouchEvent> list = generateRandomTouchEvents();
		StringBuilder stringBuilder = new StringBuilder();
		long num = 0L;
		foreach (TouchEvent item in list)
		{
			string[] array = new string[8]
			{
				item.type.ToString(),
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			string text = ",";
			array[1] = text;
			array[2] = item.delay.ToString();
			string text2 = ",0,0,";
			array[3] = text2;
			array[4] = item.pointerCount.ToString();
			string text3 = ",1,";
			array[5] = text3;
			array[6] = item.touchType.ToString();
			string text4 = ",-1;";
			array[7] = text4;
			string value = string.Concat(array);
			stringBuilder.Append(value);
			num = item.delay + item.type + num;
		}
		return new Tuple<Tuple<string, long>, long>(new Tuple<string, long>(stringBuilder.ToString(), num), list.Count);
	}
}
