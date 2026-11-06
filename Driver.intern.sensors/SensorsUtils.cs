using System;
using System.Text;
using Driver.util;

namespace Driver.intern.sensors;

internal class SensorsUtils
{
	private long[] a_a = new long[256]
	{
		3523407757L, 2768625435L, 1007455905L, 1259060791L, 3580832660L, 2724731650L, 996231864L, 1281784366L, 3705235391L, 2883475241L,
		852952723L, 1171273221L, 3686048678L, 2897449776L, 901431946L, 1119744540L, 3484811241L, 3098726271L, 565944005L, 1455205971L,
		3369614320L, 3219065702L, 651582172L, 1372678730L, 3245242331L, 3060352845L, 794826487L, 1483155041L, 3322131394L, 2969862996L,
		671994606L, 1594548856L, 3916222277L, 2657877971L, 123907689L, 1885708031L, 3993045852L, 2567322570L, 1010288L, 1997036262L,
		3887548279L, 2427484129L, 163128923L, 2126386893L, 3772416878L, 2547889144L, 248832578L, 2043925204L, 4108050209L, 2212294583L,
		450215437L, 1842515611L, 4088798008L, 2226203566L, 498629140L, 1790921346L, 4194326291L, 2366072709L, 336475711L, 1661535913L,
		4251816714L, 2322244508L, 325317158L, 1684325040L, 2766056989L, 3554254475L, 1255198513L, 1037565863L, 2746444292L, 3568589458L,
		1304234792L, 985283518L, 2852464175L, 3707901625L, 1141589763L, 856455061L, 2909332022L, 3664761504L, 1130791706L, 878818188L,
		3110715001L, 3463352047L, 1466425173L, 543223747L, 3187964512L, 3372436214L, 1342839628L, 655174618L, 3081909835L, 3233089245L,
		1505515367L, 784033777L, 2967466578L, 3352871620L, 1590793086L, 701932520L, 2679148245L, 3904355907L, 1908338681L, 112844655L,
		2564639436L, 4024072794L, 1993550816L, 30677878L, 2439710439L, 3865851505L, 2137352139L, 140662621L, 2517025534L, 3775001192L,
		2013832146L, 252678980L, 2181537457L, 4110462503L, 1812594589L, 453955339L, 2238339752L, 4067256894L, 1801730948L, 476252946L,
		2363233923L, 4225443349L, 1657960367L, 366298937L, 2343686810L, 4239843852L, 1707062198L, 314082080L, 1069182125L, 1220369467L,
		3518238081L, 2796764439L, 953657524L, 1339070498L, 3604597144L, 2715744526L, 828499103L, 1181144073L, 3748627891L, 2825434405L,
		906764422L, 1091244048L, 3624026538L, 2936369468L, 571309257L, 1426738271L, 3422756325L, 3137613171L, 627095760L, 1382516806L,
		3413039612L, 3161057642L, 752284923L, 1540473965L, 3268974039L, 3051332929L, 733688034L, 1555824756L, 3316994510L, 2998034776L,
		81022053L, 1943239923L, 3940166985L, 2648514015L, 62490748L, 1958656234L, 3988253008L, 2595281350L, 168805463L, 2097738945L,
		3825313147L, 2466682349L, 224526414L, 2053451992L, 3815530850L, 2490061300L, 425942017L, 1852075159L, 4151131437L, 2154433979L,
		504272920L, 1762240654L, 4026595636L, 2265434530L, 397988915L, 1623188645L, 4189500703L, 2393998729L, 282398762L, 1741824188L,
		4275794182L, 2312913296L, 1231433021L, 1046551979L, 2808630289L, 3496967303L, 1309403428L, 957143474L, 2684717064L, 3607279774L,
		1203610895L, 817534361L, 2847130659L, 3736401077L, 1087398166L, 936857984L, 2933784634L, 3654889644L, 1422998873L, 601230799L,
		3135200373L, 3453512931L, 1404893504L, 616286678L, 3182598252L, 3400902906L, 1510651243L, 755860989L, 3020215367L, 3271812305L,
		1567060338L, 710951396L, 3010007134L, 3295551688L, 1913130485L, 84884835L, 2617666777L, 3942734927L, 1969605100L, 40040826L,
		2607524032L, 3966539862L, 2094237127L, 198489425L, 2464015595L, 3856323709L, 2076066270L, 213479752L, 2511347954L, 3803648100L,
		1874795921L, 414723335L, 2175892669L, 4139142187L, 1758648712L, 534112542L, 2262612132L, 4057696306L, 1633981859L, 375629109L,
		2406151311L, 4167943193L, 1711886778L, 286155052L, 2282172566L, 4278190080L
	};

	private static int[] values_count = new int[1] { 128 };

	private Tuple<string, long> o(float[] fArr, float f2)
	{
		int num = fArr.Length;
		float[] array = new float[num];
		Array.Copy(fArr, 0, array, 0, fArr.Length);
		Tuple<float, float> tuple = n(fArr);
		float item = tuple.Item1;
		float item2 = tuple.Item2;
		string text = G(L(fArr, item, item2));
		long num2 = a(text);
		float num3 = b(item);
		float num4 = b(item2);
		object[] array2 = new object[4] { num3, null, null, null };
		string text2 = "Incorrect sensor data";
		string text3 = text2;
		array2[1] = num4;
		array2[2] = num2;
		array2[3] = text;
		string format = "2;{0:0.00};{1:0.00};{2};{3}";
		string text4 = string.Format(format, array2);
		long num5 = (long)Math.Round(num4 * 100f + num3 * 100f) + num2;
		if (BitCount(num) != 1)
		{
			string message = "Length must be power of 2";
			throw new ArgumentException(message);
		}
		a0(array, 0, num, new float[num]);
		float[] array3 = new float[num];
		for (int i = 0; i < num; i++)
		{
			array3[i] = Math.Abs(array[i]);
		}
		Array.Sort(array3);
		float num6 = array3[(int)Math.Floor((float)(num - 1) * f2)];
		for (int j = 0; j < num; j++)
		{
			if (Math.Abs(array[j]) < num6)
			{
				array[j] = 0f;
			}
		}
		float f3 = array[0];
		int num7 = num - 1;
		float[] array4 = new float[num7];
		Array.Copy(array, 1, array4, 0, num7);
		Tuple<float, float> tuple2 = n(array4);
		float item3 = tuple2.Item1;
		float item4 = tuple2.Item2;
		string text5 = G(L(array4, item3, item4));
		int length = text5.Length;
		long num8 = a(text5);
		float num9 = b(item3);
		float num10 = b(item4);
		float num11 = b(f3);
		float num12 = num10 * 100f;
		long num13 = (long)Math.Round(num11 * 100f + num12 + num9 * 100f) + num8;
		long item5;
		if (text.Length - length >= 20)
		{
			item5 = num13;
			string format2 = "1;{0:0.00};{1:0.00};{2:0.00};{3};{4}";
			text4 = string.Format(format2, num9, num10, num11, num8, text5);
		}
		else
		{
			item5 = num5;
		}
		if (text4.Length == 0)
		{
			string text6 = "0;";
			text4 = text6 + text3;
			item5 = 0L;
		}
		return new Tuple<string, long>(text4, item5);
	}

	private int BitCount(int n)
	{
		int num = 0;
		while (n != 0)
		{
			num++;
			n &= n - 1;
		}
		return num;
	}

	private void a0(float[] fArr, int i2, int i3, float[] fArr2)
	{
		if (i3 != 1)
		{
			int num = i3 / 2;
			for (int j = 0; j < num; j++)
			{
				int num2 = i2 + j;
				float num3 = fArr[num2];
				float num4 = fArr[i2 + i3 - 1 - j];
				fArr2[num2] = num3 + num4;
				fArr2[num2 + num] = (num3 - num4) / ((float)Math.Cos(((double)j + 0.5) * Math.PI / (double)i3) * 2f);
			}
			a0(fArr2, i2, num, fArr);
			int num5 = i2 + num;
			a0(fArr2, num5, num, fArr);
			for (int k = 0; k < num - 1; k++)
			{
				int num6 = k * 2 + i2;
				int num7 = i2 + k;
				fArr[num6] = fArr2[num7];
				int num8 = num7 + num;
				fArr[num6 + 1] = fArr2[num8] + fArr2[num8 + 1];
			}
			int num9 = i2 + i3;
			fArr[num9 - 2] = fArr2[num5 - 1];
			int num10 = num9 - 1;
			fArr[num10] = fArr2[num10];
		}
	}

	private float b(float f2)
	{
		return (float)Math.Round(f2 * 100f) / 100f;
	}

	private long a(string str)
	{
		int length = str.Length;
		long num = 0L;
		for (int i = 0; i < length; i++)
		{
			int num2 = (int)((0xFF & num) ^ str[i]);
			num = CryptoAkamai.TripleShift(num, 8) ^ a_a[num2];
		}
		return num;
	}

	private string G(string str)
	{
		int length = str.Length;
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (num < length)
		{
			int i = num + 1;
			char c = str[num];
			int num2 = 1;
			for (; i < length && c == str[i]; i++)
			{
				num2++;
			}
			if (num2 > 1)
			{
				stringBuilder.Append(num2);
			}
			stringBuilder.Append(c);
			num = i;
		}
		return stringBuilder.ToString();
	}

	private string L(float[] fArr, float f2, float f3)
	{
		int num = fArr.Length;
		StringBuilder stringBuilder = new StringBuilder();
		float num2 = (f3 - f2) / 60f;
		for (int i = 0; i < num; i++)
		{
			char c = (char)((int)Math.Floor((fArr[i] - f2) / num2) + 65);
			if (fArr[i] == f3)
			{
				c = '}';
			}
			switch (c)
			{
			case '\\':
				c = '.';
				break;
			case '.':
				c = '\\';
				break;
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	private Tuple<float, float> n(float[] fArr)
	{
		float num = fArr[0];
		float num2 = fArr[0];
		foreach (float num3 in fArr)
		{
			if (num3 < num)
			{
				num = num3;
			}
			else if (num3 > num2)
			{
				num2 = num3;
			}
		}
		return new Tuple<float, float>(num, num2);
	}

	internal Tuple<Tuple<string, string>, long, long> getOrientationRandomData()
	{
		float[][] array = generateRandomOrientation();
		return getOrientationData(array[0], array[1], array[2], array[3]);
	}

	private Tuple<Tuple<string, string>, long, long> getOrientationData(float[] azimut, float[] pitch, float[] roll, float[] timestamps)
	{
		Tuple<string, long> tuple = o(azimut, 0.6f);
		Tuple<string, long> tuple2 = o(pitch, 0.6f);
		Tuple<string, long> tuple3 = o(roll, 0.6f);
		Tuple<string, long> tuple4 = o(timestamps, 0f);
		string[] array = new string[5] { tuple.Item1, null, null, null, null };
		string text = ":";
		array[1] = text;
		array[2] = tuple2.Item1;
		string text2 = ":";
		array[3] = text2;
		array[4] = tuple3.Item1;
		Tuple<string, string> item = new Tuple<string, string>(string.Concat(array), tuple4.Item1);
		long item2 = tuple.Item2 + tuple2.Item2 + tuple3.Item2;
		return new Tuple<Tuple<string, string>, long, long>(item, item2, azimut.Length);
	}

	internal Tuple<Tuple<string, string>, long, long> getMotionRandomData()
	{
		float[][] array = generateRandomMotion();
		return getMotionData(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9]);
	}

	private Tuple<Tuple<string, string>, long, long> getMotionData(float[] ax, float[] ay, float[] az, float[] agx, float[] agy, float[] agz, float[] gx, float[] gy, float[] gz, float[] timestamps)
	{
		Tuple<string, long> tuple = o(ax, 0.6f);
		Tuple<string, long> tuple2 = o(ay, 0.6f);
		Tuple<string, long> tuple3 = o(az, 0.6f);
		Tuple<string, long> tuple4 = o(agx, 0.6f);
		Tuple<string, long> tuple5 = o(agy, 0.6f);
		Tuple<string, long> tuple6 = o(agz, 0.6f);
		Tuple<string, long> tuple7 = o(gx, 0.6f);
		Tuple<string, long> tuple8 = o(gy, 0.6f);
		Tuple<string, long> tuple9 = o(gz, 0.6f);
		Tuple<string, long> tuple10 = o(timestamps, 0f);
		string[] array = new string[17]
		{
			tuple.Item1, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null
		};
		string text = ":";
		array[1] = text;
		array[2] = tuple2.Item1;
		string text2 = ":";
		array[3] = text2;
		array[4] = tuple3.Item1;
		string text3 = ":";
		array[5] = text3;
		array[6] = tuple4.Item1;
		string text4 = ":";
		array[7] = text4;
		array[8] = tuple5.Item1;
		string text5 = ":";
		array[9] = text5;
		array[10] = tuple6.Item1;
		string text6 = ":";
		array[11] = text6;
		array[12] = tuple7.Item1;
		string text7 = ":";
		array[13] = text7;
		array[14] = tuple8.Item1;
		string text8 = ":";
		array[15] = text8;
		array[16] = tuple9.Item1;
		return new Tuple<Tuple<string, string>, long, long>(new Tuple<string, string>(string.Concat(array), tuple10.Item1), tuple.Item2 + tuple2.Item2 + tuple3.Item2 + tuple4.Item2 + tuple5.Item2 + tuple6.Item2 + tuple7.Item2 + tuple8.Item2 + tuple9.Item2, ax.Length);
	}

	private float[][] generateRandomOrientation()
	{
		int num = values_count[Driver.util.Random.nextInt(values_count.Length)];
		float[] array = new float[num];
		float num2 = Driver.util.Random.nextInt(0, 45);
		float num3 = Driver.util.Random.nextInt(0, 10);
		float[] array2 = new float[num];
		float num4 = 0.7f;
		float num5 = 0.07f;
		float[] array3 = new float[num];
		float num6 = -0.5f;
		float num7 = 0.04f;
		float[] array4 = new float[num];
		float num8 = 200f;
		float num9 = Driver.util.Random.nextInt(0, 50);
		for (int i = 0; i < num; i++)
		{
			array[i] = randfloatSmall(num2, num3, 6);
			array2[i] = randfloatSmall(num4, num5, 6);
			array3[i] = randfloatSmall(num6, num7, 6);
			array4[i] = randfloatSmall(num8, num9, 0);
		}
		array4[0] = Driver.util.Random.nextInt(600, 900);
		return new float[4][] { array, array2, array3, array4 };
	}

	private float[][] generateRandomMotion()
	{
		int num = values_count[Driver.util.Random.nextInt(values_count.Length)];
		float[] array = new float[num];
		double center = 0.02;
		double region = 0.008;
		float[] array2 = new float[num];
		double center2 = 0.03;
		double region2 = 0.01;
		float[] array3 = new float[num];
		double center3 = 0.1;
		double region3 = 0.04;
		float[] array4 = new float[num];
		double center4 = 0.1;
		Driver.util.Random.nextInt(0, 45);
		double region4 = 0.04;
		Driver.util.Random.nextInt(0, 10);
		float[] array5 = new float[num];
		double center5 = 0.04;
		double region5 = 0.01;
		float[] array6 = new float[num];
		double center6 = -10.0;
		double region6 = 0.05;
		float[] array7 = new float[num];
		double center7 = 0.2;
		double region7 = 0.4;
		Driver.util.Random.nextInt(0, 10);
		float[] array8 = new float[num];
		double center8 = 0.3;
		double region8 = 0.03;
		float[] array9 = new float[num];
		double center9 = -0.2;
		double region9 = 0.02;
		Driver.util.Random.nextInt(0, 10);
		float[] array10 = new float[num];
		double center10 = 100.0;
		double region10 = Driver.util.Random.nextInt(0, 30);
		for (int i = 0; i < num; i++)
		{
			array[i] = randfloatSmall(center, region, 8);
			array2[i] = randfloatSmall(center2, region2, 8);
			array3[i] = randfloatSmall(center3, region3, 8);
			array4[i] = randfloatSmall(center4, region4, 8);
			array5[i] = randfloatSmall(center5, region5, 8);
			array6[i] = randfloatSmall(center6, region6, 8);
			array7[i] = randfloatSmall(center7, region7, 8);
			array8[i] = randfloatSmall(center8, region8, 8);
			array9[i] = randfloatSmall(center9, region9, 8);
			array10[i] = randfloatSmall(center10, region10, 0);
		}
		array10[0] = Driver.util.Random.nextInt(600, 900);
		return new float[10][] { array, array2, array3, array4, array5, array6, array7, array8, array9, array10 };
	}

	private float randfloatSmall(double center, double region, int accurate)
	{
		double num = center - region + (ChromeUser.isTest ? 0.5 : Driver.util.Random.nextDouble()) * (2.0 * region);
		double num2 = Math.Pow(10.0, accurate);
		return (float)(Math.Round(num * num2) / num2);
	}
}
