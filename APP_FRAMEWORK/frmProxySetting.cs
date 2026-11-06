using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

public class frmProxySetting : Form
{
	internal static List<string> list_IP = new List<string>();

	public static string ipfile;

	internal bool check_;

	internal bool checkProxy;

	public static string mip;

	public static string fileTxt;

	private IContainer components;

	private BunifuElipse bunifuElipse1;

	private Label label10;

	private GroupBox groupBox1;

	private Label label9;

	private Button btn_save;

	private Label label8;

	private Label label7;

	private Label label6;

	private Label label5;

	private TextBox txt_ipPass;

	private TextBox txt_ipUser;

	private TextBox txt_port;

	private TextBox txt_ip;

	private CheckBox checkPrivate;

	private CheckBox checkSystem;

	private CheckBox checkAdmin;

	private Button button1;

	private Label label2;

	private GroupBox groupBox3;

	private GroupBox groupBox2;

	private Panel pnlHeader;

	internal Label formName;

	private GroupBox groupBox4;

	private Label label11;

	private Label label4;

	private Label label3;

	private Label label1;

	private TextBox txt_SLTime;

	private TextBox txt_AcTime;

	private System.Windows.Forms.Timer timer1;

	private Label label12;

	private Label label14;

	private Label label13;

	private Label label15;

	private Button button3;

	private CheckBox check_irctc;

	private GroupBox groupBox5;

	private Button btn_delete;

	private ComboBox comboIP;

	private Button btn_check;

	private Panel panel1;

	private GroupBox groupBox6;

	private Button button2;

	private TextBox text_limit;

	private BunifuImageButton btnClose;

	private Label label16;

	public static WebProxy Proxy_ { get; private set; }

	public frmProxySetting()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		try
		{
			string str = "";
			string[] array = new string[7] { txt_ip.Text, null, null, null, null, null, null };
			string text = "||";
			array[1] = text;
			array[2] = txt_port.Text;
			string text2 = "||";
			array[3] = text2;
			array[4] = txt_ipUser.Text;
			string text3 = "||";
			array[5] = text3;
			array[6] = txt_ipPass.Text;
			string parameter = string.Concat(array);
			if (string.IsNullOrEmpty(txt_ip.Text) | string.IsNullOrEmpty(txt_port.Text) | string.IsNullOrEmpty(txt_ipUser.Text) | string.IsNullOrEmpty(txt_ipPass.Text))
			{
				Form owner = new Form
				{
					TopMost = true
				};
				string text4 = "Please Enter Details Propperly";
				string caption = "Information";
				MessageBox.Show(owner, text4, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (check_irctc.Checked && !Check_IP(parameter, ref str))
			{
				Form owner2 = new Form
				{
					TopMost = true
				};
				string text5 = str;
				string caption2 = "Information";
				MessageBox.Show(owner2, text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (list_IP.FirstOrDefault((string stringToCheck) => stringToCheck.Contains(parameter)) == null)
			{
				list_IP.Add(parameter);
				string text6 = null;
				foreach (string item in list_IP)
				{
					if (!string.IsNullOrEmpty(text6))
					{
						string text7 = text6;
						string text8 = "####";
						text6 = text7 + text8 + item;
					}
					else
					{
						text6 = item;
					}
				}
				string path = "IRLOG//IP.Proxy";
				File.WriteAllText(path, text6);
				txt_ip.Text = null;
				txt_port.Text = null;
				txt_ipUser.Text = null;
				txt_ipPass.Text = null;
			}
			ipAdd();
			if (check_irctc.Checked)
			{
				Form owner3 = new Form
				{
					TopMost = true
				};
				string text9 = str;
				string text10 = "and Save SuccessFully";
				string text11 = text9 + text10;
				string caption3 = "Information";
				MessageBox.Show(owner3, text11, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				Form owner4 = new Form
				{
					TopMost = true
				};
				string text12 = "Save SuccessFully";
				string caption4 = "Information";
				MessageBox.Show(owner4, text12, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch
		{
		}
	}

	private void FrmProxySetting_Load(object sender, EventArgs e)
	{
		try
		{
			text_limit.Text = Program.mySettings_0.perIPlimit;
			label9.Text = mip;
			if (string.IsNullOrEmpty(Program.mySettings_0.Ac_avl) || string.IsNullOrEmpty(Program.mySettings_0.Sl_avl))
			{
				TextBox textBox = txt_AcTime;
				string text = "53";
				textBox.Text = text;
				TextBox textBox2 = txt_SLTime;
				string text2 = "47";
				textBox2.Text = text2;
			}
			else
			{
				txt_AcTime.Text = Program.mySettings_0.Ac_avl;
				txt_SLTime.Text = Program.mySettings_0.Sl_avl;
			}
			ipAdd();
		}
		catch
		{
		}
	}

	public void ipAdd()
	{
		comboIP.Items.Clear();
		ComboBox.ObjectCollection items = comboIP.Items;
		string item = "Select Proxy";
		items.Add(item);
		comboIP.SelectedIndex = 0;
		string text = "IRLOG//IP.Proxy";
		ipfile = text;
		if (File.Exists(ipfile))
		{
			fileTxt = File.ReadAllText(ipfile);
			string text2 = fileTxt;
			string[] array = new string[1];
			string text3 = "####";
			array[0] = text3;
			string[] array2 = text2.Split(array, StringSplitOptions.None);
			string[] array3 = array2;
			string[] array4 = array3;
			foreach (string item2 in array4)
			{
				if (!string.IsNullOrEmpty(item2))
				{
					if (Program.list_Proxy.FirstOrDefault((string stringToCheck) => stringToCheck.Contains(item2)) == null)
					{
						Program.int_Slot += 2;
						Program.list_Proxy.Add(item2);
					}
					if (list_IP.FirstOrDefault((string stringToCheck) => stringToCheck.Contains(item2)) == null)
					{
						list_IP.Add(item2);
					}
					if (!comboIP.Items.Contains(item2))
					{
						string text4 = item2;
						string[] array5 = new string[1];
						string text5 = "||";
						array5[0] = text5;
						string[] array6 = text4.Split(array5, StringSplitOptions.None);
						comboIP.Items.Add(array6[0]);
					}
				}
			}
		}
		Program.int_Slot = 2 + Program.list_Proxy.Count * 2;
	}

	internal void m0()
	{
		Thread thread = new Thread(GetLocalIPAddress);
		thread.IsBackground = true;
		thread.Start(0);
	}

	private void CheckAdmin_CheckedChanged(object sender, EventArgs e)
	{
		if (checkAdmin.Checked)
		{
			mySettings mySettings_ = Program.mySettings_0;
			string proxy_use = "admin";
			mySettings_.Proxy_use = proxy_use;
			checkPrivate.Checked = false;
			checkSystem.Checked = false;
		}
	}

	private void CheckSystem_CheckedChanged(object sender, EventArgs e)
	{
		if (checkSystem.Checked)
		{
			mySettings mySettings_ = Program.mySettings_0;
			string proxy_use = "system";
			mySettings_.Proxy_use = proxy_use;
			checkPrivate.Checked = false;
			checkAdmin.Checked = false;
		}
	}

	private void CheckPrivate_CheckedChanged(object sender, EventArgs e)
	{
		if (checkPrivate.Checked)
		{
			mySettings mySettings_ = Program.mySettings_0;
			string proxy_use = "private";
			mySettings_.Proxy_use = proxy_use;
			checkSystem.Checked = false;
			checkAdmin.Checked = false;
		}
	}

	internal void GetLocalIPAddress(object j)
	{
		string variable = "PrivateProxy";
		Environment.SetEnvironmentVariable(variable, "", EnvironmentVariableTarget.Process);
		string text = null;
		while (true)
		{
			try
			{
				string requestUriString = "http://checkip.dyndns.org";
				text = new StreamReader(WebRequest.Create(requestUriString).GetResponse().GetResponseStream()).ReadToEnd().Trim().Split(':')[1].Substring(1).Split('<')[0];
			}
			catch
			{
				continue;
			}
			break;
		}
		mip = text;
		label9.Text = mip;
		Program.bool_SystemIP = true;
		try
		{
			string requestUriString2 = "https://www.irctc.co.in/nget/train-search";
			WebRequest webRequest = WebRequest.Create(requestUriString2);
			webRequest.Proxy = Proxy_;
			webRequest.Timeout = 11000;
			string text2 = new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd().Trim();
			string value = "IRCTC Next Generation eTicketing System";
			if (text2.Contains(value))
			{
				Label label = label12;
				string text3 = "IRCTC Server is Working on Your IP Adress";
				label.Text = text3;
				label12.BackColor = Color.LightCyan;
				label12.ForeColor = Color.Black;
			}
		}
		catch
		{
			Program.bool_SystemIP = false;
		}
		int num = 1;
		foreach (string item in Program.list_Proxy)
		{
			num++;
			string[] array = new string[1];
			string text4 = "||";
			array[0] = text4;
			string[] array2 = item.Split(array, StringSplitOptions.None);
			Proxy_ = new WebProxy(array2[0].Trim(), int.Parse(array2[1].Trim()));
			Proxy_.BypassProxyOnLocal = true;
			Proxy_.Credentials = new NetworkCredential(array2[2].Trim(), array2[3].Trim());
			try
			{
				string requestUriString3 = "https://www.irctc.co.in/nget/train-search";
				WebRequest webRequest2 = WebRequest.Create(requestUriString3);
				webRequest2.Proxy = Proxy_;
				webRequest2.Timeout = 11000;
				string text5 = new StreamReader(webRequest2.GetResponse().GetResponseStream()).ReadToEnd().Trim();
				string value2 = "IRCTC Next Generation eTicketing System";
				if (text5.Contains(value2))
				{
					string variable2 = "PrivateProxy";
					Environment.SetEnvironmentVariable(variable2, item.ToString(), EnvironmentVariableTarget.Process);
					if (txt_ip.Text == array2[0])
					{
						checkPrivate.Checked = true;
					}
					Program.int_WorkingIP = num * 2;
					label12.BackColor = Color.LightCyan;
					label12.ForeColor = Color.Black;
					Label label2 = label12;
					string text6 = "IRCTC Server is Working on Your IP Adress";
					label2.Text = text6;
					break;
				}
			}
			catch
			{
				if (txt_ip.Text == array2[0])
				{
					checkPrivate.Checked = false;
				}
				label12.BackColor = Color.Red;
				label12.ForeColor = Color.White;
				Label label3 = label12;
				string text7 = "IRCTC Server is Not Working on Your IP Adress";
				label3.Text = text7;
			}
		}
	}

	private static bool CheckCertificate(object object_18, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		return true;
	}

	private bool Check_IP(object object_0, ref string str0)
	{
		bool result = false;
		string text = object_0.ToString();
		string[] array = new string[1];
		string text2 = "||";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		string text3 = "Not Working";
		str0 = text3;
		try
		{
			if (array2.Length > 3)
			{
				Proxy_ = new WebProxy(array2[0].Trim(), int.Parse(array2[1].Trim()));
				Proxy_.BypassProxyOnLocal = true;
				Proxy_.Credentials = new NetworkCredential(array2[2].Trim(), array2[3].Trim());
			}
			string requestUriString = "https://www.irctc.co.in/nget/train-search";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			httpWebRequest.ServerCertificateValidationCallback = CheckCertificate;
			ServicePointManager.Expect100Continue = false;
			httpWebRequest.ProtocolVersion = HttpVersion.Version11;
			httpWebRequest.Proxy = Proxy_;
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
			new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, TimeSpan.FromDays(0.0));
			httpWebRequest.CachePolicy = cachePolicy;
			httpWebRequest.KeepAlive = true;
			string connection = "keepalive";
			httpWebRequest.Connection = connection;
			httpWebRequest.Timeout = 10000;
			httpWebRequest.ReadWriteTimeout = 10000;
			string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
			httpWebRequest.Accept = accept;
			string contentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.AllowAutoRedirect = true;
			string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36";
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Language";
			string value = "en-US,en;q=0.9,hi;q=0.8";
			headers.Add(name, value);
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Origin";
			string value2 = "https://www.irctc.co.in";
			headers2.Add(name2, value2);
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "bmirak";
			string value3 = "webbm";
			headers3.Add(name3, value3);
			string text4 = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd().Trim();
			string value4 = "nget";
			if (text4.Contains(value4))
			{
				string text5 = "Proxy is Working";
				str0 = text5;
				result = true;
			}
		}
		catch (Exception ex)
		{
			string text6 = "Not Working";
			str0 = text6;
			string message = ex.Message;
			string value5 = "Authentication Required";
			if (message.Contains(value5))
			{
				string text7 = "Invalid Proxy Username or Password";
				str0 = text7;
			}
		}
		return result;
	}

	internal void AddSlot()
	{
		if (!string.IsNullOrEmpty(Program.mySettings_0.PrivateIP))
		{
			string text = Program.mySettings_0.PrivateIP.ToString();
			string[] array = new string[1];
			string text2 = ":";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.None);
			if (Program.list_Proxy.FirstOrDefault((string stringToCheck) => stringToCheck.Contains(array2[0])) == null)
			{
				Program.int_Slot += 2;
				List<string> list_Proxy = Program.list_Proxy;
				string text3 = Program.mySettings_0.PrivateIP.ToString();
				string oldValue = ":";
				string newValue = "||";
				list_Proxy.Add(text3.Replace(oldValue, newValue));
				string variable = "PrivateProxy";
				string text4 = Program.mySettings_0.PrivateIP.ToString();
				string oldValue2 = ":";
				string newValue2 = "||";
				Environment.SetEnvironmentVariable(variable, text4.Replace(oldValue2, newValue2), EnvironmentVariableTarget.Process);
			}
		}
	}

	public void check_0(object j)
	{
		try
		{
			bool flag = false;
			string requestUriString = "https://www.irctc.co.in/nget/train-search";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.Proxy = Proxy_;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "bmirak";
			string value = "webbm";
			headers.Add(name, value);
			httpWebRequest.Timeout = 8000;
			httpWebRequest.ReadWriteTimeout = 8000;
			using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
			{
				streamReader.ReadToEnd();
				flag = true;
			}
			if (!flag & !string.IsNullOrEmpty(Program.mySettings_0.PrivateIP))
			{
				Class47.prx0 = new WebProxy();
				string text = Program.mySettings_0.PrivateIP.ToString();
				string[] array = new string[1];
				string text2 = ":";
				array[0] = text2;
				string[] array2 = text.Split(array, StringSplitOptions.None);
				Class47.prx0 = new WebProxy(array2[0].Trim(), int.Parse(array2[1].Trim()));
				Class47.prx0.BypassProxyOnLocal = true;
				Class47.prx0.Credentials = new NetworkCredential(array2[2].Trim(), array2[3].Trim());
			}
		}
		catch
		{
		}
	}

	private void Txt_ip_Leave(object sender, EventArgs e)
	{
		string text = txt_ip.Text;
		string value = ":";
		if (text.Contains(value))
		{
			string text2 = (new string[1] { txt_ip.Text })[0].Trim();
			string[] array = new string[1];
			string text3 = ":";
			array[0] = text3;
			string[] array2 = text2.Split(array, StringSplitOptions.RemoveEmptyEntries);
			txt_ip.Text = array2[0];
			txt_port.Text = array2[1];
			txt_ipUser.Text = array2[2];
			txt_ipPass.Text = array2[3];
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void FrmProxySetting_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void Txt_AcTime_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void Txt_AcTime_Leave(object sender, EventArgs e)
	{
		TextBox textBox = sender as TextBox;
		int.TryParse(textBox.Text, out var result);
		if (result > 55 && textBox.Text != "")
		{
			string text = "55";
			textBox.Text = text;
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Form owner = new Form
		{
			TopMost = true
		};
		string text = "Do You Want to Delete All Proxy";
		string caption = "Delete Proxy";
		if (MessageBox.Show(owner, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
		{
			string path = "IRLOG//IP.Proxy";
			File.Delete(path);
			ipAdd();
			Form owner2 = new Form
			{
				TopMost = true
			};
			string text2 = "All Proxy Deleted Successfully";
			string caption2 = "Delete";
			MessageBox.Show(owner2, text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void writeFile(string str)
	{
		string text = null;
		string item = list_IP.FirstOrDefault((string stringToCheck) => stringToCheck.Contains(str));
		list_IP.Remove(item);
		Program.list_Proxy.Remove(item);
		Program.int_Slot -= 2;
		foreach (string item2 in list_IP)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = item2;
				continue;
			}
			string text2 = text;
			string text3 = "####";
			text = text2 + text3 + item2;
		}
		string path = "IRLOG//IP.Proxy";
		File.WriteAllText(path, text);
		base.Height = 117;
		ipAdd();
		Program.int_Slot = 2 + Program.list_Proxy.Count * 2;
	}

	private void check_irctc_CheckedChanged(object sender, EventArgs e)
	{
		if (check_irctc.Checked)
		{
			Button button = btn_save;
			string text = "Check && Save";
			button.Text = text;
		}
		else
		{
			Button button2 = btn_save;
			string text2 = "Save";
			button2.Text = text2;
		}
	}

	private void btn_delete_Click(object sender, EventArgs e)
	{
		Form owner = new Form
		{
			TopMost = true
		};
		string text = "Do You Want to Delete Selected Proxy";
		string caption = "Delete Proxy";
		if (MessageBox.Show(owner, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK || comboIP.SelectedIndex <= 0)
		{
			return;
		}
		string txt = comboIP.SelectedItem.ToString();
		list_IP.RemoveAll((string item) => item.Contains(txt));
		string text2 = null;
		foreach (string item in list_IP)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				string text3 = text2;
				string text4 = "####";
				text2 = text3 + text4 + item;
			}
			else
			{
				text2 = item;
			}
		}
		string path = "IRLOG//IP.Proxy";
		File.WriteAllText(path, text2);
		Form owner2 = new Form
		{
			TopMost = true
		};
		string text5 = "Proxy Deleted Successfully";
		string caption2 = "Delete";
		MessageBox.Show(owner2, text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		ipAdd();
	}

	private void btn_check_Click(object sender, EventArgs e)
	{
		if (comboIP.SelectedIndex > 0)
		{
			string str = "";
			string object_ = list_IP[comboIP.SelectedIndex - 1];
			Check_IP(object_, ref str);
			Form owner = new Form
			{
				TopMost = true
			};
			string text = str;
			string caption = "Information";
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void button2_Click_1(object sender, EventArgs e)
	{
		Program.mySettings_0.perIPlimit = text_limit.Text.Trim();
		string variable = "perIPlimit";
		Environment.SetEnvironmentVariable(variable, Program.mySettings_0.perIPlimit);
		Form owner = new Form
		{
			TopMost = true
		};
		string text = "Save Successfully";
		string caption = "Success";
		MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void text_limit_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmProxySetting));
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.label15 = new System.Windows.Forms.Label();
		this.checkAdmin = new System.Windows.Forms.CheckBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.checkSystem = new System.Windows.Forms.CheckBox();
		this.checkPrivate = new System.Windows.Forms.CheckBox();
		this.txt_ip = new System.Windows.Forms.TextBox();
		this.txt_port = new System.Windows.Forms.TextBox();
		this.txt_ipUser = new System.Windows.Forms.TextBox();
		this.txt_ipPass = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.btn_save = new System.Windows.Forms.Button();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label13 = new System.Windows.Forms.Label();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.check_irctc = new System.Windows.Forms.CheckBox();
		this.button3 = new System.Windows.Forms.Button();
		this.label14 = new System.Windows.Forms.Label();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.formName = new System.Windows.Forms.Label();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.txt_SLTime = new System.Windows.Forms.TextBox();
		this.txt_AcTime = new System.Windows.Forms.TextBox();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.label12 = new System.Windows.Forms.Label();
		this.comboIP = new System.Windows.Forms.ComboBox();
		this.btn_check = new System.Windows.Forms.Button();
		this.btn_delete = new System.Windows.Forms.Button();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.button2 = new System.Windows.Forms.Button();
		this.text_limit = new System.Windows.Forms.TextBox();
		this.label16 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		this.groupBox4.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox6.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		this.groupBox1.Controls.Add(this.label15);
		this.groupBox1.Controls.Add(this.checkAdmin);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Location = new System.Drawing.Point(610, 213);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(320, 46);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "IP BY ADMIN";
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(131, 21);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(67, 13);
		this.label15.TabIndex = 19;
		this.label15.Text = "Not Working";
		this.label15.Visible = false;
		this.checkAdmin.AutoSize = true;
		this.checkAdmin.Location = new System.Drawing.Point(298, 21);
		this.checkAdmin.Name = "checkAdmin";
		this.checkAdmin.Size = new System.Drawing.Size(15, 14);
		this.checkAdmin.TabIndex = 5;
		this.checkAdmin.UseVisualStyleBackColor = true;
		this.checkAdmin.Visible = false;
		this.checkAdmin.CheckedChanged += new System.EventHandler(CheckAdmin_CheckedChanged);
		this.button1.Location = new System.Drawing.Point(207, 15);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 4;
		this.button1.Text = "Check";
		this.button1.UseVisualStyleBackColor = true;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(8, 21);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(82, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "202.103.94.108";
		this.checkSystem.AutoSize = true;
		this.checkSystem.Location = new System.Drawing.Point(298, 23);
		this.checkSystem.Name = "checkSystem";
		this.checkSystem.Size = new System.Drawing.Size(15, 14);
		this.checkSystem.TabIndex = 6;
		this.checkSystem.UseVisualStyleBackColor = true;
		this.checkSystem.Visible = false;
		this.checkSystem.CheckedChanged += new System.EventHandler(CheckSystem_CheckedChanged);
		this.checkPrivate.AutoSize = true;
		this.checkPrivate.Location = new System.Drawing.Point(749, 186);
		this.checkPrivate.Name = "checkPrivate";
		this.checkPrivate.Size = new System.Drawing.Size(15, 14);
		this.checkPrivate.TabIndex = 7;
		this.checkPrivate.UseVisualStyleBackColor = true;
		this.checkPrivate.Visible = false;
		this.checkPrivate.CheckedChanged += new System.EventHandler(CheckPrivate_CheckedChanged);
		this.txt_ip.Location = new System.Drawing.Point(8, 41);
		this.txt_ip.Name = "txt_ip";
		this.txt_ip.Size = new System.Drawing.Size(85, 20);
		this.txt_ip.TabIndex = 8;
		this.txt_ip.Leave += new System.EventHandler(Txt_ip_Leave);
		this.txt_port.Location = new System.Drawing.Point(100, 41);
		this.txt_port.Name = "txt_port";
		this.txt_port.Size = new System.Drawing.Size(30, 20);
		this.txt_port.TabIndex = 9;
		this.txt_ipUser.Location = new System.Drawing.Point(136, 41);
		this.txt_ipUser.Name = "txt_ipUser";
		this.txt_ipUser.Size = new System.Drawing.Size(69, 20);
		this.txt_ipUser.TabIndex = 10;
		this.txt_ipPass.Location = new System.Drawing.Point(211, 41);
		this.txt_ipPass.Name = "txt_ipPass";
		this.txt_ipPass.Size = new System.Drawing.Size(69, 20);
		this.txt_ipPass.TabIndex = 11;
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(47, 25);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(17, 13);
		this.label5.TabIndex = 12;
		this.label5.Text = "IP";
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(101, 25);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(26, 13);
		this.label6.TabIndex = 13;
		this.label6.Text = "Port";
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(143, 25);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(55, 13);
		this.label7.TabIndex = 14;
		this.label7.Text = "Username";
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(218, 25);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(53, 13);
		this.label8.TabIndex = 15;
		this.label8.Text = "Password";
		this.btn_save.Location = new System.Drawing.Point(146, 67);
		this.btn_save.Name = "btn_save";
		this.btn_save.Size = new System.Drawing.Size(132, 23);
		this.btn_save.TabIndex = 16;
		this.btn_save.Text = "Save";
		this.btn_save.UseVisualStyleBackColor = true;
		this.btn_save.Click += new System.EventHandler(Button2_Click);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(8, 23);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(52, 13);
		this.label9.TabIndex = 17;
		this.label9.Text = "Checking";
		this.label10.AutoSize = true;
		this.label10.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.label10.Location = new System.Drawing.Point(6, 445);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(42, 13);
		this.label10.TabIndex = 3;
		this.label10.Text = "Note :- ";
		this.groupBox2.Controls.Add(this.label13);
		this.groupBox2.Controls.Add(this.label9);
		this.groupBox2.Controls.Add(this.checkSystem);
		this.groupBox2.Location = new System.Drawing.Point(610, 283);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(320, 51);
		this.groupBox2.TabIndex = 4;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "SYSTEM IP";
		this.label13.AutoSize = true;
		this.label13.Location = new System.Drawing.Point(178, 23);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(67, 13);
		this.label13.TabIndex = 18;
		this.label13.Text = "Not Working";
		this.label13.Visible = false;
		this.groupBox3.Controls.Add(this.check_irctc);
		this.groupBox3.Controls.Add(this.btn_save);
		this.groupBox3.Controls.Add(this.txt_ip);
		this.groupBox3.Controls.Add(this.label8);
		this.groupBox3.Controls.Add(this.label7);
		this.groupBox3.Controls.Add(this.txt_port);
		this.groupBox3.Controls.Add(this.label6);
		this.groupBox3.Controls.Add(this.txt_ipUser);
		this.groupBox3.Controls.Add(this.label5);
		this.groupBox3.Controls.Add(this.txt_ipPass);
		this.groupBox3.Location = new System.Drawing.Point(0, 22);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(289, 96);
		this.groupBox3.TabIndex = 5;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "PRIVATE IP";
		this.check_irctc.AutoSize = true;
		this.check_irctc.Location = new System.Drawing.Point(40, 71);
		this.check_irctc.Name = "check_irctc";
		this.check_irctc.Size = new System.Drawing.Size(92, 17);
		this.check_irctc.TabIndex = 17;
		this.check_irctc.Text = "Check IRCTC";
		this.check_irctc.UseVisualStyleBackColor = true;
		this.check_irctc.CheckedChanged += new System.EventHandler(check_irctc_CheckedChanged);
		this.button3.BackColor = System.Drawing.Color.Red;
		this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.ForeColor = System.Drawing.Color.White;
		this.button3.Location = new System.Drawing.Point(191, 181);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 23);
		this.button3.TabIndex = 20;
		this.button3.Text = "Delete ALL";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(843, 283);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(67, 13);
		this.label14.TabIndex = 19;
		this.label14.Text = "Not Working";
		this.label14.Visible = false;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.formName);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(295, 22);
		this.pnlHeader.TabIndex = 129;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(271, -2);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 24;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click_1);
		this.formName.AutoSize = true;
		this.formName.BackColor = System.Drawing.Color.Transparent;
		this.formName.Enabled = false;
		this.formName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.formName.ForeColor = System.Drawing.Color.Black;
		this.formName.Location = new System.Drawing.Point(2, 2);
		this.formName.Name = "formName";
		this.formName.Size = new System.Drawing.Size(116, 16);
		this.formName.TabIndex = 23;
		this.formName.Text = "Proxy IP Setting";
		this.groupBox4.Controls.Add(this.label11);
		this.groupBox4.Controls.Add(this.label4);
		this.groupBox4.Controls.Add(this.label3);
		this.groupBox4.Controls.Add(this.label1);
		this.groupBox4.Controls.Add(this.txt_SLTime);
		this.groupBox4.Controls.Add(this.txt_AcTime);
		this.groupBox4.Location = new System.Drawing.Point(503, 31);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(320, 80);
		this.groupBox4.TabIndex = 130;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Availablity TIME";
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.Location = new System.Drawing.Point(188, 48);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(71, 16);
		this.label11.TabIndex = 17;
		this.label11.Text = "10  :  59  :";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(188, 16);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(71, 16);
		this.label4.TabIndex = 16;
		this.label4.Text = "09  :  59  :";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(8, 49);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(121, 13);
		this.label3.TabIndex = 14;
		this.label3.Text = "SL Availablity Start AT :-";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(8, 17);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(122, 13);
		this.label1.TabIndex = 13;
		this.label1.Text = "AC Availablity Start AT :-";
		this.txt_SLTime.Location = new System.Drawing.Point(265, 46);
		this.txt_SLTime.MaxLength = 2;
		this.txt_SLTime.Name = "txt_SLTime";
		this.txt_SLTime.Size = new System.Drawing.Size(28, 20);
		this.txt_SLTime.TabIndex = 1;
		this.txt_SLTime.Text = "39";
		this.txt_SLTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Txt_AcTime_KeyPress);
		this.txt_SLTime.Leave += new System.EventHandler(Txt_AcTime_Leave);
		this.txt_AcTime.Location = new System.Drawing.Point(265, 14);
		this.txt_AcTime.MaxLength = 2;
		this.txt_AcTime.Name = "txt_AcTime";
		this.txt_AcTime.Size = new System.Drawing.Size(28, 20);
		this.txt_AcTime.TabIndex = 0;
		this.txt_AcTime.Text = "47";
		this.txt_AcTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Txt_AcTime_KeyPress);
		this.txt_AcTime.Leave += new System.EventHandler(Txt_AcTime_Leave);
		this.timer1.Tick += new System.EventHandler(Timer1_Tick);
		this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label12.Location = new System.Drawing.Point(607, 317);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(333, 20);
		this.label12.TabIndex = 131;
		this.label12.Text = "Checking";
		this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.comboIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboIP.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.comboIP.FormattingEnabled = true;
		this.comboIP.Location = new System.Drawing.Point(4, 25);
		this.comboIP.Margin = new System.Windows.Forms.Padding(2);
		this.comboIP.Name = "comboIP";
		this.comboIP.Size = new System.Drawing.Size(126, 21);
		this.comboIP.TabIndex = 139;
		this.btn_check.Location = new System.Drawing.Point(136, 23);
		this.btn_check.Name = "btn_check";
		this.btn_check.Size = new System.Drawing.Size(59, 23);
		this.btn_check.TabIndex = 140;
		this.btn_check.Text = "Check";
		this.btn_check.UseVisualStyleBackColor = true;
		this.btn_check.Click += new System.EventHandler(btn_check_Click);
		this.btn_delete.Location = new System.Drawing.Point(200, 22);
		this.btn_delete.Name = "btn_delete";
		this.btn_delete.Size = new System.Drawing.Size(79, 23);
		this.btn_delete.TabIndex = 141;
		this.btn_delete.Text = "Delete";
		this.btn_delete.UseVisualStyleBackColor = true;
		this.btn_delete.Click += new System.EventHandler(btn_delete_Click);
		this.groupBox5.Controls.Add(this.comboIP);
		this.groupBox5.Controls.Add(this.btn_delete);
		this.groupBox5.Controls.Add(this.btn_check);
		this.groupBox5.Location = new System.Drawing.Point(0, 123);
		this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox5.Size = new System.Drawing.Size(289, 54);
		this.groupBox5.TabIndex = 139;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Proxy IP";
		this.groupBox6.Controls.Add(this.button2);
		this.groupBox6.Controls.Add(this.text_limit);
		this.groupBox6.Controls.Add(this.label16);
		this.groupBox6.Location = new System.Drawing.Point(0, 219);
		this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox6.Size = new System.Drawing.Size(289, 57);
		this.groupBox6.TabIndex = 140;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "Se Proxy Limit";
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.Location = new System.Drawing.Point(211, 15);
		this.button2.Margin = new System.Windows.Forms.Padding(2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(67, 25);
		this.button2.TabIndex = 17;
		this.button2.Text = "SAVE";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click_1);
		this.text_limit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.text_limit.Location = new System.Drawing.Point(162, 18);
		this.text_limit.Name = "text_limit";
		this.text_limit.Size = new System.Drawing.Size(45, 22);
		this.text_limit.TabIndex = 16;
		this.text_limit.Text = "4";
		this.text_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.text_limit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(text_limit_KeyPress);
		this.label16.AutoSize = true;
		this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label16.Location = new System.Drawing.Point(5, 20);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(151, 17);
		this.label16.TabIndex = 15;
		this.label16.Text = "Per Proxy Pair Limit";
		this.panel1.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
		this.panel1.Location = new System.Drawing.Point(-4, 209);
		this.panel1.Margin = new System.Windows.Forms.Padding(2);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(318, 6);
		this.panel1.TabIndex = 141;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(295, 282);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.groupBox6);
		base.Controls.Add(this.groupBox5);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.checkPrivate);
		base.Controls.Add(this.groupBox4);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.groupBox3);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.groupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmProxySetting";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmProxySetting";
		base.TransparencyKey = System.Drawing.Color.FromArgb(192, 255, 255);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmProxySetting_FormClosing);
		base.Load += new System.EventHandler(FrmProxySetting_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void btnClose_Click_1(object sender, EventArgs e)
	{
		Close();
	}
}
