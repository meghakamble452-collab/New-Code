using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace APP_FRAMEWORK;

[DesignTimeVisible(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
[Browsable(false)]
internal static class Class34
{
	internal static Dictionary<int, string> dictionary_0;

	internal static List<string> list_0;

	internal static string string_Database;

	private static string string_1;

	private static string string_2;

	private static string string_3;

	private static string string_4;

	private static string[] string_5;

	private static string[] string_6;

	private static string[] string_7;

	private static string[] string_8;

	static Class34()
	{
		dictionary_0 = new Dictionary<int, string>();
		list_0 = new List<string>();
		string text = "^\\w*$";
		string_1 = text;
		string text2 = "^\\d*$";
		string_2 = text2;
		string text3 = "^[a-zA-Z0-9/-]+$";
		string_3 = text3;
		string text4 = "^[a-z]*$";
		string_4 = text4;
		string[] array = new string[1];
		string text5 = "SRCTZN";
		array[0] = text5;
		string_5 = array;
		Array.Sort(string_5);
		string[] array2 = new string[9];
		string text6 = "1A";
		array2[0] = text6;
		string text7 = "2A";
		array2[1] = text7;
		string text8 = "FC";
		array2[2] = text8;
		string text9 = "3A";
		array2[3] = text9;
		string text10 = "CC";
		array2[4] = text10;
		string text11 = "SL";
		array2[5] = text11;
		string text12 = "2S";
		array2[6] = text12;
		string text13 = "3E";
		array2[7] = text13;
		string text14 = "EC";
		array2[8] = text14;
		string_6 = array2;
		Array.Sort(string_6);
		string[] array3 = new string[4];
		string text15 = "GN";
		array3[0] = text15;
		string text16 = "TQ";
		array3[1] = text16;
		string text17 = "LD";
		array3[2] = text17;
		string text18 = "PT";
		array3[3] = text18;
		string_7 = array3;
		Array.Sort(string_7);
		string[] array4 = new string[8];
		string text19 = "Lower";
		array4[0] = text19;
		string text20 = "Middle";
		array4[1] = text20;
		string text21 = "Upper";
		array4[2] = text21;
		string text22 = "Side lower";
		array4[3] = text22;
		string text23 = "Side upper";
		array4[4] = text23;
		string text24 = "Side middle";
		array4[5] = text24;
		string text25 = "Window Seat";
		array4[6] = text25;
		string text26 = "No Choice";
		array4[7] = text26;
		string_8 = array4;
		Array.Sort(string_8);
	}

	internal static bool smethod_1(string string_10)
	{
		if (string_10.Length >= 4)
		{
			return Regex.IsMatch(string_10, string_3);
		}
		return false;
	}

	internal static bool smethod_2(string string_10)
	{
		string_10 = string_10.ToLower();
		if (string_10.Length >= 2 && string_10.Length <= 5)
		{
			return Regex.IsMatch(string_10, string_1);
		}
		return false;
	}

	internal static bool smethod_3(string string_10)
	{
		return Regex.IsMatch(string_10.ToLower(), string_1);
	}

	internal static bool smethod_4(string string_10)
	{
		if (string_10.Length == 10 && (string_10[0] == '9' || string_10[0] == '8' || string_10[0] == '7' || string_10[0] == '6'))
		{
			return Regex.IsMatch(string_10, string_2);
		}
		return false;
	}

	internal static bool smethod_5(string string_10)
	{
		return Regex.IsMatch(string_10, string_2);
	}

	internal static bool smethod_6(string string_10)
	{
		string_10 = string_10.ToLower();
		if (string_10.Length >= 1 && string_10.Length <= 4)
		{
			return Regex.IsMatch(string_10.ToLower(), string_4);
		}
		return false;
	}

	internal static void smethod_15(string string_10)
	{
		if (!list_0.Contains(string_10))
		{
			list_0.Add(string_10);
		}
	}
}
