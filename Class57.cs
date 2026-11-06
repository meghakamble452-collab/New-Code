using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

internal class Class57
{
	private delegate string Delegate3();

	private class Class58
	{
		private static readonly Delegate3 delegate3_0 = smethod_5;

		internal static readonly Class58 class58_0 = new Class58();

		internal int[] int_0;

		internal long[] long_0;

		internal float[] float_0;

		internal double[] double_0;

		private Class58()
		{
			Stream stream_ = Class70.smethod_0(Assembly.GetExecutingAssembly().GetManifestResourceStream(delegate3_0()));
			method_0(stream_);
		}

		private void method_0(Stream stream_0)
		{
			BinaryReader binaryReader = new BinaryReader(stream_0);
			int num = binaryReader.ReadInt32() ^ 0x74BC4AA5;
			if (num > 0)
			{
				int_0 = new int[num];
				while (--num >= 0)
				{
					int_0[num] = binaryReader.ReadInt32() ^ 0x2DD0103C;
				}
			}
			num = binaryReader.ReadInt32() ^ 0xC901485;
			while (num > 0)
			{
				long_0 = new long[num];
				while (--num >= 0)
				{
					long_0[num] = binaryReader.ReadInt64() ^ 0x49DA2CDD;
				}
			}
			num = binaryReader.ReadInt32() ^ 0x918F8CD;
			while (num > 0)
			{
				float_0 = new float[num];
				while (--num >= 0)
				{
					float_0[num] = binaryReader.ReadSingle();
				}
			}
			num = binaryReader.ReadInt32() ^ 0x6B90DD25;
			while (num > 0)
			{
				double_0 = new double[num];
				while (--num >= 0)
				{
					double_0[num] = binaryReader.ReadDouble();
				}
			}
		}

		internal static Array smethod_0(byte[] byte_0)
		{
			MemoryStream stream_ = new MemoryStream(byte_0);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using Stream serializationStream = Class70.smethod_0(stream_);
			return (Array)binaryFormatter.Deserialize(serializationStream);
		}
	}

	public static int smethod_0(int int_0)
	{
		return Class58.class58_0.int_0[int_0];
	}

	public static long smethod_1(int int_0)
	{
		return Class58.class58_0.long_0[int_0];
	}

	public static float smethod_2(int int_0)
	{
		return Class58.class58_0.float_0[int_0];
	}

	public static double smethod_3(int int_0)
	{
		return Class58.class58_0.double_0[int_0];
	}

	public static Array smethod_4(byte[] byte_0)
	{
		return Class58.smethod_0(byte_0);
	}

	public static string smethod_5()
	{
		string text = "\u0012\u00184\n";
		char[] array = text.ToCharArray();
		int num = array.Length;
		while (--num >= 0)
		{
			char[] array2 = array;
			int num2 = num;
			char[] array3 = array2;
			int num3 = num2;
			array3[num3] ^= 'Y';
		}
		return new string(array);
	}
}
