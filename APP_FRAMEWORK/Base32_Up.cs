using System;
using System.Text;

namespace APP_FRAMEWORK;

public static class Base32_Up
{
	private static readonly char[] char_0;

	private static int smethod_0(char char_1)
	{
		if (1 == 0)
		{
		}
		int result = char_1 switch
		{
			'2' => 26, 
			'3' => 27, 
			'4' => 28, 
			'5' => 29, 
			'6' => 30, 
			'7' => 31, 
			'A' => 0, 
			'B' => 1, 
			'C' => 2, 
			'D' => 3, 
			'E' => 4, 
			'F' => 5, 
			'G' => 6, 
			'H' => 7, 
			'I' => 8, 
			'J' => 9, 
			'K' => 10, 
			'L' => 11, 
			'M' => 12, 
			'N' => 13, 
			'O' => 14, 
			'P' => 15, 
			'Q' => 16, 
			'R' => 17, 
			'S' => 18, 
			'T' => 19, 
			'U' => 20, 
			'V' => 21, 
			'W' => 22, 
			'X' => 23, 
			'Y' => 24, 
			'Z' => 25, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static byte[] FromBase32String(string encoded)
	{
		if (encoded == null)
		{
			string paramName = "encoded";
			throw new ArgumentNullException(paramName);
		}
		encoded = encoded.Trim().TrimEnd('=').ToUpper();
		if (encoded.Length == 0)
		{
			return new byte[0];
		}
		byte[] array = new byte[encoded.Length * 5 / 8];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string text = encoded;
		int num5 = 0;
		char char_;
		while (true)
		{
			if (num5 < text.Length)
			{
				char_ = text[num5];
				num4 = smethod_0(char_);
				if (num4 < 0)
				{
					break;
				}
				num = (num << 5) | (num4 & 0x1F);
				num3 += 5;
				if (num3 >= 8)
				{
					array[num2++] = (byte)(num >> num3 - 8);
					num3 -= 8;
				}
				num5++;
				continue;
			}
			return array;
		}
		string text2 = "Illegal character: `";
		string text3 = char_.ToString();
		string text4 = "`";
		throw new FormatException(text2 + text3 + text4);
	}

	public static string ToBase32String(byte[] data, bool padOutput = false)
	{
		return ToBase32String(data, 0, data.Length, padOutput);
	}

	public static string ToBase32String(byte[] data, int offset, int length, bool padOutput = false)
	{
		if (data == null)
		{
			string paramName = "data";
			throw new ArgumentNullException(paramName);
		}
		if (offset >= 0)
		{
			if (length < 0)
			{
				string paramName2 = "length";
				throw new ArgumentOutOfRangeException(paramName2);
			}
			if (offset + length <= data.Length)
			{
				if (length != 0)
				{
					if (length < 268435456)
					{
						StringBuilder stringBuilder = new StringBuilder((length * 8 + 5 - 1) / 5);
						int num = offset + length;
						int num2 = data[offset++];
						int num3 = 8;
						while (num3 > 0 || offset < num)
						{
							if (num3 < 5)
							{
								if (offset < num)
								{
									num2 = (num2 << 8) | (data[offset++] & 0xFF);
									num3 += 8;
								}
								else
								{
									int num4 = 5 - num3;
									num2 <<= num4;
									num3 += num4;
								}
							}
							int num5 = 0x1F & (num2 >> num3 - 5);
							num3 -= 5;
							stringBuilder.Append(char_0[num5]);
						}
						if (padOutput)
						{
							int num6 = 8 - stringBuilder.Length % 8;
							if (num6 > 0)
							{
								stringBuilder.Append('=', (num6 != 8) ? num6 : 0);
							}
						}
						return stringBuilder.ToString();
					}
					string paramName3 = "data";
					throw new ArgumentOutOfRangeException(paramName3);
				}
				return string.Empty;
			}
			throw new ArgumentOutOfRangeException();
		}
		string paramName4 = "offset";
		throw new ArgumentOutOfRangeException(paramName4);
	}

	static Base32_Up()
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
		char_0 = text.ToCharArray();
	}
}
