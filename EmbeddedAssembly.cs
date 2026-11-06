using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

public class EmbeddedAssembly
{
	private static Dictionary<string, Assembly> dictionary_0;

	public static void Assembly_Load()
	{
		try
		{
			string embeddedResource = "NEXUS.Extention.MReget.dll";
			string fileName = "MReget.dll";
			Load(embeddedResource, fileName);
			string embeddedResource2 = "NEXUS.Extention.Ionic.Zip.Reduced.dll";
			string fileName2 = "Ionic.Zip.Reduced.dll";
			Load(embeddedResource2, fileName2);
			string embeddedResource3 = "NEXUS.Extention.PhonePeCSharp.dll";
			string fileName3 = "PhonePeCSharp.dll";
			Load(embeddedResource3, fileName3);
			string embeddedResource4 = "NEXUS.Extention.FreeCharge.dll";
			string fileName4 = "FreeCharge.dll";
			Load(embeddedResource4, fileName4);
			string embeddedResource5 = "NEXUS.Extention.BhimAXIS.dll";
			string fileName5 = "BhimAXIS.dll";
			Load(embeddedResource5, fileName5);
			string embeddedResource6 = "NEXUS.Extention.NpciPay.dll";
			string fileName6 = "NpciPay.dll";
			Load(embeddedResource6, fileName6);
			string embeddedResource7 = "NEXUS.Extention.Driver.dll";
			string fileName7 = "Driver.dll";
			Load(embeddedResource7, fileName7);
			string embeddedResource8 = "NEXUS.Extention.BhimSBI.dll";
			string fileName8 = "BhimSBI.dll";
			Load(embeddedResource8, fileName8);
			AppDomain.CurrentDomain.AssemblyResolve += smethod_0;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private static Assembly smethod_0(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		return Get(resolveEventArgs_0.Name);
	}

	public static void Load(string embeddedResource, string fileName)
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

	public static Assembly Get(string assemblyFullName)
	{
		object obj = ((dictionary_0 == null || dictionary_0.Count == 0) ? null : ((!dictionary_0.ContainsKey(assemblyFullName)) ? null : dictionary_0[assemblyFullName]));
		return (Assembly)obj;
	}
}
