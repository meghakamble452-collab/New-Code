using System;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace APP_FRAMEWORK;

public class FreechargeProcess
{
	public struct FreeChargeStruct
	{
		public string device_name;

		public string os_version;

		public string android_id;

		public string device_id;

		public string ipaddress;

		public string mobilenumber;

		public string email;

		public string userid;

		public string ownername;

		public string vpa;

		public string pin;

		public string csrfRequestIdentifier;

		public string fc_tv;

		public string string_customerbank;

		public string string_deviceInfo;

		public JObject customerbank;

		public JObject deviceInfoObject;

		public string Cookie_Token;

		public string npci_token;

		public string pub_key;

		public string ki_value;

		public string randomkey;

		public string secondrandom;
	}

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	public CookieContainer cookie;

	private readonly Random random_0 = new Random();

	private static RNGCryptoServiceProvider rngcryptoServiceProvider_0;

	private string string_4;

	private string otpid;

	private string string_6;

	private string fcversion = "134171";

	private string string_7 = "com.freecharge.upi";

	private string string_8 = "134171";

	private string string_9 = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtNqlJBV6JvIZqvcesc4QNH+geZikHeEYSizXzqm2O/O9M54BjNK5Q22RY7SZfwP3caUkECcW9vaXQ4ZIKOAplruXRxuVURT3hGiWyERHyrxqqWnavAdpvZbQLVjRFg2Kx/fr/vtx86+A9e8vAvI/JYrkPzuLJ8hXonrpl4akEL/PYbhz1e/djyVXaT/Vq++CYo+qZR0N8lfjf6hbbHkIA8g1odWjQRArVdbNl4eF0shcpLV+W4Dq8qBMTn3fohYMz3bGfduG4CG7i4Bwu1k6rrclZqIojvfOXH57VX0Fj8ER1JAtv5sFmXDXa3IHMBUOXJpXwkkZGQHfI1V7KCLG2QIDAQAB";

	private string string_10 = "R0xPQkFM";

	public FreeChargeStruct FR_DATA;

	private string string_11 = "";

	[CompilerGenerated]
	private string string_12;

	public static string freeChargeApiHeader;

	public string headers { get; private set; }

	[DllImport("kernel32.dll")]
	internal static extern void ExitProcess(uint uint_0);

	public string GetJsonValue(string json, string parameterName)
	{
		string text = "\"\\s*";
		string text2 = "\\s*\"\\s*:\\s*\"([^\"]*)\"";
		Match match = new Regex(text + parameterName + text2).Match(json);
		if (match.Success)
		{
			return match.Groups[1].Value;
		}
		return string.Empty;
	}

	public static string GetRandAesKeyAsHexString32Bytes(int ity)
	{
		byte[] array = new byte[ity];
		rngcryptoServiceProvider_0.GetBytes(array);
		return ToHexStringLowerCase(array);
	}

	public static string ToHexStringLowerCase(byte[] input)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			ref byte reference = ref input[i];
			string text = "x2";
			stringBuilder.Append(reference.ToString(text));
		}
		return stringBuilder.ToString();
	}

	public string GetAndroidID(int length = 16)
	{
		char[] array = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
		};
		string text = "";
		for (int i = 0; i < length; i++)
		{
			text += array[random_0.Next(16)];
		}
		return text;
	}

	public string GetGuid()
	{
		Guid guid = Guid.NewGuid();
		string text = "N";
		return guid.ToString(text);
	}

	public static string smethod_1(string input, string symmetricKey)
	{
		byte[] key = GenerateAesKey(symmetricKey);
		byte[] iv = new byte[12];
		string algorithm = "AES/GCM/NoPadding";
		IBufferedCipher cipher = CipherUtilities.GetCipher(algorithm);
		cipher.Init(forEncryption: true, new ParametersWithIV(new KeyParameter(key), iv));
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		return Convert.ToBase64String(cipher.DoFinal(bytes));
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

	public static string smethod_2(string input, string base64PublicKey)
	{
		try
		{
			if (!(PublicKeyFactory.CreateKey(Convert.FromBase64String(base64PublicKey)) is RsaKeyParameters parameters))
			{
				string message = "The provided public key is not an RSA key.";
				throw new InvalidOperationException(message);
			}
			Pkcs1Encoding pkcs1Encoding = new Pkcs1Encoding(new RsaEngine());
			((IAsymmetricBlockCipher)pkcs1Encoding).Init(forEncryption: true, (ICipherParameters)parameters);
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(((IAsymmetricBlockCipher)pkcs1Encoding).ProcessBlock(bytes, 0, bytes.Length));
		}
		catch (Exception ex)
		{
			string text = "Exception while encrypting data: ";
			return text + ex.Message;
		}
	}

	public string LoginOtp(string phoneNumber)
	{
		FR_DATA.mobilenumber = phoneNumber;
		string text = "Samsung Galaxy S21,Samsung Galaxy S22,Samsung Galaxy Note20,Samsung Galaxy Z Fold3,Samsung Galaxy Z Flip3,Samsung Galaxy A52,Samsung Galaxy A72,Samsung Galaxy M32,Samsung Galaxy M42,Samsung Galaxy F62,Huawei P40,Huawei P40 Pro,Huawei Mate 40,Huawei Mate 40 Pro,Huawei Nova 7,Huawei Nova 7 SE,Huawei Y9a,Huawei P Smart 2021,Huawei Mate X2,Huawei P30,Xiaomi Mi 11,Xiaomi Mi 11 Ultra,Xiaomi Redmi Note 10,Xiaomi Redmi Note 10 Pro,Xiaomi Poco X3 NFC,Xiaomi Poco F3,Xiaomi Mi 10T,Xiaomi Mi 10T Pro,Xiaomi Redmi 9,Xiaomi Redmi 9A,OnePlus 9,OnePlus 9 Pro,OnePlus 8T,OnePlus Nord,OnePlus Nord N10,OnePlus 7T,OnePlus 7T Pro,OnePlus 6T,OnePlus 5T,OnePlus 3T,Oppo Find X3,Oppo Find X3 Pro,Oppo Reno5,Oppo Reno5 Pro,Oppo A54,Oppo A74,Oppo F19,Oppo F19 Pro,Oppo A15,Oppo A15s,Vivo X60,Vivo X60 Pro,Vivo V21,Vivo V21e,Vivo Y72,Vivo Y20,Vivo S1,Vivo S1 Pro,Vivo Y11,Vivo Y12,Realme GT,Realme GT Master Edition,Realme 8,Realme 8 Pro,Realme C25,Realme C21,Realme Narzo 30,Realme Narzo 30A,Realme X7,Realme X7 Pro,Motorola Edge S,Motorola Edge Plus,Motorola G100,Motorola G30,Motorola G10,Motorola E7,Motorola E7 Plus,Motorola One Fusion,Motorola One Fusion Plus,Motorola Razr 5G,Google Pixel 5,Google Pixel 4a,Google Pixel 4a 5G,Google Pixel 3a,Google Pixel 3a XL,Google Pixel 2,Google Pixel 2 XL,Sony Xperia 1 II,Sony Xperia 5 II,Sony Xperia 10 II,Sony Xperia L4,Sony Xperia XZ3,Sony Xperia XZ2,Sony Xperia XZ1,Sony Xperia XA";
		string[] array = text.Split(',');
		string text2 = "26,27,28,29,30";
		string[] array2 = text2.Split(',');
		ref FreeChargeStruct fR_DATA = ref FR_DATA;
		string format = "192.168.0.{0}";
		fR_DATA.ipaddress = string.Format(format, random_0.Next(255));
		FR_DATA.device_name = array[random_0.Next(array.Length)];
		FR_DATA.os_version = array2[random_0.Next(array2.Length)];
		FR_DATA.device_id = GetGuid();
		FR_DATA.android_id = GetAndroidID();
		string text3 = "https://tracker.freechargebiz.in/api/v2/tracker/getVisitId?fcAppType=ios&fcChannel=5&fcversion=";
		string text4 = fcversion;
		string text5 = "&fcAppType=ios&fcChannel=5&fcversion=";
		string_0 = text3 + text4 + text5 + fcversion;
		method_0(string_0, "", ref string_4, ref this.cookie, ref string_3, headers);
		string text6 = "";
		string text7 = "";
		string format2 = "http://{0}/";
		string arg = "tracker.freechargebiz.in";
		Uri uri = new Uri(string.Format(format2, arg));
		foreach (Cookie cookie in this.cookie.GetCookies(uri))
		{
			string format3 = "Name = {0} ; Value = {1} ; Domain = {2}";
			Console.WriteLine(format3, cookie.Name, cookie.Value, cookie.Domain);
			string name = cookie.Name;
			string text8 = "fc.tc3";
			if (name == text8)
			{
				text6 = cookie.Value;
				continue;
			}
			string name2 = cookie.Name;
			string text9 = "fc.tv";
			if (name2 == text9)
			{
				text7 = cookie.Value;
			}
		}
		string text10 = "https://mobile-rest.freechargebiz.in/api/ims/rest/create/csrf?fcAppType=ios&fcChannel=5&fcversion=";
		string_0 = text10 + fcversion;
		method_0(string_0, "", ref string_4, ref this.cookie, ref string_3, headers);
		ref FreeChargeStruct fR_DATA2 = ref FR_DATA;
		string input = string_4;
		string pattern = "\"csrfRequestIdentifier\":\"(.*?)\"";
		fR_DATA2.csrfRequestIdentifier = Regex.Match(input, pattern).Groups[1].Value;
		if (!string.IsNullOrEmpty(FR_DATA.csrfRequestIdentifier))
		{
			string text11 = "https://mobile-rest.freechargebiz.in/api/ems/nosession/v2/external/encryption/generatekeys?fcAppType=ios&fcChannel=5&fcversion=";
			string_0 = text11 + fcversion;
			string text12 = "csrfRequestIdentifier#";
			headers = text12 + FR_DATA.csrfRequestIdentifier;
			string string_ = string_0;
			string string_2 = "{}";
			method_0(string_, string_2, ref string_4, ref this.cookie, ref string_3, headers);
			string text13 = string_4;
			string value = "key";
			if (text13.Contains(value))
			{
				string input2 = string_4;
				string pattern2 = "\"key\":\"(.*?)\"";
				string[] array3 = Regex.Match(input2, pattern2).Groups[1].Value.Split('|');
				if (array3.Length > 1)
				{
					string_9 = array3[0];
					FR_DATA.pub_key = string_9;
					string_10 = array3[1];
				}
			}
			string randAesKeyAsHexString32Bytes = GetRandAesKeyAsHexString32Bytes(32);
			string text14 = smethod_1(phoneNumber, randAesKeyAsHexString32Bytes);
			Encoding uTF = Encoding.UTF8;
			string text15 = "FREECHARGE_V2|";
			text14 = Convert.ToBase64String(uTF.GetBytes(text15 + text14));
			string text16 = smethod_2(randAesKeyAsHexString32Bytes, FR_DATA.pub_key);
			Encoding uTF2 = Encoding.UTF8;
			string text17 = "FREECHARGE_V2|";
			text16 = Convert.ToBase64String(uTF2.GetBytes(text17 + text16));
			string[] array4 = new string[8];
			string text18 = "csrfRequestIdentifier#";
			array4[0] = text18;
			array4[1] = FR_DATA.csrfRequestIdentifier;
			string text19 = "&cske#";
			array4[2] = text19;
			array4[3] = text16;
			string text20 = "&pke#";
			array4[4] = text20;
			array4[5] = string_9;
			string text21 = "|";
			array4[6] = text21;
			array4[7] = string_10;
			headers = string.Concat(array4);
			string[] array5 = new string[17];
			string text22 = "{\"mobileNumber\":\"";
			array5[0] = text22;
			array5[1] = text14;
			string text23 = "\",\"fcChannel\":\"3\",\"platformType\":\"IOS\",\"assignedClientId\":\"";
			array5[2] = text23;
			array5[3] = text6;
			string text24 = "\",\"visitId\":\"";
			array5[4] = text24;
			array5[5] = text7;
			string text25 = "\",\"publicDevice\":false,\"osVersion\":\"";
			array5[6] = text25;
			array5[7] = FR_DATA.os_version;
			string text26 = "\",\"oemDeviceId\":\"";
			array5[8] = text26;
			array5[9] = FR_DATA.device_id;
			string text27 = "\",\"userAgent\":\"\",\"clientIp\":\"\",\"appVersion\":\"";
			array5[10] = text27;
			array5[11] = string_8;
			string text28 = "\",\"deviceName\":\"";
			array5[12] = text28;
			array5[13] = FR_DATA.device_name;
			string text29 = "\",\"lanIp\":\"";
			array5[14] = text29;
			array5[15] = FR_DATA.ipaddress;
			string text30 = "\"}";
			array5[16] = text30;
			string_1 = string.Concat(array5);
			string text31 = "https://mobile-rest.freechargebiz.in/api/ims/rest/otp/send/login/signup?fcAppType=ios&fcChannel=5&fcversion=";
			string_0 = text31 + fcversion;
			method_0(string_0, string_1, ref string_4, ref this.cookie, ref string_3, headers);
			string input3 = string_4;
			string pattern3 = "\"otpId\":\"(.*?)\"";
			otpid = Regex.Match(input3, pattern3).Groups[1].Value;
			if (string.IsNullOrEmpty(otpid))
			{
				string json = string_4;
				string parameterName = "errorMessage";
				string jsonValue = GetJsonValue(json, parameterName);
				if (!string.IsNullOrEmpty(jsonValue))
				{
					return jsonValue;
				}
				return "Failed send otp, try again";
			}
			return otpid;
		}
		return "Try again after sometime";
	}

	public string LoginVerifyOtp(string otp)
	{
		try
		{
			string text = smethod_2(GetRandAesKeyAsHexString32Bytes(32), FR_DATA.pub_key);
			Encoding uTF = Encoding.UTF8;
			string text2 = "FREECHARGE_V2|";
			string text3 = Convert.ToBase64String(uTF.GetBytes(text2 + text));
			string pub_key = FR_DATA.pub_key;
			string text4 = "|R0xPQkFM";
			string text5 = pub_key + text4;
			string[] array = new string[6];
			string text6 = "csrfRequestIdentifier#";
			array[0] = text6;
			array[1] = FR_DATA.csrfRequestIdentifier;
			string text7 = "&pke#";
			array[2] = text7;
			array[3] = text5;
			string text8 = "&cske#";
			array[4] = text8;
			array[5] = text3;
			headers = string.Concat(array);
			string[] array2 = new string[9];
			string text9 = "{\"platformType\":\"iOS\",\"osVersion\":\"26.3\",\"deviceName\":\"iPhone iPhone\",\"fcChannel\":\"15\",\"lanIp\":\"bfe5:bfe5:bfe5:bfe5:bfe5:bfe5:bfe5:bfe5\",\"publicDevice\":false,\"appVersion\":\"134169\",\"visitId\":\"\",\"twoFA\":\"true\",\"oemDeviceId\":\"";
			array2[0] = text9;
			array2[1] = FR_DATA.device_id;
			string text10 = "\",\"otpId\":\"";
			array2[2] = text10;
			array2[3] = otpid;
			string text11 = "\",\"assignedClientId\":\"";
			array2[4] = text11;
			array2[5] = FR_DATA.device_id;
			string text12 = "\",\"increaseTokenSession\":true,\"otp\":\"";
			array2[6] = text12;
			array2[7] = otp;
			string text13 = "\"}";
			array2[8] = text13;
			string_1 = string.Concat(array2);
			string text14 = "https://mobile-rest.freechargebiz.in/api/ims/rest/mobileOnly/verify?fcAppType=ios&fcChannel=5&fcversion=";
			string_0 = text14 + fcversion;
			if (cookie == null)
			{
				cookie = new CookieContainer();
			}
			string uriString = "https://mobile-rest.freechargebiz.in";
			Uri uri = new Uri(uriString);
			CookieContainer cookieContainer = cookie;
			string name = "fc.tc3";
			cookieContainer.Add(uri, new Cookie(name, FR_DATA.device_id));
			method_0(string_0, string_1, ref string_4, ref cookie, ref string_3, headers);
			string text15 = string_4;
			string value = "userId";
			if (text15.Contains(value))
			{
				ref FreeChargeStruct fR_DATA = ref FR_DATA;
				string json = string_4;
				string parameterName = "userId";
				fR_DATA.userid = GetJsonValue(json, parameterName);
				ref FreeChargeStruct fR_DATA2 = ref FR_DATA;
				string json2 = string_4;
				string parameterName2 = "email";
				fR_DATA2.email = GetJsonValue(json2, parameterName2);
				if (string.IsNullOrEmpty(FR_DATA.email))
				{
					ref FreeChargeStruct fR_DATA3 = ref FR_DATA;
					string prompt = "Please Enter Your Email Id";
					fR_DATA3.email = Interaction.InputBox(prompt);
				}
				ref FreeChargeStruct fR_DATA4 = ref FR_DATA;
				string json3 = string_4;
				string parameterName3 = "firstName";
				fR_DATA4.ownername = GetJsonValue(json3, parameterName3);
				ref FreeChargeStruct fR_DATA5 = ref FR_DATA;
				string json4 = string_4;
				string parameterName4 = "fcWalletToken";
				fR_DATA5.Cookie_Token = GetJsonValue(json4, parameterName4);
				JObject jObject = new JObject();
				string propertyName = "app";
				jObject.Add(propertyName, string_7);
				string propertyName2 = "capability";
				jObject.Add(propertyName2, FR_DATA.mobilenumber);
				string propertyName3 = "id";
				jObject.Add(propertyName3, FR_DATA.device_id);
				string propertyName4 = "ip";
				string text16 = "192.168.0.66";
				jObject.Add(propertyName4, text16);
				string propertyName5 = "mobile";
				string text17 = "91";
				jObject.Add(propertyName5, text17 + FR_DATA.mobilenumber);
				string propertyName6 = "os";
				string text18 = "ios";
				jObject.Add(propertyName6, text18);
				string propertyName7 = "type";
				string text19 = "MOB";
				jObject.Add(propertyName7, text19);
				JObject deviceInfoObject = jObject;
				FR_DATA.deviceInfoObject = deviceInfoObject;
				return "success";
			}
			string input = string_4;
			string pattern = "\"errorMessage\":\"(.*?)\"";
			string value2 = Regex.Match(input, pattern).Groups[1].Value;
			if (string.IsNullOrEmpty(value2))
			{
				string text20 = "Invalid otp or Server Error: ";
				return text20 + string_4;
			}
			return value2;
		}
		catch (Exception ex)
		{
			string text21 = "Exception: ";
			return text21 + ex.Message;
		}
	}

	public string CheckDeviceStatus()
	{
		try
		{
			string text = smethod_2(GetRandAesKeyAsHexString32Bytes(32), FR_DATA.pub_key);
			Encoding uTF = Encoding.UTF8;
			string text2 = "FREECHARGE_V2|";
			string text3 = Convert.ToBase64String(uTF.GetBytes(text2 + text));
			string pub_key = FR_DATA.pub_key;
			string text4 = "|R0xPQkFM";
			string text5 = pub_key + text4;
			string cookie_Token = FR_DATA.Cookie_Token;
			string[] array = new string[8];
			string text6 = "csrfRequestIdentifier#";
			array[0] = text6;
			array[1] = FR_DATA.csrfRequestIdentifier;
			string text7 = "&token#";
			array[2] = text7;
			array[3] = cookie_Token;
			string text8 = "&pke#";
			array[4] = text8;
			array[5] = text5;
			string text9 = "&cske#";
			array[6] = text9;
			array[7] = text3;
			headers = string.Concat(array);
			string text10 = "{\"device\":{\"id\":\"";
			string device_id = FR_DATA.device_id;
			string text11 = "\",\"capability\":null,\"type\":\"MOB\",\"os\":\"ios\",\"deviceName\":\"iPhone17,2\",\"ip\":\"192.168.0.66\",\"app\":\"com.freecharge.upi\",\"mobile\":null,\"osVersion\":\"26.3\"}}";
			string_1 = text10 + device_id + text11;
			string text12 = "https://mobile-rest.freechargebiz.in/rest/upi/v2/upistatus?fcAppType=ios&fcChannel=5&fcversion=";
			string_0 = text12 + fcversion;
			if (cookie == null)
			{
				cookie = new CookieContainer();
			}
			string uriString = "https://mobile-rest.freechargebiz.in";
			Uri uri = new Uri(uriString);
			CookieContainer cookieContainer = cookie;
			string name = "fc.tc3";
			cookieContainer.Add(uri, new Cookie(name, FR_DATA.device_id));
			method_0(string_0, string_1, ref string_2, ref cookie, ref string_3, headers);
			string json = string_2;
			string parameterName = "registrationStatus";
			return GetJsonValue(json, parameterName);
		}
		catch (Exception)
		{
			return "PENDING";
		}
	}

	public string BindDevice()
	{
		JObject jObject = new JObject();
		string propertyName = "deviceInfo";
		jObject.Add(propertyName, FR_DATA.deviceInfoObject);
		JObject jObject2 = jObject;
		string_1 = jObject2.ToString();
		string text = "https://mobile-rest.freechargebiz.in/rest/upi/v1/updateDeviceBindingAttempt?fcAppType=ios&fcChannel=5&fcversion=";
		string_0 = text + fcversion;
		string text2 = "csrfRequestIdentifier#";
		headers = text2 + FR_DATA.csrfRequestIdentifier;
		method_0(string_0, string_1, ref string_4, ref cookie, ref string_3, headers);
		string text3 = string_4.ToLower();
		string value = "success";
		if (text3.Contains(value))
		{
			return "success";
		}
		return "Device binding failed retry";
	}

	public string DeviceOtp()
	{
		string text = "csrfRequestIdentifier#";
		headers = text + FR_DATA.csrfRequestIdentifier;
		string[] array = new string[5];
		string text2 = "{\"emailId\":\"";
		array[0] = text2;
		array[1] = FR_DATA.email;
		string text3 = "\",\"mobile\":\"";
		array[2] = text3;
		array[3] = FR_DATA.mobilenumber;
		string text4 = "\"}";
		array[4] = text4;
		string_1 = string.Concat(array);
		string text5 = "https://mobile-rest.freechargebiz.in/rest/upi/session/v1/otp/generate?fcAppType=ios&fcChannel=5&fcversion=";
		string_0 = text5 + fcversion;
		method_0(string_0, string_1, ref string_4, ref cookie, ref string_3, headers);
		string input = string_4;
		string pattern = "\"otpId\":\"(.*?)\"";
		otpid = Regex.Match(input, pattern).Groups[1].Value;
		if (string.IsNullOrEmpty(otpid))
		{
			string json = string_4;
			string parameterName = "errorMessage";
			string jsonValue = GetJsonValue(json, parameterName);
			if (string.IsNullOrEmpty(jsonValue))
			{
				return "Failed send otp, try again";
			}
			return jsonValue;
		}
		return otpid;
	}

	public string DeviceVerifyOtp(string otp)
	{
		string text = "csrfRequestIdentifier#";
		headers = text + FR_DATA.csrfRequestIdentifier;
		string[] array = new string[7];
		string text2 = "{\"otpId\":\"";
		array[0] = text2;
		array[1] = otpid;
		string text3 = "\",\"otp\":\"";
		array[2] = text3;
		array[3] = otp;
		string text4 = "\",\"mobile\":\"";
		array[4] = text4;
		array[5] = FR_DATA.mobilenumber;
		string text5 = "\"}";
		array[6] = text5;
		string_1 = string.Concat(array);
		string text6 = "https://mobile-rest.freechargebiz.in/rest/upi/session/v1/otp/verify?fcAppType=ios&fcChannel=5&fcversion=";
		string_0 = text6 + fcversion;
		method_0(string_0, string_1, ref string_4, ref cookie, ref string_3, headers);
		string text7 = string_4.ToLower();
		string value = "success";
		if (!text7.Contains(value))
		{
			return "Device Verify failed retry";
		}
		return "success";
	}

	private bool method_0(string string_13, string string_14, ref string string_15, ref CookieContainer cookieContainer_0, ref string string_16, string string_17)
	{
		string_15 = string.Empty;
		string_16 = string.Empty;
		bool result = false;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_13);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			ServicePointManager.DefaultConnectionLimit = int.MaxValue;
			ServicePointManager.Expect100Continue = false;
			if (cookieContainer_0 == null)
			{
				cookieContainer_0 = new CookieContainer();
			}
			httpWebRequest.CookieContainer = cookieContainer_0;
			string accept = "application/json";
			httpWebRequest.Accept = accept;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			string referer = "https://mobile-rest.freechargebiz.in";
			httpWebRequest.Referer = referer;
			string userAgent = "FreeCharge/134171 CFNetwork/3860.400.1 Darwin/25.3.0";
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection webHeaderCollection = httpWebRequest.Headers;
			string name = "Accept-Language";
			string value = "en-IN,en;q=0.9";
			webHeaderCollection.Add(name, value);
			WebHeaderCollection webHeaderCollection2 = httpWebRequest.Headers;
			string name2 = "userAgent";
			string value2 = "ios";
			webHeaderCollection2.Add(name2, value2);
			WebHeaderCollection webHeaderCollection3 = httpWebRequest.Headers;
			string name3 = "userMachineIdentifier";
			string value3 = "ios";
			webHeaderCollection3.Add(name3, value3);
			httpWebRequest.AllowAutoRedirect = false;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = 55000;
			httpWebRequest.ReadWriteTimeout = 55000;
			if (!string.IsNullOrEmpty(string_17))
			{
				string delimiter = "&";
				string[] array = Strings.Split(string_17, delimiter);
				int num = Information.UBound(array);
				for (int i = 0; i <= num; i++)
				{
					string expression = array[i];
					string delimiter2 = "#";
					string[] array2 = Strings.Split(expression, delimiter2);
					httpWebRequest.Headers.Add(array2[0], array2[1]);
				}
			}
			if (!string.IsNullOrEmpty(string_14))
			{
				string method = "POST";
				httpWebRequest.Method = method;
				using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
				streamWriter.Write(string_14);
			}
			else
			{
				string method2 = "GET";
				httpWebRequest.Method = method2;
			}
			using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
			{
				string_15 = streamReader.ReadToEnd();
			}
			result = true;
		}
		catch (Exception ex)
		{
			string_16 = ex.Message;
		}
		return result;
	}

	private static bool smethod_0(object object_0, X509Certificate x509Certificate_0, object object_1, SslPolicyErrors sslPolicyErrors_0)
	{
		try
		{
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public void Table_Write_Save_RegisInfo(string val)
	{
		string[] array = new string[5];
		string text = "INSERT INTO TBL_FREECHARGE(MobNo, RegiInfo, TimeStamp) VALUES ('";
		array[0] = text;
		array[1] = FR_DATA.mobilenumber;
		string text2 = "', '";
		string text3 = "', '";
		array[2] = text2 + val + text3;
		DateTime now = DateTime.Now;
		string text4 = "dd/M/yyyy hh:mm:ss.fff tt";
		array[3] = now.ToString(text4);
		string text5 = "')";
		array[4] = text5;
		string string_ = string.Concat(array);
		method_1(string_);
	}

	private void method_1(string string_13)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteCommand.CommandText = string_13;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
		}
		catch
		{
		}
	}

	static FreechargeProcess()
	{
		string text = "FREECHARGE_V2";
		freeChargeApiHeader = text;
		rngcryptoServiceProvider_0 = new RNGCryptoServiceProvider();
	}
}
