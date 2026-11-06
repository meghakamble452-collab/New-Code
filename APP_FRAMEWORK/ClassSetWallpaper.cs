using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace APP_FRAMEWORK;

internal class ClassSetWallpaper
{
	public enum Style
	{
		Tiled,
		Centered,
		Stretched
	}

	private const int SPI_SETDESKWALLPAPER = 20;

	private const int SPIF_UPDATEINIFILE = 1;

	private const int SPIF_SENDWININICHANGE = 2;

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

	public static void Set(Uri uri, Style style)
	{
		try
		{
			Image image = Image.FromStream(new WebClient().OpenRead(uri.ToString()));
			string tempPath = Path.GetTempPath();
			string path = "wallpaper.bmp";
			string text = Path.Combine(tempPath, path);
			image.Save(text, ImageFormat.Bmp);
			RegistryKey currentUser = Registry.CurrentUser;
			string name = "Control Panel\\Desktop";
			RegistryKey registryKey = currentUser.OpenSubKey(name, writable: true);
			string name2 = "WallpaperStyle";
			registryKey.SetValue(name2, 10.ToString());
			string name3 = "TileWallpaper";
			registryKey.SetValue(name3, 0.ToString());
			SystemParametersInfo(20, 0, text, 3);
		}
		catch (Exception)
		{
		}
	}

	public static void Set2(Uri uri, Style style)
	{
		try
		{
			Image image = null;
			string text = "C:\\Windows\\Web\\4K\\Wallpaper\\Windows\\img19_1920x1200.jpg";
			string text2 = text;
			image = ((!File.Exists(text2)) ? Image.FromStream(new WebClient().OpenRead(uri.ToString())) : new Bitmap(text2));
			string tempPath = Path.GetTempPath();
			string path = "wallpaper.bmp";
			string text3 = Path.Combine(tempPath, path);
			image.Save(text3, ImageFormat.Bmp);
			RegistryKey currentUser = Registry.CurrentUser;
			string name = "Control Panel\\Desktop";
			RegistryKey registryKey = currentUser.OpenSubKey(name, writable: true);
			string name2 = "WallpaperStyle";
			registryKey.SetValue(name2, 10.ToString());
			string name3 = "TileWallpaper";
			registryKey.SetValue(name3, 0.ToString());
			SystemParametersInfo(20, 0, text3, 3);
		}
		catch (Exception)
		{
		}
	}

	public static void setwallpaper(object j)
	{
		try
		{
			Set(new Uri(Program.Nexusjpg), Style.Tiled);
		}
		catch
		{
		}
	}

	public static void Re_setwallpaper(object j)
	{
		try
		{
			Set2(new Uri(Program.Windowsjpg), Style.Tiled);
		}
		catch
		{
		}
	}
}
