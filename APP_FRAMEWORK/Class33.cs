using System;
using System.Text;

namespace APP_FRAMEWORK;

public static class Class33
{
	public static string tales;

	public static string string_0;

	public static string string_1;

	public static string string_2;

	public static string string_3;

	public static string string_4;

	public static string string_5;

	public static string string_6;

	public static string string_7;

	public static string string_8;

	public static string string_9;

	public static string string_10;

	public static string string_11;

	public static string string_12;

	public static string string_13;

	public static string string_14;

	public static string string_15;

	public static string string_16;

	public static string string_17;

	public static string string_18;

	public static string string_19;

	public static string string_20;

	public static string string_21;

	public static string string_22;

	public static string string_23;

	public static string string_24;

	public static string string_25;

	public static string string_26;

	public static string string_27;

	public static string string_28;

	public static string[,] Jrny_Traindata;

	static Class33()
	{
		string text = "162.241.27.64 newsetup.xyz";
		tales = text;
		Jrny_Traindata = new string[200, 12];
		string_0 = "";
		string_1 = "";
		string_2 = "";
		string_3 = "";
		string_4 = "";
		string_5 = "";
		string_6 = "";
		string_7 = "";
		string_8 = "";
		string_9 = "";
		string_10 = "";
		string_11 = "";
		string_12 = "";
		string_13 = "";
		string_14 = "";
		string_15 = "";
		string_16 = "";
		string_17 = "";
		string_18 = "";
		string_19 = "";
		string_20 = "";
		string_21 = "";
		string_22 = "";
		string_23 = "";
		string_24 = "";
		string_25 = "";
		string_26 = "";
		string_27 = "";
		smethod_0();
	}

	private static void smethod_0()
	{
		string_0 = Class32.String_19;
		string_7 = smethod_1(Class32.String_21);
		string_8 = smethod_1(Class32.String_0);
		string_9 = smethod_1(Class32.String_1);
		string_10 = smethod_1(Class32.String_20);
		string_11 = smethod_1(Class32.String_15);
		string_12 = smethod_1(Class32.String_9);
		string_13 = smethod_1(Class32.String_23);
		string_14 = smethod_1(Class32.String_16);
		string_15 = smethod_1(Class32.String_2);
		string_28 = smethod_1(Class32.String_26);
		string_16 = smethod_1(Class32.String_6);
		string_17 = smethod_1(Class32.String_32);
		string_18 = smethod_1(Class32.String_3);
		string_19 = smethod_1(Class32.String_4);
		string_20 = smethod_1(Class32.String_5);
		string_21 = smethod_1(Class32.String_7);
		string_22 = smethod_1(Class32.String_8);
		string_25 = smethod_1(Class32.String_12);
		string_26 = smethod_1(Class32.String_13);
		string_23 = smethod_1(Class32.String_10);
		string_24 = smethod_1(Class32.String_11);
		string_27 = smethod_1(Class32.String_14);
	}

	private static string smethod_1(string string_29)
	{
		try
		{
			return string_29;
		}
		catch
		{
		}
		return "";
	}

	public static string DB64(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}
		byte[] bytes = Convert.FromBase64String(value);
		return Encoding.UTF8.GetString(bytes);
	}
}
