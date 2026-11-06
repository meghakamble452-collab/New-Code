using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Driver.util;

namespace Driver;

internal class CryptoAkamai
{
	private static string PUBLIC_KEY_RSA;

	private static string DELIMETER_DATA;

	internal string AKAMAI_OUTPUT_FORMAT = "3,a,{0},{1}${2}$1000,1000,1000$$";

	internal byte[] aes128CBCEncrypt(byte[] plainTextBytes, byte[] aesKeyBytes, byte[] ivBytes)
	{
		return GetCBCRijndaelManaged(aesKeyBytes, ivBytes).CreateEncryptor().TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
	}

	internal byte[] aes128CBCDecrypt(byte[] encTextBytes, byte[] aesKeyBytes, byte[] ivBytes)
	{
		return GetCBCRijndaelManaged(aesKeyBytes, ivBytes).CreateDecryptor().TransformFinalBlock(encTextBytes, 0, encTextBytes.Length);
	}

	private RijndaelManaged GetCBCRijndaelManaged(byte[] secretKeyBytes, byte[] ivBytes)
	{
		return new RijndaelManaged
		{
			Mode = CipherMode.CBC,
			Padding = PaddingMode.PKCS7,
			KeySize = 128,
			BlockSize = 128,
			Key = secretKeyBytes,
			IV = ivBytes
		};
	}

	internal byte[] hmacSha256(byte[] message, byte[] key)
	{
		return new HMACSHA256(key).ComputeHash(message);
	}

	internal string rsaEncrypt(byte[] data)
	{
		return Convert.ToBase64String(PemKeyUtils.DecodeX509PublicKey(Convert.FromBase64String(PUBLIC_KEY_RSA)).Encrypt(data, fOAEP: false));
	}

	internal string concatData(List<Tuple<string, string>> list)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list.Count; i++)
		{
			if (i != 0)
			{
				StringBuilder stringBuilder2 = stringBuilder.Append(list[i].Item1);
				string value = ",";
				stringBuilder2.Append(value).Append(list[i].Item2);
			}
			else
			{
				stringBuilder.Append(list[i].Item2);
			}
			if (i != list.Count - 1)
			{
				stringBuilder.Append(DELIMETER_DATA);
			}
		}
		return stringBuilder.ToString();
	}

	internal int hashCustom(string str)
	{
		if (str != null && !str.Trim().Equals(""))
		{
			int i = 0;
			int num = 0;
			for (; i < str.Length; i++)
			{
				char c = str[i];
				if (c < '\u0080')
				{
					num += c;
				}
			}
			return num;
		}
		return -1;
	}

	internal long k(long l10, int n10)
	{
		int num = (int)l10;
		int num2 = (int)(l10 >> 32);
		int num3 = 0;
		int num4;
		while ((num4 = num3) < 16)
		{
			num3 = num4 + 1;
			num4 = num2 ^ (((n10 << num4) | TripleShift(n10, 32 - num4)) ^ num);
			num2 = num;
			num = num4;
		}
		l10 = num2;
		long num5 = num;
		return (l10 << 32) | (num5 & 0xFFFFFFFFu);
	}

	internal static long TripleShift(long n, int s)
	{
		if (n >= 0)
		{
			while (true)
			{
				int[,,] array = new int[2, 1, 5]
				{
					{ { 693035857, 499124221, -270266296, 1148462599, -1692943923 } },
					{ { -1692943920, 1231057937, -1382546396, -500175239, -535929648 } }
				};
				switch ((array[0, 0, 4] - 1701614445) ^ 0x35AB2661)
				{
				case 1:
					return n >> s;
				case 0:
					continue;
				}
				break;
			}
		}
		return (n >> s) + (2 << ~s);
	}

	public static int TripleShift(int n, int s)
	{
		if (n >= 0)
		{
			while (true)
			{
				int[,,,,] array = new int[2, 1, 5, 1, 1]
				{
					{ 
					{
						{ { -2144572174 } },
						{ { 501621199 } },
						{ { -1796133314 } },
						{ { 160597784 } },
						{ { -2144572175 } }
					} },
					{ 
					{
						{ { 2038855655 } },
						{ { 2031579823 } },
						{ { 1827845017 } },
						{ { -497279750 } },
						{ { -1259138179 } }
					} }
				};
				int num = array[0, 0, 0, 0, 0];
				switch (-2144572173 - num)
				{
				case 1:
					return n >> s;
				case 0:
					continue;
				}
				break;
			}
		}
		return (n >> s) + (2 << ~s);
	}

	internal string getPerfomanceString(ChromeUser chromeUser)
	{
		long num = Driver.util.Random.nextInt(2, 8);
		long num2 = Driver.util.Random.nextInt(1, 3);
		long num3 = Driver.util.Random.nextInt(10, 20);
		try
		{
			long num4 = uptimeMillis0();
			int i = 1;
			int num5 = 0;
			int num6 = 0;
			for (; i < 1000000; i++)
			{
				if (4508713 % i * 11 % i == 0)
				{
					num5++;
				}
				if (i % 100 == 0 && uptimeMillis0() - num4 > num)
				{
					break;
				}
				num6++;
			}
			int num7 = num6 / 100;
			float num8 = 33.34f;
			long num9 = uptimeMillis0();
			int num10 = 0;
			int num11 = 0;
			for (int j = 1; j < 1000000; j++)
			{
				num8 += (float)j;
				if (19.239f * num8 / 3.56f < 10000f)
				{
					num10++;
				}
				if (j % 100 == 0 && uptimeMillis0() - num9 > 2)
				{
					break;
				}
				num11++;
			}
			int num12 = num11 / 100;
			long num13 = uptimeMillis0();
			int num14 = 0;
			int num15 = 0;
			for (double num16 = 1.0; num16 < 1000000.0; num16 += 1.0)
			{
				if (Math.Sqrt(num16) > 30.0)
				{
					num14++;
				}
				if ((int)num16 % 100 == 0 && uptimeMillis0() - num13 > num2)
				{
					break;
				}
				num15++;
			}
			int num17 = num14;
			int num18 = num15 / 100;
			long num19 = uptimeMillis0();
			int num20 = 1;
			int num21 = 0;
			int num22 = 0;
			int num23 = 1000000;
			while (num20 < num23)
			{
				long num24 = num19;
				if (Math.Acos(num20 / num23) + Math.Asin(num20 / num23) + Math.Atan(num20 / 1000000) > 1.5)
				{
					num21++;
				}
				if (num20 % 100 == 0 && uptimeMillis0() - num24 > num3)
				{
					break;
				}
				num22++;
				num20++;
				num19 = num24;
				num23 = 1000000;
			}
			int num25 = num22 / 100;
			long num26 = uptimeMillis0();
			int num27 = 0;
			for (int k = 1; k < 1000000; k++)
			{
				if (uptimeMillis0() - num26 > 2)
				{
					break;
				}
				num27++;
			}
			string[] array = new string[17]
			{
				num5.ToString(),
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			string text = ",";
			array[1] = text;
			array[2] = num7.ToString();
			string text2 = ",";
			array[3] = text2;
			array[4] = num10.ToString();
			string text3 = ",";
			array[5] = text3;
			array[6] = num12.ToString();
			string text4 = ",";
			array[7] = text4;
			array[8] = num17.ToString();
			string text5 = ",";
			array[9] = text5;
			array[10] = num18.ToString();
			string text6 = ",";
			array[11] = text6;
			array[12] = num21.ToString();
			string text7 = ",";
			array[13] = text7;
			array[14] = num25.ToString();
			string text8 = ",";
			array[15] = text8;
			array[16] = num27.ToString();
			return string.Concat(array);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private long uptimeMillis0()
	{
		long num = System2.currentTimeMillis() - Driver.util.Random.nextInt(300000, 180000000);
		return System2.currentTimeMillis() - num;
	}

	internal string D0(string str)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		StringBuilder stringBuilder = new StringBuilder(bytes.Length);
		byte[] array = bytes;
		byte[] array2 = array;
		byte[] array3 = array2;
		foreach (byte b in array3)
		{
			if (b >= 33 && b <= 126 && b != 34 && b != 37 && b != 39 && b != 44 && b != 92)
			{
				stringBuilder.Append((char)b);
				continue;
			}
			stringBuilder.Append('%');
			char c = forDigit((b >> 4) & 0xF, 16);
			if (char.IsLetter(c))
			{
				c = (char)(c - 32);
			}
			stringBuilder.Append(c);
			char c2 = forDigit(b & 0xF, 16);
			if (char.IsLetter(c2))
			{
				c2 = (char)(c2 - 32);
			}
			stringBuilder.Append(c2);
		}
		return stringBuilder.ToString();
	}

	private char forDigit(int digit, int radix)
	{
		if (digit < radix && digit >= 0)
		{
			if (radix >= 2 && radix <= 36)
			{
				if (digit < 10)
				{
					return (char)(48 + digit);
				}
				return (char)(87 + digit);
			}
			return '\0';
		}
		return '\0';
	}

	static CryptoAkamai()
	{
		string pUBLIC_KEY_RSA = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDMUymkqr6SQfxqefXMdkI6E1tDzHispEm4WhZAfIWjhvEqfStzy16HvCjIBX2SRpn5pqW2w1TxqyxRnJOe4NEskWGdYY2y4JiD9vpYpWB54u6TOnKutXn2LzjMrvfIJpVXYZ5LYtD1ZUaeTKPz6qELXmBNcSfh/kGLiP8AH4eWKwIDAQAB";
		PUBLIC_KEY_RSA = pUBLIC_KEY_RSA;
		string dELIMETER_DATA = "-1,2,-94,";
		DELIMETER_DATA = dELIMETER_DATA;
	}
}
