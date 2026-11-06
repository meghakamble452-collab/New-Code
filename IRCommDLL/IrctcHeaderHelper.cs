using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace IRCommDLL;

internal class IrctcHeaderHelper
{
	public static void FilterALL(ref CookieContainer cookie_, ref string csrf_token, ref string _Authorization, ref string greq, ref string bmiyek, string responseString, Uri fallbackUri = null)
	{
		if (cookie_ == null)
		{
			cookie_ = new CookieContainer();
		}
		try
		{
			JObject jObject = JObject.Parse(responseString);
			string path = "requestHeaders";
			Dictionary<string, string> dictionary = jObject.SelectToken(path)?.ToObject<Dictionary<string, string>>();
			if (dictionary != null)
			{
				string key2 = "authorization";
				_Authorization = GetIgnoreCase(dictionary, key2) ?? _Authorization;
				string key3 = "greq";
				greq = GetIgnoreCase(dictionary, key3) ?? greq;
				string key4 = "bmiyek";
				object obj = GetIgnoreCase(dictionary, key4);
				if (obj == null)
				{
					string key5 = "bmirak";
					obj = GetIgnoreCase(dictionary, key5) ?? bmiyek;
				}
				bmiyek = (string)obj;
				string key6 = "cookie";
				string text = GetIgnoreCase(dictionary, key6);
				if (text == null)
				{
					string key7 = "cookies";
					text = GetIgnoreCase(dictionary, key7);
				}
				if (!string.IsNullOrEmpty(text) && (object)fallbackUri == null)
				{
					string propertyName = "url";
					if (!Uri.TryCreate(jObject[propertyName]?.ToString(), UriKind.Absolute, out var _))
					{
						string uriString = "https://www.irctc.co.in/";
						new Uri(uriString);
					}
				}
			}
			string path2 = "responseHeaders";
			Dictionary<string, string> dictionary2 = jObject.SelectToken(path2)?.ToObject<Dictionary<string, string>>();
			if (dictionary2 != null)
			{
				string key8 = "csrf-token";
				object obj2 = GetIgnoreCase(dictionary2, key8);
				if (obj2 == null)
				{
					string key9 = "spa-csrf-token";
					obj2 = GetIgnoreCase(dictionary2, key9);
					if (obj2 == null)
					{
						string key10 = "x-csrf-token";
						obj2 = GetIgnoreCase(dictionary2, key10) ?? csrf_token;
					}
				}
				csrf_token = (string)obj2;
				string key11 = "set-cookie";
				string text2 = GetIgnoreCase(dictionary2, key11);
				if (text2 == null)
				{
					string key12 = "cookies";
					text2 = GetIgnoreCase(dictionary2, key12);
					if (text2 == null)
					{
						string key13 = "cookie";
						text2 = GetIgnoreCase(dictionary2, key13);
					}
				}
				string text3 = text2;
				if (!string.IsNullOrEmpty(text3))
				{
					Uri uri = fallbackUri;
					if ((object)uri == null)
					{
						string propertyName2 = "url";
						if (!Uri.TryCreate(jObject[propertyName2]?.ToString(), UriKind.Absolute, out var result2))
						{
							string uriString2 = "https://www.irctc.co.in/";
							uri = new Uri(uriString2);
						}
						else
						{
							uri = result2;
						}
					}
					Uri targetUri = uri;
					ApplySetCookieStringToContainer(cookie_, targetUri, text3);
				}
			}
			string propertyName3 = "cookies";
			if (jObject[propertyName3] == null)
			{
				return;
			}
			string propertyName4 = "cookies";
			if (string.IsNullOrEmpty(jObject[propertyName4].ToString()))
			{
				return;
			}
			Uri uri2 = fallbackUri;
			if ((object)uri2 == null)
			{
				string propertyName5 = "url";
				if (!Uri.TryCreate(jObject[propertyName5]?.ToString(), UriKind.Absolute, out var result3))
				{
					string uriString3 = "https://www.irctc.co.in/";
					uri2 = new Uri(uriString3);
				}
				else
				{
					uri2 = result3;
				}
			}
			Uri targetUri2 = uri2;
			CookieContainer container = cookie_;
			string propertyName6 = "cookies";
			ApplySetCookieStringToContainer(container, targetUri2, jObject[propertyName6].ToString());
		}
		catch
		{
		}
		static string GetIgnoreCase(IDictionary<string, string> dict, string key)
		{
			if (dict == null)
			{
				return null;
			}
			foreach (KeyValuePair<string, string> item in dict)
			{
				if (string.Equals(item.Key, key, StringComparison.OrdinalIgnoreCase))
				{
					return item.Value;
				}
			}
			return null;
		}
	}

	private static void ApplySetCookieStringToContainerRE(CookieContainer container, Uri targetUri, string cookieHeader)
	{
		if (string.IsNullOrEmpty(cookieHeader) || container == null || targetUri == null)
		{
			return;
		}
		try
		{
			string[] array = cookieHeader.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				string value = "=";
				if (text.Contains(value))
				{
					string uriString = "https://www.irctc.co.in";
					Uri uri = new Uri(uriString);
					try
					{
						container.SetCookies(uri, text);
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
	}

	private static void ApplySetCookieStringToContainer(CookieContainer container, Uri targetUri, string cookieHeader)
	{
		if (string.IsNullOrEmpty(cookieHeader) || container == null || targetUri == null)
		{
			return;
		}
		try
		{
			container.SetCookies(targetUri, cookieHeader);
		}
		catch
		{
			string[] array = cookieHeader.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				string value = "=";
				if (text.Contains(value))
				{
					try
					{
						container.SetCookies(targetUri, text);
					}
					catch
					{
					}
				}
			}
		}
	}

	private static List<string> SplitSetCookieHeader(string header)
	{
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(header))
		{
			return list;
		}
		int num = 0;
		while (num < header.Length)
		{
			int num2 = header.IndexOf(',', num);
			if (num2 != -1)
			{
				int num3 = num2 + 1;
				if (num3 < header.Length && header[num3] == ' ')
				{
					num3++;
				}
				int num4 = header.IndexOf('=', num3);
				int num5 = header.IndexOf(';', num3);
				if (num4 != -1 && (num5 == -1 || num4 < num5))
				{
					list.Add(header.Substring(num, num2 - num));
					num = num2 + 1;
					if (num < header.Length && header[num] == ' ')
					{
						num++;
					}
				}
				else
				{
					num = num2 + 1;
				}
				continue;
			}
			list.Add(header.Substring(num));
			break;
		}
		return (from s in list
			select s.Trim() into s
			where !string.IsNullOrEmpty(s)
			select s).ToList();
	}
}
