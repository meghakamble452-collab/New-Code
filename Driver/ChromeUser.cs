using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Driver.intern.hook;
using Driver.intern.sensors;
using Driver.intern.touch;
using Driver.key;
using Driver.life;
using Driver.util;

namespace Driver;

internal class ChromeUser
{
	public static bool isTest;

	private SystemClock systemClock = new SystemClock();

	private long timeBeginSession = System2.currentTimeMillis() - Driver.util.Random.nextInt(120000, 190000);

	private string packageName = "cris.org.in.prs.ima";

	private string phoneRelease = "12";

	private string phoneModel = "SM-J730FM";

	private string phoneBootloader = "J730FMXXS7CUD2";

	private string phoneSDK = "32";

	private string phoneHardware = "samsungexynos7870";

	private string phoneAndroidId = getRandomAndroidID();

	private string phoneIncremental = "J730FMXXS7CUD2";

	private string phoneManufacture = "samsung";

	private string phoneProduct = "j7y17ltexxm";

	private string phoneDisplay = "PPR1.180610.011.J730FMXXS7CUD2";

	private string phoneBoard = "universal7870";

	private string phoneBrand = "samsung";

	private string phoneDevice = "j7y17lte";

	private string phoneFingerPrint = "samsung/j7y17ltexxm/j7y17lte:9/PPR1.180610.011/J730FMXXS7CUD2:user/release-keys";

	private string phoneHost = "SWDH4621";

	private string phoneId = "PPR1.180610.011";

	private string phoneBatteryCharge = Driver.util.Random.nextInt(30, 90).ToString();

	private int phoneHeightPixels = 1920;

	private int phoneWidthPixels = 1080;

	private string phoneData;

	private long timeCalculatePhoneData;

	private string perfomance_string = "default_performance";

	public ChromeUser()
	{
		Thread currentThread = Thread.CurrentThread;
		string name = "en-GB";
		currentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(name);
	}

	private long uptimeMillis()
	{
		long num = System2.currentTimeMillis() - Driver.util.Random.nextInt(300000, 180000000);
		return System2.currentTimeMillis() - num;
	}

	private static string getRandomAndroidID()
	{
		long num = Math.Abs((long)Driver.util.Random.nextUnLong()) + 1152921504606846976L;
		string text = "x16";
		return num.ToString(text);
	}

	internal long getTimeBeginSession()
	{
		return timeBeginSession;
	}

	private string getPhoneRelease()
	{
		return phoneRelease;
	}

	private string getPhoneModel()
	{
		return phoneModel;
	}

	private string getPhoneBootloader()
	{
		return phoneBootloader;
	}

	private string getPhoneSDK()
	{
		return phoneSDK;
	}

	private string getPhoneHardware()
	{
		return phoneHardware;
	}

	private string getPackageName()
	{
		return packageName;
	}

	private string getPhoneAndroidId()
	{
		return phoneAndroidId;
	}

	private string getPhoneIncremental()
	{
		return phoneIncremental;
	}

	private string getPhoneManufacture()
	{
		return phoneManufacture;
	}

	private string getPhoneProduct()
	{
		return phoneProduct;
	}

	private string getPhoneBoard()
	{
		return phoneBoard;
	}

	private string getPhoneDisplay()
	{
		return phoneDisplay;
	}

	private string getPhoneBrand()
	{
		return phoneBrand;
	}

	private string getPhoneDevice()
	{
		return phoneDevice;
	}

	private string getPhoneFingerPrint()
	{
		return phoneFingerPrint;
	}

	private string getPhoneHost()
	{
		return phoneHost;
	}

	private string getPhoneId()
	{
		return phoneId;
	}

	private string getPhoneBatteryCharge()
	{
		return phoneBatteryCharge;
	}

	private int getPhoneHeightPixels()
	{
		return phoneHeightPixels;
	}

	private int getPhoneWidthPixels()
	{
		return phoneWidthPixels;
	}

	private string getPhoneData()
	{
		if (phoneData == null)
		{
			phoneData = generatePhoneData();
		}
		return phoneData;
	}

	private void setTimeCalculatePhoneData(long timeCalculatePhoneData)
	{
		this.timeCalculatePhoneData = timeCalculatePhoneData;
	}

	private long getTimeCalculatePhoneData()
	{
		return timeCalculatePhoneData;
	}

	private string getPerfomance_string()
	{
		return perfomance_string;
	}

	private void setPerfomance_string(string perfomance_string)
	{
		this.perfomance_string = perfomance_string;
	}

	private string generatePhoneData()
	{
		CryptoAkamai cryptoAkamai = new CryptoAkamai();
		long num = uptimeMillis();
		int value = getPhoneHeightPixels();
		int value2 = getPhoneWidthPixels();
		int value3 = Driver.util.Random.nextInt(1, 3);
		string text = "in";
		string str = text;
		string str2 = getPhoneRelease();
		int value4 = Driver.util.Random.nextInt(0, 2);
		string str3 = getPhoneModel();
		string str4 = getPhoneBootloader();
		string value5 = getPhoneSDK();
		string str5 = getPhoneHardware();
		string value6 = getPackageName();
		string value7 = getPhoneAndroidId();
		long num2 = num;
		string text2 = "REL";
		string str6 = text2;
		string str7 = getPhoneIncremental();
		string str8 = getPhoneManufacture();
		string str9 = getPhoneProduct();
		string text3 = "release-keys";
		string str10 = text3;
		string text4 = "user";
		string str11 = text4;
		string text5 = "dpi";
		string str12 = text5;
		string str13 = getPhoneDisplay();
		string str14 = getPhoneBoard();
		string str15 = getPhoneBrand();
		string str16 = getPhoneDevice();
		string str17 = getPhoneFingerPrint();
		string str18 = getPhoneHost();
		string str19 = getPhoneId();
		StringBuilder stringBuilder = new StringBuilder();
		string value8 = "-1";
		stringBuilder.Append(value8);
		string value9 = ",uaend,-1,";
		stringBuilder.Append(value9);
		stringBuilder.Append(value);
		string value10 = ",";
		stringBuilder.Append(value10);
		stringBuilder.Append(value2);
		string value11 = ",";
		stringBuilder.Append(value11);
		stringBuilder.Append(1);
		string value12 = ",";
		stringBuilder.Append(value12);
		stringBuilder.Append(getPhoneBatteryCharge());
		string value13 = ",";
		stringBuilder.Append(value13);
		stringBuilder.Append(value3);
		string value14 = ",";
		stringBuilder.Append(value14);
		stringBuilder.Append(cryptoAkamai.D0(str));
		string value15 = ",";
		stringBuilder.Append(value15);
		stringBuilder.Append(cryptoAkamai.D0(str2));
		string value16 = ",";
		stringBuilder.Append(value16);
		stringBuilder.Append(value4);
		string value17 = ",";
		stringBuilder.Append(value17);
		stringBuilder.Append(cryptoAkamai.D0(str3));
		string value18 = ",";
		stringBuilder.Append(value18);
		stringBuilder.Append(cryptoAkamai.D0(str4));
		string value19 = ",";
		stringBuilder.Append(value19);
		stringBuilder.Append(cryptoAkamai.D0(str5));
		string value20 = ",";
		stringBuilder.Append(value20);
		string str20 = "-1";
		stringBuilder.Append(cryptoAkamai.D0(str20));
		string value21 = ",";
		stringBuilder.Append(value21);
		stringBuilder.Append(value6);
		string value22 = ",";
		stringBuilder.Append(value22);
		string str21 = "-1";
		stringBuilder.Append(cryptoAkamai.D0(str21));
		string value23 = ",-1,";
		stringBuilder.Append(value23);
		stringBuilder.Append(value7);
		string value24 = ",-1,";
		stringBuilder.Append(value24);
		stringBuilder.Append(0);
		string value25 = ",";
		stringBuilder.Append(value25);
		stringBuilder.Append(0);
		string value26 = ",";
		stringBuilder.Append(value26);
		stringBuilder.Append(cryptoAkamai.D0(str6));
		string value27 = ",";
		stringBuilder.Append(value27);
		stringBuilder.Append(cryptoAkamai.D0(str7));
		string value28 = ",";
		stringBuilder.Append(value28);
		stringBuilder.Append(value5);
		string value29 = ",";
		stringBuilder.Append(value29);
		stringBuilder.Append(cryptoAkamai.D0(str8));
		string value30 = ",";
		stringBuilder.Append(value30);
		stringBuilder.Append(cryptoAkamai.D0(str9));
		string value31 = ",";
		stringBuilder.Append(value31);
		stringBuilder.Append(cryptoAkamai.D0(str10));
		string value32 = ",";
		stringBuilder.Append(value32);
		stringBuilder.Append(cryptoAkamai.D0(str11));
		string value33 = ",";
		stringBuilder.Append(value33);
		stringBuilder.Append(cryptoAkamai.D0(str12));
		string value34 = ",";
		stringBuilder.Append(value34);
		stringBuilder.Append(cryptoAkamai.D0(str13));
		string value35 = ",";
		stringBuilder.Append(value35);
		stringBuilder.Append(cryptoAkamai.D0(str14));
		string value36 = ",";
		stringBuilder.Append(value36);
		stringBuilder.Append(cryptoAkamai.D0(str15));
		string value37 = ",";
		stringBuilder.Append(value37);
		stringBuilder.Append(cryptoAkamai.D0(str16));
		string value38 = ",";
		stringBuilder.Append(value38);
		stringBuilder.Append(cryptoAkamai.D0(str17));
		string value39 = ",";
		stringBuilder.Append(value39);
		stringBuilder.Append(cryptoAkamai.D0(str18));
		string value40 = ",";
		stringBuilder.Append(value40);
		stringBuilder.Append(cryptoAkamai.D0(str19));
		Thread.Sleep(Driver.util.Random.nextInt(1, 2));
		setTimeCalculatePhoneData(uptimeMillis() - num2);
		return stringBuilder.ToString();
	}

	public string buildAkamaiHeader()
	{
		return buildChromeHeader(HookEvent.Webmtoken);
	}

	internal string buildChromeHeader(HookEvent hookEvent)
	{
		CryptoAkamai cryptoAkamai = new CryptoAkamai();
		SensorsUtils sensorsUtils = new SensorsUtils();
		TouchUtils touchUtils = new TouchUtils();
		KeysUtils keysUtils = new KeysUtils();
		ActivityUtils activityUtils = new ActivityUtils();
		string text = getPerfomance_string();
		string value = "default_performance";
		if (text.Equals(value))
		{
			setPerfomance_string(cryptoAkamai.getPerfomanceString(this));
		}
		long num = uptimeMillis();
		string text2 = getPhoneData();
		string[] array = new string[7] { text2, null, null, null, null, null, null };
		string text3 = ",";
		array[1] = text3;
		array[2] = cryptoAkamai.hashCustom(text2).ToString();
		string text4 = ",";
		array[3] = text4;
		array[4] = Driver.util.Random.nextInt(int.MaxValue).ToString();
		string text5 = ",";
		array[5] = text5;
		array[6] = (getTimeBeginSession() / 2).ToString();
		string item = string.Concat(array);
		Tuple<Tuple<string, string>, long, long> orientationRandomData = sensorsUtils.getOrientationRandomData();
		Tuple<Tuple<string, string>, long, long> motionRandomData = sensorsUtils.getMotionRandomData();
		Tuple<Tuple<string, long>, long> randomTouchData = touchUtils.getRandomTouchData();
		Tuple<string, long> item2 = randomTouchData.Item1;
		Tuple<Tuple<string, long>, long> randomKeyData = keysUtils.getRandomKeyData(hookEvent);
		Tuple<string, long> item3 = randomKeyData.Item1;
		string item4 = item3.Item1;
		string item5 = item2.Item1;
		string editTextsList = keysUtils.getEditTextsList(hookEvent);
		string randomActivityData = activityUtils.getRandomActivityData(hookEvent, this);
		string text6 = "do_en,dm_en,t_en";
		string item6 = text6;
		long num2 = (uptimeMillis() - num) * 1000;
		int num3 = 0;
		long num4 = item3.Item2 + item2.Item2 + orientationRandomData.Item2 + motionRandomData.Item2;
		long num5 = System2.currentTimeMillis() - getTimeBeginSession();
		long item7 = randomKeyData.Item2;
		long item8 = randomTouchData.Item2;
		string[] array2 = new string[29];
		array2[0] = item3.Item2.ToString();
		string text7 = ",";
		array2[1] = text7;
		array2[2] = item2.Item2.ToString();
		string text8 = ",";
		array2[3] = text8;
		array2[4] = orientationRandomData.Item2.ToString();
		string text9 = ",";
		array2[5] = text9;
		array2[6] = motionRandomData.Item2.ToString();
		string text10 = ",";
		array2[7] = text10;
		array2[8] = num4.ToString();
		string text11 = ",";
		array2[9] = text11;
		array2[10] = num5.ToString();
		string text12 = ",";
		array2[11] = text12;
		array2[12] = item7.ToString();
		string text13 = ",";
		array2[13] = text13;
		array2[14] = item8.ToString();
		string text14 = ",";
		array2[15] = text14;
		array2[16] = orientationRandomData.Item3.ToString();
		string text15 = ",";
		array2[17] = text15;
		array2[18] = motionRandomData.Item3.ToString();
		string text16 = ",";
		array2[19] = text16;
		array2[20] = (getTimeCalculatePhoneData() * 1000).ToString();
		string text17 = ",";
		array2[21] = text17;
		array2[22] = (num2 / 4).ToString();
		string text18 = ",";
		array2[23] = text18;
		array2[24] = 1.ToString();
		string text19 = ",";
		array2[25] = text19;
		array2[26] = cryptoAkamai.k(((long)(int)num4 << 32) | ((int)(item7 + item8 + orientationRandomData.Item3 + motionRandomData.Item3) & 0xFFFFFFFFu), (int)num5).ToString();
		string text20 = ",";
		array2[27] = text20;
		array2[28] = getTimeBeginSession().ToString();
		string item9 = string.Concat(array2);
		string text21 = num3.ToString();
		string text22 = ",";
		string item10 = text21 + text22 + 0;
		string item11 = orientationRandomData.Item1.Item1;
		string item12 = motionRandomData.Item1.Item1;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		string item13 = "3.3.0";
		list.Add(new Tuple<string, string>("", item13));
		string item14 = "-70";
		list.Add(new Tuple<string, string>(item14, ""));
		string item15 = "-80";
		list.Add(new Tuple<string, string>(item15, ""));
		string item16 = "-100";
		list.Add(new Tuple<string, string>(item16, item));
		string item17 = "-101";
		list.Add(new Tuple<string, string>(item17, item6));
		string item18 = "-102";
		list.Add(new Tuple<string, string>(item18, editTextsList));
		string item19 = "-103";
		list.Add(new Tuple<string, string>(item19, randomActivityData));
		string item20 = "-108";
		list.Add(new Tuple<string, string>(item20, item4));
		string item21 = "-112";
		list.Add(new Tuple<string, string>(item21, getPerfomance_string()));
		string item22 = "-115";
		list.Add(new Tuple<string, string>(item22, item9));
		string item23 = "-117";
		list.Add(new Tuple<string, string>(item23, item5));
		string item24 = "-120";
		list.Add(new Tuple<string, string>(item24, ""));
		string item25 = "-121";
		list.Add(new Tuple<string, string>(item25, ""));
		string item26 = "-144";
		list.Add(new Tuple<string, string>(item26, orientationRandomData.Item1.Item2));
		string item27 = "-142";
		list.Add(new Tuple<string, string>(item27, item11));
		string item28 = "-145";
		list.Add(new Tuple<string, string>(item28, motionRandomData.Item1.Item2));
		string item29 = "-143";
		list.Add(new Tuple<string, string>(item29, item12));
		string item30 = "-150";
		list.Add(new Tuple<string, string>(item30, item10));
		string value2 = "ArrayList<Tuple<string, string>> list2 = new ArrayList<>();";
		StringBuilder stringBuilder = new StringBuilder(value2);
		foreach (Tuple<string, string> item31 in list)
		{
			string value3 = "\r\n";
			StringBuilder stringBuilder2 = stringBuilder.Append(value3);
			string format = "list2.add(new Tuple<string, string>(\"{0}\", \"{1}\"));";
			stringBuilder2.Append(string.Format(format, item31.Item1, item31.Item2));
		}
		if (isTest)
		{
			foreach (Tuple<string, string> item32 in list)
			{
				string format2 = "\"{0}\", \"{1}\"";
				Console.WriteLine(string.Format(format2, item32.Item1, item32.Item2));
			}
		}
		string text23 = cryptoAkamai.concatData(list);
		if (isTest)
		{
			Console.WriteLine(text23);
		}
		byte[] array3 = new byte[16];
		byte[] array4 = new byte[32];
		byte[] array5 = new byte[16];
		Driver.util.Random.nextBytes(array3);
		Driver.util.Random.nextBytes(array4);
		Driver.util.Random.nextBytes(array5);
		byte[] array6 = cryptoAkamai.aes128CBCEncrypt(Encoding.UTF8.GetBytes(text23), array3, array5);
		byte[] array7 = new byte[array5.Length + array6.Length];
		Array.Copy(array5, 0, array7, 0, array5.Length);
		Array.Copy(array6, 0, array7, array5.Length, array6.Length);
		byte[] array8 = cryptoAkamai.hmacSha256(array7, array4);
		byte[] array9 = new byte[array7.Length + array8.Length];
		Array.Copy(array7, 0, array9, 0, array7.Length);
		Array.Copy(array8, 0, array9, array7.Length, array8.Length);
		string arg = Convert.ToBase64String(array9);
		string arg2 = cryptoAkamai.rsaEncrypt(array3);
		string arg3 = cryptoAkamai.rsaEncrypt(array4);
		return string.Format(cryptoAkamai.AKAMAI_OUTPUT_FORMAT, arg2, arg3, arg);
	}
}
