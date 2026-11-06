using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace IRCommDLL;

internal static class Class50
{
	private static string CAAA0 = string.Empty;

	public static string smethod_E00000()
	{
		if (string.IsNullOrEmpty(CAAA0))
		{
			CAAA0 = smethod_1(getUUID2());
		}
		return CAAA0;
	}

	private static string smethod_1(string string_0)
	{
		return smethod_2(new MD5CryptoServiceProvider().ComputeHash(new ASCIIEncoding().GetBytes(string_0)));
	}

	private static string smethod_2(byte[] byte_0)
	{
		string text = string.Empty;
		for (int i = 0; i < byte_0.Length; i++)
		{
			byte b = byte_0[i];
			int num = b & 0xF;
			int num2 = (b >> 4) & 0xF;
			string text2;
			if (num2 <= 9)
			{
				text2 = text + num2;
			}
			else
			{
				string text3 = text;
				string text4 = ((char)(num2 - 10 + 65)).ToString();
				text2 = text3 + text4;
			}
			if (num <= 9)
			{
				text = text2 + num;
			}
			else
			{
				string text5 = text2;
				string text6 = ((char)(num - 10 + 65)).ToString();
				text = text5 + text6;
			}
			if (i + 1 != byte_0.Length && (i + 1) % 2 == 0)
			{
				string text7 = text;
				string text8 = "-";
				text = text7 + text8;
			}
		}
		return text;
	}

	public static string smethod_100()
	{
		string string_ = "Win32_LogicalDisk";
		string string_2 = "VolumeSerialNumber";
		string text = smethod_8(string_, string_2);
		if (text == "")
		{
			string string_3 = "Win32_LogicalDisk";
			string string_4 = "Name";
			text = smethod_8(string_3, string_4);
		}
		return text;
	}

	private static string smethod_8(string string_0, string string_1)
	{
		string text = "";
		foreach (ManagementObject instance in new ManagementClass(string_0).GetInstances())
		{
			if (text == "")
			{
				try
				{
					text = instance[string_1].ToString();
				}
				catch
				{
					continue;
				}
				break;
			}
		}
		return text;
	}

	public static string getUUID2()
	{
		string text = "";
		try
		{
			string format = "\\\\{0}\\root\\CIMV2";
			string arg = "localhost";
			ManagementScope managementScope = new ManagementScope(string.Format(format, arg), null);
			managementScope.Connect();
			string query = "SELECT UUID FROM Win32_ComputerSystemProduct";
			ObjectQuery query2 = new ObjectQuery(query);
			foreach (ManagementBaseObject item in new ManagementObjectSearcher(managementScope, query2).Get())
			{
				string format2 = "{0,-35} {1,-40}";
				string arg2 = "UUID";
				string propertyName = "UUID";
				text = string.Format(format2, arg2, item[propertyName]);
				Console.WriteLine(text);
			}
			string text2 = text;
			string oldValue = "\n";
			string text3 = text2.Replace(oldValue, "");
			string oldValue2 = "\r";
			string text4 = text3.Replace(oldValue2, "");
			string oldValue3 = "\t";
			string text5 = text4.Replace(oldValue3, "");
			string oldValue4 = " ";
			text = text5.Replace(oldValue4, "");
			string text6 = text;
			string oldValue5 = "UUID";
			string newValue = "UUID >> ";
			text = text6.Replace(oldValue5, newValue);
		}
		catch (Exception ex)
		{
			string text7 = "Exception ";
			string message = ex.Message;
			string text8 = " Trace ";
			Console.WriteLine(text7 + message + text8 + ex.StackTrace);
		}
		return text;
	}
}
