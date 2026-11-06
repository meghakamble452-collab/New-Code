using System;

namespace NativeCSharpJWTToken;

public static class Base64Url
{
	public static string Encode(byte[] input)
	{
		return Convert.ToBase64String(input).Split('=')[0].Replace('+', '-').Replace('/', '_');
	}

	public static byte[] Decode(string input)
	{
		string text = input.Replace('-', '+');
		text = text.Replace('_', '/');
		switch (text.Length % 4)
		{
		default:
		{
			string paramName = "input";
			string message = "Illegal base64url string!";
			throw new ArgumentOutOfRangeException(paramName, message);
		}
		case 2:
		{
			string text4 = text;
			string text5 = "==";
			text = text4 + text5;
			break;
		}
		case 3:
		{
			string text2 = text;
			string text3 = "=";
			text = text2 + text3;
			break;
		}
		case 0:
			break;
		}
		return Convert.FromBase64String(text);
	}
}
