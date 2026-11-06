using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using APP_FRAMEWORK;
using Bunifu.Framework.UI;

namespace Booking;

public class frmPAYTM_BYPASS : Form
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private CookieContainer cookieContainer_0;

	private Dictionary<string, string> B0AAA;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string Brwpath;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal string string_10;

	internal string string_11;

	internal string string_12;

	internal string string_13;

	private WebException C0AA0;

	private static List<string> list_0;

	private static object object_0;

	private string string_0;

	private WebProxy webProxy_0;

	private bool bool_0;

	private string string_14 = "";

	private string string_15 = "";

	private CookieContainer cookieContainer_1 = new CookieContainer();

	private string string_16;

	private string string_17;

	private string B1AAA;

	private string C1AA0;

	private string string_18;

	private string string_19;

	private string string_20;

	private string string_21;

	private string string_22;

	private static RijndaelManaged rijndaelManaged_0;

	private IContainer icontainer_0;

	private ComboBox cmbBanks5;

	private Button btnbypass;

	private TextBox txtOTP5;

	private Button B2AAA;

	private BunifuElipse C2AA0;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label label50;

	private BunifuDragControl bunifuDragControl_0;

	private Panel panel1;

	private void btnbypass_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		if (cmbBanks5.SelectedIndex <= 0)
		{
			string text = "Select PAYTM Account";
			string caption = "Error";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		string_2 = cmbBanks5.SelectedItem.ToString();
		string_3 = B0AAA[string_2];
		string text2 = string_3;
		string[] array = new string[1];
		string text3 = "||";
		array[0] = text3;
		string[] array2 = text2.Split(array, StringSplitOptions.RemoveEmptyEntries);
		if (array2.Length == 2)
		{
			string_4 = array2[0];
			string_5 = array2[1];
		}
		string startupPath = Application.StartupPath;
		string path = "PAYTM";
		string text4 = Path.Combine(startupPath, path);
		if (!Directory.Exists(text4))
		{
			Directory.CreateDirectory(text4);
		}
		string text5 = "\\";
		string text6 = string_4;
		string text7 = ".rg";
		Brwpath = text4 + text5 + text6 + text7;
		if (array2.Length <= 2)
		{
			string startupPath2 = Application.StartupPath;
			string path2 = "PAYTM";
			string text8 = Path.Combine(startupPath2, path2);
			string text9 = "\\";
			string text10 = string_4;
			string text11 = ".rg";
			string path3 = text8 + text9 + text10 + text11;
			if (File.Exists(path3))
			{
				File.Delete(path3);
			}
			string string_ = "";
			string text12 = string_4;
			string text13 = "||";
			if (CAAA0(text12 + text13 + string_5, ref string_, 0))
			{
				txtOTP5.Visible = true;
				B2AAA.Visible = true;
				txtOTP5.Focus();
				btnbypass.Visible = false;
			}
			else
			{
				string text14 = "Error occured while processing request!";
				string caption2 = "Error";
				MessageBox.Show(text14, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			string text15 = "OTP is already By-Passed for ";
			string text16 = string_2;
			string text17 = "\r\n\r\nIf you want to setup again then Delete the bank and Add again.";
			string text18 = text15 + text16 + text17;
			string caption3 = "Already By-Passed";
			MessageBox.Show(text18, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void method_1()
	{
	}

	private void cmbBanks5_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	public frmPAYTM_BYPASS()
	{
		InitializeComponent();
	}

	private void frmPAYTM_BYPASS_Load(object sender, EventArgs e)
	{
		B0AAA = new Dictionary<string, string>();
		method_2();
	}

	private void method_2()
	{
		new DataTable();
		cmbBanks5.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks5.Items;
		string item = "Select Bank Account";
		items.Add(item);
		Dictionary<string, string> dictionary = Staticm.PAYTM();
		foreach (string key in dictionary.Keys)
		{
			B0AAA.Add(key, dictionary[key]);
			cmbBanks5.Items.Add(key);
		}
		cmbBanks5.SelectedIndex = 0;
	}

	private string method_3(int int_4, string string_23)
	{
		Random random = new Random();
		return new string((from s in Enumerable.Repeat(string_23, int_4)
			select s[random.Next(s.Length)]).ToArray());
	}

	private string method_4(string string_23, string string_24, string string_25)
	{
		try
		{
			int num = string_24.Length + 3;
			string text = string_23.Substring(string_23.IndexOf(string_24) + num);
			return text.Substring(0, text.IndexOf(string_25));
		}
		catch (Exception ex)
		{
			return ex.ToString();
		}
	}

	private void B2AAA_Click(object sender, EventArgs e)
	{
		if (txtOTP5.Text.Trim().Length != 6)
		{
			string text = "Enter Correct OTP!";
			string caption = "Error";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtOTP5.Text = null;
			txtOTP5.Focus();
		}
		else if (!method_5(txtOTP5.Text.Trim()))
		{
			string text2 = "Error occured while processing request!";
			string caption2 = "Error";
			MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else
		{
			Close();
		}
	}

	private void BAAAA(object sender, EventArgs e)
	{
		Close();
	}

	private bool CAAA0(string string_23, ref string string_24, int int_4)
	{
		bool result = false;
		try
		{
			string[] array = new string[1];
			string text = "||";
			array[0] = text;
			string[] array2 = string_23.Split(array, StringSplitOptions.None);
			string_14 = array2[0];
			string_15 = array2[1];
			string string_25 = "0123456789";
			string_16 = method_3(15, string_25);
			string text2 = "OPPO-A1601-";
			string_17 = text2 + string_16;
			string string_26 = "0123456789";
			string text3 = method_3(19, string_26);
			string text4 = "f";
			B1AAA = text3 + text4;
			string[] array3 = new string[5];
			string text5 = "https://accounts.paytm.com/v2/user?fetch_strategy=DEFAULT,USERID,USER_TYPE,USER_CREDENTIAL&deviceIdentifier=";
			array3[0] = text5;
			array3[1] = string_17;
			string text6 = "&deviceManufacturer=OPPO&deviceName=A1601&client=androidapp&version=6.0.3&playStore=false&language=en&networkType=WIFI&imei=";
			array3[2] = text6;
			array3[3] = string_16;
			string text7 = "&osVersion=5.1";
			array3[4] = text7;
			C1AA0 = string.Concat(array3);
			string[] array4 = new string[6];
			string text8 = "?deviceIdentifier=";
			array4[0] = text8;
			array4[1] = string_17;
			string text9 = "&deviceManufacturer=OPPO&deviceName=A1601&client=androidapp&version=6.0.3&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&imei=";
			array4[2] = text9;
			array4[3] = string_16;
			string text10 = "&osVersion=5.1&sim1=";
			array4[4] = text10;
			array4[5] = B1AAA;
			string_18 = string.Concat(array4);
			string_19 = "";
			string_20 = "";
			string_21 = "";
			string_22 = "";
			bool_0 = true;
			string text11 = "Basic bWFya2V0LWFwcDo5YTA3MTc2Mi1hNDk5LTRiZDktOTE0YS00MzYxZTdjM2Y0YmM=";
			string_0 = text11;
			Http(C1AA0, string_19, string_20, webProxy_0, ref cookieContainer_1, bool_CContainer: true, bool_26: true, 60000, 60000, ref string_21, ref string_22, ref C0AA0);
			bool_0 = true;
			string text12 = "https://accounts.paytm.com/oauth2/authorize";
			C1AA0 = text12 + string_18;
			string text13 = "response_type=code&do_not_redirect=true&scope=paytm&client_id=market-app&username=";
			string text14 = string_14;
			string text15 = "&password=";
			string_19 = text13 + text14 + text15 + string_15;
			if (!Http(C1AA0, string_19, string_20, webProxy_0, ref cookieContainer_1, bool_CContainer: true, bool_26: true, 60000, 60000, ref string_21, ref string_22, ref C0AA0))
			{
				result = false;
				return false;
			}
			string text16 = string_21;
			string value = "We have sent an OTP";
			if (text16.Contains(value))
			{
				result = true;
				return true;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.StackTrace);
		}
		return result;
	}

	private bool method_5(string string_23)
	{
		bool result = false;
		try
		{
			bool_0 = true;
			string string_24 = string_21;
			string string_25 = "state";
			string string_26 = "\"";
			string text = method_4(string_24, string_25, string_26);
			string[] array = new string[5];
			string text2 = "{\"otp\":\"";
			array[0] = text2;
			array[1] = string_23;
			string text3 = "\",\"state\":\"";
			array[2] = text3;
			array[3] = text;
			string text4 = "\"}";
			array[4] = text4;
			string_19 = string.Concat(array);
			string text5 = "https://accounts.paytm.com/login/validate/otp";
			C1AA0 = text5 + string_18;
			bool_0 = true;
			if (!Http(C1AA0, string_19, string_20, webProxy_0, ref cookieContainer_1, bool_CContainer: false, bool_26: true, 60000, 60000, ref string_21, ref string_22, ref C0AA0))
			{
				result = false;
				return false;
			}
			string text6 = string_21;
			string value = "code";
			if (text6.Contains(value))
			{
				string text7 = "code=";
				string string_27 = string_21;
				string string_28 = "code";
				string string_29 = "\"";
				string text8 = method_4(string_27, string_28, string_29);
				string text9 = "&scope=paytm&grant_type=authorization_code&client_id=market-app&client_secret=9a068364-a499-4bd9-914a-4361e7c3f4bc";
				string_19 = text7 + text8 + text9;
				string text10 = "https://accounts.paytm.com/oauth2/token";
				C1AA0 = text10 + string_18;
				bool_0 = true;
				if (!Http(C1AA0, string_19, string_20, webProxy_0, ref cookieContainer_1, bool_CContainer: true, bool_26: true, 60000, 60000, ref string_21, ref string_22, ref C0AA0))
				{
					result = false;
					return false;
				}
				string text11 = string_21;
				string value2 = "access_token";
				if (text11.Contains(value2))
				{
					string string_30 = string_21;
					string string_31 = "access_token";
					string string_32 = "\"";
					string text12 = method_4(string_30, string_31, string_32);
					string_19 = "";
					string text13 = "https://accounts.paytm.com/oauth2/usertokens/";
					C1AA0 = text13 + text12 + string_18;
					bool_0 = true;
					if (!Http(C1AA0, string_19, string_20, webProxy_0, ref cookieContainer_1, bool_CContainer: true, bool_26: true, 60000, 60000, ref string_21, ref string_22, ref C0AA0))
					{
						result = false;
						return false;
					}
					string text14 = string_21;
					string value3 = "tokens";
					if (text14.Contains(value3))
					{
						string text15 = string_21;
						string value4 = "access_token";
						if (text15.IndexOf(value4) < 0)
						{
							string text16 = "Some Thing Worng With PAYTM Registration Failed-5";
							MessageBox.Show(text16);
							return false;
						}
						string text17 = string_21;
						string text18 = string_21;
						string value5 = "access_token";
						string text19 = text17.Substring(text18.IndexOf(value5) + 15);
						string value6 = "\",";
						string text20 = text19.Substring(0, text19.IndexOf(value6));
						string_21 = string_21.Substring(string_21.IndexOf(text20));
						string text21 = string_21;
						string text22 = string_21;
						string value7 = "access_token";
						string text23 = text21.Substring(text22.IndexOf(value7) + 15);
						string value8 = "\",";
						string text24 = text23.Substring(0, text23.IndexOf(value8));
						string_21 = string_21.Substring(string_21.IndexOf(text24));
						string text25 = string_21;
						string text26 = string_21;
						string value9 = "access_token";
						string text27 = text25.Substring(text26.IndexOf(value9) + 15);
						string value10 = "\",";
						string text28 = text27.Substring(0, text27.IndexOf(value10));
						string_21 = string_21.Substring(string_21.IndexOf(text28));
						string text29 = string_21;
						string text30 = string_21;
						string value11 = "access_token";
						string text31 = text29.Substring(text30.IndexOf(value11) + 15);
						string value12 = "\",";
						string text32 = text31.Substring(0, text31.IndexOf(value12));
						string text33 = string_21;
						string text34 = string_21;
						string value13 = "expires";
						string text35 = text33.Substring(text34.IndexOf(value13) + 9);
						string value14 = ",";
						text35.Substring(0, text35.IndexOf(value14));
						DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
						string text36 = ((long)(DateTime.UtcNow.AddDays(5.0) - dateTime).TotalMilliseconds).ToString();
						string text37 = "OPPO-A1601-";
						string text38 = text37 + string_7;
						try
						{
							string[] array2 = new string[13]
							{
								string_3, null, null, null, null, null, null, null, null, null,
								null, null, null
							};
							string text39 = "||";
							array2[1] = text39;
							array2[2] = text20;
							string text40 = "||";
							array2[3] = text40;
							array2[4] = text24;
							string text41 = "||";
							array2[5] = text41;
							array2[6] = text28;
							string text42 = "||";
							array2[7] = text42;
							array2[8] = text32;
							string text43 = "||";
							array2[9] = text43;
							array2[10] = text38;
							string text44 = "||";
							array2[11] = text44;
							array2[12] = text36;
							string_1 = string.Concat(array2);
							string string_33 = "PAYTM";
							method_6(string_33);
							Staticm.method_36();
							cmbBanks5.SelectedIndex = 0;
							result = true;
							return true;
						}
						catch
						{
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.StackTrace);
		}
		return result;
	}

	public static bool smethod_1(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
	{
		if (!Program.BypassAnalizer)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)A_0;
				int num;
				if (httpWebRequest != null)
				{
					string text = httpWebRequest.Address.ToString().ToLower();
					string value = "https://www.google.co.in";
					if (text.Contains(value))
					{
						string issuer = A_1.Issuer;
						string value2 = "CN=Google";
						num = ((!issuer.StartsWith(value2)) ? 1 : 0);
						goto IL_0223;
					}
				}
				num = 0;
				goto IL_0223;
				IL_0079:
				int num2;
				if ((num | num2) != 0)
				{
					Form owner = new Form
					{
						TopMost = true
					};
					string text2 = "Security Failed for S/w. Your ID has been logged.\r\n\r\nPlease contact Your Admin.";
					string caption = "Security";
					MessageBox.Show(owner, text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Application.Exit();
					return false;
				}
				string text3 = A_1.Issuer.ToLower();
				string value3 = "httpanalyze";
				if (!text3.Contains(value3))
				{
					string text4 = A_1.Issuer.ToLower();
					string value4 = "fiddler";
					if (!text4.Contains(value4))
					{
						string text5 = A_1.Issuer.ToLower();
						string value5 = "commview";
						if (!text5.Contains(value5))
						{
							string text6 = A_1.Issuer.ToLower();
							string value6 = "debugger";
							if (!text6.Contains(value6))
							{
								string text7 = A_1.Issuer.ToLower();
								string value7 = "debug";
								if (!text7.Contains(value7))
								{
									string text8 = A_1.Issuer.ToLower();
									string value8 = "sniffer";
									if (!text8.Contains(value8))
									{
										string text9 = A_1.Issuer.ToUpper();
										string value9 = "IEINSPECTOR";
										if (!text9.Contains(value9))
										{
											return true;
										}
									}
								}
							}
						}
					}
				}
				Form owner2 = new Form
				{
					TopMost = true
				};
				string text10 = "Security Failed for S/w. Your ID has been logged.\r\n\r\nPlease contact Your Admin.";
				string caption2 = "Security";
				MessageBox.Show(owner2, text10, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
				return false;
				IL_0223:
				if (httpWebRequest != null)
				{
					string text11 = httpWebRequest.Address.ToString().ToLower();
					string value10 = "irctc.co.in";
					if (text11.Contains(value10))
					{
						string issuer2 = A_1.Issuer;
						string value11 = "CN=GeoTrust";
						num2 = ((!issuer2.StartsWith(value11)) ? 1 : 0);
						goto IL_0079;
					}
				}
				num2 = 0;
				goto IL_0079;
			}
			catch (Exception)
			{
				return true;
			}
		}
		return true;
	}

	internal bool Http(string url_, string postdata_, string reff_, WebProxy proxy, ref CookieContainer C_Container, bool bool_CContainer, bool bool_26, int int_timeout, int int_RWtimeout, ref string response, ref string errormsg, ref WebException Ex)
	{
		int num = 0;
		int num2 = 0;
		if (postdata_ == null)
		{
			postdata_ = "";
		}
		int num3;
		while (true)
		{
			errormsg = "";
			response = "";
			Ex = null;
			num3 = 0;
			HttpWebResponse httpWebResponse = null;
			string text = "";
			string value = "https://www.irctc.co.in";
			int num4;
			if (url_.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) != 0)
			{
				string value2 = "http://www.irctc.co.in";
				if (url_.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase) != 0)
				{
					num4 = 0;
					goto IL_007b;
				}
			}
			num4 = 1;
			goto IL_007b;
			IL_007b:
			int num5 = num4;
			try
			{
				ServicePointManager.DnsRefreshTimeout = 240000;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				ServicePointManager.ServerCertificateValidationCallback = smethod_1;
				ServicePointManager.MaxServicePointIdleTime = 10000;
				ServicePointManager.MaxServicePoints = 10000;
				ServicePointManager.UseNagleAlgorithm = true;
				ServicePointManager.Expect100Continue = false;
				ServicePointManager.CheckCertificateRevocationList = true;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url_);
				httpWebRequest.ProtocolVersion = HttpVersion.Version11;
				httpWebRequest.Proxy = proxy;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				httpWebRequest.ConnectionGroupName = string_9;
				httpWebRequest.Timeout = int_timeout;
				httpWebRequest.ReadWriteTimeout = int_RWtimeout;
				byte[] bytes = Encoding.UTF8.GetBytes(postdata_);
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.CookieContainer = C_Container;
				httpWebRequest.Referer = reff_;
				string method = "POST";
				httpWebRequest.Method = method;
				if (bool_0)
				{
					string userAgent = "Dalvik/2.1.0 (Linux; U; Android 5.1; A1601 Build/LMY47I";
					httpWebRequest.UserAgent = userAgent;
					string contentType = "application/x-www-form-urlencoded";
					httpWebRequest.ContentType = contentType;
					if (!string.IsNullOrEmpty(string_0))
					{
						WebHeaderCollection headers = httpWebRequest.Headers;
						string name = "Authorization";
						headers.Set(name, string_0);
					}
					if (!bool_CContainer)
					{
						string contentType2 = "application/json;charset=UTF-8";
						httpWebRequest.ContentType = contentType2;
					}
					bool_0 = false;
				}
				if (postdata_.Length > 0)
				{
					using Stream stream = httpWebRequest.GetRequestStream();
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					string method2 = "GET";
					httpWebRequest.Method = method2;
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (num5 != 0 && (httpWebResponse.StatusCode == HttpStatusCode.Found || httpWebResponse.StatusCode == HttpStatusCode.MovedPermanently))
				{
					WebHeaderCollection headers2 = httpWebResponse.Headers;
					string name2 = "Location";
					string text2 = headers2[name2].ToString();
					string value3 = "error";
					if (text2.Contains(value3) && num2 < 20)
					{
						Thread.Sleep(200);
						num2++;
						httpWebResponse.Close();
						httpWebResponse = null;
						continue;
					}
				}
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					if (bool_26)
					{
						text = streamReader.ReadToEnd();
					}
					else
					{
						httpWebRequest.Abort();
					}
				}
				response = text;
				num3 = 1;
			}
			catch (WebException ex)
			{
				num3 = 0;
				errormsg = ex.Message;
				Ex = ex;
				if (ex.Response != null)
				{
					int statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
					string text3 = "StatusCode: ";
					string text4 = text3;
					HttpStatusCode httpStatusCode = (HttpStatusCode)statusCode;
					string text5 = httpStatusCode.ToString();
					string text6 = "\t";
					errormsg = text4 + text5 + text6 + errormsg;
					if (num < 1)
					{
						string value4 = "pgi.billdesk.com";
						if (url_.Contains(value4) && statusCode == 504)
						{
							num++;
							continue;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				num3 = 0;
				errormsg = ex2.Message;
				if (num < 3)
				{
					string text7 = errormsg;
					string value5 = "String reference not set to an instance";
					if (text7.Contains(value5))
					{
						errormsg = "";
						num++;
						continue;
					}
				}
			}
			finally
			{
				try
				{
					httpWebResponse?.Close();
				}
				catch
				{
				}
			}
			if (num < 3)
			{
				string text8 = errormsg.ToUpper();
				string value6 = "CONNECTION WAS CLOSED";
				if (!text8.Contains(value6))
				{
					string text9 = errormsg.ToUpper();
					string value7 = "SERVICEUNAVAILABLE";
					if (!text9.Contains(value7))
					{
						string text10 = errormsg.ToUpper();
						string value8 = "UNABLE TO CONNECT";
						if (!text10.Contains(value8))
						{
							goto IL_04fb;
						}
					}
				}
				string text11 = errormsg.ToUpper();
				string value9 = "SERVICEUNAVAILABLE";
				if (text11.Contains(value9))
				{
					Thread.Sleep(2000);
				}
				num++;
				continue;
			}
			goto IL_04fb;
			IL_04fb:
			if (num < 7)
			{
				string text12 = errormsg.ToUpper();
				string value10 = "INTERNAL SERVER ERROR";
				if (text12.Contains(value10))
				{
					Thread.Sleep(500);
					num++;
					continue;
				}
			}
			if (num < 1)
			{
				string text13 = errormsg.ToUpper();
				string value11 = "Gateway Timeout";
				if (text13.Contains(value11))
				{
					string value12 = "freecharge";
					if (url_.Contains(value12))
					{
						num++;
						continue;
					}
				}
			}
			if (num < 5)
			{
				string text14 = errormsg.ToUpper();
				string value13 = "(403)";
				if (text14.Contains(value13))
				{
					Thread.Sleep(500);
					num++;
					continue;
				}
			}
			if (num < 5)
			{
				string text15 = errormsg.ToUpper();
				string value14 = "(502)";
				if (text15.Contains(value14))
				{
					Thread.Sleep(500);
					num++;
					continue;
				}
			}
			if (num >= 3)
			{
				break;
			}
			string text16 = errormsg.ToUpper();
			string value15 = "THE REMOTE NAME COULD NOT BE RESOLVED";
			if (!text16.Contains(value15))
			{
				break;
			}
			Thread.Sleep(500);
			num++;
		}
		return num3 != 0;
	}

	private void method_6(string string_23)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			SQLiteCommand sQLiteCommand = new SQLiteCommand();
			sQLiteConnection.Open();
			sQLiteCommand.Connection = sQLiteConnection;
			string[] array = new string[5];
			string text = "UPDATE [TBL_BANK] SET [BANK_DETAILS] = '";
			array[0] = text;
			array[1] = string_1;
			string text2 = "' WHERE [BANK_SAVEAS] = '";
			array[2] = text2;
			array[3] = string_2;
			string text3 = "'";
			array[4] = text3;
			sQLiteCommand.CommandText = string.Concat(array);
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
			method_7(string_23);
			string text4 = "BANK BY-PASSED SUCCESFULLY.\r\n\r\nBy-Pass Updated successfully, You can use Now.\r\n\rPlease delete all the Tickets having ";
			string text5 = " Bank A/c.";
			string text6 = text4 + string_23 + text5;
			string text7 = " BY-PASSED";
			MessageBox.Show(text6, string_23 + text7, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception)
		{
			string text8 = "Error occured while processing request!";
			string caption = "Error";
			MessageBox.Show(text8, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_7(string string_23)
	{
		string text = "./";
		string text2 = text + string_23;
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = "\\";
		string text4 = string_4;
		string text5 = ".rg";
		using (FileStream fileStream = new FileStream(text2 + text3 + text4 + text5, FileMode.Create, FileAccess.ReadWrite))
		{
			using MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, string_1);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			smethod_1(memoryStream, fileStream);
			fileStream.Close();
		}
		StatClass.method_36();
	}

	public static void smethod_1(Stream stream_0, Stream stream_1)
	{
		smethod_0();
		ICryptoTransform transform = rijndaelManaged_0.CreateEncryptor();
		stream_0.Position = 0L;
		CryptoStream cryptoStream = new CryptoStream(stream_1, transform, CryptoStreamMode.Write);
		smethod_2(stream_0, cryptoStream);
		cryptoStream.FlushFinalBlock();
	}

	private static void smethod_0()
	{
		rijndaelManaged_0 = new RijndaelManaged();
		string password = "/8520*96ASqw";
		Encoding aSCII = Encoding.ASCII;
		string s = "MY*SECRET*KEY+-";
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, aSCII.GetBytes(s));
		rijndaelManaged_0.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged_0.KeySize / 8);
		rijndaelManaged_0.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged_0.BlockSize / 8);
		rijndaelManaged_0.Padding = PaddingMode.PKCS7;
	}

	public static void smethod_2(Stream stream_0, Stream stream_1)
	{
		byte[] array = new byte[16384];
		int count;
		while ((count = stream_0.Read(array, 0, array.Length)) > 0)
		{
			stream_1.Write(array, 0, count);
		}
	}

	public static void smethod_3(Stream stream_0, Stream stream_1)
	{
		smethod_0();
		ICryptoTransform transform = rijndaelManaged_0.CreateDecryptor();
		stream_0.Position = 0L;
		smethod_2(new CryptoStream(stream_0, transform, CryptoStreamMode.Read), stream_1);
		stream_1.Position = 0L;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booking.frmPAYTM_BYPASS));
		this.cmbBanks5 = new System.Windows.Forms.ComboBox();
		this.btnbypass = new System.Windows.Forms.Button();
		this.txtOTP5 = new System.Windows.Forms.TextBox();
		this.B2AAA = new System.Windows.Forms.Button();
		this.C2AA0 = new Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label50 = new System.Windows.Forms.Label();
		this.bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(this.icontainer_0);
		this.panel1 = new System.Windows.Forms.Panel();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.cmbBanks5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cmbBanks5.FormattingEnabled = true;
		this.cmbBanks5.Location = new System.Drawing.Point(46, 23);
		this.cmbBanks5.Name = "cmbBanks5";
		this.cmbBanks5.Size = new System.Drawing.Size(245, 26);
		this.cmbBanks5.TabIndex = 0;
		this.cmbBanks5.SelectedIndexChanged += new System.EventHandler(cmbBanks5_SelectedIndexChanged);
		this.btnbypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnbypass.Location = new System.Drawing.Point(185, 73);
		this.btnbypass.Name = "btnbypass";
		this.btnbypass.Size = new System.Drawing.Size(106, 33);
		this.btnbypass.TabIndex = 1;
		this.btnbypass.Text = "ByPass";
		this.btnbypass.Click += new System.EventHandler(btnbypass_Click);
		this.txtOTP5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOTP5.Location = new System.Drawing.Point(61, 127);
		this.txtOTP5.Name = "txtOTP5";
		this.txtOTP5.Size = new System.Drawing.Size(100, 30);
		this.txtOTP5.TabIndex = 2;
		this.txtOTP5.Visible = false;
		this.B2AAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B2AAA.Location = new System.Drawing.Point(185, 124);
		this.B2AAA.Name = "btnSubmit5";
		this.B2AAA.Size = new System.Drawing.Size(106, 33);
		this.B2AAA.TabIndex = 3;
		this.B2AAA.Text = "Submit OTP";
		this.B2AAA.Visible = false;
		this.B2AAA.Click += new System.EventHandler(B2AAA_Click);
		this.C2AA0.ElipseRadius = 5;
		this.C2AA0.TargetControl = this;
		this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label50);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(347, 35);
		this.pnlHeader.TabIndex = 1211;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(309, 5);
		this.btnClose.Margin = new System.Windows.Forms.Padding(4);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(32, 25);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(BAAAA);
		this.label50.AutoSize = true;
		this.label50.BackColor = System.Drawing.Color.Transparent;
		this.label50.Font = new System.Drawing.Font("Segoe UI Semibold", 11f, System.Drawing.FontStyle.Bold);
		this.label50.ForeColor = System.Drawing.Color.White;
		this.label50.Location = new System.Drawing.Point(6, 5);
		this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(174, 25);
		this.label50.TabIndex = 0;
		this.label50.Text = "PAYTM OTP ByPass";
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = this.pnlHeader;
		this.bunifuDragControl_0.Vertical = true;
		this.panel1.BackColor = System.Drawing.SystemColors.Control;
		this.panel1.Controls.Add(this.cmbBanks5);
		this.panel1.Controls.Add(this.btnbypass);
		this.panel1.Controls.Add(this.B2AAA);
		this.panel1.Controls.Add(this.txtOTP5);
		this.panel1.Location = new System.Drawing.Point(3, 33);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(340, 178);
		this.panel1.TabIndex = 1212;
		base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.DarkSlateBlue;
		base.ClientSize = new System.Drawing.Size(347, 215);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.pnlHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmPAYTM_BYPASS";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmPAYTM_BYPASS";
		base.TopMost = true;
		base.Load += new System.EventHandler(frmPAYTM_BYPASS_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		base.ResumeLayout(false);
	}
}
