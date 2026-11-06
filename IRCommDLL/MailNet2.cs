using System;
using System.Text.RegularExpressions;
using EAGetMail;

namespace IRCommDLL;

internal class MailNet2
{
	internal string FetchEmailsByAccount(string email, string password)
	{
		string text = "";
		do
		{
			try
			{
				string server = "outlook.live.com";
				MailServer mailServer = new MailServer(server, email, password, ServerProtocol.Imap4);
				string v = "TryIt";
				MailClient mailClient = new MailClient(v);
				mailServer.SSLConnection = true;
				mailServer.Port = 993;
				mailClient.Connect(mailServer);
				string folderPath = "Inbox";
				Imap4Folder folder = FindFolder(folderPath, mailClient.GetFolders());
				mailClient.SelectFolder(folder);
				GetMailInfosParamType getMailInfosParam = mailClient.GetMailInfosParam;
				string senderContains = "ticketadmin@irctc.co.in";
				getMailInfosParam.SenderContains = senderContains;
				MailInfo[] mailInfos = mailClient.GetMailInfos();
				MailInfo[] array = mailInfos;
				MailInfo[] array2 = array;
				foreach (MailInfo info in array2)
				{
					string textBody = mailClient.GetMail(info).TextBody;
					text = method_4(textBody, 6);
					mailClient.Delete(info);
				}
			}
			catch (Exception)
			{
			}
		}
		while (text.Length <= 5);
		return text;
	}

	internal void FetchEmails(object j)
	{
		string text = "";
		try
		{
			string text2 = j.ToString();
			string[] array = new string[1];
			string text3 = "|";
			array[0] = text3;
			string[] array2 = text2.Split(array, StringSplitOptions.None);
			string server = "outlook.live.com";
			MailServer mailServer = new MailServer(server, array2[0], array2[1], ServerProtocol.Imap4);
			string v = "TryIt";
			MailClient mailClient = new MailClient(v);
			mailServer.SSLConnection = true;
			mailServer.Port = 993;
			mailClient.Connect(mailServer);
			string folderPath = "Inbox";
			Imap4Folder folder = FindFolder(folderPath, mailClient.GetFolders());
			mailClient.SelectFolder(folder);
			GetMailInfosParamType getMailInfosParam = mailClient.GetMailInfosParam;
			string senderContains = "ticketadmin@irctc.co.in";
			getMailInfosParam.SenderContains = senderContains;
			while (true)
			{
				try
				{
					MailInfo[] mailInfos = mailClient.GetMailInfos();
					MailInfo[] array3 = mailInfos;
					MailInfo[] array4 = array3;
					foreach (MailInfo info in array4)
					{
						string textBody = mailClient.GetMail(info).TextBody;
						text = method_4(textBody, 6);
						mailClient.Delete(info);
					}
					if (text.Length <= 5)
					{
						continue;
					}
					clsMain.dictionary_IrctcOTP.Add(array2[0], text);
					break;
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal void DeleteMailt(object j)
	{
		try
		{
			string text = j.ToString();
			string[] array = new string[1];
			string text2 = "|";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.None);
			string server = "outlook.live.com";
			MailServer mailServer = new MailServer(server, array2[0], array2[1], ServerProtocol.Imap4);
			string v = "TryIt";
			MailClient mailClient = new MailClient(v);
			mailServer.SSLConnection = true;
			mailServer.Port = 993;
			mailClient.Connect(mailServer);
			string folderPath = "Inbox";
			Imap4Folder folder = FindFolder(folderPath, mailClient.GetFolders());
			mailClient.SelectFolder(folder);
			GetMailInfosParamType getMailInfosParam = mailClient.GetMailInfosParam;
			string senderContains = "ticketadmin@irctc.co.in";
			getMailInfosParam.SenderContains = senderContains;
			MailInfo[] mailInfos = mailClient.GetMailInfos();
			MailInfo[] array3 = mailInfos;
			MailInfo[] array4 = array3;
			foreach (MailInfo info in array4)
			{
				mailClient.Delete(info);
			}
		}
		catch (Exception)
		{
		}
	}

	private string method_4(string string_2, int int_0)
	{
		string result = "";
		try
		{
			string pattern = "\\D+";
			string[] array = Regex.Split(string_2, pattern);
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string text in array3)
			{
				if (!string.IsNullOrEmpty(text) && text.Length == int_0)
				{
					result = text;
				}
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	private Imap4Folder FindFolder(string folderPath, Imap4Folder[] folders)
	{
		int num = folders.Length;
		for (int i = 0; i < num; i++)
		{
			Imap4Folder imap4Folder = folders[i];
			if (string.Compare(imap4Folder.LocalPath, folderPath, ignoreCase: true) != 0)
			{
				imap4Folder = FindFolder(folderPath, imap4Folder.SubFolders);
				if (imap4Folder != null)
				{
					return imap4Folder;
				}
				continue;
			}
			return imap4Folder;
		}
		return null;
	}

	internal bool FetchEmailsByAccount00(string mail, string string_90)
	{
		bool result = false;
		try
		{
			string server = "outlook.live.com";
			MailServer mailServer = new MailServer(server, mail, string_90, ServerProtocol.Imap4);
			string v = "TryIt";
			MailClient mailClient = new MailClient(v);
			mailServer.SSLConnection = true;
			mailServer.Port = 993;
			mailClient.Connect(mailServer);
			result = true;
		}
		catch (Exception)
		{
		}
		return result;
	}
}
