using System;
using Microsoft.Win32;

namespace Booking;

public class GetDotNetVersion
{
	public static string GetDotNetVersionOff()
	{
		string text = smethod_2();
		string strA = text;
		string strB = "4.5";
		if (string.Compare(strA, strB) >= 0)
		{
			string text2 = smethod_0();
			if (text2 != "")
			{
				text = text2;
			}
		}
		string text3 = "*** Maximum .NET version number found is: ";
		string text4 = text;
		string text5 = "***";
		Console.WriteLine(text3 + text4 + text5);
		return text;
	}

	private static string smethod_0()
	{
		string text = "";
		RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
		string name = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\";
		using (RegistryKey registryKey2 = registryKey.OpenSubKey(name))
		{
			if (registryKey2 == null)
			{
				goto IL_007f;
			}
			string name2 = "Release";
			if (registryKey2.GetValue(name2) == null)
			{
				goto IL_007f;
			}
			string name3 = "Release";
			text = smethod_1((int)registryKey2.GetValue(name3));
			string text2 = ".NET Framework Version: ";
			Console.WriteLine(text2 + text);
			goto end_IL_0025;
			IL_007f:
			string value = ".NET Framework Version 4.5 or later is not detected.";
			Console.WriteLine(value);
			end_IL_0025:;
		}
		return text;
	}

	private static string smethod_1(int int_0)
	{
		if (int_0 >= 528040)
		{
			return "4.8 or later";
		}
		if (int_0 < 461808)
		{
			if (int_0 < 461308)
			{
				if (int_0 >= 460798)
				{
					return "4.7";
				}
				if (int_0 >= 394802)
				{
					return "4.6.2";
				}
				if (int_0 >= 394254)
				{
					return "4.6.1";
				}
				if (int_0 >= 393295)
				{
					return "4.6";
				}
				if (int_0 >= 379893)
				{
					return "4.5.2";
				}
				if (int_0 >= 378675)
				{
					return "4.5.1";
				}
				if (int_0 < 378389)
				{
					return "No 4.5 or later version detected";
				}
				return "4.5";
			}
			return "4.7.1";
		}
		return "4.7.2";
	}

	private static string smethod_2()
	{
		string text = "";
		RegistryKey registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "");
		string name = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\";
		using RegistryKey registryKey2 = registryKey.OpenSubKey(name);
		string[] subKeyNames = registryKey2.GetSubKeyNames();
		string[] array = subKeyNames;
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			string value = "v";
			if (!text2.StartsWith(value))
			{
				continue;
			}
			RegistryKey registryKey3 = registryKey2.OpenSubKey(text2);
			string name2 = "Version";
			string text3 = (string)registryKey3.GetValue(name2, "");
			string name3 = "SP";
			string text4 = registryKey3.GetValue(name3, "").ToString();
			string name4 = "Install";
			string text5 = registryKey3.GetValue(name4, "").ToString();
			if (text5 == "")
			{
				string text6 = "  ";
				Console.WriteLine(text2 + text6 + text3);
				if (string.Compare(text, text3) < 0)
				{
					text = text3;
				}
			}
			else if (text4 != "")
			{
				string text7 = "1";
				if (text5 == text7)
				{
					string[] array3 = new string[5] { text2, null, null, null, null };
					string text8 = "  ";
					array3[1] = text8;
					array3[2] = text3;
					string text9 = "  SP";
					array3[3] = text9;
					array3[4] = text4;
					Console.WriteLine(string.Concat(array3));
					if (string.Compare(text, text3) < 0)
					{
						text = text3;
					}
				}
			}
			if (text3 != "")
			{
				continue;
			}
			string[] subKeyNames2 = registryKey3.GetSubKeyNames();
			string[] array4 = subKeyNames2;
			string[] array5 = array4;
			foreach (string text10 in array5)
			{
				RegistryKey registryKey4 = registryKey3.OpenSubKey(text10);
				string name5 = "Version";
				string text11 = (string)registryKey4.GetValue(name5, "");
				if (text11 != "")
				{
					string name6 = "SP";
					text4 = registryKey4.GetValue(name6, "").ToString();
				}
				string name7 = "Install";
				string text12 = registryKey4.GetValue(name7, "").ToString();
				if (!(text12 == ""))
				{
					if (text4 != "")
					{
						string text13 = "1";
						if (text12 == text13)
						{
							string[] array6 = new string[6];
							string text14 = "  ";
							array6[0] = text14;
							array6[1] = text10;
							string text15 = "  ";
							array6[2] = text15;
							array6[3] = text11;
							string text16 = "  SP";
							array6[4] = text16;
							array6[5] = text4;
							Console.WriteLine(string.Concat(array6));
							if (string.Compare(text, text11) < 0)
							{
								text = text11;
							}
							continue;
						}
					}
					string text17 = "1";
					if (text12 == text17)
					{
						string text18 = "  ";
						string text19 = "  ";
						Console.WriteLine(text18 + text10 + text19 + text11);
						if (string.Compare(text, text11) < 0)
						{
							text = text11;
						}
					}
				}
				else
				{
					string text20 = "  ";
					Console.WriteLine(text2 + text20 + text11);
					if (string.Compare(text, text11) < 0)
					{
						text = text11;
					}
				}
			}
		}
		return text;
	}
}
