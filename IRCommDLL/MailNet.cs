using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using MailKit;
using MailKit.Net.Imap;

namespace IRCommDLL;

internal class MailNet
{
	private uint UniqueId_;

	private ImapClient client;

	private ImapClient imapClient;

	private const string mailServer = "imap.gmail.com";

	private const int port = 993;

	private const bool ssl = true;

	private ImapClient ImapClient => imapClient ?? (imapClient = new ImapClient());

	internal bool CheckMail(string email, string emai_password)
	{
		bool result = false;
		try
		{
			ImapClient.ServerCertificateValidationCallback = (object s, X509Certificate c, X509Chain h, SslPolicyErrors e) => true;
			ImapClient imapClient = ImapClient;
			string host = "imap.gmail.com";
			imapClient.Connect(host, 993, useSsl: true);
			ImapClient.Authenticate(email, emai_password);
			result = true;
		}
		catch
		{
		}
		return result;
	}

	internal string getotp(string email, string emai_password)
	{
		return "0";
	}

	private void DeleteEmail(uint uniqueId)
	{
		try
		{
			IMailFolder inbox = ImapClient.Inbox;
			inbox.Open(FolderAccess.ReadWrite);
			inbox.AddFlags(new UniqueId(uniqueId), MessageFlags.Deleted, silent: false);
			if (ImapClient.Capabilities.HasFlag(ImapCapabilities.UidPlus))
			{
				inbox.Expunge(new UniqueId[1]
				{
					new UniqueId(uniqueId)
				});
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
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
}
