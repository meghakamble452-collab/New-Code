using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace NativeCSharpJWTToken;

internal class JWTUtils
{
	private static byte[] keyType;

	private static byte[] keyLength;

	private static readonly byte[] DefaultIV;

	private static int keyLengthBits;

	private byte[] constPartKey = new byte[345]
	{
		48, 130, 1, 181, 48, 130, 1, 77, 6, 7,
		42, 134, 72, 206, 61, 2, 1, 48, 130, 1,
		64, 2, 1, 1, 48, 60, 6, 7, 42, 134,
		72, 206, 61, 1, 1, 2, 49, 0, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 254,
		255, 255, 255, 255, 0, 0, 0, 0, 0, 0,
		0, 0, 255, 255, 255, 255, 48, 100, 4, 48,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 254, 255, 255, 255, 255, 0, 0, 0, 0,
		0, 0, 0, 0, 255, 255, 255, 252, 4, 48,
		179, 49, 47, 167, 226, 62, 231, 228, 152, 142,
		5, 107, 227, 248, 45, 25, 24, 29, 156, 110,
		254, 129, 65, 18, 3, 20, 8, 143, 80, 19,
		135, 90, 198, 86, 57, 141, 138, 46, 209, 157,
		42, 133, 200, 237, 211, 236, 42, 239, 4, 97,
		4, 170, 135, 202, 34, 190, 139, 5, 55, 142,
		177, 199, 30, 243, 32, 173, 116, 110, 29, 59,
		98, 139, 167, 155, 152, 89, 247, 65, 224, 130,
		84, 42, 56, 85, 2, 242, 93, 191, 85, 41,
		108, 58, 84, 94, 56, 114, 118, 10, 183, 54,
		23, 222, 74, 150, 38, 44, 111, 93, 158, 152,
		191, 146, 146, 220, 41, 248, 244, 29, 189, 40,
		154, 20, 124, 233, 218, 49, 19, 181, 240, 184,
		192, 10, 96, 177, 206, 29, 126, 129, 157, 122,
		67, 29, 124, 144, 234, 14, 95, 2, 49, 0,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 199, 99, 77, 129, 244, 55,
		45, 223, 88, 26, 13, 178, 72, 176, 167, 122,
		236, 236, 25, 106, 204, 197, 41, 115, 2, 1,
		1, 3, 98, 0, 4
	};

	internal string createJwtToken(CngKey cngKey_0, string keyFromServer, string greq, string x_request_for)
	{
		string result = "";
		try
		{
			long num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			byte[] array = new byte[16];
			new Random().NextBytes(array);
			string value = Convert.ToBase64String(array);
			string text = "aud";
			string key = text;
			string text2 = "MAPPS";
			string value2 = text2;
			string text3 = "sub";
			string key2 = text3;
			string text4 = "オケクキカ#";
			string value3 = text4;
			string text5 = "アイ#ウエオ";
			string key3 = text5;
			string text6 = "salutbébé";
			string key4 = text6;
			string text7 = "電子メールID";
			string key5 = text7;
			int length = greq.Length;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string key6 = "iss";
			dictionary.Add(key6, greq);
			dictionary.Add(key, value2);
			string key7 = "exp";
			dictionary.Add(key7, num + 1200);
			string key8 = "jti";
			dictionary.Add(key8, value);
			string key9 = "iat";
			dictionary.Add(key9, num);
			string key10 = "nbf";
			dictionary.Add(key10, num - 600);
			dictionary.Add(key2, value3);
			dictionary.Add(key3, x_request_for);
			dictionary.Add(key4, greq);
			dictionary.Add(key5, length);
			Dictionary<string, object> payload = dictionary;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			string key11 = "kid";
			string value4 = "deviceyek";
			dictionary2.Add(key11, value4);
			Dictionary<string, object> extraHeaders = dictionary2;
			string payload2 = EncodeSignature(payload, cngKey_0, extraHeaders);
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			string key12 = "kid";
			string value5 = "serveryek";
			dictionary3.Add(key12, value5);
			string key13 = "cty";
			string value6 = "JWT";
			dictionary3.Add(key13, value6);
			Dictionary<string, object> extraHeaders2 = dictionary3;
			result = Encode(payload2, keyFromServer, extraHeaders2);
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	internal CngKey getRandomAppCngKey()
	{
		return CngKey.Create(CngAlgorithm.ECDsaP384, null, new CngKeyCreationParameters
		{
			ExportPolicy = CngExportPolicies.AllowPlaintextExport
		});
	}

	internal string getStringRandomCngKeyForSendingToServer(CngKey cngKeyRandomApp)
	{
		byte[] second = cngKeyRandomApp.Export(CngKeyBlobFormat.EccPublicBlob).Skip(8).Take(96)
			.ToArray();
		return Convert.ToBase64String(constPartKey.Concat(second).ToArray());
	}

	private AsymmetricCipherKeyPair GenerateRandomKeysInApp(int keySize)
	{
		ECKeyPairGenerator eCKeyPairGenerator = new ECKeyPairGenerator();
		KeyGenerationParameters parameters = new KeyGenerationParameters(new SecureRandom(), keySize);
		eCKeyPairGenerator.Init(parameters);
		return eCKeyPairGenerator.GenerateKeyPair();
	}

	private byte[] createPublicKeyArrayFromServer(string publicKeyFromServerString)
	{
		return ((ECPublicKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKeyFromServerString))).Q.GetEncoded();
	}

	private string EncodeSignature(object payload, object key, IDictionary<string, object> extraHeaders = null)
	{
		return EncodeSignatureNext(JSSerializerMapper.Serialize(payload), key, extraHeaders);
	}

	private string EncodeSignatureNext(string payload, object key, IDictionary<string, object> extraHeaders = null)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(payload);
		return EncodeBytesSignature(bytes, key, extraHeaders);
	}

	private string EncodeBytesSignature(byte[] payload, object key, IDictionary<string, object> extraHeaders = null)
	{
		if (payload == null)
		{
			return null;
		}
		if (extraHeaders == null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string key2 = "typ";
			string value = "JWT";
			dictionary.Add(key2, value);
			extraHeaders = dictionary;
		}
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		string key3 = "alg";
		string value2 = "ES384";
		dictionary2.Add(key3, value2);
		Dictionary<string, object> dictionary3 = dictionary2;
		Append(dictionary3, extraHeaders);
		byte[] bytes = Encoding.UTF8.GetBytes(JSSerializerMapper.Serialize(dictionary3));
		byte[] bytes2 = Encoding.UTF8.GetBytes(Compact.Serialize(bytes, payload));
		byte[] array = Sign(bytes2, key);
		return Compact.Serialize(bytes, payload, array);
	}

	private byte[] Sign(byte[] securedInput, object key)
	{
		try
		{
			if (key is CngKey)
			{
				using (ECDsaCng eCDsaCng = new ECDsaCng((CngKey)key))
				{
					eCDsaCng.HashAlgorithm = CngAlgorithm.Sha384;
					return eCDsaCng.SignData(securedInput);
				}
			}
			string message = "EcdsaUsingSha algorithm expects key to be of either CngKey or ECDsa types.";
			throw new ArgumentException(message);
		}
		catch (CryptographicException innerException)
		{
			string message2 = "Unable to sign content.";
			throw new Exception(message2, innerException);
		}
	}

	private string Encode(string payload, string publicKeyFromServer, IDictionary<string, object> extraHeaders)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(payload);
		if (publicKeyFromServer == null || publicKeyFromServer.Length == 0)
		{
			string format = "Public Key From Server string empty! : {0}";
			throw new Exception(string.Format(format, publicKeyFromServer));
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string key = "alg";
		string value = "ECDH-ES+A128KW";
		dictionary.Add(key, value);
		string key2 = "enc";
		string value2 = "A128GCM";
		dictionary.Add(key2, value2);
		string key3 = "zip";
		string value3 = "DEF";
		dictionary.Add(key3, value3);
		IDictionary<string, object> dictionary2 = dictionary;
		Append(dictionary2, extraHeaders);
		byte[][] array = WrapNewKey(128, publicKeyFromServer, dictionary2);
		byte[] cek = array[0];
		byte[] array2 = array[1];
		bytes = Compress(bytes);
		byte[] bytes2 = Encoding.UTF8.GetBytes(JSSerializerMapper.Serialize(dictionary2));
		byte[][] array3 = AesGcmEncryption.Encrypt(Encoding.UTF8.GetBytes(Compact.Serialize(bytes2)), bytes, cek);
		return Compact.Serialize(bytes2, array2, array3[0], array3[1], array3[2]);
	}

	private byte[] Compress(byte[] plainText)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
		{
			deflateStream.Write(plainText, 0, plainText.Length);
		}
		return memoryStream.ToArray();
	}

	private void Append<K, V>(IDictionary<K, V> src, IDictionary<K, V> other)
	{
		if (src == null || other == null)
		{
			return;
		}
		foreach (KeyValuePair<K, V> item in other.Where((KeyValuePair<K, V> pair) => !src.ContainsKey(pair.Key)))
		{
			src.Add(item);
		}
	}

	private byte[][] WrapNewKey(int cekSizeBits, string key, IDictionary<string, object> header)
	{
		byte[] key2 = WrapNewKeyNext(keyLengthBits, key, header)[0];
		return WrapNewKeyLast(cekSizeBits, key2, header);
	}

	private byte[][] WrapNewKeyLast(int cekSizeBits, byte[] key, IDictionary<string, object> header)
	{
		byte[] array = Arrays.Random(cekSizeBits);
		byte[] array2 = AesKeyWrap(array, key);
		return new byte[2][] { array, array2 };
	}

	private byte[] AesKeyWrap(byte[] cek, byte[] kek)
	{
		byte[] array = DefaultIV;
		byte[][] array2 = Arrays.Slice(cek, 8);
		long num = array2.Length;
		for (long num2 = 0L; num2 < 6; num2++)
		{
			for (long num3 = 0L; num3 < num; num3++)
			{
				long right = num * num2 + num3 + 1;
				byte[] arr = AesEnc(kek, Arrays.Concat(array, array2[(int)(IntPtr)num3]));
				array = Arrays.FirstHalf(arr);
				array2[(int)(IntPtr)num3] = Arrays.SecondHalf(arr);
				array = Arrays.Xor(array, right);
			}
		}
		byte[][] array3 = new byte[num + 1][];
		array3[0] = array;
		for (long num4 = 1L; num4 <= num; num4++)
		{
			array3[(int)(IntPtr)num4] = array2[(int)(IntPtr)(num4 - 1)];
		}
		return Arrays.Concat(array3);
	}

	private byte[] AesEnc(byte[] sharedKey, byte[] plainText)
	{
		using Aes aes = new AesCryptoServiceProvider();
		aes.Key = sharedKey;
		aes.Mode = CipherMode.ECB;
		aes.Padding = PaddingMode.None;
		using MemoryStream memoryStream = new MemoryStream();
		using ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(plainText, 0, plainText.Length);
		cryptoStream.FlushFinalBlock();
		return memoryStream.ToArray();
	}

	private byte[][] WrapNewKeyNext(int cekSizeBits, string key, IDictionary<string, object> header)
	{
		try
		{
			byte[] array = NewKey(cekSizeBits, key, header);
			byte[] array2 = new byte[0];
			return new byte[2][] { array, array2 };
		}
		catch (Exception)
		{
			return new byte[0][];
		}
	}

	private byte[] NewKey(int keyLength, string publicKeyFromServer, IDictionary<string, object> header)
	{
		AsymmetricCipherKeyPair asymmetricCipherKeyPair = GenerateRandomKeysInApp(384);
		byte[] encoded = ((ECPublicKeyParameters)asymmetricCipherKeyPair.Public).Q.GetEncoded();
		IDictionary<string, object> dictionary = new Dictionary<string, object>();
		string key = "kty";
		string value = "EC";
		dictionary[key] = value;
		string key2 = "x";
		dictionary[key2] = Base64Url.Encode(encoded.Skip(1).Take(48).ToArray());
		string key3 = "y";
		dictionary[key3] = Base64Url.Encode(encoded.Skip(49).Take(48).ToArray());
		string key4 = "crv";
		string value2 = "P-384";
		dictionary[key4] = value2;
		string key5 = "epk";
		header[key5] = dictionary;
		((ECPrivateKeyParameters)asymmetricCipherKeyPair.Private).D.ToByteArray();
		ECPublicKeyParameters pubKey = (ECPublicKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKeyFromServer));
		ECDHCBasicAgreement eCDHCBasicAgreement = new ECDHCBasicAgreement();
		eCDHCBasicAgreement.Init(asymmetricCipherKeyPair.Private);
		byte[] array = eCDHCBasicAgreement.CalculateAgreement(pubKey).ToByteArray();
		if (array.Length > 48)
		{
			array = array.Skip(1).Take(48).ToArray();
		}
		byte[] array2 = new byte[30]
		{
			0, 0, 0, 14, 69, 67, 68, 72, 45, 69,
			83, 43, 65, 49, 50, 56, 75, 87, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 128
		};
		byte[] array3 = new byte[4] { 0, 0, 0, 1 };
		Sha256Digest sha256Digest = new Sha256Digest();
		byte[] array4 = new byte[((IDigest)sha256Digest).GetDigestSize()];
		((IDigest)sha256Digest).BlockUpdate(array3, 0, array3.Length);
		((IDigest)sha256Digest).BlockUpdate(array, 0, array.Length);
		((IDigest)sha256Digest).BlockUpdate(array2, 0, array2.Length);
		((IDigest)sha256Digest).DoFinal(array4, 0);
		return array4.Take(16).ToArray();
	}

	internal string getHash(string fakeImei, string fakeSimSerialNumber, string fakeAndroidId)
	{
		long mostSignificantBits = HashCodeJavaForString(fakeImei);
		HashCodeJavaForString(fakeSimSerialNumber);
		HashCodeJavaForString(fakeAndroidId);
		long leastSignificantBits = HashCodeJavaForString(fakeSimSerialNumber) | ((long)HashCodeJavaForString(fakeAndroidId) << 32);
		return new JavaUUID.Uuid(mostSignificantBits, leastSignificantBits).ToString();
	}

	internal string GetHash(ref string mup)
	{
		Guid.NewGuid().ToString();
		string string_ = "abcdefghijklstu0123456789vwxyz";
		string text = RandomString(9, string_).ToUpper();
		string string_2 = "abcdefghijklstu0123456789vwxyz";
		string text2 = RandomString(5, string_2).ToUpper();
		string string_3 = "abcdhijklmnopqrwxyz0123456789";
		string text3 = RandomString(5, string_3).ToUpper();
		string string_4 = "abcdefghijklstu0123456789vwxyz";
		string text4 = RandomString(5, string_4).ToUpper();
		string string_5 = "abcdefghijklstu0123456789vwxyz";
		string text5 = RandomString(13, string_5).ToUpper();
		string[] array = new string[9];
		string text6 = "ir";
		array[0] = text6 + text;
		string text7 = "=";
		array[1] = text7;
		array[2] = text2;
		string text8 = "=";
		array[3] = text8;
		array[4] = text3;
		string text9 = "=";
		array[5] = text9;
		array[6] = text4;
		string text10 = "=";
		array[7] = text10;
		array[8] = text5;
		string result = string.Concat(array);
		string[] array2 = new string[9]
		{
			text.Remove(text.Length - 1),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		string text11 = "-";
		array2[1] = text11;
		array2[2] = text2.Remove(text2.Length - 1);
		string text12 = "-";
		array2[3] = text12;
		array2[4] = text3.Remove(text3.Length - 1);
		string text13 = "-";
		array2[5] = text13;
		array2[6] = text4.Remove(text4.Length - 1);
		string text14 = "-";
		array2[7] = text14;
		array2[8] = text5.Remove(text5.Length - 1);
		mup = string.Concat(array2);
		return result;
	}

	public static string generateGrep(string androidId, string versionApp, bool isAR = true)
	{
		string text = new JavaUUID.Uuid(hashCodeJava(androidId), 0L).ToString();
		string[] array = new string[1];
		string text2 = "-";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		string[] array3 = new string[1];
		string text3 = ".";
		array3[0] = text3;
		string[] array4 = versionApp.Split(array3, StringSplitOptions.None);
		string text4 = "";
		for (int num = array2.Length - 1; num >= 0; num--)
		{
			string text5 = "";
			if (num != 4)
			{
				if (num != 3)
				{
					if (num <= 2)
					{
						string text6 = ((array4.Length > 2) ? array4[2] : null);
						string text7 = array2[num];
						string text8;
						if (text6 != null && text6.Length > num)
						{
							text8 = text6.Substring(num, 1);
						}
						else
						{
							string text9 = "0";
							text8 = text9;
						}
						text5 = text7 + text8;
					}
				}
				else
				{
					string text10 = array2[num];
					object obj;
					if (array4.Length > 1 && !string.IsNullOrEmpty(array4[1]))
					{
						obj = array4[1];
					}
					else
					{
						string text11 = "0";
						obj = text11;
					}
					text5 = text10 + (string)obj;
				}
			}
			else
			{
				string text12 = array2[num];
				object obj2;
				if (array4.Length != 0 && !string.IsNullOrEmpty(array4[0]))
				{
					obj2 = array4[0];
				}
				else
				{
					string text13 = "0";
					obj2 = text13;
				}
				text5 = text12 + (string)obj2;
			}
			string text16;
			if (!string.IsNullOrEmpty(text4))
			{
				string text14 = text5;
				string text15 = "-";
				text16 = text14 + text15 + text4;
			}
			else
			{
				text16 = text5;
			}
			text4 = text16;
		}
		string text18;
		if (!isAR)
		{
			string text17 = "ir";
			text18 = text17;
		}
		else
		{
			string text19 = "ar";
			text18 = text19;
		}
		return text18 + text4;
	}

	public static int hashCodeJava(string str)
	{
		int num = 0;
		char[] array = str.ToCharArray();
		if (array.Length != 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				num = 31 * num + array[i];
			}
		}
		return num;
	}

	internal string RandomString(int int_28, string string_86)
	{
		char[] array = new char[int_28];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = string_86[random.Next(string_86.Length)];
		}
		return new string(array);
	}

	private int HashCodeJavaForString(string value)
	{
		int num = 0;
		char[] array = value.ToCharArray();
		for (int i = 0; i < value.Length; i++)
		{
			num = 31 * num + array[i];
		}
		return num;
	}

	public static string getClientTransactionId(string userId, string fakeImei)
	{
		DateTime now = DateTime.Now;
		string text = "yyyyMMddHHmmss";
		string text2 = now.ToString(text);
		string s = fakeImei + userId.ToString() + text2;
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		byte[] bytes2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
		return new BigInteger(1, bytes2).ToString(16).Substring(0, 8);
	}

	static JWTUtils()
	{
		keyType = new byte[4] { 69, 67, 83, 51 };
		keyLength = new byte[4] { 48, 0, 0, 0 };
		DefaultIV = new byte[8] { 166, 166, 166, 166, 166, 166, 166, 166 };
		keyLengthBits = 128;
	}
}
