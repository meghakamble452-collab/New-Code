using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;

namespace APP_FRAMEWORK;

[EditorBrowsable(EditorBrowsableState.Never)]
[Browsable(false)]
[DesignTimeVisible(false)]
internal class Class38
{
	public string string_0;

	public string string_1;

	public string string_2;

	public string string_3;

	public string string_4;

	public string string_5;

	public string string_6;

	public string string_7;

	private int int_0;

	private int int_1;

	public static bool ErFound;

	private string string_8;

	private string string_9;

	private string string_10;

	public Class38()
	{
	}

	public Class38(string string_8, string string_9, string string_10, string string_11, bool bool_0)
	{
		string_0 = string_8;
		string_1 = string_9;
		string_2 = string_10;
		string_3 = string_11;
		if (bool_0)
		{
			string text = "SRCTZN";
			string_4 = text;
		}
		else
		{
			string_4 = "";
		}
	}

	public void SlientFileDownloader(object sender)
	{
		string text = sender.ToString();
		try
		{
			string[] array = new string[1];
			string text2 = "|";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
			int_1 = array2.Length;
			string[] array3 = array2;
			string[] array4 = array3;
			foreach (string text3 in array4)
			{
				string[] array5 = new string[1];
				string text4 = "#";
				array5[0] = text4;
				string[] array6 = text3.Split(array5, StringSplitOptions.RemoveEmptyEntries);
				string_8 = array6[0];
				string_9 = array6[1];
				if (!Directory.Exists(Path.GetDirectoryName(string_9)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(string_9));
				}
				string_10 = array6[2];
				Thread.Sleep(500);
				startDownload(string_8, string_9);
			}
		}
		catch (Exception)
		{
		}
	}

	public void startDownload(string pUri, string pFile)
	{
		StatClass.IsFileDownloaing = true;
		try
		{
			new Thread((ThreadStart)delegate
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += method_0;
				webClient.DownloadFileCompleted += method_1;
				webClient.DownloadFileAsync(new Uri(pUri), pFile);
			}).Start();
		}
		catch
		{
		}
	}

	private void method_0(object sender, DownloadProgressChangedEventArgs e)
	{
	}

	private void method_1(object sender, AsyncCompletedEventArgs e)
	{
		StatClass.IsFileDownloaing = false;
		if (e.Error == null)
		{
			string offlineSourcePath = string_9;
			string password = "WRox#$123456";
			Staticm.ExtractZipFile(offlineSourcePath, password);
		}
	}
}
