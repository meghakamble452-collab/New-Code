using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Driver;

internal class PemKeyUtils
{
	private const string pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";

	private const string pemprivfooter = "-----END RSA PRIVATE KEY-----";

	private const string pempubheader = "-----BEGIN PUBLIC KEY-----";

	private const string pempubfooter = "-----END PUBLIC KEY-----";

	private const string pemp8header = "-----BEGIN PRIVATE KEY-----";

	private const string pemp8footer = "-----END PRIVATE KEY-----";

	private const string pemp8encheader = "-----BEGIN ENCRYPTED PRIVATE KEY-----";

	private const string pemp8encfooter = "-----END ENCRYPTED PRIVATE KEY-----";

	private static bool verbose;

	public static RSACryptoServiceProvider GetRSAProviderFromPemFile(string pemfile)
	{
		bool flag = true;
		string text = File.ReadAllText(pemfile).Trim();
		string value = "-----BEGIN PUBLIC KEY-----";
		if (text.StartsWith(value))
		{
			string value2 = "-----END PUBLIC KEY-----";
			if (text.EndsWith(value2))
			{
				flag = false;
			}
		}
		byte[] array = ((!flag) ? DecodeOpenSSLPublicKey(text) : DecodeOpenSSLPrivateKey(text));
		if (array == null)
		{
			return null;
		}
		if (!flag)
		{
			return DecodeX509PublicKey(array);
		}
		return DecodeRSAPrivateKey(array);
	}

	public static byte[] DecodeOpenSSLPublicKey(string instr)
	{
		string text = instr.Trim();
		string value = "-----BEGIN PUBLIC KEY-----";
		if (text.StartsWith(value))
		{
			string value2 = "-----END PUBLIC KEY-----";
			if (text.EndsWith(value2))
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				string oldValue = "-----BEGIN PUBLIC KEY-----";
				stringBuilder.Replace(oldValue, "");
				string oldValue2 = "-----END PUBLIC KEY-----";
				stringBuilder.Replace(oldValue2, "");
				string s = stringBuilder.ToString().Trim();
				try
				{
					return Convert.FromBase64String(s);
				}
				catch (FormatException)
				{
					return null;
				}
			}
		}
		return null;
	}

	public static RSACryptoServiceProvider DecodeX509PublicKey(byte[] x509Key)
	{
		byte[] b = new byte[15]
		{
			48, 13, 6, 9, 42, 134, 72, 134, 247, 13,
			1, 1, 1, 5, 0
		};
		using MemoryStream input = new MemoryStream(x509Key);
		using BinaryReader binaryReader = new BinaryReader(input);
		try
		{
			switch (binaryReader.ReadUInt16())
			{
			default:
				return null;
			case 33328:
				binaryReader.ReadInt16();
				break;
			case 33072:
				binaryReader.ReadByte();
				break;
			}
			if (!CompareBytearrays(binaryReader.ReadBytes(15), b))
			{
				return null;
			}
			switch (binaryReader.ReadUInt16())
			{
			case 33027:
				binaryReader.ReadByte();
				break;
			default:
				return null;
			case 33283:
				binaryReader.ReadInt16();
				break;
			}
			if (binaryReader.ReadByte() == 0)
			{
				switch (binaryReader.ReadUInt16())
				{
				case 33072:
					binaryReader.ReadByte();
					break;
				default:
					return null;
				case 33328:
					binaryReader.ReadInt16();
					break;
				}
				ushort num = binaryReader.ReadUInt16();
				byte b2 = 0;
				byte b3 = 0;
				switch (num)
				{
				default:
					return null;
				case 33282:
					b3 = binaryReader.ReadByte();
					b2 = binaryReader.ReadByte();
					break;
				case 33026:
					b2 = binaryReader.ReadByte();
					break;
				}
				int num2 = BitConverter.ToInt32(new byte[4] { b2, b3, 0, 0 }, 0);
				byte b4 = binaryReader.ReadByte();
				binaryReader.BaseStream.Seek(-1L, SeekOrigin.Current);
				if (b4 == 0)
				{
					binaryReader.ReadByte();
					num2--;
				}
				byte[] modulus = binaryReader.ReadBytes(num2);
				if (binaryReader.ReadByte() == 2)
				{
					int count = binaryReader.ReadByte();
					byte[] exponent = binaryReader.ReadBytes(count);
					RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
					RSAParameters rSAParameters = default(RSAParameters);
					rSAParameters.Modulus = modulus;
					rSAParameters.Exponent = exponent;
					RSAParameters parameters = rSAParameters;
					rSACryptoServiceProvider.ImportParameters(parameters);
					return rSACryptoServiceProvider;
				}
				return null;
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
	{
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(privkey));
		ushort num = 0;
		int num2 = 0;
		try
		{
			switch (binaryReader.ReadUInt16())
			{
			default:
				return null;
			case 33328:
				binaryReader.ReadInt16();
				break;
			case 33072:
				binaryReader.ReadByte();
				break;
			}
			num = binaryReader.ReadUInt16();
			if (num != 258)
			{
				return null;
			}
			if (binaryReader.ReadByte() == 0)
			{
				num2 = GetIntegerSize(binaryReader);
				byte[] array = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array2 = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array3 = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array4 = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array5 = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array6 = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array7 = binaryReader.ReadBytes(num2);
				num2 = GetIntegerSize(binaryReader);
				byte[] array8 = binaryReader.ReadBytes(num2);
				string value = "showing components ..";
				Console.WriteLine(value);
				if (verbose)
				{
					string info = "\nModulus";
					showBytes(info, array);
					string info2 = "\nExponent";
					showBytes(info2, array2);
					string info3 = "\nD";
					showBytes(info3, array3);
					string info4 = "\nP";
					showBytes(info4, array4);
					string info5 = "\nQ";
					showBytes(info5, array5);
					string info6 = "\nDP";
					showBytes(info6, array6);
					string info7 = "\nDQ";
					showBytes(info7, array7);
					string info8 = "\nIQ";
					showBytes(info8, array8);
				}
				RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
				rSACryptoServiceProvider.ImportParameters(new RSAParameters
				{
					Modulus = array,
					Exponent = array2,
					D = array3,
					P = array4,
					Q = array5,
					DP = array6,
					DQ = array7,
					InverseQ = array8
				});
				return rSACryptoServiceProvider;
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
		finally
		{
			binaryReader.Close();
		}
	}

	private static int GetIntegerSize(BinaryReader binr)
	{
		byte b = 0;
		byte b2 = 0;
		byte b3 = 0;
		int num = 0;
		b = binr.ReadByte();
		if (b == 2)
		{
			b = binr.ReadByte();
			switch (b)
			{
			default:
				num = b;
				break;
			case 130:
				b3 = binr.ReadByte();
				b2 = binr.ReadByte();
				num = BitConverter.ToInt32(new byte[4] { b2, b3, 0, 0 }, 0);
				break;
			case 129:
				num = binr.ReadByte();
				break;
			}
			while (binr.ReadByte() == 0)
			{
				num--;
			}
			binr.BaseStream.Seek(-1L, SeekOrigin.Current);
			return num;
		}
		return 0;
	}

	private static byte[] DecodeOpenSSLPrivateKey(string instr)
	{
		string text = instr.Trim();
		string value = "-----BEGIN RSA PRIVATE KEY-----";
		if (text.StartsWith(value))
		{
			string value2 = "-----END RSA PRIVATE KEY-----";
			if (text.EndsWith(value2))
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				string oldValue = "-----BEGIN RSA PRIVATE KEY-----";
				stringBuilder.Replace(oldValue, "");
				string oldValue2 = "-----END RSA PRIVATE KEY-----";
				stringBuilder.Replace(oldValue2, "");
				string s = stringBuilder.ToString().Trim();
				try
				{
					return Convert.FromBase64String(s);
				}
				catch (FormatException)
				{
				}
				StringReader stringReader = new StringReader(s);
				string text2 = stringReader.ReadLine();
				string value3 = "Proc-Type: 4,ENCRYPTED";
				if (!text2.StartsWith(value3))
				{
					return null;
				}
				string text3 = stringReader.ReadLine();
				string value4 = "DEK-Info: DES-EDE3-CBC,";
				if (text3.StartsWith(value4))
				{
					string value5 = ",";
					string text4 = text3.Substring(text3.IndexOf(value5) + 1).Trim();
					byte[] array = new byte[text4.Length / 2];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Convert.ToByte(text4.Substring(i * 2, 2), 16);
					}
					if (stringReader.ReadLine() == "")
					{
						string s2 = stringReader.ReadToEnd();
						byte[] cipherData;
						try
						{
							cipherData = Convert.FromBase64String(s2);
						}
						catch (FormatException)
						{
							return null;
						}
						string prompt = "Enter password to derive 3DES key==>";
						SecureString secPswd = GetSecPswd(prompt);
						byte[] openSSL3deskey = GetOpenSSL3deskey(array, secPswd, 1, 2);
						if (openSSL3deskey != null)
						{
							byte[] array2 = DecryptKey(cipherData, openSSL3deskey, array);
							if (array2 != null)
							{
								return array2;
							}
							string value6 = "Failed to decrypt RSA private key; probably wrong password.";
							Console.WriteLine(value6);
							return null;
						}
						return null;
					}
					return null;
				}
				return null;
			}
		}
		return null;
	}

	private static byte[] DecryptKey(byte[] cipherData, byte[] desKey, byte[] IV)
	{
		MemoryStream memoryStream = new MemoryStream();
		TripleDES tripleDES = TripleDES.Create();
		tripleDES.Key = desKey;
		tripleDES.IV = IV;
		try
		{
			CryptoStream cryptoStream = new CryptoStream(memoryStream, tripleDES.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(cipherData, 0, cipherData.Length);
			cryptoStream.Close();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return null;
		}
		return memoryStream.ToArray();
	}

	private static byte[] GetOpenSSL3deskey(byte[] salt, SecureString secpswd, int count, int miter)
	{
		int num = 16;
		byte[] array = new byte[16 * miter];
		byte[] array2 = new byte[secpswd.Length];
		IntPtr intPtr = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
		Marshal.Copy(intPtr, array2, 0, array2.Length);
		Marshal.ZeroFreeGlobalAllocAnsi(intPtr);
		byte[] array3 = new byte[array2.Length + salt.Length];
		Array.Copy(array2, array3, array2.Length);
		Array.Copy(salt, 0, array3, array2.Length, salt.Length);
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] array4 = null;
		byte[] array5 = new byte[16 + array3.Length];
		for (int i = 0; i < miter; i++)
		{
			if (i == 0)
			{
				array4 = array3;
			}
			else
			{
				Array.Copy(array4, array5, array4.Length);
				Array.Copy(array3, 0, array5, array4.Length, array3.Length);
				array4 = array5;
			}
			for (int j = 0; j < count; j++)
			{
				array4 = mD.ComputeHash(array4);
			}
			Array.Copy(array4, 0, array, i * num, array4.Length);
		}
		byte[] array6 = new byte[24];
		Array.Copy(array, array6, array6.Length);
		Array.Clear(array2, 0, array2.Length);
		Array.Clear(array3, 0, array3.Length);
		Array.Clear(array4, 0, array4.Length);
		Array.Clear(array5, 0, array5.Length);
		Array.Clear(array, 0, array.Length);
		return array6;
	}

	private static SecureString GetSecPswd(string prompt)
	{
		SecureString secureString = new SecureString();
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.Write(prompt);
		Console.ForegroundColor = ConsoleColor.Magenta;
		while (true)
		{
			ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(intercept: true);
			if (consoleKeyInfo.Key == ConsoleKey.Enter)
			{
				break;
			}
			if (consoleKeyInfo.Key != ConsoleKey.Backspace)
			{
				if (consoleKeyInfo.Key == ConsoleKey.Escape)
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.WriteLine();
					return secureString;
				}
				if (char.IsLetterOrDigit(consoleKeyInfo.KeyChar) || char.IsSymbol(consoleKeyInfo.KeyChar))
				{
					if (secureString.Length < 20)
					{
						secureString.AppendChar(consoleKeyInfo.KeyChar);
						string value = "*";
						Console.Write(value);
					}
					else
					{
						Console.Beep();
					}
				}
				else
				{
					Console.Beep();
				}
			}
			else if (secureString.Length > 0)
			{
				Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				string value2 = " ";
				Console.Write(value2);
				Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				secureString.RemoveAt(secureString.Length - 1);
			}
		}
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine();
		return secureString;
	}

	private static bool CompareBytearrays(byte[] a, byte[] b)
	{
		if (a.Length != b.Length)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < a.Length)
			{
				if (a[num2] != b[num])
				{
					break;
				}
				num++;
				num2++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static void showBytes(string info, byte[] data)
	{
		string format = "{0}  [{1} bytes]";
		Console.WriteLine(format, info, data.Length);
		for (int i = 1; i <= data.Length; i++)
		{
			string format2 = "{0:X2}  ";
			Console.Write(format2, data[i - 1]);
			if (i % 16 == 0)
			{
				Console.WriteLine();
			}
		}
		string value = "\n\n";
		Console.WriteLine(value);
	}
}
