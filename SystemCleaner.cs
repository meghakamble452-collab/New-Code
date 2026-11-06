using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

public static class SystemCleaner
{
	[DllImport("Shell32.dll")]
	private static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

	public static void DeepClean()
	{
		CleanUserTemp();
		CleanWindowsTemp();
		CleanPrefetch();
		CleanThumbnailCache();
		CleanDirectXCache();
		CleanDeliveryOptimization();
		CleanWindowsUpdateCache();
		CleanCrashDumps();
		CleanLogs();
		FlushDNS();
		EmptyRecycleBin();
		CleanBrowsers();
	}

	private static void CleanUserTemp()
	{
		DeleteFolder(Environment.GetEnvironmentVariable("TEMP"));
	}

	private static void CleanWindowsTemp()
	{
		DeleteFolder("C:\\Windows\\Temp");
	}

	private static void CleanPrefetch()
	{
		DeleteFolder("C:\\Windows\\Prefetch");
	}

	private static void CleanThumbnailCache()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Windows\\Explorer");
		DeleteFiles(path, "thumbcache*.db");
	}

	private static void CleanDirectXCache()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "D3DSCache");
		DeleteFolder(path);
	}

	private static void CleanDeliveryOptimization()
	{
		DeleteFolder("C:\\Windows\\ServiceProfiles\\NetworkService\\AppData\\Local\\Microsoft\\Windows\\DeliveryOptimization\\Cache");
	}

	private static void CleanWindowsUpdateCache()
	{
		DeleteFolder("C:\\Windows\\SoftwareDistribution\\Download");
	}

	private static void CleanCrashDumps()
	{
		DeleteFolder(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CrashDumps"));
	}

	private static void CleanLogs()
	{
		DeleteFolder("C:\\Windows\\Logs\\CBS\\");
	}

	private static void FlushDNS()
	{
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "ipconfig",
				Arguments = "/flushdns",
				CreateNoWindow = true,
				UseShellExecute = true
			});
		}
		catch
		{
		}
	}

	private static void EmptyRecycleBin()
	{
		try
		{
			SHEmptyRecycleBin(IntPtr.Zero, null, 7u);
		}
		catch
		{
		}
	}

	private static void CleanBrowsers()
	{
		KillProcess("chrome");
		KillProcess("firefox");
		KillProcess("msedge");
		KillProcess("brave");
		CleanChromeFingerprint();
		CleanEdgeFingerprint();
		CleanFirefoxCompleteProfile();
	}

	private static void KillProcess(string processName)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
				process.WaitForExit(2000);
			}
		}
		catch
		{
		}
	}

	private static void CleanChromeFingerprint()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\User Data");
		if (Directory.Exists(path))
		{
			DeleteFolder(path);
		}
		string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\Local State");
		DeleteFileIfExists(filePath);
	}

	private static void CleanEdgeFingerprint()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Edge\\User Data");
		if (Directory.Exists(path))
		{
			DeleteFolder(path);
		}
		string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Edge\\Local State");
		DeleteFileIfExists(filePath);
	}

	private static void CleanFirefoxCompleteProfile()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox");
		string path2 = Path.Combine(path, "Profiles");
		if (Directory.Exists(path2))
		{
			DeleteFolder(path2);
		}
		string filePath = Path.Combine(path, "profiles.ini");
		DeleteFileIfExists(filePath);
	}

	private static void DeleteFileIfExists(string filePath)
	{
		try
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}
		catch
		{
		}
	}

	private static void DeleteFolder(string path)
	{
		try
		{
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path);
			string[] array = files;
			foreach (string path2 in array)
			{
				try
				{
					File.SetAttributes(path2, FileAttributes.Normal);
					File.Delete(path2);
				}
				catch
				{
				}
			}
			string[] directories = Directory.GetDirectories(path);
			string[] array2 = directories;
			foreach (string path3 in array2)
			{
				try
				{
					Directory.Delete(path3, recursive: true);
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	private static void DeleteFiles(string path, string pattern)
	{
		try
		{
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path, pattern);
			string[] array = files;
			foreach (string path2 in array)
			{
				try
				{
					File.Delete(path2);
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}
}
