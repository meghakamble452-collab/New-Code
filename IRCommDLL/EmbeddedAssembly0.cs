using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace IRCommDLL;

public class EmbeddedAssembly0
{
	private static Dictionary<string, Assembly> dictionary_0;

	public static void Assembly_Load()
	{
		string embeddedResource = "IRCommDLL.include.PhonePeCSharp.dll";
		string fileName = "PhonePeCSharp.dll";
		EmbeddedAssembly.Load(embeddedResource, fileName);
		string embeddedResource2 = "IRCommDLL.include.FreeCharge.dll";
		string fileName2 = "FreeCharge.dll";
		EmbeddedAssembly.Load(embeddedResource2, fileName2);
		string embeddedResource3 = "IRCommDLL.include.BhimAXIS.dll";
		string fileName3 = "BhimAXIS.dll";
		EmbeddedAssembly.Load(embeddedResource3, fileName3);
		string embeddedResource4 = "IRCommDLL.include.NpciPay.dll";
		string fileName4 = "NpciPay.dll";
		EmbeddedAssembly.Load(embeddedResource4, fileName4);
		string embeddedResource5 = "IRCommDLL.include.Driver.dll";
		string fileName5 = "Driver.dll";
		EmbeddedAssembly.Load(embeddedResource5, fileName5);
		string embeddedResource6 = "IRCommDLL.include.BhimSBI.dll";
		string fileName6 = "BhimSBI.dll";
		EmbeddedAssembly.Load(embeddedResource6, fileName6);
		AppDomain.CurrentDomain.AssemblyResolve += smethod_0;
	}

	private static Assembly smethod_0(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		return EmbeddedAssembly.Get(resolveEventArgs_0.Name);
	}

	public static void Load(string embeddedResource, string fileName)
	{
		try
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<string, Assembly>();
			}
			byte[] array = null;
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
			{
				if (stream == null)
				{
					string text = " is not found in Embedded Resources.";
					throw new Exception(embeddedResource + text);
				}
				array = new byte[(int)stream.Length];
				stream.Read(array, 0, (int)stream.Length);
				try
				{
					Assembly assembly = Assembly.Load(array);
					dictionary_0.Add(assembly.FullName, assembly);
					return;
				}
				catch
				{
				}
			}
			bool flag = false;
			string path = "";
			using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider())
			{
				string text2 = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(array));
				string oldValue = "-";
				string text3 = text2.Replace(oldValue, string.Empty);
				path = Path.GetTempPath() + fileName;
				if (!File.Exists(path))
				{
					flag = false;
				}
				else
				{
					byte[] buffer = File.ReadAllBytes(path);
					string text4 = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(buffer));
					string oldValue2 = "-";
					string text5 = text4.Replace(oldValue2, string.Empty);
					flag = text3 == text5;
				}
			}
			if (!flag)
			{
				File.WriteAllBytes(path, array);
			}
			Assembly assembly2 = Assembly.LoadFile(path);
			dictionary_0.Add(assembly2.FullName, assembly2);
		}
		catch (Exception)
		{
		}
	}

	public static Assembly Get(string assemblyFullName)
	{
		object obj = ((dictionary_0 == null || dictionary_0.Count == 0) ? null : ((!dictionary_0.ContainsKey(assemblyFullName)) ? null : dictionary_0[assemblyFullName]));
		return (Assembly)obj;
	}

	public static string ReadFile(string embeddedResource)
	{
		string result = "";
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		try
		{
			using Stream stream = executingAssembly.GetManifestResourceStream(embeddedResource);
			if (stream == null)
			{
				int num2;
				do
				{
					int[,,] array = new int[2, 1, 5]
					{
						{ { 147486513, -136686581, 406410345, -2, 1477180593 } },
						{ { 1273293070, -1, 529069280, -686896693, 940706066 } }
					};
					int num = ~array[0, 0, 3];
					num2 = num;
					if (num2 == 1)
					{
						string text = " is not found in Embedded Resources.";
						throw new Exception(embeddedResource + text);
					}
				}
				while (num2 == 2);
			}
			using StreamReader streamReader = new StreamReader(stream);
			result = streamReader.ReadToEnd();
		}
		catch
		{
		}
		return result;
	}
}
