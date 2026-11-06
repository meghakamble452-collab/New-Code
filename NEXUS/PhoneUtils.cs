using System;
using System.Collections.Generic;
using System.Text;

namespace NEXUS;

public class PhoneUtils
{
	private static char[] decimalNumber;

	private static string[] phoneModels;

	private static string[] tacModels;

	private static string[] AndroidVersions;

	private static string[] AndroidOS;

	private static Dictionary<string, string> mapWithTACmodels;

	private static Dictionary<string, string> mapWithAndroidVersions;

	private static Random random;

	static PhoneUtils()
	{
		decimalNumber = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		string[] array = new string[10];
		string text = "SM-J100H";
		array[0] = text;
		string text2 = "U900-Soul";
		array[1] = text2;
		string text3 = "SGH-N100";
		array[2] = text3;
		string text4 = "SGH-X510";
		array[3] = text4;
		string text5 = "GT-I9060";
		array[4] = text5;
		string text6 = "GT-I8262";
		array[5] = text6;
		string text7 = "SGH-Z170";
		array[6] = text7;
		string text8 = "SGH-T408";
		array[7] = text8;
		string text9 = "SGH-S300";
		array[8] = text9;
		string text10 = "SM-G925F";
		array[9] = text10;
		phoneModels = array;
		string[] array2 = new string[10];
		string text11 = "35301007";
		array2[0] = text11;
		string text12 = "35599002";
		array2[1] = text12;
		string text13 = "35009791";
		array2[2] = text13;
		string text14 = "35463301";
		array2[3] = text14;
		string text15 = "35559106";
		array2[4] = text15;
		string text16 = "35283806";
		array2[5] = text16;
		string text17 = "35488901";
		array2[6] = text17;
		string text18 = "35106500";
		array2[7] = text18;
		string text19 = "35046790";
		array2[8] = text19;
		string text20 = "35952006";
		array2[9] = text20;
		tacModels = array2;
		string[] array3 = new string[13];
		string text21 = "5.0";
		array3[0] = text21;
		string text22 = "5.0.1";
		array3[1] = text22;
		string text23 = "5.0.2";
		array3[2] = text23;
		string text24 = "5.1";
		array3[3] = text24;
		string text25 = "5.1.1";
		array3[4] = text25;
		string text26 = "6.0";
		array3[5] = text26;
		string text27 = "6.0.1";
		array3[6] = text27;
		string text28 = "7.0";
		array3[7] = text28;
		string text29 = "7.1";
		array3[8] = text29;
		string text30 = "7.1.1";
		array3[9] = text30;
		string text31 = "7.1.2";
		array3[10] = text31;
		string text32 = "8.0";
		array3[11] = text32;
		string text33 = "8.1";
		array3[12] = text33;
		AndroidVersions = array3;
		string[] array4 = new string[13];
		string text34 = "21";
		array4[0] = text34;
		string text35 = "21";
		array4[1] = text35;
		string text36 = "21";
		array4[2] = text36;
		string text37 = "22";
		array4[3] = text37;
		string text38 = "22";
		array4[4] = text38;
		string text39 = "23";
		array4[5] = text39;
		string text40 = "23";
		array4[6] = text40;
		string text41 = "24";
		array4[7] = text41;
		string text42 = "25";
		array4[8] = text42;
		string text43 = "25";
		array4[9] = text43;
		string text44 = "25";
		array4[10] = text44;
		string text45 = "26";
		array4[11] = text45;
		string text46 = "27";
		array4[12] = text46;
		AndroidOS = array4;
		mapWithTACmodels = new Dictionary<string, string>();
		mapWithAndroidVersions = new Dictionary<string, string>();
		random = new Random();
		for (int i = 0; i < phoneModels.Length; i++)
		{
			mapWithTACmodels[phoneModels[i]] = tacModels[i];
		}
		for (int j = 0; j < AndroidVersions.Length; j++)
		{
			mapWithAndroidVersions[AndroidVersions[j]] = AndroidOS[j];
		}
	}

	public static string GetRandomModel()
	{
		return phoneModels[random.Next(phoneModels.Length)];
	}

	public static string GetRandomIMEIForModel(string phoneModel)
	{
		string text = mapWithTACmodels[phoneModel];
		string text2 = GenerateRandomSerialNumber();
		string text3 = text + text2;
		for (int i = 0; i < decimalNumber.Length; i++)
		{
			string text4 = text3 + decimalNumber[i];
			if (Check(text4))
			{
				return text4;
			}
		}
		return null;
	}

	private static string GenerateRandomSerialNumber()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append(decimalNumber[random.Next(decimalNumber.Length)]);
		}
		return stringBuilder.ToString();
	}

	public static bool Check(string ccNumber)
	{
		int num = 0;
		bool flag = false;
		for (int num2 = ccNumber.Length - 1; num2 >= 0; num2--)
		{
			int num3 = int.Parse(ccNumber.Substring(num2, 1));
			if (flag)
			{
				num3 *= 2;
				if (num3 > 9)
				{
					num3 = num3 % 10 + 1;
				}
			}
			num += num3;
			flag = !flag;
		}
		return num % 10 == 0;
	}

	public static string GetRandomBuildSerial()
	{
		string text = Guid.NewGuid().ToString();
		string oldValue = "-";
		return text.Replace(oldValue, "").Substring(0, 16);
	}

	public static string GetRandomPhoneBrand()
	{
		return "samsung";
	}

	public static string GetRandomBuildPhone()
	{
		string[] array = new string[6]
		{
			(GetRandomBigChar() + GetRandomBigChar() + GetRandomBigChar()).ToString(),
			null,
			null,
			null,
			null,
			null
		};
		string text = "/";
		array[1] = text;
		array[2] = GetRandomBigChar().ToString();
		array[3] = GetRandomNumber().ToString();
		array[4] = GetRandomBigChar().ToString();
		array[5] = GetRandomBigChar().ToString();
		return string.Concat(array);
	}

	public static char GetRandomBigChar()
	{
		string text = "QWERTYUIOPASDFGHJKLZXCVBNM";
		char[] array = text.ToCharArray();
		return array[random.Next(array.Length)];
	}

	public static int GetRandomNumber()
	{
		int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		return array[random.Next(array.Length)];
	}

	public static string GetRandomFingerPrint()
	{
		string format = "{0}{1}{2}.{3}{4}{5}{6}{7} release-keys";
		return string.Format(format, GetRandomNumber(), GetRandomBigChar(), GetRandomBigChar(), GetRandomBigChar(), GetRandomNumber(), GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
	}

	public static string GetRandomUserAgent()
	{
		string format = "Mozilla/5.0 (Linux; Android {0}; {1} Build/{2}{3}B{4}{5}M; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/59.0.3071.125 Safari/537.36";
		return string.Format(format, GetRandomAndroidOs(), GetRandomModel(), GetRandomBigChar(), GetRandomBigChar(), GetRandomNumber(), GetRandomNumber());
	}

	public static string GetRandomAndroidOs()
	{
		return AndroidVersions[random.Next(AndroidVersions.Length)];
	}

	public static string GetAndroidSdkByAndroidOs(string androidOs)
	{
		int i;
		for (i = 0; i < AndroidVersions.Length && !AndroidVersions[i].Equals(androidOs); i++)
		{
		}
		return AndroidOS[i];
	}

	public static string GetRandomGCMToken()
	{
		string text = "c_HgNKaAFHE:APA91bHO4OIMgJEuLHoN-KSNuIrbuHnzTmvp2PpqFSQ5FVtrY3ukGkH3WtEfMc74DMtGDynu0U9LOHiHIwMNAv8T_CdE_Wer-sfGnqyrOPBr9xCkOxsW6sceze8WreFIRr_GGxHeLN6I";
		string text2 = text;
		string[] array = new string[6];
		string text3 = "c_HgNKaAFHE";
		array[0] = TextUtils.getRandomStringAnyCase(text3.Length);
		string text4 = ":";
		array[1] = text4;
		string text5 = "c_HgNKaAFHE:";
		int length = text5.Length;
		string text6 = "APA91bHO4OIMgJEuLHoN-KSNuIrbuHnzTmvp2PpqFSQ5FVtrY3ukGkH3WtEfMc74DMtGDynu0U9LOHiHIwMNAv8T_CdE_Wer-";
		array[2] = text2.Substring(length, text6.Length);
		string text7 = "sfGnqyrOPBr9xCkOxsW6sceze8WreFIRr";
		array[3] = TextUtils.getRandomStringAnyCase(text7.Length);
		string text8 = "_";
		array[4] = text8;
		string text9 = "GGxHeLN6I";
		array[5] = TextUtils.getRandomStringAnyCase(text9.Length);
		return string.Concat(array);
	}

	public static string GetRandomAndroidId()
	{
		long num = Math.Abs(random.NextLong(1152921504606846976L, long.MaxValue));
		string format = "{0:x16}";
		return string.Format(format, num);
	}
}
