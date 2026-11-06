using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;

public class Class17
{
	public class CustomWebRequest : IDisposable
	{
		protected HttpWebResponse _myHttpWebResponse;

		private string _URL = string.Empty;

		private ArrayList _ParamsCollection = new ArrayList();

		private Stream _ResponseStream;

		private string _Method = "POST";

		private string _ContentType = "multipart/form-data; boundary=----WebKitFormBoundaryj0AM3cF5ShvILPJX";

		private string _Boundary = "AaB03x";

		private string _Accept = "iso-8859-1";

		public string URL => _URL;

		public ArrayList ParamsCollection
		{
			get
			{
				return _ParamsCollection;
			}
			set
			{
				_ParamsCollection = value;
			}
		}

		public Stream ResponseStream => _ResponseStream;

		public string Method
		{
			get
			{
				return _Method;
			}
			set
			{
				_Method = value;
			}
		}

		public string Boundary
		{
			get
			{
				return _Boundary;
			}
			set
			{
				_Boundary = value;
			}
		}

		public string Accept
		{
			get
			{
				return _Accept;
			}
			set
			{
				_Accept = value;
			}
		}

		public string ResponseString
		{
			get
			{
				string text = "";
				StreamReader streamReader = new StreamReader(_ResponseStream);
				char[] array = new char[256];
				for (int num = streamReader.Read(array, 0, 256); num > 0; num = streamReader.Read(array, 0, 256))
				{
					text += new string(array, 0, num);
					Console.WriteLine(text);
				}
				streamReader.Close();
				return text;
			}
		}

		public CustomWebRequest(string URL)
		{
			_URL = URL;
		}

		~CustomWebRequest()
		{
			Dispose();
		}

		public void PostData()
		{
			try
			{
				string uriString = "https://www.irctcipay.com/pgui/jsp/verifyUpiResponse";
				Uri requestUri = new Uri(uriString);
				ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
				string path = "rss.txt";
				string s = File.ReadAllText(path);
				string path2 = "rss.txt";
				string text = File.ReadAllText(path2);
				string value = "customToken";
				string text2 = text.Substring(text.IndexOf(value) + 20);
				string text3 = text2;
				string text4 = text2;
				string value2 = "\"";
				text2 = text3.Substring(0, text4.IndexOf(value2));
				string value3 = "innerAmount";
				text2 = text.Substring(text.IndexOf(value3) + 13);
				string text5 = text2;
				string text6 = text2;
				string value4 = "<";
				text2 = text5.Substring(0, text6.IndexOf(value4));
				byte[] bytes = aSCIIEncoding.GetBytes(s);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
				httpWebRequest.Method = _Method;
				string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36";
				httpWebRequest.UserAgent = userAgent;
				string accept = "*/*";
				httpWebRequest.Accept = accept;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "Accept-Language";
				string value5 = "en-US,en;q=0.9,hi;q=0.8";
				headers.Add(name, value5);
				httpWebRequest.AllowWriteStreamBuffering = true;
				string contentType = _ContentType;
				if (_Boundary.Length > 0)
				{
					string text7 = contentType;
					string text8 = "boundary=";
					contentType = text7 + text8 + _Boundary;
				}
				httpWebRequest.ContentType = _ContentType;
				httpWebRequest.Accept = _Accept;
				httpWebRequest.ContentLength = bytes.Length;
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				_myHttpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				_ResponseStream = _myHttpWebResponse.GetResponseStream();
			}
			catch (Exception)
			{
			}
		}

		private string GetPostData()
		{
			string text = "--";
			string text2 = text + _Boundary;
			string[] array = new string[_ParamsCollection.Count * 5];
			int num = 0;
			foreach (ParamsStruct item in _ParamsCollection)
			{
				array[num] = text2;
				num++;
				if (item.Type != 0)
				{
					int num2 = num;
					string text3 = "Content-Disposition: form-data; name=\"";
					string name = item.Name;
					string text4 = "\"";
					array[num2] = text3 + name + text4;
					num++;
					array[num] = "";
					num++;
					array[num] = item.StringValue;
					num++;
					continue;
				}
				int num3 = num;
				string[] array2 = new string[5];
				string text5 = "Content-Disposition: file; name=\"";
				array2[0] = text5;
				array2[1] = item.Name;
				string text6 = "\"; filename=\"";
				array2[2] = text6;
				array2[3] = item.GetOnlyFileName();
				string text7 = "\"";
				array2[4] = text7;
				array[num3] = string.Concat(array2);
				num++;
				int num4 = num;
				string text8 = "Content-Type: text/plain";
				array[num4] = text8;
				num++;
				array[num] = "";
				num++;
				array[num] = item.StringValue;
				num++;
			}
			array[num] = text2;
			num++;
			string separator = "\r\n";
			return string.Join(separator, array);
		}

		public void Dispose()
		{
			if (_myHttpWebResponse != null)
			{
				_myHttpWebResponse.Close();
				_myHttpWebResponse = null;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose();
		}
	}

	public class ParamsStruct
	{
		public enum ParamType
		{
			File,
			Parameter
		}

		private string _Name = string.Empty;

		private object _Value;

		private ParamType _Type = ParamType.Parameter;

		private string _FileName = string.Empty;

		public string Name => _Name;

		public object Value => _Value;

		public string StringValue
		{
			get
			{
				switch (_Type)
				{
				default:
					return _Value.ToString();
				case ParamType.Parameter:
					return (string)_Value;
				case ParamType.File:
					if (_Value is Stream stream)
					{
						return new StreamReader(stream).ReadToEnd();
					}
					return (string)_Value;
				}
			}
		}

		public ParamType Type => _Type;

		public string FileName => _FileName;

		public ParamsStruct(string name, object value)
		{
			_Name = name;
			_Value = value;
		}

		public ParamsStruct(string name, object value, ParamType type, string fileName)
		{
			_Name = name;
			_Value = value;
			_Type = type;
			_FileName = fileName;
		}

		public string GetOnlyFileName()
		{
			return Path.GetFileName(_FileName);
		}
	}

	public void gbm()
	{
		new CustomWebRequest(null).PostData();
	}
}
