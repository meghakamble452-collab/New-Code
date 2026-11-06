using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.Win32;

internal class Class11
{
	public static string smethod_0(string string_0, string string_1)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			string text = "SELECT * FROM [TBL_USER] WHERE [UserName] = '";
			string text2 = "'";
			new SQLiteDataAdapter(text + string_0 + text2, clsMain.DataBase_String).Fill(dataTable);
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						result = row[string_1].ToString();
					}
					return result;
				}
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static void smethod_1(string string_0, string string_1, string string_2, string string_3)
	{
		string[] array = new string[5];
		string text = "UPDATE [TBL_USER] SET [";
		string text2 = "] = '";
		array[0] = text + string_1 + text2;
		array[1] = string_2;
		string text3 = "' WHERE [UserName] = '";
		array[2] = text3;
		array[3] = string_3;
		string text4 = "'";
		array[4] = text4;
		smethod_4(string.Concat(array));
	}

	public static void smethod_2(string string_0, string string_1)
	{
		string[] array = new string[5];
		string text = "UPDATE [TBL_BANK] SET [BANK_DETAILS] = '";
		array[0] = text;
		array[1] = string_0;
		string text2 = "' WHERE [BANK_SAVEAS] = '";
		array[2] = text2;
		array[3] = string_1;
		string text3 = "'";
		array[4] = text3;
		smethod_4(string.Concat(array));
	}

	public static void smethod_3(string string_0, string string_1)
	{
		string text = "DELETE from TBL_BANK where BANK_SAVEAS = '";
		string text2 = "' AND BANK_ISDEBIT = ";
		smethod_4(text + string_0 + text2 + string_1);
	}

	public static void smethod_4(string string_0)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.DataBase_String);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteCommand.CommandText = string_0;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
		}
		catch
		{
		}
	}

	public static void smethod_5(string string_0, string string_1)
	{
		SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.DataBase_String);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		string[] array = new string[7];
		string text = "UPDATE [TBL_USER] SET [UserState] = '";
		array[0] = text;
		array[1] = string_0;
		string text2 = "||";
		array[2] = text2;
		DateTime date = DateTime.Now.Date;
		string text3 = "dd/M/yyyy";
		array[3] = date.ToString(text3);
		string text4 = "' WHERE [UserName] = '";
		array[4] = text4;
		array[5] = string_1;
		string text5 = "'";
		array[6] = text5;
		sQLiteCommand.CommandText = string.Concat(array);
		sQLiteCommand.ExecuteNonQuery();
	}

	public static string smethod_6(string string_0)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			string text = "SELECT BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS = '";
			string text2 = "'";
			new SQLiteDataAdapter(text + string_0 + text2, clsMain.DataBase_String).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0][0].ToString();
				dataTable.Dispose();
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static Dictionary<string, string> smethod_7()
	{
		while (true)
		{
			try
			{
				DataTable dataTable = new DataTable();
				string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK";
				new SQLiteDataAdapter(commandText, clsMain.DataBase_String).Fill(dataTable);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						string columnName = "BANK_SAVEAS";
						string key = row[columnName].ToString();
						string columnName2 = "BANK_DETAILS";
						dictionary.Add(key, row[columnName2].ToString());
					}
				}
				return dictionary;
			}
			catch
			{
			}
		}
	}

	public static string smethod_8(string string_0, string string_1)
	{
		string text = "";
		string delimiter = "#";
		string[] array = Strings.Split(string_1, delimiter);
		try
		{
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter(string_0, clsMain.DataBase_String).Fill(dataTable);
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (i != 0)
							{
								string text2 = text;
								string text3 = "$";
								text = text2 + text3;
							}
							text += row[array[i]].ToString();
						}
					}
					return text;
				}
				return text;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	public static string user_RegistryRead()
	{
		string text = "";
		try
		{
			string text2 = "Software\\Microsoft\\Windows\\Shell";
			string name = text2;
			string text3 = "NgetData";
			string name2 = text3;
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name);
			if (registryKey != null)
			{
				object value = registryKey.GetValue(name2);
				if (value != null)
				{
					string string_ = value.ToString();
					string string_2 = "4d4#r7%55";
					string text4 = Decrypt(string_, string_2);
					string[] array = new string[1];
					string text5 = "___";
					array[0] = text5;
					string[] array2 = text4.Split(array, StringSplitOptions.None);
					string s = array2[0];
					string text6 = "dd-MMM-yyyy HH:mm:ss";
					string format = text6;
					DateTime dateTime = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
					string string_3 = array2[1];
					string string_4 = "leftDays";
					string string_5 = ",";
					string s2 = method_1(string_3, string_4, string_5);
					dateTime = dateTime.AddDays(int.Parse(s2));
					if (dateTime >= DateTime.Now)
					{
						text = array2[1];
						string string_6 = text;
						string string_7 = "appVersion\"";
						string string_8 = "\"";
						string text7 = method_1(string_6, string_7, string_8);
						string[] array3 = new string[1];
						string text8 = "||";
						array3[0] = text8;
						array2 = text7.Split(array3, StringSplitOptions.None);
					}
					else
					{
						string text9 = "{\"success\":false,\"message\":\"Licence Key Expire\",\"leftDays\":0,\"tokens\":null,\"appVersion\":null,\"ipList\":null,\"ShortMessage\":null,\"News\":null,\"KeyType\":null,\"paid\":null,\"DllVersion\":null,\"ChromeDriver\":null,\"SaltKey\":null,\"ChromeVersion\":null,\"SellerId\":null,\"Premium\":false,\"S3URL\":null,\"edata\":null,\"sdata\":null,\"adata\":null,\"SuperSeller\":null,\"Admin\":null,\"pass\":null}";
						text = text9;
					}
				}
			}
		}
		catch
		{
		}
		return text;
	}

	public static string Decrypt(string string_0, string string_4)
	{
		if (string.IsNullOrEmpty(string_4))
		{
			string text = "4t56765y";
			string_4 = text;
		}
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_4.Substring(0, 8));
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = Convert.FromBase64String(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	private static string method_1(string string_0, string string_1, string string_2)
	{
		try
		{
			int num = string_1.Length + 2;
			string text = string_0.Substring(string_0.IndexOf(string_1) + num);
			return text.Substring(0, text.IndexOf(string_2));
		}
		catch (Exception ex)
		{
			return ex.ToString();
		}
	}
}
