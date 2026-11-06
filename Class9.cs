using System;
using System.Collections.Generic;
using System.Web;

internal class Class9 : IDisposable
{
	private clsMain class28_0;

	public static byte[] byte_0;

	public static byte[] byte_1;

	internal Class9()
	{
		try
		{
			class28_0 = new clsMain();
		}
		catch (Exception)
		{
		}
	}

	internal void SetCon(string string_0)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		try
		{
			clsMain.DataBase_String = string_0;
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
		}
		catch
		{
		}
	}

	internal void SetData(string string_0, string string_1)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
		}
		catch
		{
		}
		class28_0.SetData(string_0, string_1);
	}

	internal string GetData(string string_0)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		string result = "";
		try
		{
			result = class28_0.GetData(string_0);
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal void SetSpare(string string_0, string string_1)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
		}
		catch
		{
		}
	}

	internal string isLV(string string_0, string string_1, ref string string_2)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		string result = "";
		try
		{
			result = class28_0.isLV(string_0, string_1, ref string_2);
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal bool GetTBSN(string string_0, string string_1, DateTime dateTime_0, ref List<string> list_0)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		bool result = false;
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			result = class28_0.GetTBSN(string_0, string_1, dateTime_0, ref list_0);
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal string GetF(string string_0, string string_1, string string_2, string string_3)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		string result = "";
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			result = class28_0.GetF(string_0, string_1, string_2, string_3);
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal List<string> GetPType()
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		List<string> result = null;
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			result = class28_0.GetPType();
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal Dictionary<string, string> GetNet()
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		Dictionary<string, string> result = null;
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			result = class28_0.GetNet();
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string text9 = "value";
			string value4 = text9;
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal Dictionary<string, string> GetD()
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		string text2 = text;
		string text3 = text2;
		string oldValue = "'";
		string newValue = "\"";
		text2 = text3.Replace(oldValue, newValue);
		Dictionary<string, string> result = null;
		try
		{
			string text4 = text2;
			string value = "name=";
			int startIndex = text4.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			result = class28_0.GetD();
			string text5 = text2;
			string value2 = "\"";
			startIndex = text5.LastIndexOf(value2, startIndex);
			string text6 = text2;
			string value3 = ">";
			int length = text6.IndexOf(value3, startIndex) - startIndex;
			string text7 = text2.Substring(startIndex, length);
			string oldValue2 = "'";
			string newValue2 = "\"";
			string text8 = text7.Replace(oldValue2, newValue2);
			string value4 = "value";
			startIndex = text8.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase);
			string value5 = "\"";
			startIndex = text8.IndexOf(value5, startIndex) + 1;
			string value6 = "\"";
			length = text8.IndexOf(value6, startIndex) - startIndex;
			HttpUtility.UrlEncode(text8.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	public void Dispose()
	{
		class28_0.Dispose();
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}
}
