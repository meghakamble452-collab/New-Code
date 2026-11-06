using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

internal class Class10
{
	private static CultureInfo cultureInfo_0;

	public static object object_0;

	public static object object_1;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal Class10()
	{
	}

	public HtmlDocument method_0(string string_0)
	{
		try
		{
			WebBrowser webBrowser = new WebBrowser();
			webBrowser.ScriptErrorsSuppressed = true;
			webBrowser.DocumentText = string_0;
			webBrowser.Document.OpenNew(replaceInHistory: true);
			webBrowser.Document.Write(string_0);
			webBrowser.Refresh();
			return webBrowser.Document;
		}
		catch
		{
		}
		return null;
	}

	public string method_1(string string_0, ref string string_1, bool bool_0)
	{
		string_1 = "";
		try
		{
			string text = string_0;
			string oldValue = "'";
			string newValue = "\"";
			string text2 = text.Replace(oldValue, newValue);
			string value = " action=";
			int num = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			if (num <= 0)
			{
				string value2 = " action =";
				num = text2.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase);
			}
			string value3 = "\"";
			num = text2.IndexOf(value3, num) + 1;
			string value4 = "\"";
			int num2 = text2.IndexOf(value4, num);
			string_1 = text2.Substring(num, num2 - num);
		}
		catch
		{
		}
		string text3 = "";
		try
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			string text4 = string_0;
			string oldValue2 = "document.forms[0].submit();";
			string text5 = text4.Replace(oldValue2, "");
			string oldValue3 = ".submit();";
			string_0 = text5.Replace(oldValue3, "");
			HtmlDocument htmlDocument = method_0(string_0);
			string tagName = "form";
			HtmlElement htmlElement = htmlDocument.GetElementsByTagName(tagName)[0];
			try
			{
				int num3 = 0;
				string tagName2 = "input";
				foreach (HtmlElement item in htmlElement.GetElementsByTagName(tagName2))
				{
					if (Operators.CompareString(item.Name, "", TextCompare: true) != 0)
					{
						string name = item.Name;
						string value5 = "reset";
						if (!name.Contains(value5))
						{
							string name2 = item.Name;
							string value6 = "submit";
							if (!name2.Contains(value6))
							{
								string attributeName = "type";
								string attribute = item.GetAttribute(attributeName);
								string right = "radio";
								if (Operators.CompareString(attribute, right, TextCompare: true) == 0)
								{
									string attributeName2 = "checked";
									string attribute2 = item.GetAttribute(attributeName2);
									string right2 = "checked";
									if (Operators.CompareString(attribute2, right2, TextCompare: true) == 0)
									{
										string name3 = item.Name;
										string text6 = "=";
										string attributeName3 = "value";
										string text7 = name3 + text6 + HttpUtility.UrlEncode(item.GetAttribute(attributeName3));
										string text8;
										if (num3 == 0)
										{
											text8 = text7;
										}
										else
										{
											string text9 = text3;
											string text10 = "&";
											text8 = text9 + text10 + text7;
										}
										text3 = text8;
									}
								}
								else
								{
									string name4 = item.Name;
									string text11 = "=";
									string attributeName4 = "value";
									string text12 = name4 + text11 + HttpUtility.UrlEncode(item.GetAttribute(attributeName4));
									string text13;
									if (num3 == 0)
									{
										text13 = text12;
									}
									else
									{
										string text14 = text3;
										string text15 = "&";
										text13 = text14 + text15 + text12;
									}
									text3 = text13;
								}
							}
						}
					}
					num3++;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			try
			{
				string tagName3 = "select";
				enumerator2 = htmlElement.GetElementsByTagName(tagName3).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					IEnumerator enumerator4 = null;
					HtmlElement htmlElement3 = (HtmlElement)enumerator2.Current;
					string attributeName5 = "name";
					string attribute3 = htmlElement3.GetAttribute(attributeName5);
					try
					{
						string tagName4 = "option";
						foreach (HtmlElement item2 in htmlElement3.GetElementsByTagName(tagName4))
						{
							string attributeName6 = "selected";
							string attribute4 = item2.GetAttribute(attributeName6);
							string right3 = "True";
							if (Operators.CompareString(attribute4, right3, TextCompare: true) == 0)
							{
								string[] array = new string[5] { text3, null, null, null, null };
								string text16 = "&";
								array[1] = text16;
								array[2] = attribute3;
								string text17 = "=";
								array[3] = text17;
								string attributeName7 = "value";
								array[4] = HttpUtility.UrlEncode(item2.GetAttribute(attributeName7));
								text3 = string.Concat(array);
							}
						}
					}
					finally
					{
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			return text3;
		}
		catch (Exception ex)
		{
			ex.Message.ToString();
			return text3;
		}
	}

	public string method_2(string string_0, string string_1, string string_2, string string_3)
	{
		string text = "";
		try
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			HtmlDocument htmlDocument = method_0(string_1);
			HtmlElement htmlElement;
			if (Operators.CompareString(string_0, "", TextCompare: true) == 0)
			{
				string tagName = "form";
				htmlElement = htmlDocument.GetElementsByTagName(tagName)[0];
			}
			else
			{
				htmlElement = htmlDocument.GetElementById(string_0);
			}
			HtmlElement htmlElement2 = htmlElement;
			string text2 = "input";
			if (string_2 == text2)
			{
				string tagName2 = "input";
				HtmlElementCollection elementsByTagName = htmlElement2.GetElementsByTagName(tagName2);
				int num = 0;
				try
				{
					foreach (HtmlElement item in elementsByTagName)
					{
						if (Operators.CompareString(item.Name, "", TextCompare: true) != 0)
						{
							string name = item.Name;
							string right = "reset";
							if (Operators.CompareString(name, right, TextCompare: true) != 0)
							{
								string name2 = item.Name;
								string right2 = "submit";
								if (Operators.CompareString(name2, right2, TextCompare: true) != 0)
								{
									string attributeName = "type";
									string attribute = item.GetAttribute(attributeName);
									string right3 = "radio";
									if (Operators.CompareString(attribute, right3, TextCompare: true) != 0)
									{
										string name3 = item.Name;
										string text3 = "=";
										string attributeName2 = "value";
										item.Name = name3 + text3 + HttpUtility.UrlEncode(item.GetAttribute(attributeName2));
										if (item.Name == string_3)
										{
											string attributeName3 = "value";
											text = HttpUtility.UrlEncode(item.GetAttribute(attributeName3));
										}
									}
								}
							}
						}
						num++;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			string text4 = "option";
			if (string_2 == text4)
			{
				string tagName3 = "select";
				HtmlElementCollection elementsByTagName2 = htmlElement2.GetElementsByTagName(tagName3);
				try
				{
					enumerator2 = elementsByTagName2.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						IEnumerator enumerator4 = null;
						HtmlElement htmlElement4 = (HtmlElement)enumerator2.Current;
						string attributeName4 = "name";
						htmlElement4.GetAttribute(attributeName4);
						try
						{
							string tagName4 = "option";
							foreach (HtmlElement item2 in htmlElement4.GetElementsByTagName(tagName4))
							{
								if (item2.Parent.Name.Contains(string_3))
								{
									string[] array = new string[5] { text, null, null, null, null };
									string text5 = "&";
									array[1] = text5;
									array[2] = item2.InnerHtml;
									string text6 = "=";
									array[3] = text6;
									string attributeName5 = "value";
									array[4] = HttpUtility.UrlEncode(item2.GetAttribute(attributeName5));
									text = string.Concat(array);
								}
							}
						}
						finally
						{
							if (enumerator4 is IDisposable)
							{
								(enumerator4 as IDisposable).Dispose();
							}
						}
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
			}
			text = HttpUtility.UrlDecode(text);
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}
}
