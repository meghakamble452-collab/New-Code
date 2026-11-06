using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace APP_FRAMEWORK;

internal class kewirctcLogin
{
	private Dictionary<string, string> headersDict;

	private string key = "DM75D9t0cLdmXM3pINe+0ImzJkNzO/PKD+Kr6jf6PkLrhErcfbqQvo7G18hs0hga";

	internal string ConnectHttpJava(string body)
	{
		string result = string.Empty;
		HttpWebResponse httpWebResponse = null;
		try
		{
			string text = body;
			string oldValue = "BRFGHJEREWJHNVS";
			string newValue = "ZWF67H5GYW3";
			body = text.Replace(oldValue, newValue);
			string[] array = new string[7];
			string text2 = "{\"User\":\"";
			array[0] = text2;
			string text3 = "Admin";
			array[1] = text3;
			string text4 = "\",\"data\":\"";
			array[2] = text4;
			array[3] = body;
			string text5 = "\",\"sCount\":\"";
			array[4] = text5;
			string text6 = "2";
			array[5] = text6;
			string text7 = "\"}";
			array[6] = text7;
			string.Concat(array);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text8 = "User";
			string value = "Jane Smith";
			dictionary.Add(text8, value);
			string text9 = "data";
			string value2 = "object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0) => true";
			dictionary.Add(text9, value2);
			string text10 = "sCount";
			string value3 = "3";
			dictionary.Add(text10, value3);
			headersDict = dictionary;
			JsonConvert.SerializeObject(headersDict);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("");
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			string method = "POST";
			httpWebRequest.Method = method;
			byte[] bytes = Encoding.UTF8.GetBytes(body);
			httpWebRequest.ContentLength = bytes.Length;
			httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			result = streamReader.ReadToEnd();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			try
			{
				httpWebResponse?.Close();
			}
			catch
			{
			}
		}
		return result;
	}

	private string FetchUrl()
	{
		string text = "https://raw.githubusercontent.com/Secure-Data-Center/Access/refs/heads/main/apiLink.txt";
		string requestUriString = text;
		string text2 = "";
		int num = 0;
		while (true)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.ServerCertificateValidationCallback = CheckCertificate;
				string method = "GET";
				httpWebRequest.Method = method;
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				text2 = streamReader.ReadToEnd();
				text2 = DecryptAES(text2, key);
			}
			catch (Exception)
			{
				num++;
				if (num == 1)
				{
					string text3 = "https://s3.us-east-1.amazonaws.com/secure.storage/apiLink.txt";
					requestUriString = text3;
					continue;
				}
			}
			break;
		}
		string text4 = text2;
		string[] array = new string[1];
		string text5 = "|";
		array[0] = text5;
		string[] array2 = text4.Split(array, StringSplitOptions.None);
		switch (int.Parse(DecryptString(Program.batchNumber)))
		{
		default:
			return array2[10];
		case 0:
		case 1:
		case 2:
			return array2[0];
		case 3:
		case 4:
		case 5:
			return array2[1];
		case 6:
		case 7:
		case 8:
			return array2[2];
		case 9:
		case 10:
		case 11:
			return array2[3];
		case 12:
		case 13:
		case 14:
			return array2[4];
		case 15:
		case 16:
		case 17:
			return array2[5];
		case 18:
		case 19:
		case 20:
			return array2[6];
		case 21:
		case 22:
		case 23:
			return array2[7];
		case 24:
		case 25:
		case 26:
			return array2[8];
		case 27:
		case 28:
		case 29:
			return array2[9];
		}
	}

	public static string DecryptString(string cipherText)
	{
		string text = "NifgwXAR7zWCYoz";
		string password = text;
		string text2 = cipherText;
		string oldValue = " ";
		string newValue = "+";
		cipherText = text2.Replace(oldValue, newValue);
		byte[] array = Convert.FromBase64String(cipherText);
		using Aes aes = Aes.Create();
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		aes.Key = rfc2898DeriveBytes.GetBytes(32);
		aes.IV = rfc2898DeriveBytes.GetBytes(16);
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
		{
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.Close();
		}
		cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
		return cipherText;
	}

	public static string EncryptAES(string input, string symmetricKey)
	{
		try
		{
			byte[] array = GenerateAesKey(symmetricKey);
			byte[] iv = new byte[12];
			string algorithm = "AES/GCM/NoPadding";
			IBufferedCipher cipher = CipherUtilities.GetCipher(algorithm);
			cipher.Init(forEncryption: true, new ParametersWithIV(new KeyParameter(array), iv));
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(cipher.DoFinal(bytes));
		}
		catch (Exception ex)
		{
			string text = "Exception while encrypting data: ";
			return text + ex.Message;
		}
	}

	public static string DecryptAES(string encryptedInput, string symmetricKey)
	{
		try
		{
			byte[] array = GenerateAesKey(symmetricKey);
			byte[] iv = new byte[12];
			byte[] input = Convert.FromBase64String(encryptedInput);
			string algorithm = "AES/GCM/NoPadding";
			IBufferedCipher cipher = CipherUtilities.GetCipher(algorithm);
			cipher.Init(forEncryption: false, new ParametersWithIV(new KeyParameter(array), iv));
			byte[] bytes = cipher.DoFinal(input);
			return Encoding.UTF8.GetString(bytes);
		}
		catch (Exception ex)
		{
			string text = "Exception while decrypting data: ";
			return text + ex.Message;
		}
	}

	public static byte[] GenerateAesKey(string secretKey)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(secretKey);
		Sha256Digest sha256Digest = new Sha256Digest();
		sha256Digest.BlockUpdate(bytes, 0, bytes.Length);
		byte[] array = new byte[32];
		sha256Digest.DoFinal(array, 0);
		byte[] array2 = new byte[16];
		Array.Copy(array, array2, 16);
		return array2;
	}

	private static bool CheckCertificate(object object_18, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		bool result = true;
		try
		{
			int num;
			if (object_18 is HttpWebRequest httpWebRequest)
			{
				string text = httpWebRequest.Address.ToString().ToLower();
				string value = "irctc.co.in";
				num = (text.Contains(value) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (num != 0)
			{
				string issuer = x509Certificate_0.Issuer;
				string value2 = "CN=DigiCert";
				bool flag2 = issuer.StartsWith(value2);
				string issuer2 = x509Certificate_0.Issuer;
				string value3 = "CN=GeoTrust";
				bool flag3 = flag2 | issuer2.StartsWith(value3);
				string issuer3 = x509Certificate_0.Issuer;
				string value4 = "CN=GlobalSign";
				bool flag4 = flag3 | issuer3.StartsWith(value4);
				string issuer4 = x509Certificate_0.Issuer;
				string value5 = "CN=Amazon";
				flag = !(flag4 | issuer4.StartsWith(value5));
			}
			if (flag)
			{
				result = false;
			}
			string text2 = x509Certificate_0.Issuer.ToLower();
			string value6 = "httpanalyze";
			bool flag5 = text2.Contains(value6);
			string text3 = x509Certificate_0.Issuer.ToLower();
			string value7 = "fiddler";
			bool flag6 = flag5 | text3.Contains(value7);
			string text4 = x509Certificate_0.Issuer.ToLower();
			string value8 = "commview";
			bool flag7 = flag6 | text4.Contains(value8);
			string text5 = x509Certificate_0.Issuer.ToLower();
			string value9 = "debugger";
			bool flag8 = flag7 | text5.Contains(value9);
			string text6 = x509Certificate_0.Issuer.ToLower();
			string value10 = "debug";
			bool flag9 = flag8 | text6.Contains(value10);
			string text7 = x509Certificate_0.Issuer.ToLower();
			string value11 = "sniffer";
			bool flag10 = flag9 | text7.Contains(value11);
			string text8 = x509Certificate_0.Issuer.ToUpper();
			string value12 = "IEINSPECTOR";
			if (flag10 | text8.Contains(value12))
			{
				result = false;
			}
		}
		catch (Exception)
		{
			result = true;
		}
		return result;
	}
}
