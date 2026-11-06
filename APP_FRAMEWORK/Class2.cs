using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace APP_FRAMEWORK;

internal class Class2
{
	public static string IV;

	public static string Key;

	private static Encoding smethod_0()
	{
		return Encoding.ASCII;
	}

	public static string smethod_00(string string_0)
	{
		return smethod_0().GetString(Convert.FromBase64String(string_0));
	}

	public static string Base64Encode(string plainText)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
	}

	public static string Base64Decode(string base64EncodedData)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
	}

	public static string EncryptText(string strText, string string_0)
	{
		return Encrypt(strText, string_0);
	}

	public static string Encrypt(string string_0, string string_4)
	{
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		byte[] bytes = Encoding.UTF8.GetBytes(Strings.Left(string_4, 8));
		DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
		cryptoStream.Write(bytes2, 0, bytes2.Length);
		cryptoStream.FlushFinalBlock();
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public static string Decrypt(string string_0, string string_4)
	{
		string text = string_4;
		string text2 = "g4#6hkn$uu";
		if (text == text2)
		{
			string text3 = "33E#H&7N&$";
			string_4 = text3;
		}
		if (string.IsNullOrEmpty(string_4))
		{
			string_4 = frmLogin.key;
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

	public static string DecryptText(string strText, string string_0)
	{
		string result = "";
		if (strText == "")
		{
			return result;
		}
		return Decrypt(strText, string_0);
	}

	public static string Encrypt_AesCrypto(string decrypted)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(decrypted);
		AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
		aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(IV);
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
		byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
		cryptoTransform.Dispose();
		return Convert.ToBase64String(inArray);
	}

	public static string DecryptRJ256(string prm_key, string prm_iv, string prm_text_to_decrypt)
	{
		try
		{
			ICryptoTransform transform = new RijndaelManaged
			{
				Padding = PaddingMode.Zeros,
				Mode = CipherMode.CBC,
				KeySize = 256,
				BlockSize = 256
			}.CreateDecryptor(Encoding.ASCII.GetBytes(prm_key), Encoding.ASCII.GetBytes(prm_iv));
			byte[] array = Convert.FromBase64String(prm_text_to_decrypt);
			byte[] array2 = new byte[array.Length];
			new CryptoStream(new MemoryStream(array), transform, CryptoStreamMode.Read).Read(array2, 0, array2.Length);
			return Encoding.ASCII.GetString(array2);
		}
		catch
		{
		}
		return "#";
	}

	public static string EncryptRJ256(string prm_key, string prm_iv, string prm_text_to_encrypt)
	{
		ICryptoTransform transform = new RijndaelManaged
		{
			Padding = PaddingMode.Zeros,
			Mode = CipherMode.CBC,
			KeySize = 256,
			BlockSize = 256
		}.CreateEncryptor(Encoding.ASCII.GetBytes(prm_key), Encoding.ASCII.GetBytes(prm_iv));
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		byte[] bytes = Encoding.ASCII.GetBytes(prm_text_to_encrypt);
		cryptoStream.Write(bytes, 0, bytes.Length);
		cryptoStream.FlushFinalBlock();
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	static Class2()
	{
		string iV = "qsder45HtU78hkHl";
		IV = iV;
		string key = "cfdrty76yhgr4Dfrtgfdu784r5yf67GF";
		Key = key;
	}
}
