using System;
using System.IO;
using System.Text;

namespace IRCommDLL;

public static class Encryption_Up
{
	public static string Encrypt(string data, string key)
	{
		string text = "==";
		return text + Base32_Up.ToBase32String(Encrypt(Encoding.Unicode.GetBytes(data), Encoding.Unicode.GetBytes(key))).ToUpper();
	}

	public static string Decrypt(string data, string key)
	{
		try
		{
			byte[] bytes = Decrypt(Base32_Up.FromBase32String(data.Substring(2).ToUpper()), Encoding.Unicode.GetBytes(key));
			return Encoding.Unicode.GetString(bytes);
		}
		catch
		{
			return string.Empty;
		}
	}

	public static byte[] Encrypt(byte[] data, byte[] key)
	{
		uint[] uint_ = smethod_1(key);
		uint[] array = new uint[2];
		byte[] array2 = new byte[smethod_0(data.Length + 4)];
		byte[] bytes = BitConverter.GetBytes(data.Length);
		Array.Copy(bytes, array2, bytes.Length);
		Array.Copy(data, 0, array2, bytes.Length, data.Length);
		MemoryStream memoryStream = new MemoryStream(array2);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				for (int i = 0; i < array2.Length; i += 8)
				{
					array[0] = BitConverter.ToUInt32(array2, i);
					array[1] = BitConverter.ToUInt32(array2, i + 4);
					smethod_2(32u, array, uint_);
					binaryWriter.Write(array[0]);
					binaryWriter.Write(array[1]);
				}
				return array2;
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] Decrypt(byte[] data, byte[] key)
	{
		if (data.Length % 8 == 0)
		{
			uint[] uint_ = smethod_1(key);
			uint[] array = new uint[2];
			byte[] array2 = new byte[data.Length];
			Array.Copy(data, array2, data.Length);
			MemoryStream memoryStream = new MemoryStream(array2);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					for (int i = 0; i < array2.Length; i += 8)
					{
						array[0] = BitConverter.ToUInt32(array2, i);
						array[1] = BitConverter.ToUInt32(array2, i + 4);
						smethod_3(32u, array, uint_);
						binaryWriter.Write(array[0]);
						binaryWriter.Write(array[1]);
					}
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
			uint num = BitConverter.ToUInt32(array2, 0);
			if (num > array2.Length - 4)
			{
				string message = "Invalid data";
				throw new ArgumentException(message);
			}
			byte[] array3 = new byte[num];
			Array.Copy(array2, 4L, array3, 0L, num);
			return array3;
		}
		string message2 = "Invalid data";
		throw new ArgumentException(message2);
	}

	private static int smethod_0(int int_0)
	{
		return (int_0 + 7) / 8 * 8;
	}

	private static uint[] smethod_1(byte[] byte_0)
	{
		byte[] array = new byte[16];
		for (int i = 0; i < byte_0.Length; i++)
		{
			array[i % 16] = (byte)((31 * array[i % 16]) ^ byte_0[i]);
		}
		for (int j = byte_0.Length; j < array.Length; j++)
		{
			array[j] = (byte)((17 * j) ^ byte_0[j % byte_0.Length] ^ 0x98);
		}
		return new uint[4]
		{
			BitConverter.ToUInt32(array, 0),
			BitConverter.ToUInt32(array, 4),
			BitConverter.ToUInt32(array, 8),
			BitConverter.ToUInt32(array, 12)
		};
	}

	private static void smethod_2(uint uint_0, uint[] uint_1, uint[] uint_2)
	{
		uint num = uint_1[0];
		uint num2 = uint_1[1];
		uint num3 = 0u;
		uint num4 = 883305421u;
		for (uint num5 = 0u; num5 < uint_0; num5++)
		{
			num += (((num2 << 9) ^ (num2 >> 8)) + num2) ^ (num3 + uint_2[num3 & 3]);
			num3 += num4;
			num2 += (((num << 8) ^ (num >> 7)) + num) ^ (num3 + uint_2[(num3 >> 11) & 3]) ^ 0xDEADC0DEu;
		}
		uint_1[0] = num;
		uint_1[1] = num2;
	}

	private static void smethod_3(uint uint_0, uint[] uint_1, uint[] uint_2)
	{
		uint num = uint_1[0];
		uint num2 = uint_1[1];
		uint num3 = 883305421u;
		uint num4 = 883305421 * uint_0;
		for (uint num5 = 0u; num5 < uint_0; num5++)
		{
			num2 -= (((num << 8) ^ (num >> 7)) + num) ^ (num4 + uint_2[(num4 >> 11) & 3]) ^ 0xDEADC0DEu;
			num4 -= num3;
			num -= (((num2 << 9) ^ (num2 >> 8)) + num2) ^ (num4 + uint_2[num4 & 3]);
		}
		uint_1[0] = num;
		uint_1[1] = num2;
	}
}
