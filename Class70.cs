using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

internal class Class70
{
	public static Stream smethod_0(Stream stream_0)
	{
		BinaryReader binaryReader = new BinaryReader(stream_0);
		int num = binaryReader.ReadUInt16();
		byte[] array = new byte[num];
		binaryReader.Read(array, 0, num);
		int num2 = binaryReader.ReadByte();
		byte[] array2 = new byte[num2];
		binaryReader.Read(array2, 0, array2.Length);
		for (int i = 0; i < num; i++)
		{
			byte[] array3 = array;
			int num3 = i;
			byte[] array4 = array3;
			int num4 = num3;
			array4[num4] ^= array2[i % num2];
		}
		byte b = 0;
		SymmetricAlgorithm symmetricAlgorithm = null;
		using (BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(array, writable: false)))
		{
			binaryReader2.ReadString();
			b = binaryReader2.ReadByte();
			byte byte_ = binaryReader2.ReadByte();
			byte b2 = binaryReader2.ReadByte();
			int num5 = binaryReader2.ReadByte();
			byte[] array5 = new byte[num5];
			binaryReader2.Read(array5, 0, num5);
			if (b2 < 64)
			{
				binaryReader2.Read(array5, 0, num5);
			}
			else
			{
				Buffer.BlockCopy(Assembly.GetExecutingAssembly().GetName().GetPublicKey() ?? throw new InvalidOperationException(), b2 + 12, array5, 0, num5);
			}
			symmetricAlgorithm = smethod_1(byte_);
			symmetricAlgorithm.IV = array2;
			symmetricAlgorithm.Key = array5;
		}
		MemoryStream memoryStream = new MemoryStream();
		if ((b & 2) > 0)
		{
			using (CryptoStream stream_1 = new CryptoStream(binaryReader.BaseStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
			{
				smethod_2(stream_1, memoryStream);
			}
			if ((b & 1) > 0)
			{
				memoryStream.Position = 0L;
				MemoryStream memoryStream2 = new MemoryStream();
				Class76.smethod_0(memoryStream, memoryStream2);
				memoryStream = memoryStream2;
			}
		}
		else if (b != 1)
		{
			smethod_2(binaryReader.BaseStream, memoryStream);
		}
		else
		{
			Class76.smethod_0(binaryReader.BaseStream, memoryStream);
		}
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public static SymmetricAlgorithm smethod_1(byte byte_0)
	{
		string text = null;
		switch (byte_0)
		{
		case 1:
		{
			string text6 = "DES";
			text = text6;
			goto default;
		}
		case 2:
		{
			string text5 = "Aes";
			text = text5;
			goto default;
		}
		case 3:
		{
			string text4 = "TripleDES";
			text = text4;
			goto default;
		}
		case 4:
		{
			string text3 = "Rijndael";
			text = text3;
			goto default;
		}
		case 5:
		{
			string text2 = "RC2";
			text = text2;
			goto default;
		}
		default:
		{
			string text7 = "System.Security.Cryptography.";
			string text8 = text7 + text;
			object type = Type.GetType(text8, throwOnError: false);
			if (type == null)
			{
				string text9 = ", System.Security.Cryptography.Algorithms";
				type = Type.GetType(text8 + text9, throwOnError: false);
			}
			if (type == null)
			{
				string text10 = "Could not load type ";
				throw new InvalidOperationException(text10 + text8);
			}
			Type type2 = (Type)type;
			string name = "Create";
			return (SymmetricAlgorithm)type2.InvokeMember(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null);
		}
		case 6:
			return new Class69();
		}
	}

	public static void smethod_2(Stream stream_0, Stream stream_1)
	{
		byte[] array = new byte[4096];
		while (true)
		{
			int num = stream_0.Read(array, 0, array.Length);
			if (num > 0)
			{
				stream_1.Write(array, 0, num);
				continue;
			}
			break;
		}
	}
}
