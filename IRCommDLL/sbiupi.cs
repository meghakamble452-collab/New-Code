using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace IRCommDLL;

internal class sbiupi
{
	public class CollectList
	{
		public long upiTrnRefNo { get; set; }

		public string reqDate { get; set; }

		public string txnId { get; set; }

		public string txnNote { get; set; }

		public string expDate { get; set; }

		public string txnAmount { get; set; }

		public string payerVa { get; set; }

		public string payeeVa { get; set; }

		public string payeeName { get; set; }

		public string collectExpTime { get; set; }

		public string custRefNo { get; set; }

		public string pyAccNo { get; set; }

		public string is_verified_merchant { get; set; }

		public string payType { get; set; }
	}

	public class RequestInfo
	{
		public string pspId { get; set; }

		public string pspRefNo { get; set; }
	}

	public class Root
	{
		public RequestInfo requestInfo { get; set; }

		public string status { get; set; }

		public string statusDesc { get; set; }

		public List<CollectList> collectList { get; set; }
	}

	public string bnkDetail = "";

	public string db;

	private string response;

	private string string_93;

	private string txnId;

	private string text6;

	private string string_92;

	private WebProxy webProxy_3;

	private int num;

	private string string_95;

	private WebException webException_0;

	private string otpId;

	private string modelname;

	private static string[] string_0;

	private static Random random_0;

	public static string freeChargeApiHeader;

	private static Random random;

	private string encmob;

	private string cske;

	private string upiact;

	private string smspart;

	private string uniquedevice;

	public static string listName;

	private string aesSymmetricKey;

	private static int LenghtAesKeyBytes;

	private static RNGCryptoServiceProvider rngCsp;

	protected static char[] hexArray;

	public static string x509CertSecondService;

	public static string packageName;

	private string otpLength;

	private string names;

	private string dLength;

	private string logo;

	private string Path_;

	private bool balanceshow;

	private static string logExitFile;

	private string bearer;

	private string string_96;

	private CookieContainer cookieContainer_3;

	private List<CollectList> collectList;

	public static string jsonData_Serial(string str, string what)
	{
		string result = "";
		try
		{
			string text = "\"";
			string text2 = "\"";
			string text3 = str.Substring(str.IndexOf(text + what + text2, StringComparison.CurrentCultureIgnoreCase));
			string text4 = text3;
			string text5 = text3;
			string value = ":\"";
			text3 = text4.Substring(text5.IndexOf(value) + 2);
			string text6 = text3;
			string text7 = text3;
			string value2 = "\"";
			result = text6.Substring(0, text7.IndexOf(value2));
			return result;
		}
		catch (Exception ex)
		{
			string text8 = "";
			if (ex.StackTrace != null)
			{
				string stackTrace = ex.StackTrace;
				string value3 = ":line ";
				int num = stackTrace.LastIndexOf(value3);
				if (num != -1)
				{
					text8 = ex.StackTrace.Substring(num);
				}
			}
			string text9 = "Error: ";
			string message = ex.Message;
			string text10 = "\n";
			string text11 = text9 + message + text10 + text8;
			string caption = "Exception";
			MessageBox.Show(text11, caption);
			return result;
		}
	}

	public static string RsaEncrypt(string input, AsymmetricKeyParameter publicKey)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		byte[] inArray;
		try
		{
			OaepEncoding oaepEncoding = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new Sha256Digest(), null);
			oaepEncoding.Init(forEncryption: true, publicKey);
			inArray = oaepEncoding.ProcessBlock(bytes, 0, bytes.Length);
		}
		catch (Exception ex)
		{
			string text = "Exception while encrypting data: ";
			return text + ex.Message;
		}
		return Convert.ToBase64String(inArray);
	}

	public static string AESGCMEncryptToBase64(byte[] textBytes, byte[] key, byte[] nonce)
	{
		GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
		gcmBlockCipher.Init(forEncryption: true, new AeadParameters(new KeyParameter(key), 128, nonce));
		byte[] array = new byte[gcmBlockCipher.GetOutputSize(textBytes.Length)];
		gcmBlockCipher.DoFinal(array, gcmBlockCipher.ProcessBytes(textBytes, 0, textBytes.Length, array, 0));
		return Convert.ToBase64String(array);
	}

	public static byte[] SHA256withKey(string input, byte[] key)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		SHA256 sHA = SHA256.Create();
		sHA.TransformBlock(key, 0, key.Length, key, 0);
		sHA.TransformFinalBlock(bytes, 0, bytes.Length);
		return sHA.Hash;
	}

	public static string getsafetyid()
	{
		string text = "SBI";
		string text2 = Guid.NewGuid().ToString();
		string oldValue = "-";
		string text3 = text2.Replace(oldValue, string.Empty).ToUpper().Substring(0, 31);
		string text4 = "7";
		return text + text3 + text4;
	}

	private string Table_ReadSQL(string Field, string mobileNum)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			string text = "SELECT * FROM [TBL_SBIUPI] WHERE [MobNo] = '";
			string text2 = "'";
			new SQLiteDataAdapter(text + mobileNum + text2, db).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					result = row[Field].ToString();
				}
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public void approveRequest(object object_0)
	{
		try
		{
			string text = object_0.ToString();
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.None);
			string field = "RegiInfo";
			string text3 = Table_ReadSQL(field, array2[2]);
			string text5;
			if (array2.Length != 4)
			{
				string text4 = array2[2].Trim();
				string oldValue = "₹";
				text5 = text4.Replace(oldValue, "");
				string text6 = text5;
				string[] array3 = new string[1];
				string text7 = ".";
				array3[0] = text7;
				text6.Split(array3, StringSplitOptions.None)[0].Trim();
			}
			else
			{
				string text8 = array2[3].Trim();
				string oldValue2 = "₹";
				text5 = text8.Replace(oldValue2, "");
				string text9 = text5;
				string[] array4 = new string[1];
				string text10 = ".";
				array4[0] = text10;
				text9.Split(array4, StringSplitOptions.None)[0].Trim();
			}
			string text11 = "";
			string text12 = text3;
			string text13 = text12;
			string[] array5 = new string[1];
			string text14 = "||##||";
			array5[0] = text14;
			string[] array6 = text13.Split(array5, StringSplitOptions.None);
			string str = array6[1];
			string newValue = array6[4];
			text12 = array6[0];
			string text15 = array6[5];
			string ciphertext = text12;
			string hex = "A6E969A6AFF28488FEB1B3B480BBD6D5C2E9A576357EC83D4633624E5698CD83";
			text12 = AESGCMDecrypt(ciphertext, StringToByteArray(hex), new byte[12]);
			string what = "custId";
			string s = jsonData_Serial(str, what);
			string str2 = text12;
			string what2 = "deviceId";
			string text16 = jsonData_Serial(str2, what2);
			string text17 = array6[3];
			string text18 = array6[2];
			string str3 = text12;
			string what3 = "virtualAddress";
			string text19 = jsonData_Serial(str3, what3);
			string what4 = "fcmToken";
			string text20 = jsonData_Serial(str, what4);
			string what5 = "appGenId";
			string text21 = jsonData_Serial(str, what5);
			string hex2 = array6[6];
			string what6 = "simId";
			string text22 = jsonData_Serial(str, what6);
			string text23 = "https://upionline.sbi/oauth/token";
			string_93 = text23;
			string text24 = "password=149a75cef4dc4ed6b5810debf3df79d7&grant_type=password&client_secret=a8dd71dac92f4ccfaad39411ccf7842c&client_id=0eb6a5ba728b5b89&username=201&";
			string oldValue3 = "a8dd71dac92f4ccfaad39411ccf7842c";
			string text25 = text24.Replace(oldValue3, newValue);
			string oldValue4 = "0eb6a5ba728b5b89";
			text11 = text25.Replace(oldValue4, text16);
			_Request_Sbi(string_93, text11, string_92, webProxy_3, ref cookieContainer_3, bool_63: true, bool_64: true, 15000, 15000, ref string_96, ref string_95, ref webException_0);
			string text26 = "Bearer ";
			string text27 = string_96;
			string text28 = string_96;
			string value = "access_token";
			bearer = text26 + text27.Substring(text28.IndexOf(value) + 15, 36);
			string text29 = text12;
			string value2 = "virtualAddress";
			if (text29.Contains(value2))
			{
				string str4 = text12;
				string what7 = "bankName";
				string text30 = jsonData_Serial(str4, what7);
				string text31 = "{\"addInfo\":{\"addInfo10\":\"NA\",\"addInfo9\":\"NA\"},\"appVersionCode\":228,\"deviceInfo\":{\"androidId\":\"0eb6a5ba728b5b89\",\"appGenId\":\"193ebc8f03770b78e063b2d5bf0ac053\",\"appName\":\"com.sbi.upi\",\"appVersionCode\":\"228\",\"appVersionName\":\"2.3.45\",\"bluetoothMac\":\"NA\",\"capability\":\"5200000200010004000639292929292\",\"deviceId\":\"0eb6a5ba728b5b89\",\"deviceType\":\"MOB\",\"fcmToken\":\"a7Ui5K6K5HwB5Hwnomuj4aJCVQlhPE0p1oQd\",\"geoCode\":\"19.0911 ,72.9208\",\"ip\":\"127.0.0.1\",\"location\":\"Mumbai\",\"mobileNo\":\"919140903684\",\"os\":\"Android12\",\"regId\":\"NA\",\"relayButton\":\"gQ75MtbopujDiyGZ/oONqRqq/sg\\u003d\",\"safetyNetId\":\"SBI530E4FF900F54599BBD83224B6000765\",\"selectedSimSlot\":0,\"simId\":\"0f9a9d2bf0e85bfc3\",\"smsSentTime\":\"\",\"wifiMac\":\"02:00:00:00:00:00\"},\"recoveryOptionFlag\":0,\"requestInfo\":{\"pspId\":\"201\",\"pspRefNo\":\"SBI86FEBFBA13CA406E87345E728FB96737\"},\"root_beer_count\":0,\"smsSent\":false,\"updateFlag\":0}";
				string oldValue5 = "SBI86FEBFBA13CA406E87345E728FB96737";
				string text32 = text31.Replace(oldValue5, getsafetyid());
				string oldValue6 = "193ebc8f03770b78e063b2d5bf0ac053";
				string text33 = text32.Replace(oldValue6, text21);
				string oldValue7 = "9140903684";
				string text34 = text33.Replace(oldValue7, text18);
				string oldValue8 = "0eb6a5ba728b5b89";
				string text35 = text34.Replace(oldValue8, text16);
				string oldValue9 = "a7Ui5K6K5HwB5Hwnomuj4aJCVQlhPE0p1oQd";
				string text36 = text35.Replace(oldValue9, text20);
				string oldValue10 = "0f9a9d2bf0e85bfc3";
				string text37 = text36.Replace(oldValue10, text22);
				string oldValue11 = "193780768";
				string text38 = text37.Replace(oldValue11, text17);
				string hex3 = "A6E969A6AFF28488FEB1B3B480BBD6D5C2E9A576357EC83D4633624E5698CD83";
				byte[] key = StringToByteArray(hex3);
				string newValue2 = AESGCMEncrypt(text38, key, new byte[12]);
				string text39 = "{\"key_data\":{\"keyId\":\"16\"},\"pspId\":\"201\",\"requestMsg\":\"replacedata\"}";
				this.text6 = text39;
				string text40 = this.text6;
				string oldValue12 = "replacedata";
				this.text6 = text40.Replace(oldValue12, newValue2);
				string text41 = "https://upionline.sbi/upi/api/getCollectListWeb";
				string_93 = text41;
				_Request_Sbi(string_93, this.text6, string_92, webProxy_3, ref cookieContainer_3, bool_63: true, bool_64: true, 15000, 15000, ref string_96, ref string_95, ref webException_0);
				string str5 = string_96;
				string what8 = "resp";
				string_96 = jsonData_Serial(str5, what8);
				string_96 = AESGCMDecrypt(string_96, key, new byte[12]);
				collectList = JsonConvert.DeserializeObject<Root>(string_96).collectList.ToList();
				int index = 0;
				int num = 0;
				if (0 < collectList.Count)
				{
					collectList[num].txnAmount.Equals(text5);
					collectList[num].payerVa.Contains(text19);
					index = num;
				}
				string text42 = collectList[index].txnId;
				string txnAmount = collectList[index].txnAmount;
				collectList[index].upiTrnRefNo.ToString();
				string text43 = collectList[index].upiTrnRefNo.ToString();
				string payeeVa = collectList[index].payeeVa;
				string payeeName = collectList[index].payeeName;
				string str6 = string_96;
				string what9 = "pspRefNo";
				jsonData_Serial(str6, what9);
				string text44 = "";
				try
				{
					string text45 = "369258";
					string s2 = text45;
					string text46 = "MIIBIDANBgkqhkiG9w0BAQEFAAOCAQ0AMIIBCAKCAQEAuDbDFnrdaI0hCnl2CoAn70a9krjKAaQCgtJfiEv6yDGBTC8lPfxisb/U5NIAf7JRcM2oo2YGf09aavVmvXzv5xgm9SwucHzveCi4/j/JxGZP6VUorbqX3aJHbClUyS5RsNKlkBYKKpcZH6RTHmn91FDjsjdHjUsrQK7R0hT0XLL8v0wUdhCjy2adhUlewrRFCvISJ1/jIr7BkqwH9nv+6SXL0IzSJDSibSshBFcLIv3mYF0joY370/j9pGFQOsdEduELO+AbYh1hIGu5KKQwzY0/CgKaonOzRVK+pAHxLrZt9mprRKDWRk4q3SaDG2J7ZfvAgbic67X/4IzU7py0vQIBAw==";
					string s3 = text46;
					PublicKeyFactory.CreateKey(Convert.FromBase64String(s3));
					new BigInteger(1, new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(s2), Encoding.UTF8.GetBytes(s), 500, HashAlgorithmName.SHA1).GetBytes(128)).ToString(16);
					byte[] array7 = new byte[16];
					string[] array8 = new string[12]
					{
						txnAmount, null, null, null, null, null, null, null, null, null,
						null, null
					};
					string text47 = "|";
					array8[1] = text47;
					array8[2] = text42;
					string text48 = "|";
					array8[3] = text48;
					array8[4] = text19;
					string text49 = "|";
					array8[5] = text49;
					array8[6] = payeeVa;
					string text50 = "|com.sbi.upi|91";
					array8[7] = text50;
					array8[8] = text18;
					string text51 = "|";
					array8[9] = text51;
					array8[10] = text16;
					string text52 = "|collect";
					array8[11] = text52;
					string input = string.Concat(array8);
					rngCsp.GetBytes(array7);
					string text53 = AESGCMEncryptToBase64(SHA256withKey(input, array7), StringToByteArray(hex2), array7);
					string text54 = "|";
					string text55 = text53 + text54 + Convert.ToBase64String(array7);
					string[] array9 = new string[5] { text15, null, null, null, null };
					string text56 = "|";
					array9[1] = text56;
					array9[2] = text42;
					string text57 = "|";
					array9[3] = text57;
					array9[4] = text55;
					string text58 = RsaEncrypt(string.Concat(array9), PublicKeyFactory.CreateKey(Convert.FromBase64String(s3)));
					Encoding uTF = Encoding.UTF8;
					string text59 = "2.3-v1.8|";
					string text60 = Convert.ToBase64String(uTF.GetBytes(text59 + text58));
					string oldValue13 = "=";
					string newValue3 = "\\u003d";
					text44 = text60.Replace(oldValue13, newValue3);
				}
				catch
				{
				}
				string text61 = "IRCTC";
				payeeName = text61;
				string[] array10 = new string[13];
				string text62 = "{\"addInfo\":{\"addInfo10\":\"NA\",\"addInfo9\":\"NA\"},\"amount\":\"";
				array10[0] = text62;
				array10[1] = txnAmount;
				string text63 = "\",\"approvalStatus\":\"A\",\"cred\":{\"atmCrdLength\":0,\"credentialDataCode\":\"NPCI\",\"credentialDataKi\":\"20150822\",\"credentialDataLength\":0,\"credentialDataValue\":\"";
				array10[2] = text63;
				array10[3] = text44;
				string text64 = "\",\"credentialSubType\":\"MPIN\",\"credentialType\":\"PIN\",\"otpCrdLength\":0},\"deviceInfo\":{\"androidId\":\"0eb6a5ba728b5b89\",\"appGenId\":\"193ebc8f03770b78e063b2d5bf0ac053\",\"appName\":\"com.sbi.upi\",\"appVersionCode\":\"172\",\"appVersionName\":\"2.3.33\",\"bluetoothMac\":\"NA\",\"capability\":\"5200000200010004000639292929292\",\"deviceId\":\"0eb6a5ba728b5b89\",\"deviceType\":\"MOB\",\"fcmToken\":\"";
				array10[4] = text64;
				array10[5] = text20;
				string text65 = "\",\"geoCode\":\"19.0911 ,72.9208\",\"ip\":\"127.0.0.1\",\"location\":\"Mumbai\",\"mobileNo\":\"919140903684\",\"os\":\"Android12\",\"regId\":\"NA\",\"relayButton\":\"gQ75MtbopujDiyGZ/oONqRqq/sg\\u003d\",\"safetyNetId\":\"SBI530E4FF900F54599BBD83224B6000765\",\"selectedSimSlot\":0,\"simId\":\"0f9a9d2bf0e85bfc3\",\"smsSentTime\":\"\",\"wifiMac\":\"02:00:00:00:00:00\"},\"expiryTime\":0,\"initMode\":\"00\",\"is_verified_merchant\":\"N\",\"npciTranId\":\"PTM40525802871063581705202405251028\",\"payeeType\":{\"name\":\"";
				array10[6] = text65;
				array10[7] = payeeName;
				string text66 = "\",\"virtualAddress\":\"";
				array10[8] = text66;
				array10[9] = payeeVa;
				string text67 = "\"},\"payerType\":{\"accountId\":\"193780768\",\"payerBankName\":\"HDFC BANK LTD\",\"virtualAddress\":\"";
				array10[10] = text67;
				array10[11] = text19;
				string text68 = "\"},\"requestInfo\":{\"pspId\":\"201\",\"pspRefNo\":\"SBI1512CA7213FB45E198576860924C3257\"},\"upiTransRefNo\":154554517036}";
				array10[12] = text68;
				string text69 = string.Concat(array10);
				string oldValue14 = "PTM40525802871063581705202405251028";
				string text70 = text69.Replace(oldValue14, text42.Trim());
				string oldValue15 = "193ebc8f03770b78e063b2d5bf0ac053";
				string text71 = text70.Replace(oldValue15, text21.Trim());
				string oldValue16 = "9140903684";
				string text72 = text71.Replace(oldValue16, text18.Trim());
				string oldValue17 = "0eb6a5ba728b5b89";
				string text73 = text72.Replace(oldValue17, text16.Trim());
				string oldValue18 = "5Hwnomuj4aJCVQlhPE0p1oQd";
				string text74 = text73.Replace(oldValue18, text20.Trim());
				string oldValue19 = "0f9a9d2bf0e85bfc3";
				string text75 = text74.Replace(oldValue19, text22.Trim());
				string oldValue20 = "193780768";
				string text76 = text75.Replace(oldValue20, text17.Trim());
				string oldValue21 = "paytm-irctcapp@paytm";
				string text77 = text76.Replace(oldValue21, payeeVa.Trim());
				string oldValue22 = "9140903684@sbi";
				string text78 = text77.Replace(oldValue22, text19.Trim());
				string oldValue23 = "154554517036";
				string text79 = text78.Replace(oldValue23, text43.Trim());
				string oldValue24 = "SBI1512CA7213FB45E198576860924C3257";
				string text80 = text79.Replace(oldValue24, getsafetyid());
				string oldValue25 = "HDFC BANK LTD";
				string text81 = text80.Replace(oldValue25, text30.Trim());
				string oldValue26 = "credvaluereplace";
				string text82 = text81.Replace(oldValue26, text44.Trim());
				string hex4 = "A6E969A6AFF28488FEB1B3B480BBD6D5C2E9A576357EC83D4633624E5698CD83";
				key = StringToByteArray(hex4);
				newValue2 = AESGCMEncrypt(text82, key, new byte[12]);
				string text83 = "{\"key_data\":{\"keyId\":\"16\"},\"pspId\":\"201\",\"requestMsg\":\"replacedata\"}";
				this.text6 = text83;
				string text84 = "{\"key_data\":{\"keyId\":\"16\"},\"pspId\":\"201\",\"requestMsg\":\"replacedata\"}";
				this.text6 = text84;
				string text85 = this.text6;
				string oldValue27 = "replacedata";
				this.text6 = text85.Replace(oldValue27, newValue2);
				string text86 = "https://upionline.sbi/upi/api/UPICollectApproveReject";
				string_93 = text86;
				string text87 = "https://upionline.sbi/upi/api/UPICollectApproveReject";
				string_93 = text87;
				_Request_Sbi(string_93, this.text6, string_92, webProxy_3, ref cookieContainer_3, bool_63: true, bool_64: true, 15000, 15000, ref string_96, ref string_95, ref webException_0);
				string str7 = string_96;
				string what10 = "resp";
				string_96 = jsonData_Serial(str7, what10);
				string_96 = AESGCMDecrypt(string_96, key, new byte[12]);
				string text88 = string_96;
				string value3 = "Payment Successful";
				if (!text88.Contains(value3))
				{
					string str8 = string_96;
					string what11 = "statusDesc";
					text11 = jsonData_Serial(str8, what11);
					string text89 = "IRLOG/_";
					string variable = "Userid";
					string environmentVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
					string text90 = " --SBI_UPI_RESPONSE_ERROR ";
					DateTime now = DateTime.Now;
					string text91 = "hhmmssfff";
					File.WriteAllText(text89 + environmentVariable + text90 + now.ToString(text91), text11);
				}
			}
		}
		catch (Exception ex)
		{
			string text92 = "";
			if (ex.StackTrace != null)
			{
				string stackTrace = ex.StackTrace;
				string value4 = ":line ";
				int num2 = stackTrace.LastIndexOf(value4);
				if (num2 != -1)
				{
					text92 = ex.StackTrace.Substring(num2);
				}
			}
			string text93 = "Error: ";
			string message = ex.Message;
			string text94 = "\n";
			string text95 = text93 + message + text94 + text92;
			string caption = "Exception";
			MessageBox.Show(text95, caption);
		}
	}

	public static string ByteArrayToString(byte[] ba)
	{
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		for (int i = 0; i < ba.Length; i++)
		{
			string format = "{0:x2}";
			stringBuilder.AppendFormat(format, ba[i]);
		}
		return stringBuilder.ToString();
	}

	public static string AESGCMEncrypt(string text, byte[] key, byte[] nonce)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
		gcmBlockCipher.Init(forEncryption: true, new AeadParameters(new KeyParameter(key), 128, nonce));
		byte[] array = new byte[gcmBlockCipher.GetOutputSize(bytes.Length)];
		gcmBlockCipher.DoFinal(array, gcmBlockCipher.ProcessBytes(bytes, 0, bytes.Length, array, 0));
		return ByteArrayToString(array).ToUpper();
	}

	public static string AESGCMDecrypt(string ciphertext, byte[] key, byte[] nonce)
	{
		byte[] array = StringToByteArray(ciphertext);
		GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
		gcmBlockCipher.Init(forEncryption: false, new AeadParameters(new KeyParameter(key), 128, nonce));
		byte[] array2 = new byte[gcmBlockCipher.GetOutputSize(array.Length)];
		gcmBlockCipher.DoFinal(array2, gcmBlockCipher.ProcessBytes(array, 0, array.Length, array2, 0));
		return Encoding.UTF8.GetString(array2);
	}

	public static byte[] StringToByteArray(string hex)
	{
		return (from x in Enumerable.Range(0, hex.Length)
			where x % 2 == 0
			select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
	}

	internal bool _Request_Sbi(string string_86, string string_87, string string_88, WebProxy webProxy_5, ref CookieContainer cookieContainer_2, bool bool_63, bool bool_64, int int_28, int int_29, ref string string_89, ref string string_90, ref WebException webException_1)
	{
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_86);
			httpWebRequest.Timeout = int_28;
			httpWebRequest.ReadWriteTimeout = int_29;
			if (cookieContainer_2 == null)
			{
				cookieContainer_2 = new CookieContainer();
			}
			httpWebRequest.CookieContainer = cookieContainer_2;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string connection = "keepalive";
			httpWebRequest.Connection = connection;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value = "gzip,deflate";
			headers.Set(name, value);
			string text = "https://upionline.sbi/oauth/token";
			if (string_86 == text)
			{
				string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
				httpWebRequest.ContentType = contentType;
			}
			else
			{
				string contentType2 = "application/json; charset=utf-8";
				httpWebRequest.ContentType = contentType2;
			}
			string userAgent = "Dalvik/2.1.0 (Linux; U; Android 11; HD1911 Build/RKQ1.201022.002)";
			httpWebRequest.UserAgent = userAgent;
			ServicePointManager.Expect100Continue = true;
			if (string.IsNullOrEmpty(bearer))
			{
				WebHeaderCollection headers2 = httpWebRequest.Headers;
				string name2 = "Authorization";
				string value2 = "Bearer ";
				headers2.Add(name2, value2);
			}
			else
			{
				WebHeaderCollection headers3 = httpWebRequest.Headers;
				string name3 = "Authorization";
				headers3.Add(name3, bearer);
			}
			if (!string.IsNullOrEmpty(string_87))
			{
				string method = "POST";
				httpWebRequest.Method = method;
				httpWebRequest.ContentLength = Encoding.UTF8.GetBytes(string_87).Length;
				using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
				streamWriter.Write(string_87);
			}
			else
			{
				string method2 = "GET";
				httpWebRequest.Method = method2;
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			response = streamReader.ReadToEnd();
			string_89 = response;
			return true;
		}
		catch (WebException ex)
		{
			string message = (webException_1 = ex).Message;
			string text2 = "";
			string[] array = new string[7];
			string text3 = "<StatusCode>";
			array[0] = text3;
			array[1] = HttpStatusCode.OK.ToString();
			string text4 = "</StatusCode>\t<ErrorCode>";
			array[2] = text4;
			array[3] = message;
			string text5 = "</ErrorCode>\t<ResponseCode>";
			array[4] = text5;
			array[5] = text2;
			string text6 = "</ResponseCode>";
			array[6] = text6;
			string_90 = string.Concat(array);
		}
		return true;
	}

	static sbiupi()
	{
		string text = "FREECHARGE_V2";
		freeChargeApiHeader = text;
		random = new Random();
		LenghtAesKeyBytes = 32;
		rngCsp = new RNGCryptoServiceProvider();
		string text2 = "0123456789ABCDEF";
		hexArray = text2.ToCharArray();
		string text3 = "-----BEGIN CERTIFICATE-----\nMIIErDCCA5SgAwIBAgIKFzMa/spgXyVfATANBgkqhkiG9w0BAQsFADCB9zELMAkG\nA1UEBhMCSU4xRTBDBgNVBAoTPEluc3RpdHV0ZSBmb3IgRGV2ZWxvcG1lbnQgYW5k\nIFJlc2VhcmNoIGluIEJhbmtpbmcgVGVjaG5vbG9neTEdMBsGA1UECxMUQ2VydGlm\neWluZyBBdXRob3JpdHkxDzANBgNVBBETBjUwMDA1NzEXMBUGA1UECBMOQW5kaHJh\nIFByYWRlc2gxKTAnBgNVBAkTIFJvYWQgTm8uMSwgTWFzYWIgVGFuaywgSHlkZXJh\nYmFkMRUwEwYDVQQzEwxDYXN0bGUgSGlsbHMxFjAUBgNVBAMTDUlEUkJUIENBIDIw\nMTQwHhcNMTYwMzMxMTIwMzUyWhcNMTgwMzMxMTIwMzUyWjASMRAwDgYDVQQDEwd1\ncGlucGNpMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAsqMattxoTibl\naGsAneFo5TgFfvRltQ2CqteIgUVJlLMz95P35Y+GQc2EOjVEO0L1OUd5IDTIBaqh\nrTqeWypOyna+CsHPqDRY0vsklCYizw/VQkdwLBZHMMhU4jL4wciE7qcf2kdyri6B\n135SzUF5IGPn4SnSkeB3IqHzneUrabP0lJweLF7IU5l9qtpPa6A5cH1iVKQT5YAI\n4NWH+3E/MRNKvdqgU1PILlOEaVB0vJZ1pBWW1aMaecoHfzC8/pTfM2PJ5s/CDbR0\n4xqX9/AYmkt34jMwBKvboyWjD1UgCkPnJd3SaZ4vDpA+nyTITM6uGOI6e6sv/b6v\ntF7nbM3H7wIDAQABo4IBHDCCARgwDgYDVR0PAQH/BAQDAgWgMB0GA1UdDgQWBBQq\nlITKolqdgylQXHZgJ1WJMLhvnDAfBgNVHSMEGDAWgBSAdQI0B9ReDs4FarWs8BBr\nQhsHxzAdBgNVHSUEFjAUBggrBgEFBQcDAQYIKwYBBQUHAwIwOAYDVR0gBDEwLzAt\nBgZggmRkAgMwIzAhBggrBgEFBQcCAjAVGhNDbGFzcyAzIENlcnRpZmljYXRlMBIG\nA1UdEQQLMAmCB3VwaW5wY2kwWQYDVR0fBFIwUDAkoCKgIIYeaHR0cDovLzEwLjAu\nNjUuNjUvY3JsXzI3QjAuY3JsMCigJqAkhiJodHRwOi8vaWRyYnRjYS5vcmcuaW4v\nY3JsXzI3QjAuY3JsMA0GCSqGSIb3DQEBCwUAA4IBAQB6Y1FmD1GRKdEW4GINYutM\njDxZmHy4HGFmkE3xZjQx9aDT34TpLSNpsg8jUF+nW/KUMb+nWKJuIRZESYfBSCS9\n2fP1AJAO+PKopJMep/weJ+6a0ydPeoKbqKYllTlmFy+DPC56/UuEBQ9iIX3n5RW9\nxZFTB3NFC9A8zhxCBTsxizElrP8Jd4s+I3+qzJIw9ZqGknDgipyYoi0GGx2mjfwH\npg4YQ4/2xjG2ZRQwkgEmcxy/NvbXz1NV5P5u7dit9SwX3gaAZybu2guIcLFcVEvw\n1VpioZlgPjr5RVhyGzX+tBS8rapTNG1C8A7ANLxpk3nqYzNh4XjhMm5EQ3oKDD9d\n-----END CERTIFICATE-----";
		x509CertSecondService = text3;
		string text4 = "com.sbi.upi";
		packageName = text4;
		string text5 = "Log_Freecharge.rxt";
		logExitFile = text5;
	}
}
