using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace APP_FRAMEWORK;

internal class SBISecure2_0_1
{
	public static string EncryptEncData(string plnData, string userId, string mpin, string appKey)
	{
		return UpperCaseUrlEncode(Base64Encode(EncryptAESCBC(plnData, HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin))), isUrlSafe: false), Encoding.UTF8);
	}

	public static string DecryptRequestEncData(string encData, string userId, string mpin, string appKey)
	{
		return Encoding.UTF8.GetString(DecryptAESCBC(Base64Decode(HttpUtility.UrlDecode(encData)), HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin))));
	}

	public static string DecryptResponseEncData(string encData, string userId, string mpin, string appKey)
	{
		return Encoding.UTF8.GetString(DecryptAESCBC(Base64Decode(encData), HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin))));
	}

	internal static string GetRequest(string plnData)
	{
		string text = "c8f4a4536cabfe8233d8d234d005d93e6a91702853cb2d93cb3c846e7ac6c322";
		string text2 = text;
		string text3 = "#";
		return smethod_0(plnData + text3 + text2);
	}

	internal static string GetKey(string mpin, string appKey)
	{
		return smethod_0(mpin + appKey).ToUpper();
	}

	internal static string GetIV(string userId, string mpin)
	{
		return smethod_0(Reverse(FormatUserId(userId)) + Reverse(mpin)).Substring(0, 32).ToUpper();
	}

	public static string Reverse(string s)
	{
		char[] array = s.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}

	internal static string FormatUserId(string userId)
	{
		return (userId + userId).Substring(0, (userId.Length >= 5) ? 10 : (userId.Length * 2));
	}

	private static string smethod_0(string string_0)
	{
		string hashName = "SHA-256";
		return BytesToHexStr(HashAlgorithm.Create(hashName).ComputeHash(Encoding.UTF8.GetBytes(string_0)));
	}

	internal static byte[] EncryptAESCBC(string plainText, byte[] aesKeyBytes, byte[] ivBytes)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		return GetCBCRijndaelManaged(aesKeyBytes, ivBytes).CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
	}

	internal static byte[] DecryptAESCBC(byte[] encTextBytes, byte[] aesKeyBytes, byte[] ivBytes)
	{
		return GetCBCRijndaelManaged(aesKeyBytes, ivBytes).CreateDecryptor().TransformFinalBlock(encTextBytes, 0, encTextBytes.Length);
	}

	public static RijndaelManaged GetCBCRijndaelManaged(byte[] secretKeyBytes, byte[] ivBytes)
	{
		return new RijndaelManaged
		{
			Mode = CipherMode.CBC,
			Padding = PaddingMode.PKCS7,
			KeySize = 256,
			BlockSize = 128,
			Key = secretKeyBytes,
			IV = ivBytes
		};
	}

	public static string UpperCaseUrlEncode(string s, Encoding encoding)
	{
		char[] array = HttpUtility.UrlEncode(s, encoding).ToCharArray();
		for (int i = 0; i < array.Length - 2; i++)
		{
			if (array[i] == '%')
			{
				array[i + 1] = char.ToUpper(array[i + 1]);
				array[i + 2] = char.ToUpper(array[i + 2]);
			}
		}
		return new string(array);
	}

	public static string ConvertStringToHexString(string text)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array = bytes;
		byte[] array2 = array;
		byte[] array3 = array2;
		foreach (byte b in array3)
		{
			string text2 = "x";
			stringBuilder.Append(b.ToString(text2));
		}
		return stringBuilder.ToString();
	}

	public static string BytesToHexStr(byte[] bArr)
	{
		if (bArr == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < bArr.Length; i++)
		{
			string format = "{0:x2}";
			stringBuilder.Append(string.Format(format, bArr[i]));
		}
		return stringBuilder.ToString();
	}

	public static byte[] HexStrToBytes(string text)
	{
		byte[] array = new byte[text.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte.Parse(text.Substring(i * 2, 2), NumberStyles.HexNumber);
		}
		return array;
	}

	public static string Base64Encode(string plainText, bool isUrlSafe)
	{
		string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		if (isUrlSafe)
		{
			text = text.Replace('+', '-').Replace('/', '_');
		}
		return text;
	}

	public static string Base64Encode(byte[] plainTextBytes, bool isUrlSafe)
	{
		string text = Convert.ToBase64String(plainTextBytes);
		if (isUrlSafe)
		{
			text = text.Replace('+', '-').Replace('/', '_');
		}
		return text;
	}

	public static byte[] Base64Decode(string base64EncodedData)
	{
		return Convert.FromBase64String(base64EncodedData);
	}
}
