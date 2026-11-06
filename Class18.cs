using System.Collections.Generic;
using System.Linq;
using IRCommDLL;

internal class Class18
{
	internal Dictionary<string, int> dictionary_0 = new Dictionary<string, int>();

	internal Dictionary<string, int> dictionary_1 = new Dictionary<string, int>();

	internal Dictionary<string, string> dictionary_2 = new Dictionary<string, string>();

	internal Dictionary<string, Class6> dictionary_3 = new Dictionary<string, Class6>();

	internal string string_0 = "";

	public static int int_0;

	public static byte[] byte_0;

	public static byte[] byte_1;

	public static byte[] byte_2;

	public static byte[] byte_3;

	internal string method_0(ref string string_1, string string_2, bool bool_0, int int_1, string string_3)
	{
		try
		{
			int num = dictionary_0[string_2.ToUpper()];
			int num2 = dictionary_0[string_1.ToUpper()];
			if (int_1 == 2)
			{
				num = dictionary_0.Count - 1;
			}
			if (num - num2 <= 1)
			{
				if (num2 <= 0)
				{
					return string_2.ToUpper();
				}
				num2 = 0;
			}
			if (bool_0)
			{
				foreach (string item in dictionary_1.Keys.Reverse())
				{
					if (dictionary_1[item] < num)
					{
						return item;
					}
				}
			}
			string text = string_3.ToUpper();
			string text2 = "GN";
			if (text == text2)
			{
				num--;
				return dictionary_0.ElementAt(num).Key;
			}
			if (int_1 == 3 && num - num2 >= 9)
			{
				num -= 4;
			}
			else if (int_1 == 3 && num - num2 >= 8)
			{
				num -= 3;
			}
			if (int_1 == 2 && num - num2 >= 8)
			{
				num -= 3;
			}
			else if (int_1 == 2 && num - num2 >= 7)
			{
				num -= 2;
			}
			if ((int_1 == 1 || int_1 == 2) && num - num2 >= 4)
			{
				string key = dictionary_0.ElementAt(++num2).Key;
				if (dictionary_2[key] == dictionary_2[string_1])
				{
					string_1 = key;
				}
				else
				{
					num2 -= 2;
					if (num2 >= 0)
					{
						key = dictionary_0.ElementAt(num2).Key;
						if (dictionary_2[key] == dictionary_2[string_1])
						{
							string_1 = key;
						}
					}
				}
			}
			if (string_0.Length > 0)
			{
				string_1 = string_0;
			}
			num--;
			return dictionary_0.ElementAt(num).Key;
		}
		catch
		{
			return string_2;
		}
	}

	internal string method_1(ref string string_1, string string_2, bool bool_0, int int_1, string string_3)
	{
		try
		{
			int num = dictionary_0[string_2.ToUpper()];
			int num2 = dictionary_0[string_1.ToUpper()];
			if (int_1 == 2)
			{
				num = dictionary_0.Count - 1;
			}
			if (num - num2 <= 1)
			{
				if (num2 <= 0)
				{
					return string_2.ToUpper();
				}
				num2 = 0;
			}
			if (bool_0)
			{
				foreach (string item in dictionary_1.Keys.Reverse())
				{
					if (dictionary_1[item] < num)
					{
						return item;
					}
				}
			}
			string text = string_3.ToUpper();
			string text2 = "GN";
			if (text == text2)
			{
				num--;
				return dictionary_0.ElementAt(num).Key;
			}
			if (int_1 == 3 && num - num2 >= 9)
			{
				num -= 4;
			}
			else if (int_1 == 3 && num - num2 >= 8)
			{
				num -= 3;
			}
			if (int_1 == 2 && num - num2 >= 8)
			{
				num -= 3;
			}
			else if (int_1 == 2 && num - num2 >= 7)
			{
				num -= 2;
			}
			if ((int_1 == 1 || int_1 == 2) && num - num2 >= 4)
			{
				string key = dictionary_0.ElementAt(++num2).Key;
				if (!(dictionary_2[key] == dictionary_2[string_1]))
				{
					num2 -= 2;
					if (num2 >= 0)
					{
						key = dictionary_0.ElementAt(num2).Key;
						if (dictionary_2[key] == dictionary_2[string_1])
						{
							string_1 = key;
						}
					}
				}
				else
				{
					string_1 = key;
				}
			}
			if (string_0.Length > 0)
			{
				string_1 = string_0;
			}
			num--;
			return dictionary_0.ElementAt(num).Key;
		}
		catch
		{
			return string_2;
		}
	}

	internal void method_2(string string_1)
	{
		try
		{
			string value = "</partial-response>";
			int num = string_1.IndexOf(value);
			string value2 = "Day";
			int num2 = string_1.IndexOf(value2);
			int num3 = 0;
			dictionary_0.Clear();
			dictionary_1.Clear();
			dictionary_2.Clear();
			try
			{
				while (num2 > 0 && num2 < num)
				{
					string value3 = "<tr align";
					num2 = string_1.IndexOf(value3, num2);
					if (num2 >= 0)
					{
						string value4 = "left";
						num2 = string_1.IndexOf(value4, num2);
						string value5 = ">";
						num2 = string_1.IndexOf(value5, num2) + 1;
						string value6 = "<";
						int length = string_1.IndexOf(value6, num2) - num2;
						string key = string_1.Substring(num2, length).Trim().ToUpper();
						dictionary_0.Add(key, num3);
						string value7 = "</tr>";
						num2 = string_1.IndexOf(value7, num2);
						string value8 = "rf-dt-c";
						num2 = string_1.LastIndexOf(value8, num2);
						string value9 = ">";
						num2 = string_1.IndexOf(value9, num2) + 1;
						string value10 = "<";
						length = string_1.IndexOf(value10, num2) - num2;
						dictionary_2.Add(key, string_1.Substring(num2, length).Trim().ToUpper());
						num3++;
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			string value11 = "</partial-response>";
			num = string_1.IndexOf(value11);
			string value12 = "Day";
			num2 = string_1.IndexOf(value12);
			num3 = 0;
			dictionary_3.Clear();
			while (num2 > 0 && num2 < num)
			{
				Class6 @class = new Class6();
				string value13 = "<tr align";
				num2 = string_1.IndexOf(value13, num2);
				if (num2 > 0)
				{
					string value14 = ">";
					num2 = string_1.IndexOf(value14, num2);
					string value15 = "rf-dt-c";
					num2 = string_1.IndexOf(value15, num2) + 1;
					string value16 = ">";
					num2 = string_1.IndexOf(value16, num2) + 1;
					string value17 = "<";
					int length2 = string_1.IndexOf(value17, num2) - num2;
					@class.int_0 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
					string value18 = "rf-dt-c";
					num2 = string_1.IndexOf(value18, num2) + 1;
					string value19 = ">";
					num2 = string_1.IndexOf(value19, num2) + 1;
					string value20 = "<";
					length2 = string_1.IndexOf(value20, num2) - num2;
					@class.string_0 = string_1.Substring(num2, length2).Trim().ToUpper();
					string value21 = "rf-dt-c";
					num2 = string_1.IndexOf(value21, num2) + 1;
					string value22 = "rf-dt-c";
					num2 = string_1.IndexOf(value22, num2) + 1;
					string value23 = "rf-dt-c";
					num2 = string_1.IndexOf(value23, num2) + 1;
					string value24 = "rf-dt-c";
					num2 = string_1.IndexOf(value24, num2) + 1;
					string value25 = "rf-dt-c";
					num2 = string_1.IndexOf(value25, num2) + 1;
					string value26 = ">";
					num2 = string_1.IndexOf(value26, num2) + 1;
					string value27 = "<";
					length2 = string_1.IndexOf(value27, num2) - num2;
					string text = string_1.Substring(num2, length2).Trim().ToUpper();
					string oldValue = ":00";
					int.TryParse(text.Replace(oldValue, ""), out @class.int_1);
					string value28 = "rf-dt-c";
					num2 = string_1.IndexOf(value28, num2) + 1;
					string value29 = ">";
					num2 = string_1.IndexOf(value29, num2) + 1;
					string value30 = "<";
					length2 = string_1.IndexOf(value30, num2) - num2;
					@class.int_2 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
					string value31 = "rf-dt-c";
					num2 = string_1.IndexOf(value31, num2) + 1;
					string value32 = ">";
					num2 = string_1.IndexOf(value32, num2) + 1;
					string value33 = "<";
					length2 = string_1.IndexOf(value33, num2) - num2;
					@class.int_3 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
					dictionary_3.Add(@class.string_0.ToUpper(), @class);
					num3++;
					continue;
				}
				break;
			}
		}
		catch
		{
		}
	}

	public void method_3(string string_1)
	{
		try
		{
			string value = "</partial-response>";
			int num = string_1.IndexOf(value);
			string value2 = "Day";
			int num2 = string_1.IndexOf(value2);
			int num3 = 0;
			dictionary_0.Clear();
			dictionary_1.Clear();
			dictionary_2.Clear();
			try
			{
				while (num2 > 0 && num2 < num)
				{
					string value3 = "<tr align";
					num2 = string_1.IndexOf(value3, num2);
					if (num2 >= 0)
					{
						string value4 = "left";
						num2 = string_1.IndexOf(value4, num2);
						string value5 = ">";
						num2 = string_1.IndexOf(value5, num2) + 1;
						string value6 = "<";
						int length = string_1.IndexOf(value6, num2) - num2;
						string key = string_1.Substring(num2, length).Trim().ToUpper();
						dictionary_0.Add(key, num3);
						string value7 = "</tr>";
						num2 = string_1.IndexOf(value7, num2);
						string value8 = "rf-dt-c";
						num2 = string_1.LastIndexOf(value8, num2);
						string value9 = ">";
						num2 = string_1.IndexOf(value9, num2) + 1;
						string value10 = "<";
						length = string_1.IndexOf(value10, num2) - num2;
						dictionary_2.Add(key, string_1.Substring(num2, length).Trim().ToUpper());
						num3++;
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			string value11 = "</partial-response>";
			num = string_1.IndexOf(value11);
			string value12 = "Day";
			num2 = string_1.IndexOf(value12);
			num3 = 0;
			dictionary_3.Clear();
			while (num2 > 0 && num2 < num)
			{
				Class6 @class = new Class6();
				string value13 = "<tr align";
				num2 = string_1.IndexOf(value13, num2);
				if (num2 > 0)
				{
					string value14 = ">";
					num2 = string_1.IndexOf(value14, num2);
					string value15 = "rf-dt-c";
					num2 = string_1.IndexOf(value15, num2) + 1;
					string value16 = ">";
					num2 = string_1.IndexOf(value16, num2) + 1;
					string value17 = "<";
					int length2 = string_1.IndexOf(value17, num2) - num2;
					@class.int_0 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
					string value18 = "rf-dt-c";
					num2 = string_1.IndexOf(value18, num2) + 1;
					string value19 = ">";
					num2 = string_1.IndexOf(value19, num2) + 1;
					string value20 = "<";
					length2 = string_1.IndexOf(value20, num2) - num2;
					@class.string_0 = string_1.Substring(num2, length2).Trim().ToUpper();
					string value21 = "rf-dt-c";
					num2 = string_1.IndexOf(value21, num2) + 1;
					string value22 = "rf-dt-c";
					num2 = string_1.IndexOf(value22, num2) + 1;
					string value23 = "rf-dt-c";
					num2 = string_1.IndexOf(value23, num2) + 1;
					string value24 = "rf-dt-c";
					num2 = string_1.IndexOf(value24, num2) + 1;
					string value25 = "rf-dt-c";
					num2 = string_1.IndexOf(value25, num2) + 1;
					string value26 = ">";
					num2 = string_1.IndexOf(value26, num2) + 1;
					string value27 = "<";
					length2 = string_1.IndexOf(value27, num2) - num2;
					string text = string_1.Substring(num2, length2).Trim().ToUpper();
					string oldValue = ":00";
					int.TryParse(text.Replace(oldValue, ""), out @class.int_1);
					string value28 = "rf-dt-c";
					num2 = string_1.IndexOf(value28, num2) + 1;
					string value29 = ">";
					num2 = string_1.IndexOf(value29, num2) + 1;
					string value30 = "<";
					length2 = string_1.IndexOf(value30, num2) - num2;
					@class.int_2 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
					string value31 = "rf-dt-c";
					num2 = string_1.IndexOf(value31, num2) + 1;
					string value32 = ">";
					num2 = string_1.IndexOf(value32, num2) + 1;
					string value33 = "<";
					length2 = string_1.IndexOf(value33, num2) - num2;
					@class.int_3 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
					dictionary_3.Add(@class.string_0.ToUpper(), @class);
					num3++;
					continue;
				}
				break;
			}
		}
		catch
		{
		}
	}

	internal void method_4(string string_1, string string_2, int int_1, string string_3, ref string string_4, ref string string_5, bool bool_0)
	{
		byte[] array = new byte[258];
		array[79] = 241;
		string text = "cßÀ:ûKM9E\u0013\u0087Î";
		string text2 = text;
		for (int i = 0; i < text2.Length; i++)
		{
			array[i + 80] = (byte)text2[i];
		}
		array[114] = 71;
		string text3 = "h\u0012Ê\u0005N#G\u008am\u00b85ù\u0004Ó\u0011ó";
		string text4 = text3;
		for (int j = 0; j < text4.Length; j++)
		{
			array[j + 116] = (byte)text4[j];
		}
		array[134] = 21;
		array[141] = 160;
		array[76] = 112;
		array[95] = 38;
		array[142] = 132;
		string text5 = string_1.ToUpper();
		array[96] = 155;
		array[97] = 7;
		string_4 = text5;
		array[78] = 134;
		array[98] = 74;
		string text6 = "\u0002[£ùÿÎ< \0\0\0";
		string text7 = text6;
		for (int k = 0; k < text7.Length; k++)
		{
			array[k + 100] = (byte)text7[k];
		}
		array[111] = 52;
		array[112] = 181;
		array[132] = 167;
		string text8 = "×~\u0092 Þ\u0086";
		string text9 = text8;
		for (int l = 0; l < text9.Length; l++)
		{
			array[l + 135] = (byte)text9[l];
		}
		array[92] = 14;
		array[93] = 154;
		array[94] = 124;
		array[77] = 183;
		array[113] = 150;
		array[115] = 170;
		string text10 = string_2.ToUpper();
		array[75] = 125;
		array[133] = 91;
		string_5 = text10;
		try
		{
			string text11 = "ó§[\u0015×~\u0092 Þ\u0086";
			string text12 = text11;
			for (int m = 0; m < text12.Length; m++)
			{
				array[m + 131] = (byte)text12[m];
			}
			array[141] = 160;
			array[142] = 132;
			array[99] = 49;
			GClass0.byte_1 = array;
			if (dictionary_3.Count <= 4)
			{
				return;
			}
			_ = dictionary_3[string_5.ToUpper()];
			Class6 @class = dictionary_3[string_4.ToUpper()];
			int num = -1;
			int num2 = -1;
			for (int n = 0; n < dictionary_3.Count; n++)
			{
				Class6 value = dictionary_3.ElementAt(n).Value;
				if (value.int_3 == @class.int_3 && num == -1)
				{
					num = n;
				}
				if (value.int_3 != @class.int_3 + 1 || num2 != -1)
				{
					continue;
				}
				num2 = n - 1;
				if (num2 == -1)
				{
					num2 = dictionary_3.Count / 2;
				}
				int num3 = (bool_0 ? (num + (num2 - num) / 2) : ((dictionary_3.ElementAt(@class.int_0 + 1).Value.int_3 == @class.int_3) ? (@class.int_0 + 1) : ((dictionary_3.ElementAt(@class.int_0).Value.int_3 != @class.int_3) ? (@class.int_0 - 1) : @class.int_0)));
				int num4 = dictionary_3.Count - 1;
				if (num4 - num3 >= 2)
				{
					for (num4 = num3 + (num4 - num3) / 2; num4 < dictionary_3.Count && dictionary_3.ElementAt(num3).Value.int_2 + 70 > dictionary_3.ElementAt(num4).Value.int_2; num4++)
					{
					}
					if (num4 > num3)
					{
						string_4 = dictionary_3.ElementAt(num3).Value.string_0.ToUpper();
						string_5 = dictionary_3.ElementAt(num4).Value.string_0.ToUpper();
					}
				}
				break;
			}
		}
		catch
		{
		}
	}

	internal void method_5(string string_1, string string_2, int int_1, string string_3, ref string string_4, ref string string_5, bool bool_0)
	{
		string_4 = string_1.ToUpper();
		string_5 = string_2.ToUpper();
		try
		{
			if (dictionary_3.Count <= 4)
			{
				return;
			}
			_ = dictionary_3[string_5.ToUpper()];
			Class6 @class = dictionary_3[string_4.ToUpper()];
			int num = -1;
			int num2 = -1;
			int num3 = 0;
			while (true)
			{
				if (0 < dictionary_3.Count)
				{
					Class6 value = dictionary_3.ElementAt(num3).Value;
					if (value.int_3 == @class.int_3 && num == -1)
					{
						num = num3;
					}
					if (value.int_3 == @class.int_3 + 1 && num2 == -1)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			num2 = num3 - 1;
			if (num2 == -1)
			{
				num2 = dictionary_3.Count / 2;
			}
			int num4 = (bool_0 ? (num + (num2 - num) / 2) : ((dictionary_3.ElementAt(@class.int_0 + 1).Value.int_3 == @class.int_3) ? (@class.int_0 + 1) : ((dictionary_3.ElementAt(@class.int_0).Value.int_3 != @class.int_3) ? (@class.int_0 - 1) : @class.int_0)));
			int num5 = dictionary_3.Count - 1;
			if (num5 - num4 >= 2)
			{
				for (num5 = num4 + (num5 - num4) / 2; num5 < dictionary_3.Count && dictionary_3.ElementAt(num4).Value.int_2 + 70 > dictionary_3.ElementAt(num5).Value.int_2; num5++)
				{
				}
				if (num5 > num4)
				{
					string_4 = dictionary_3.ElementAt(num4).Value.string_0.ToUpper();
					string_5 = dictionary_3.ElementAt(num5).Value.string_0.ToUpper();
				}
			}
		}
		catch
		{
		}
	}

	internal static int smethod_0(int int_1)
	{
		if (1 == 0)
		{
		}
		int result = int_1 switch
		{
			119 => -243, 
			117 => -32, 
			112 => -26, 
			128 => -254, 
			126 => -245, 
			122 => -27, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
