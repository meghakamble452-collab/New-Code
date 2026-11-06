using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace APP_FRAMEWORK;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
[DesignTimeVisible(false)]
internal class Class28
{
	internal class Class29
	{
		public NetworkInterface networkInterface_0;

		public bool bool_0;

		public string string_0;

		public Class29()
		{
			string_0 = "";
		}
	}

	private Timer aTimer;

	public Size size_0;

	public Form0.Enum8 enum8_0;

	public static long long_1;

	public static long long_2;

	public static long long_3;

	private byte[] byte_0;

	private string string_1;

	private int int_2 = 180;

	private static StreamWriter streamWriter_0;

	private static object object_0;

	private static List<Class29> list_0;

	internal static int int_0;

	internal static int int_4;

	internal static Dictionary<string, int> dictionary_8;

	internal static Dictionary<string, int> dictionary_9;

	internal static bool bool_1;

	internal static Dictionary<int, int> dictionary_0;

	internal static List<string> list_2;

	private int int_5;

	public static bool ErFound;

	static Class28()
	{
		list_0 = new List<Class29>();
		try
		{
			string text = "Logs";
			string text2 = text;
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			try
			{
				string path = "Logs";
				string[] files = Directory.GetFiles(path);
				for (int i = 0; i < files.Length; i++)
				{
					string path2;
					Path.GetFileName(path2 = files[i]);
					if (File.Exists(path2))
					{
						File.Delete(path2);
					}
				}
			}
			catch
			{
			}
			string text3 = "Exlgs_";
			string text4 = text3;
			string text5 = new Random().Next(1, 100).ToString();
			DateTime now = DateTime.Now;
			string text6 = "ddMMyyyyhhmmss";
			string text7 = now.ToString(text6);
			string text8 = ".lg";
			streamWriter_0 = new StreamWriter(Path.Combine(text2, text4 + text7 + text5 + text8));
			object_0 = new object();
		}
		catch (Exception ex)
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text9 = "Uninterpted Close Application, ";
			string message = ex.Message;
			string text10 = " Closing Now!";
			string text11 = text9 + message + text10;
			string caption = "Login Failed";
			MessageBox.Show(owner, text11, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public Class28()
	{
		string text = "0";
		string_1 = text;
	}

	public Class28(Size size_1, Form0.Enum8 enum8_1)
	{
		size_0 = size_1;
		enum8_0 = enum8_1;
	}

	internal static void smethod_26(string string_7, string string_8)
	{
		lock (object_0)
		{
			string[] array = new string[5];
			DateTime now = DateTime.Now;
			string text = "dd-MMM-yyyy hh:mm:ss.fff";
			array[0] = now.ToString(text);
			string text2 = " : ";
			array[1] = text2;
			array[2] = string_7;
			string text3 = " : ";
			array[3] = text3;
			array[4] = string_8;
			string value = string.Concat(array);
			streamWriter_0.WriteLine(value);
			streamWriter_0.Flush();
		}
	}

	internal static void smethod_29(string string_7, string string_8)
	{
		try
		{
			string path = "Tasks.ini";
			StreamWriter streamWriter = new StreamWriter(path, append: true);
			lock (new object())
			{
				string text = ":";
				string text2 = "#";
				string value = string_7 + text + string_8 + text2;
				streamWriter.WriteLine(value);
				streamWriter.Flush();
			}
		}
		catch
		{
		}
	}

	internal static void smethod_29d()
	{
		try
		{
			string path = "Tasks.ini";
			if (File.Exists(path))
			{
				string path2 = "Tasks.ini";
				string text = File.ReadAllText(path2);
				string value = "Database.db:DELETE";
				if (text.Contains(value))
				{
					string path3 = "Database.db";
					File.Delete(path3);
				}
				string path4 = "Tasks.ini";
				File.Delete(path4);
			}
		}
		catch
		{
		}
	}

	internal byte[] method_9()
	{
		return byte_0;
	}

	internal string method_10()
	{
		return string_1;
	}

	internal int method_11()
	{
		return int_2;
	}

	public void CkeckAna()
	{
		DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond).AddSeconds(10.0);
		string text = "HHmmss";
		long_1 = long.Parse(dateTime.ToString(text));
		dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond).AddSeconds(12.0);
		string text2 = "HHmmss";
		long_2 = long.Parse(dateTime.ToString(text2));
		dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond).AddSeconds(14.0);
		string text3 = "HHmmss";
		long_3 = long.Parse(dateTime.ToString(text3));
	}

	internal static int Registry_Setup()
	{
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string text = "SOFTWARE\\MICROSOFT\\";
			if (localMachine.OpenSubKey(text + Class33.string_13, writable: true) == null)
			{
				RegistryKey localMachine2 = Registry.LocalMachine;
				string name = "SOFTWARE\\MICROSOFT";
				RegistryKey registryKey = localMachine2.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree);
				registryKey.CreateSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
				registryKey.Close();
			}
			RegistryKey localMachine3 = Registry.LocalMachine;
			string text2 = "SOFTWARE\\MICROSOFT\\";
			string string_ = Class33.string_13;
			string text3 = "\\";
			RegistryKey registryKey2 = localMachine3.OpenSubKey(text2 + string_ + text3 + Class33.string_12, writable: true);
			if (registryKey2 != null)
			{
				string name2 = "tcp";
				if (registryKey2.GetValue(name2) != null)
				{
					return 0;
				}
			}
			if (registryKey2 == null)
			{
				RegistryKey localMachine4 = Registry.LocalMachine;
				string text4 = "SOFTWARE\\MICROSOFT\\";
				RegistryKey registryKey3 = localMachine4.OpenSubKey(text4 + Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
				registryKey3.CreateSubKey(Class33.string_12, RegistryKeyPermissionCheck.ReadWriteSubTree);
				registryKey3.Close();
			}
			string string_2 = "netsh";
			string string_3 = "int tcp set heuristics disabled";
			Program.smethod_8(string_2, string_3);
			string string_4 = "netsh";
			string string_5 = "int tcp set global autotuninglevel=normal";
			Program.smethod_8(string_4, string_5);
			string string_6 = "netsh";
			string string_7 = "int tcp set global congestionprovider=ctcp";
			Program.smethod_8(string_6, string_7);
			string string_8 = "netsh";
			string string_9 = "int tcp set global ecncapability=default";
			Program.smethod_8(string_8, string_9);
			string string_10 = "netsh";
			string string_11 = "int tcp set global rss=enabled";
			Program.smethod_8(string_10, string_11);
			string string_12 = "netsh";
			string string_13 = "int tcp set global chimney=disabled";
			Program.smethod_8(string_12, string_13);
			string string_14 = "netsh";
			string string_15 = "int tcp set global dca=enabled";
			Program.smethod_8(string_14, string_15);
			string string_16 = "netsh";
			string string_17 = "int tcp set global timestamps=disabled";
			Program.smethod_8(string_16, string_17);
			string string_18 = "netsh";
			string string_19 = "int tcp set global rsc=enabled";
			Program.smethod_8(string_18, string_19);
			RegistryKey localMachine5 = Registry.LocalMachine;
			string name3 = "SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters";
			RegistryKey registryKey4 = localMachine5.OpenSubKey(name3, writable: true);
			string name4 = "DisableLargeMtu";
			registryKey4.SetValue(name4, 0);
			string name5 = "Tcp1323Opts";
			registryKey4.SetValue(name5, 1);
			string name6 = "EnableTCPA";
			registryKey4.SetValue(name6, 1);
			string name7 = "DisableTaskOffload";
			registryKey4.SetValue(name7, 0);
			string name8 = "DefaultTTL";
			registryKey4.SetValue(name8, 64);
			string name9 = "TCPMaxDataRetransmissions";
			registryKey4.SetValue(name9, 5);
			string name10 = "EnableConnectionRateLimiting";
			registryKey4.SetValue(name10, 0);
			string name11 = "MaxUserPort";
			registryKey4.SetValue(name11, 65534);
			string name12 = "TcpTimedWaitDelay";
			registryKey4.SetValue(name12, 30);
			string name13 = "MaxFreeTcbs";
			registryKey4.SetValue(name13, 65535);
			string name14 = "MaxHashTableSize";
			registryKey4.SetValue(name14, 65535);
			registryKey4.Close();
			RegistryKey localMachine6 = Registry.LocalMachine;
			string name15 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile";
			RegistryKey registryKey5 = localMachine6.OpenSubKey(name15, writable: true);
			if (registryKey5 != null)
			{
				string name16 = "NetworkThrottlingIndex";
				registryKey5.SetValue(name16, int.MaxValue.ToString());
				string name17 = "SystemResponsiveness";
				registryKey5.SetValue(name17, 0);
				registryKey5.Close();
			}
			RegistryKey localMachine7 = Registry.LocalMachine;
			string name18 = "SYSTEM\\CurrentControlSet\\Services\\Tcpip\\ServiceProvider";
			RegistryKey registryKey6 = localMachine7.OpenSubKey(name18, writable: true);
			string name19 = "LocalPriority";
			registryKey6.SetValue(name19, 4);
			string name20 = "HostsPriority";
			registryKey6.SetValue(name20, 5);
			string name21 = "DnsPriority";
			registryKey6.SetValue(name21, 6);
			string name22 = "NetbtPriority";
			registryKey6.SetValue(name22, 7);
			registryKey6.Close();
			RegistryKey localMachine8 = Registry.LocalMachine;
			string name23 = "System\\CurrentControlSet\\Services\\Tcpip\\QoS";
			RegistryKey registryKey7 = localMachine8.OpenSubKey(name23, writable: true);
			if (registryKey7 != null)
			{
				string name24 = "Do not use NLA";
				string value = "1";
				registryKey7.SetValue(name24, value);
				registryKey7.Close();
			}
			RegistryKey localMachine9 = Registry.LocalMachine;
			string name25 = "SOFTWARE\\Policies\\Microsoft\\Windows\\Psched";
			RegistryKey registryKey8 = localMachine9.OpenSubKey(name25, writable: true);
			if (registryKey8 != null)
			{
				string name26 = "NonBestEffortLimit";
				registryKey8.SetValue(name26, 0);
				registryKey8.Close();
			}
			RegistryKey localMachine10 = Registry.LocalMachine;
			string name27 = "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management";
			RegistryKey registryKey9 = localMachine10.OpenSubKey(name27, writable: true);
			string name28 = "LargeSystemCache";
			registryKey9.SetValue(name28, 1);
			registryKey9.Close();
			Form owner = new Form
			{
				TopMost = true
			};
			string text5 = "Some Important changes have been made!\r\n\r\nPlease RESTART YOUR COMPUTER.";
			string caption = "Restart Computer";
			MessageBox.Show(owner, text5, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			RegistryKey localMachine11 = Registry.LocalMachine;
			string text6 = "SOFTWARE\\MICROSOFT\\";
			string string_20 = Class33.string_13;
			string text7 = "\\";
			RegistryKey registryKey10 = localMachine11.OpenSubKey(text6 + string_20 + text7 + Class33.string_12, writable: true);
			string name29 = "tcp";
			registryKey10.SetValue(name29, 1);
			registryKey10.Close();
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	internal static void smethod_12(object string_7)
	{
		string string_8 = Class33.string_12;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				(registryKey.OpenSubKey(string_8, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? registryKey.CreateSubKey(string_8, RegistryKeyPermissionCheck.ReadWriteSubTree)).SetValue(Class33.string_14, string_7);
			}
		}
		catch (Exception ex)
		{
			string string_9 = "GetKey";
			smethod_26(string_9, ex.Message);
		}
	}

	internal static string smethod_13()
	{
		string result = "";
		string string_ = Class33.string_12;
		if (!Program.clientID.ToUpper().Contains(Class33.string_8))
		{
			try
			{
				RegistryKey localMachine = Registry.LocalMachine;
				string name = "SOFTWARE\\MICROSOFT";
				RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
				if (registryKey != null)
				{
					RegistryKey registryKey2 = registryKey.OpenSubKey(string_, RegistryKeyPermissionCheck.ReadWriteSubTree);
					if (registryKey2 != null)
					{
						try
						{
							string string_2 = Class33.string_15;
							string text = "Nval";
							if (string_2 == text)
							{
								string string_3 = "expKey";
								Class33.string_15 = string_3;
							}
							result = registryKey2.GetValue(Class33.string_15).ToString();
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				string string_4 = "GetAnalyser";
				smethod_26(string_4, ex.Message);
			}
			return result;
		}
		return result;
	}

	internal static void smethod_14(object string_7)
	{
		string string_8 = Class33.string_12;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				(registryKey.OpenSubKey(string_8, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? registryKey.CreateSubKey(string_8, RegistryKeyPermissionCheck.ReadWriteSubTree)).SetValue(Class33.string_15, string_7);
			}
		}
		catch (Exception ex)
		{
			string string_9 = "SetKey";
			smethod_26(string_9, ex.Message);
		}
	}

	internal static string smethod_15(bool clearPwd, int A)
	{
		string text = "";
		string text2 = "MUDLS";
		string text3 = text2;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				RegistryKey registryKey2 = registryKey.OpenSubKey(text3, RegistryKeyPermissionCheck.ReadWriteSubTree);
				if (registryKey2 != null)
				{
					if (clearPwd)
					{
						registryKey.DeleteSubKey(text3, throwOnMissingSubKey: true);
						return text;
					}
					try
					{
						text = registryKey2.GetValue(Class33.string_17).ToString();
						string strText = text;
						string string_ = "rtt4690&";
						text = Class2.DecryptText(strText, string_);
						string expression = text;
						string delimiter = "~";
						string[] array = Strings.Split(expression, delimiter);
						if (array.Length > 1)
						{
							string text4 = array[0].ToString().Trim();
							string text5 = array[1].ToString().Trim();
							text = ((A != 0) ? text5 : text4);
						}
					}
					catch
					{
					}
				}
			}
		}
		catch (Exception ex)
		{
			string string_2 = "GetAnalyser";
			smethod_26(string_2, ex.Message);
		}
		return text;
	}

	internal static void smethod_16(string string_7)
	{
		string text = "MUDLS";
		string text2 = text;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				RegistryKey registryKey2 = registryKey.OpenSubKey(text2, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? registryKey.CreateSubKey(text2, RegistryKeyPermissionCheck.ReadWriteSubTree);
				string strText = string_7;
				string string_8 = "rtt4690&";
				string_7 = Class2.EncryptText(strText, string_8);
				registryKey2.SetValue(Class33.string_17, string_7);
			}
		}
		catch (Exception ex)
		{
			string string_9 = "SetKey";
			smethod_26(string_9, ex.Message);
		}
	}

	internal static string smethod_17()
	{
		string result = "";
		string string_ = Class33.string_12;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				RegistryKey registryKey2 = registryKey.OpenSubKey(string_, RegistryKeyPermissionCheck.ReadWriteSubTree);
				if (registryKey2 != null)
				{
					try
					{
						if (!string.IsNullOrEmpty(registryKey2.GetValue(Class33.string_16).ToString()))
						{
							result = registryKey2.GetValue(Class33.string_16).ToString();
						}
					}
					catch
					{
					}
				}
			}
		}
		catch (Exception ex)
		{
			string string_2 = "GetChance";
			smethod_26(string_2, ex.Message);
		}
		return result;
	}

	internal static void smethod_18(object string_7)
	{
		string string_8 = Class33.string_12;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				(registryKey.OpenSubKey(string_8, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? registryKey.CreateSubKey(string_8, RegistryKeyPermissionCheck.ReadWriteSubTree)).SetValue(Class33.string_16, string_7);
			}
		}
		catch (Exception ex)
		{
			string string_9 = "SetChance";
			smethod_26(string_9, ex.Message);
		}
	}

	internal static void smethod_9(string string_7)
	{
		string text = "NUDLS";
		string text2 = text;
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\MICROSOFT";
			RegistryKey registryKey = localMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree).OpenSubKey(Class33.string_13, RegistryKeyPermissionCheck.ReadWriteSubTree);
			if (registryKey != null)
			{
				RegistryKey registryKey2 = registryKey.OpenSubKey(text2, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? registryKey.CreateSubKey(text2, RegistryKeyPermissionCheck.ReadWriteSubTree);
				string name2 = "ZLS";
				registryKey2.SetValue(name2, string_7);
			}
		}
		catch (Exception ex)
		{
			string string_8 = "SetKey";
			smethod_26(string_8, ex.Message);
		}
	}

	internal static void smethod_31()
	{
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			int num = 0;
			NetworkInterface[] array = allNetworkInterfaces;
			NetworkInterface[] array2 = array;
			NetworkInterface[] array3 = array2;
			foreach (NetworkInterface networkInterface in array3)
			{
				try
				{
					if (networkInterface.OperationalStatus != OperationalStatus.Up || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback || networkInterface.IsReceiveOnly || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
					{
						continue;
					}
					bool flag = smethod_5(networkInterface.Id);
					string text = smethod_6(networkInterface.Description);
					string[] array4 = null;
					if (!string.IsNullOrEmpty(text))
					{
						array4 = text.Split(',');
					}
					IPAddressCollection dnsAddresses = networkInterface.GetIPProperties().DnsAddresses;
					if (dnsAddresses != null && dnsAddresses.Count > 0)
					{
						if (dnsAddresses[0].AddressFamily == AddressFamily.InterNetwork)
						{
							string value = "8.8.8.8";
							if (text.Contains(value))
							{
								string value2 = "8.8.8.8";
								if (text.Contains(value2) && !flag && array4.Length == 3)
								{
									Class29 @class = new Class29();
									@class.networkInterface_0 = networkInterface;
									@class.bool_0 = flag;
									string oldValue = "8.8.8.8,";
									@class.string_0 = text.Replace(oldValue, "");
									list_0.Add(@class);
									Program.bool_8 = true;
								}
							}
							else
							{
								list_0.Add(new Class29
								{
									networkInterface_0 = networkInterface,
									bool_0 = flag,
									string_0 = text
								});
								Program.bool_8 = true;
							}
						}
						else if (dnsAddresses[0].AddressFamily == AddressFamily.InterNetworkV6)
						{
							string value3 = "2001:4860:4860::8888";
							if (!text.Contains(value3))
							{
								list_0.Add(new Class29
								{
									networkInterface_0 = networkInterface,
									bool_0 = flag,
									string_0 = text
								});
								Program.bool_8 = true;
							}
							else
							{
								string value4 = "2001:4860:4860::8888";
								if (text.Contains(value4) && !flag && array4.Length == 3)
								{
									Class29 class2 = new Class29();
									class2.networkInterface_0 = networkInterface;
									class2.bool_0 = flag;
									string oldValue2 = "2001:4860:4860::8888,";
									class2.string_0 = text.Replace(oldValue2, "");
									list_0.Add(class2);
									Program.bool_8 = true;
								}
							}
						}
					}
					num++;
				}
				catch (Exception ex)
				{
					string string_ = "DSN Failed for Interface";
					string description = networkInterface.Description;
					string text2 = " Err=";
					smethod_26(string_, description + text2 + ex.Message);
				}
			}
		}
		catch (Exception ex2)
		{
			string string_2 = "SetDNS";
			smethod_26(string_2, ex2.Message);
		}
	}

	internal static void smethod_32()
	{
		try
		{
			foreach (Class29 item in list_0)
			{
				try
				{
					if (!item.bool_0)
					{
						string string_ = item.string_0;
						string value = "::";
						if (!string_.Contains(value))
						{
							string string_2 = item.string_0;
							string oldValue = "8.8.8.8,";
							string_2.Replace(oldValue, "");
						}
						else
						{
							string string_3 = item.string_0;
							string oldValue2 = "2001:4860:4860::8888,";
							string_3.Replace(oldValue2, "");
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			string string_4 = "ResetDNS";
			smethod_26(string_4, ex.Message);
		}
	}

	private static bool smethod_5(string string_6)
	{
		try
		{
			string text = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\\";
			string keyName = text + string_6;
			string valueName = "NameServer";
			return string.IsNullOrEmpty((string)Registry.GetValue(keyName, valueName, null));
		}
		catch (Exception ex)
		{
			string string_7 = "DNSAutoOrStatic";
			smethod_26(string_7, ex.Message);
		}
		return true;
	}

	private static string smethod_6(string string_6)
	{
		string result = "";
		try
		{
			string path = "Win32_NetworkAdapterConfiguration";
			foreach (ManagementObject instance in new ManagementClass(path).GetInstances())
			{
				string propertyName = "IPEnabled";
				if (!(bool)instance[propertyName])
				{
					continue;
				}
				string propertyName2 = "Caption";
				if (!instance[propertyName2].ToString().Contains(string_6))
				{
					continue;
				}
				try
				{
					string propertyName3 = "DNSServerSearchOrder";
					object obj = instance[propertyName3];
					object obj2;
					if (obj != null && obj is string[])
					{
						string separator = ",";
						obj2 = string.Join(separator, (string[])obj);
					}
					else
					{
						obj2 = null;
					}
					result = (string)obj2;
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
		return result;
	}
}
