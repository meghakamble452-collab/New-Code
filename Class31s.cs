using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

internal class Class31s
{
	private class Class32
	{
		private string string_0 = "";

		private string string_1 = "";

		private AsymmetricCipherKeyPair asymmetricCipherKeyPair_0;

		public Class32()
		{
			RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
			rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
			AsymmetricCipherKeyPair asymmetricCipherKeyPair = rsaKeyPairGenerator.GenerateKeyPair();
			string_1 = Convert.ToBase64String(PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricCipherKeyPair.Private).ToAsn1Object().GetDerEncoded());
			string_0 = Convert.ToBase64String(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(asymmetricCipherKeyPair.Public).ToAsn1Object().GetDerEncoded());
			asymmetricCipherKeyPair_0 = asymmetricCipherKeyPair;
		}

		public string method_0(string string_2, string string_3, ref string string_4)
		{
			string_2 = string_2.Replace(string_4, string_0);
			string_2 = string_2.ToLower();
			string pattern = "[^\\x00-\\x7F]|[\\p{Cc}&&[^\n\t]]|\\p{C}|\\s+";
			string_2 = new Regex(pattern, RegexOptions.None).Replace(string_2, string.Empty);
			string result = method_1(string_2, asymmetricCipherKeyPair_0.Private);
			Sha256Digest sha256Digest = new Sha256Digest();
			byte[] bytes = Encoding.UTF8.GetBytes(string_2);
			sha256Digest.BlockUpdate(bytes, 0, bytes.Length);
			RsaDigestSigner rsaDigestSigner = new RsaDigestSigner(sha256Digest);
			rsaDigestSigner.Init(forSigning: true, asymmetricCipherKeyPair_0.Private);
			Convert.ToBase64String(rsaDigestSigner.GenerateSignature());
			string_3 = string_1;
			string_4 = string_0;
			return result;
		}

		public string method_1(string string_2, AsymmetricKeyParameter asymmetricKeyParameter_0)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(string_2);
				string algorithm = "SHA-256withRSA";
				ISigner signer = SignerUtilities.GetSigner(algorithm);
				signer.Init(forSigning: true, asymmetricKeyParameter_0);
				signer.BlockUpdate(bytes, 0, bytes.Length);
				return Convert.ToBase64String(signer.GenerateSignature());
			}
			catch (Exception ex)
			{
				string text = "Signing Failed: ";
				Console.WriteLine(text + ex.ToString());
				return null;
			}
		}
	}

	internal string string_0;

	internal string string_1;

	internal string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private string string_11;

	private string string_12;

	private bool bool_0;

	private string string_13;

	internal string string_14 = "okhttp/3.12.1";

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private CookieContainer cookieContainer_0;

	private Dictionary<string, string> dictionary_0;

	internal string string_15;

	internal string string_16;

	internal string string_17;

	internal string string_18;

	internal string string_19;

	internal string string_20;

	internal string string_21;

	internal string string_22;

	internal string string_23;

	internal string string_24;

	internal string string_25;

	internal string string_26;

	internal string string_27;

	private string string_28;

	internal string method_0(string string_29)
	{
		string result = "";
		string[] array = new string[1];
		string text = "||";
		array[0] = text;
		string[] array2 = string_29.Split(array, StringSplitOptions.RemoveEmptyEntries);
		string_4 = array2[1];
		string_12 = array2[2];
		WebProxy webProxy_ = null;
		string text2 = "samsung";
		string_21 = text2;
		string text3 = "SM-J320F";
		string_22 = text3;
		string text4 = "samsung-SM-J320F-860d588d64558aa";
		string_19 = text4;
		string_19 = smethod_0(ref string_21, ref string_22);
		string text5 = string_19;
		string[] array3 = new string[1];
		string text6 = "-";
		array3[0] = text6;
		string[] array4 = text5.Split(array3, StringSplitOptions.None);
		string_1 = array4[0];
		string_2 = array4[1];
		string_0 = array4[2];
		string text7 = "8.14.0";
		string_23 = text7;
		string text8 = "5.1.1";
		string_24 = text8;
		string_25 = "";
		string_3 = string_4;
		long num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
		num /= 1000;
		int num2 = 1;
		string text9 = "860d588d64558aa:1602774768259:16:16";
		string_5 = text9;
		string[] array5 = new string[7] { string_0, null, null, null, null, null, null };
		string text10 = ":";
		array5[1] = text10;
		array5[2] = num.ToString();
		string text11 = ":";
		array5[3] = text11;
		array5[4] = num2.ToString();
		string text12 = ":";
		array5[5] = text12;
		array5[6] = num2.ToString();
		string_5 = string.Concat(array5);
		string text13 = "89300500203268030312";
		string_6 = text13;
		string text14 = "Basic bWFya2V0LWFwcDo5YTA3MTc2Mi1hNDk5LTRiZDktOTE0YS00MzYxZTdjM2Y0YmM=";
		string_7 = text14;
		DateTimeOffset.Now.ToUnixTimeSeconds();
		double totalSeconds = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		string text15 = "1602774768";
		string_8 = text15;
		string_8 = totalSeconds.ToString();
		string string_30 = "";
		string[] array6 = new string[18];
		string text16 = "x-phone-number#";
		array6[0] = text16;
		array6[1] = string_3;
		string text17 = "||x-app-rid#";
		array6[2] = text17;
		array6[3] = string_5;
		string text18 = "||x-device-name#";
		array6[4] = text18;
		array6[5] = string_22;
		string text19 = "||x-app-version#";
		array6[6] = text19;
		array6[7] = string_23;
		string text20 = "||x-device-manufacturer#";
		array6[8] = text20;
		array6[9] = string_21;
		string text21 = "||x-iccid#";
		array6[10] = text21;
		array6[11] = string_6;
		string text22 = "||x-device-identifier#";
		array6[12] = text22;
		array6[13] = string_19;
		string text23 = "||x-epoch#";
		array6[14] = text23;
		array6[15] = string_8;
		string text24 = "||Authorization#";
		array6[16] = text24;
		array6[17] = string_7;
		string_9 = string.Concat(array6);
		string[] array7 = new string[11];
		string text25 = "https://accounts.paytm.com/devicebinding/config/sv1?deviceIdentifier=";
		array7[0] = text25;
		array7[1] = string_19;
		string text26 = "&deviceManufacturer=";
		array7[2] = text26;
		array7[3] = string_21;
		string text27 = "&deviceName=";
		array7[4] = text27;
		array7[5] = string_22;
		string text28 = "&client=androidapp&version=";
		array7[6] = text28;
		array7[7] = string_23;
		string text29 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
		array7[8] = text29;
		array7[9] = string_24;
		string text30 = "&locale=en-IN&flow=LOGIN_REGISTER";
		array7[10] = text30;
		string string_31 = string.Concat(array7);
		string string_32 = "";
		if (!method_1(string_31, string_32, string_30, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_10, ref string_28))
		{
			string text31 = "PAYTM Registration Failed-2";
			MessageBox.Show(text31);
			return result;
		}
		string text32 = string_10;
		string value = "NO_MAPPING_FOUND";
		if (text32.IndexOf(value) >= 0)
		{
			Class32 @class = new Class32();
			num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			num /= 1000;
			num2++;
			string[] array8 = new string[7] { string_0, null, null, null, null, null, null };
			string text33 = ":";
			array8[1] = text33;
			array8[2] = num.ToString();
			string text34 = ":";
			array8[3] = text34;
			array8[4] = num2.ToString();
			string text35 = ":";
			array8[5] = text35;
			array8[6] = num2.ToString();
			string_5 = string.Concat(array8);
			string_8 = num.ToString();
			string_30 = "";
			string[] array9 = new string[11];
			string text36 = "https://accounts.paytm.com/v2/simple/login/init/sv1?deviceIdentifier=";
			array9[0] = text36;
			array9[1] = string_19;
			string text37 = "&deviceManufacturer=";
			array9[2] = text37;
			array9[3] = string_21;
			string text38 = "&deviceName=";
			array9[4] = text38;
			array9[5] = string_22;
			string text39 = "&client=androidapp&version=";
			array9[6] = text39;
			array9[7] = string_23;
			string text40 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
			array9[8] = text40;
			array9[9] = string_24;
			string text41 = "&locale=en-IN";
			array9[10] = text41;
			string_31 = string.Concat(array9);
			string text42 = "{\"loginId\":\"";
			string text43 = string_4;
			string text44 = "\"}";
			string_32 = text42 + text43 + text44;
			string text45 = "java_rsa_256hmac";
			string_26 = text45;
			string[] array10 = new string[24];
			string text46 = "/v2/simple/login/init/sv1|post|client=androidapp&deviceidentifier=";
			array10[0] = text46;
			array10[1] = string_19;
			string text47 = "&devicemanufacturer=";
			array10[2] = text47;
			array10[3] = string_21;
			string text48 = "&devicename=";
			array10[4] = text48;
			array10[5] = string_22;
			string text49 = "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=";
			array10[6] = text49;
			array10[7] = string_24;
			string text50 = "&playstore=false&version=";
			array10[8] = text50;
			array10[9] = string_23;
			string text51 = "|authorization=";
			array10[10] = text51;
			array10[11] = string_7;
			string text52 = "&autoreadhash=asask/gtt2i&x-device-identifier=";
			array10[12] = text52;
			array10[13] = string_19;
			string text53 = "&x-device-manufacturer=";
			array10[14] = text53;
			array10[15] = string_21;
			string text54 = "&x-device-name=";
			array10[16] = text54;
			array10[17] = string_22.ToLower();
			string text55 = "&x-epoch=";
			array10[18] = text55;
			array10[19] = string_8;
			string text56 = "&x-public-key=";
			array10[20] = text56;
			array10[21] = string_26;
			string text57 = "|";
			array10[22] = text57;
			array10[23] = string_32;
			string text58 = string.Concat(array10);
			string_27 = @class.method_0(text58, "", ref string_26);
			string[] array11 = new string[18];
			string text59 = "x-client-signature#";
			array11[0] = text59;
			array11[1] = string_27;
			string text60 = "||autoReadHash#asasK/GTt2i||x-app-rid#";
			array11[2] = text60;
			array11[3] = string_5;
			string text61 = "||x-device-name#";
			array11[4] = text61;
			array11[5] = string_22;
			string text62 = "||x-app-version#";
			array11[6] = text62;
			array11[7] = string_23;
			string text63 = "||x-device-manufacturer#";
			array11[8] = text63;
			array11[9] = string_21;
			string text64 = "||x-public-key#";
			array11[10] = text64;
			array11[11] = string_26;
			string text65 = "||x-device-identifier#";
			array11[12] = text65;
			array11[13] = string_19;
			string text66 = "||x-epoch#";
			array11[14] = text66;
			array11[15] = string_8;
			string text67 = "||Authorization#";
			array11[16] = text67;
			array11[17] = string_7;
			string_9 = string.Concat(array11);
			if (!method_1(string_31, string_32, string_30, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_10, ref string_28))
			{
				string text68 = "PAYTM Registration Failed-2";
				MessageBox.Show(text68);
				return result;
			}
			string text69 = string_10;
			string value2 = "Please enter OTP to continue login";
			if (text69.IndexOf(value2) <= 0)
			{
				string text70 = string_10;
				string value3 = "Please enter password to continue.";
				if (text70.IndexOf(value3) < 0)
				{
					string text71 = "Some Thing Worng With PAYTM Registration Failed-1";
					MessageBox.Show(text71);
					return result;
				}
				string text72 = string_10;
				string text73 = string_10;
				string value4 = "stateToken";
				string text74 = text72.Substring(text73.IndexOf(value4) + 13);
				string value5 = "\",";
				string_11 = text74.Substring(0, text74.IndexOf(value5));
				num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
				num /= 1000;
				num2++;
				string[] array12 = new string[7] { string_0, null, null, null, null, null, null };
				string text75 = ":";
				array12[1] = text75;
				array12[2] = num.ToString();
				string text76 = ":";
				array12[3] = text76;
				array12[4] = num2.ToString();
				string text77 = ":";
				array12[5] = text77;
				array12[6] = num2.ToString();
				string_5 = string.Concat(array12);
				string_8 = num.ToString();
				string_30 = "";
				string[] array13 = new string[11];
				string text78 = "https://accounts.paytm.com/v2/simple/login/validate/password/sv1?deviceIdentifier=";
				array13[0] = text78;
				array13[1] = string_19;
				string text79 = "&deviceManufacturer=";
				array13[2] = text79;
				array13[3] = string_21;
				string text80 = "&deviceName=";
				array13[4] = text80;
				array13[5] = string_22;
				string text81 = "&client=androidapp&version=";
				array13[6] = text81;
				array13[7] = string_23;
				string text82 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
				array13[8] = text82;
				array13[9] = string_24;
				string text83 = "&locale=en-IN";
				array13[10] = text83;
				string_31 = string.Concat(array13);
				string[] array14 = new string[5];
				string text84 = "{\"password\":\"";
				array14[0] = text84;
				array14[1] = string_12;
				string text85 = "\",\"stateToken\":\"";
				array14[2] = text85;
				array14[3] = string_11;
				string text86 = "\"}";
				array14[4] = text86;
				string_32 = string.Concat(array14);
				string text87 = "java_rsa_256hmac";
				string_26 = text87;
				string[] array15 = new string[22];
				string text88 = "/v2/simple/login/validate/password/sv1|post|client=androidapp&deviceidentifier=";
				array15[0] = text88;
				array15[1] = string_19;
				string text89 = "&devicemanufacturer=";
				array15[2] = text89;
				array15[3] = string_21;
				string text90 = "&devicename=";
				array15[4] = text90;
				array15[5] = string_22;
				string text91 = "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=";
				array15[6] = text91;
				array15[7] = string_24;
				string text92 = "&playstore=false&version=";
				array15[8] = text92;
				array15[9] = string_23;
				string text93 = "|authorization=";
				array15[10] = text93;
				array15[11] = string_7;
				string text94 = "&x-device-identifier=";
				array15[12] = text94;
				array15[13] = string_19;
				string text95 = "&x-device-manufacturer=";
				array15[14] = text95;
				array15[15] = string_21;
				string text96 = "&x-device-name=";
				array15[16] = text96;
				array15[17] = string_22.ToLower();
				string text97 = "&x-epoch=";
				array15[18] = text97;
				array15[19] = string_8;
				string text98 = "|";
				array15[20] = text98;
				array15[21] = string_32;
				text58 = string.Concat(array15);
				string_27 = @class.method_0(text58, "", ref string_26);
				string[] array16 = new string[16];
				string text99 = "x-client-signature#";
				array16[0] = text99;
				array16[1] = string_27;
				string text100 = "||x-app-rid#";
				array16[2] = text100;
				array16[3] = string_5;
				string text101 = "||x-device-name#";
				array16[4] = text101;
				array16[5] = string_22;
				string text102 = "||x-app-version#";
				array16[6] = text102;
				array16[7] = string_23;
				string text103 = "||x-device-manufacturer#";
				array16[8] = text103;
				array16[9] = string_21;
				string text104 = "||x-device-identifier#";
				array16[10] = text104;
				array16[11] = string_19;
				string text105 = "||x-epoch#";
				array16[12] = text105;
				array16[13] = string_8;
				string text106 = "||Authorization#";
				array16[14] = text106;
				array16[15] = string_7;
				string_9 = string.Concat(array16);
				if (!method_1(string_31, string_32, string_30, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_10, ref string_28))
				{
					string text107 = "PAYTM Registration Failed-2";
					MessageBox.Show(text107);
					return result;
				}
			}
			string text108 = string_10;
			string value6 = "Please enter OTP to continue login.";
			if (text108.IndexOf(value6) >= 0)
			{
				string prompt = "Enter PayTM OTP Received on your Mobile for ByPass.";
				string title = "Enter PAYTM OTP";
				string text109 = Interaction.InputBox(prompt, title);
				string text110 = string_10;
				string text111 = string_10;
				string value7 = "stateToken";
				string text112 = text110.Substring(text111.IndexOf(value7) + 13);
				string value8 = "\",";
				string_11 = text112.Substring(0, text112.IndexOf(value8));
				num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
				num /= 1000;
				num2++;
				string[] array17 = new string[7] { string_0, null, null, null, null, null, null };
				string text113 = ":";
				array17[1] = text113;
				array17[2] = num.ToString();
				string text114 = ":";
				array17[3] = text114;
				array17[4] = num2.ToString();
				string text115 = ":";
				array17[5] = text115;
				array17[6] = num2.ToString();
				string_5 = string.Concat(array17);
				string_8 = num.ToString();
				string[] array18 = new string[11];
				string text116 = "https://accounts.paytm.com/v2/simple/login/validate/otp/sv1?deviceIdentifier=";
				array18[0] = text116;
				array18[1] = string_19;
				string text117 = "&deviceManufacturer=";
				array18[2] = text117;
				array18[3] = string_21;
				string text118 = "&deviceName=";
				array18[4] = text118;
				array18[5] = string_22;
				string text119 = "&client=androidapp&version=";
				array18[6] = text119;
				array18[7] = string_23;
				string text120 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
				array18[8] = text120;
				array18[9] = string_24;
				string text121 = "&locale=en-IN";
				array18[10] = text121;
				string_31 = string.Concat(array18);
				string[] array19 = new string[5];
				string text122 = "{\"otp\":\"";
				array19[0] = text122;
				array19[1] = text109;
				string text123 = "\",\"stateToken\":\"";
				array19[2] = text123;
				array19[3] = string_11;
				string text124 = "\"}";
				array19[4] = text124;
				string_32 = string.Concat(array19);
				string text125 = "java_rsa_256hmac";
				string_26 = text125;
				string[] array20 = new string[22];
				string text126 = "/v2/simple/login/validate/otp/sv1|post|client=androidapp&deviceidentifier=";
				array20[0] = text126;
				array20[1] = string_19;
				string text127 = "&devicemanufacturer=";
				array20[2] = text127;
				array20[3] = string_21;
				string text128 = "&devicename=";
				array20[4] = text128;
				array20[5] = string_22;
				string text129 = "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=";
				array20[6] = text129;
				array20[7] = string_24;
				string text130 = "&playstore=false&version=";
				array20[8] = text130;
				array20[9] = string_23;
				string text131 = "|authorization=";
				array20[10] = text131;
				array20[11] = string_7;
				string text132 = "&x-device-identifier=";
				array20[12] = text132;
				array20[13] = string_19;
				string text133 = "&x-device-manufacturer=";
				array20[14] = text133;
				array20[15] = string_21;
				string text134 = "&x-device-name=";
				array20[16] = text134;
				array20[17] = string_22.ToLower();
				string text135 = "&x-epoch=";
				array20[18] = text135;
				array20[19] = string_8;
				string text136 = "|";
				array20[20] = text136;
				array20[21] = string_32;
				text58 = string.Concat(array20);
				string_27 = @class.method_0(text58, "", ref string_26);
				string[] array21 = new string[16];
				string text137 = "x-client-signature#";
				array21[0] = text137;
				array21[1] = string_27;
				string text138 = "||x-app-rid#";
				array21[2] = text138;
				array21[3] = string_5;
				string text139 = "||x-device-name#";
				array21[4] = text139;
				array21[5] = string_22;
				string text140 = "||x-app-version#";
				array21[6] = text140;
				array21[7] = string_23;
				string text141 = "||x-device-manufacturer#";
				array21[8] = text141;
				array21[9] = string_21;
				string text142 = "||x-device-identifier#";
				array21[10] = text142;
				array21[11] = string_19;
				string text143 = "||x-epoch#";
				array21[12] = text143;
				array21[13] = string_8;
				string text144 = "||Authorization#";
				array21[14] = text144;
				array21[15] = string_7;
				string_9 = string.Concat(array21);
				if (method_1(string_31, string_32, string_30, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_10, ref string_28))
				{
					string text145 = string_10;
					string value9 = "status\":\"success";
					if (text145.IndexOf(value9) < 0)
					{
						string text146 = "Some Thing Worng With PAYTM Registration Failed-3";
						MessageBox.Show(text146);
						return result;
					}
					string text147 = string_10;
					string text148 = string_10;
					string value10 = "oauthCode";
					string text149 = text147.Substring(text148.IndexOf(value10) + 12);
					string text150 = text149;
					string text151 = text149;
					string value11 = "\"";
					text149 = text150.Substring(0, text151.IndexOf(value11));
					num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
					num /= 1000;
					num2++;
					string[] array22 = new string[7] { string_0, null, null, null, null, null, null };
					string text152 = ":";
					array22[1] = text152;
					array22[2] = num.ToString();
					string text153 = ":";
					array22[3] = text153;
					array22[4] = num2.ToString();
					string text154 = ":";
					array22[5] = text154;
					array22[6] = num2.ToString();
					string_5 = string.Concat(array22);
					string_8 = num.ToString();
					string_30 = "";
					string[] array23 = new string[11];
					string text155 = "https://accounts.paytm.com/oauth2/v3/token/sv1?deviceIdentifier=";
					array23[0] = text155;
					array23[1] = string_19;
					string text156 = "&deviceManufacturer=";
					array23[2] = text156;
					array23[3] = string_21;
					string text157 = "&deviceName=";
					array23[4] = text157;
					array23[5] = string_22;
					string text158 = "&client=androidapp&version=";
					array23[6] = text158;
					array23[7] = string_23;
					string text159 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
					array23[8] = text159;
					array23[9] = string_24;
					string text160 = "&locale=en-IN";
					array23[10] = text160;
					string_31 = string.Concat(array23);
					string[] array24 = new string[5];
					string text161 = "{\"code\":\"";
					array24[0] = text161;
					array24[1] = text149;
					string text162 = "\",\"deviceId\":\"";
					array24[2] = text162;
					array24[3] = string_19;
					string text163 = "\",\"grantType\":\"authorization_code\"}";
					array24[4] = text163;
					string_32 = string.Concat(array24);
					string[] array25 = new string[14];
					string text164 = "x-app-rid#";
					array25[0] = text164;
					array25[1] = string_5;
					string text165 = "||x-device-name#";
					array25[2] = text165;
					array25[3] = string_22;
					string text166 = "||x-app-version#";
					array25[4] = text166;
					array25[5] = string_23;
					string text167 = "||x-device-manufacturer#";
					array25[6] = text167;
					array25[7] = string_21;
					string text168 = "||x-device-identifier#";
					array25[8] = text168;
					array25[9] = string_19;
					string text169 = "||x-epoch#";
					array25[10] = text169;
					array25[11] = string_8;
					string text170 = "||Authorization#";
					array25[12] = text170;
					array25[13] = string_7;
					string_9 = string.Concat(array25);
					if (method_1(string_31, string_32, string_30, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_10, ref string_28))
					{
						string text171 = string_10;
						string value12 = "tokens";
						if (text171.IndexOf(value12) < 0)
						{
							string text172 = "Some Thing Worng With PAYTM Registration Failed-4";
							MessageBox.Show(text172);
							return result;
						}
						string text173 = string_10;
						string text174 = string_10;
						string value13 = "{\"accessToken";
						string text175 = text173.Substring(text174.IndexOf(value13));
						string text176 = text175;
						string text177 = text175;
						string value14 = "},";
						string text178 = text176.Substring(0, text177.IndexOf(value14) + 1);
						string_10 = string_10.Substring(string_10.IndexOf(text178) + 20);
						string text179 = string_10;
						string text180 = string_10;
						string value15 = "{\"accessToken";
						text175 = text179.Substring(text180.IndexOf(value15));
						string text181 = text175;
						string text182 = text175;
						string value16 = "},";
						string text183 = text181.Substring(0, text182.IndexOf(value16) + 1);
						string_10 = string_10.Substring(string_10.IndexOf(text183) + 20);
						string text184 = string_10;
						string text185 = string_10;
						string value17 = "{\"accessToken";
						text175 = text184.Substring(text185.IndexOf(value17));
						string text186 = text175;
						string text187 = text175;
						string value18 = "},";
						string text188 = text186.Substring(0, text187.IndexOf(value18) + 1);
						string_10 = string_10.Substring(string_10.IndexOf(text188) + 20);
						string text189 = string_10;
						string text190 = string_10;
						string value19 = "{\"accessToken";
						text175 = text189.Substring(text190.IndexOf(value19));
						string text191 = text175;
						string text192 = text175;
						string value20 = "}";
						string text193 = text191.Substring(0, text192.IndexOf(value20));
						string text194 = text178;
						string oldValue = "\"";
						text178 = text194.Replace(oldValue, "");
						string text195 = text183;
						string oldValue2 = "\"";
						text183 = text195.Replace(oldValue2, "");
						string text196 = text188;
						string oldValue3 = "\"";
						text188 = text196.Replace(oldValue3, "");
						string text197 = text193;
						string oldValue4 = "\"";
						text193 = text197.Replace(oldValue4, "");
						string text198 = text188;
						string text199 = text188;
						string value21 = ":";
						string text200 = text198.Substring(text199.IndexOf(value21) + 1);
						string text201 = text200;
						string text202 = text200;
						string value22 = ",";
						text200 = text201.Substring(0, text202.IndexOf(value22));
						num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
						num /= 1000;
						num2++;
						string[] array26 = new string[7] { string_0, null, null, null, null, null, null };
						string text203 = ":";
						array26[1] = text203;
						array26[2] = num.ToString();
						string text204 = ":";
						array26[3] = text204;
						array26[4] = num2.ToString();
						string text205 = ":";
						array26[5] = text205;
						array26[6] = num2.ToString();
						string_5 = string.Concat(array26);
						string_30 = "";
						string[] array27 = new string[11];
						string text206 = "https://paytm.com/v1/user/token/enc/generate?deviceIdentifier=";
						array27[0] = text206;
						array27[1] = string_19;
						string text207 = "&deviceManufacturer=";
						array27[2] = text207;
						array27[3] = string_21;
						string text208 = "&deviceName=";
						array27[4] = text208;
						array27[5] = string_22;
						string text209 = "&client=androidapp&version=";
						array27[6] = text209;
						array27[7] = string_23;
						string text210 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
						array27[8] = text210;
						array27[9] = string_24;
						string text211 = "&locale=en-IN";
						array27[10] = text211;
						string_31 = string.Concat(array27);
						string_32 = "";
						string text212 = "sso_token#";
						string text213 = text200;
						string text214 = "||x-app-rid#";
						string_9 = text212 + text213 + text214 + string_5;
						if (!method_1(string_31, string_32, string_30, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_10, ref string_28))
						{
							string text215 = "Some Thing Error With PAYTM OTP Bypass,\n\r\nPlease Retry After Some Time.";
							string caption = "By-Passed";
							MessageBox.Show(text215, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							return result;
						}
						string text216 = string_10;
						string value23 = "sso_token_enc";
						if (text216.IndexOf(value23) < 0)
						{
							string text217 = "Some Thing Worng With PAYTM Registration Failed-5";
							MessageBox.Show(text217);
							return result;
						}
						Random random = new Random((int)DateTime.Now.Ticks);
						string text218 = "3549194";
						string text219 = random.Next(300000, 900000).ToString();
						string text220 = "76";
						string text221 = text218 + text219 + text220;
						try
						{
							string[] array28 = new string[13]
							{
								string_17, null, null, null, null, null, null, null, null, null,
								null, null, null
							};
							string text222 = "||";
							array28[1] = text222;
							array28[2] = text178;
							string text223 = "||";
							array28[3] = text223;
							array28[4] = text183;
							string text224 = "||";
							array28[5] = text224;
							array28[6] = text188;
							string text225 = "||";
							array28[7] = text225;
							array28[8] = text193;
							string text226 = "||";
							array28[9] = text226;
							array28[10] = string_19;
							string text227 = "||";
							array28[11] = text227;
							array28[12] = text221;
							result = string.Concat(array28);
							return result;
						}
						catch (Exception)
						{
							string text228 = "Error occured while processing request!";
							string caption2 = "Error";
							MessageBox.Show(text228, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return result;
						}
					}
					string text229 = "PAYTM Registration Device Register Failed-4";
					MessageBox.Show(text229);
					return result;
				}
				string text230 = "PAYTM Registration OTP Verfiy Failed-3";
				MessageBox.Show(text230);
				return result;
			}
			string text231 = "Some Thing Worng With PAYTM Registration Failed-2";
			MessageBox.Show(text231);
			return result;
		}
		string text232 = "Some Thing Worng With PAYTM Registration Failed-1";
		MessageBox.Show(text232);
		return result;
	}

	internal static string smethod_0(ref string string_29, ref string string_30)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "Mi3";
		string value = "Xiomi";
		dictionary.Add(key, value);
		string key2 = "Mi4";
		string value2 = "Xiomi";
		dictionary.Add(key2, value2);
		string key3 = "P600";
		string value3 = "Micomax";
		dictionary.Add(key3, value3);
		string key4 = "GT_S5303B";
		string value4 = "Samsung";
		dictionary.Add(key4, value4);
		string key5 = "GT_C3310R";
		string value5 = "Samsung";
		dictionary.Add(key5, value5);
		string key6 = "A88_3i";
		string value6 = "Micromax";
		dictionary.Add(key6, value6);
		string key7 = "Note_A2";
		string value7 = "Karbonn";
		dictionary.Add(key7, value7);
		string key8 = "MSD7Android";
		string value8 = "MAXX";
		dictionary.Add(key8, value8);
		string key9 = "N818";
		string value9 = "ZTE";
		dictionary.Add(key9, value9);
		string key10 = "N909";
		string value10 = "ZTE";
		dictionary.Add(key10, value10);
		string key11 = "Iris351";
		string value11 = "Lava";
		dictionary.Add(key11, value11);
		string key12 = "AX8NoteII";
		string value12 = "MAXX";
		dictionary.Add(key12, value12);
		string key13 = "MSD7Touch35";
		string value13 = "MAXX";
		dictionary.Add(key13, value13);
		string key14 = "91_A3";
		string value14 = "Karbonn";
		dictionary.Add(key14, value14);
		string key15 = "911_A91";
		string value15 = "Micromax";
		dictionary.Add(key15, value15);
		string key16 = "Iris454";
		string value16 = "Lava";
		dictionary.Add(key16, value16);
		string key17 = "X1000";
		string value17 = "Xolo";
		dictionary.Add(key17, value17);
		string key18 = "K3_Note";
		string value18 = "Lenovo";
		dictionary.Add(key18, value18);
		string key19 = "B407";
		string value19 = "LEMON";
		dictionary.Add(key19, value19);
		string key20 = "Andi4v";
		string value20 = "iball";
		dictionary.Add(key20, value20);
		string key21 = "Andi5l";
		string value21 = "iball";
		dictionary.Add(key21, value21);
		string key22 = "A112";
		string value22 = "Micromax";
		dictionary.Add(key22, value22);
		string key23 = "9_A4";
		string value23 = "Karbonn";
		dictionary.Add(key23, value23);
		string key24 = "MI_530";
		string value24 = "Spice";
		dictionary.Add(key24, value24);
		string key25 = "55_A62";
		string value25 = "Micromax";
		dictionary.Add(key25, value25);
		string key26 = "60_A115";
		string value26 = "Micromax";
		dictionary.Add(key26, value26);
		string key27 = "P880g";
		string value27 = "LG";
		dictionary.Add(key27, value27);
		string key28 = "8_A520";
		string value28 = "Lenovo";
		dictionary.Add(key28, value28);
		string key29 = "9_Q700";
		string value29 = "XOLO";
		dictionary.Add(key29, value29);
		string key30 = "5_B700";
		string value30 = "XOLO";
		dictionary.Add(key30, value30);
		string key31 = "6_A500";
		string value31 = "Xolo";
		dictionary.Add(key31, value31);
		string key32 = "1_A800";
		string value32 = "Xolo";
		dictionary.Add(key32, value32);
		string key33 = "2_A700";
		string value33 = "XOLO";
		dictionary.Add(key33, value33);
		string key34 = "35_A90S";
		string value34 = "Micromax";
		dictionary.Add(key34, value34);
		Dictionary<string, string> dictionary2 = dictionary;
		Random random = new Random((int)DateTime.Now.Ticks);
		KeyValuePair<string, string> keyValuePair = dictionary2.ElementAt(random.Next(0, dictionary2.Count - 1));
		string_30 = keyValuePair.Key;
		string_29 = keyValuePair.Value;
		string[] array = new string[6] { string_29, null, null, null, null, null };
		string text = "-";
		array[1] = text;
		array[2] = string_30;
		string text2 = "-1449194";
		array[3] = text2;
		array[4] = random.Next(300000, 900000).ToString();
		string text3 = "760180f";
		array[5] = text3;
		return string.Concat(array);
	}

	internal bool method_1(string string_29, string string_30, string string_31, int int_4, WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_5, ref string string_32, ref string string_33)
	{
		int num = 0;
		if (!string.IsNullOrEmpty(string_9))
		{
			string_13 = string_9;
		}
		string text = "Tls";
		string text2 = text;
		WebProxy proxy = null;
		bool result = false;
		bool flag;
		do
		{
			string_33 = "";
			string_32 = "";
			flag = false;
			HttpWebResponse httpWebResponse = null;
			HttpWebRequest httpWebRequest = null;
			string text3 = "";
			try
			{
				httpWebRequest = (HttpWebRequest)WebRequest.Create(string_29);
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.Proxy = proxy;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
				string text4 = text2;
				string text5 = "Tls";
				bool flag2 = text4 == text5;
				string text6 = text2;
				string text7 = "Ssl3";
				if (flag2 | (text6 == text7))
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				}
				if (int_5 > 0)
				{
					httpWebRequest.Timeout = int_5;
					httpWebRequest.ReadWriteTimeout = int_5;
				}
				byte[] bytes = Encoding.UTF8.GetBytes(string_30);
				if (bool_1)
				{
					if (cookieContainer_1 == null)
					{
						cookieContainer_1 = new CookieContainer();
					}
					httpWebRequest.CookieContainer = cookieContainer_1;
				}
				HttpWebRequest httpWebRequest2 = httpWebRequest;
				string method = "POST";
				httpWebRequest2.Method = method;
				httpWebRequest.ContentLength = bytes.Length;
				HttpWebRequest httpWebRequest3 = httpWebRequest;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest3.ContentType = contentType;
				string value = "{\"";
				if (string_30.Contains(value) || int_4 == 2)
				{
					HttpWebRequest httpWebRequest4 = httpWebRequest;
					string contentType2 = "application/json";
					httpWebRequest4.ContentType = contentType2;
				}
				httpWebRequest.UserAgent = string_14;
				if (!string.IsNullOrEmpty(string_13))
				{
					string expression = string_13;
					string delimiter = "||";
					string[] array = Strings.Split(expression, delimiter);
					int num2 = Information.UBound(array);
					for (int i = 0; i <= num2; i++)
					{
						string expression2 = array[i];
						string delimiter2 = "#";
						string[] array2 = Strings.Split(expression2, delimiter2);
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
					string_9 = "";
				}
				if (string_30.Length > 0)
				{
					using Stream stream = httpWebRequest.GetRequestStream();
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					HttpWebRequest httpWebRequest5 = httpWebRequest;
					string method2 = "GET";
					httpWebRequest5.Method = method2;
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader textReader_ = smethod_1(httpWebResponse.GetResponseStream()))
				{
					text3 = smethod_2(textReader_);
				}
				string_32 = text3;
				flag = true;
			}
			catch (Exception ex)
			{
				flag = false;
				string_33 = ex.Message;
				string text8 = string_33.ToUpper();
				string value2 = "CONNECTION WAS CLOSED";
				if (!text8.Contains(value2))
				{
					string text9 = string_33.ToUpper();
					string value3 = "SERVICEUNAVAILABLE";
					text9.Contains(value3);
				}
				string text10 = string_33;
				string value4 = "The underlying connection was closed";
				if (text10.Contains(value4))
				{
					string text11 = "Tls12";
					text2 = text11;
				}
				string text12 = string_33;
				string value5 = "The underlying connection was closed";
				text12.Contains(value5);
				if (num < 3)
				{
					num++;
					continue;
				}
				return result = flag;
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
		}
		while (!(string_32 != ""));
		while (true)
		{
			int[,] array3 = new int[2, 3]
			{
				{ 2107772987, -1625884132, 427804490 },
				{ -1957675827, -1625884131, 434193956 }
			};
			switch (array3[0, 1])
			{
			default:
				return result;
			case -1625884132:
				return flag;
			case -1625884133:
				break;
			}
		}
	}

	private static StreamReader smethod_1(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	private static string smethod_2(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}
}
