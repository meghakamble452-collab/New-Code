using System.Drawing;
using System.Globalization;
using System.Resources;

namespace Booking;

internal class Class32
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				string baseName = "NEXUS.APP_FRAMEWORK.Class32";
				resourceManager_0 = new ResourceManager(baseName, typeof(Class32).Assembly);
			}
			return resourceManager_0;
		}
	}

	internal static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal static Bitmap Actions_ok_icon
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "Actions_ok_icon";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string allowedUser1
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "allowedUser1";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string allowedUser2
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "allowedUser2";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string anlKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "anlKey";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string aPath1
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "aPath1";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string aPath2
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "aPath2";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string aPath3
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "aPath3";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap Cancel32
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "Cancel32";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string chanceKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "chanceKey";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap cross
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "cross";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string dbPassword
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "dbPassword";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string dbPasswordNew
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "dbPasswordNew";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string dsName
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "dsName";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap Edit32
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "Edit32";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string email1
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "email1";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string email2
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "email2";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string emailPass1
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "emailPass1";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string emailPass2
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "emailPass2";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string emailSend
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "emailSend";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string encKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "encKey";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string expKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "expKey";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string HDFC_Des
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "HDFC_Des";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string HDFCDebit_Des
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "HDFCDebit_Des";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static byte[] ilass
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "ilass";
			return (byte[])resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string key
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "key";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string kldpUser
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "kldpUser";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string localCompName
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "localCompName";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap mnuDelete
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "mnuDelete";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static Bitmap mnuOk
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "mnuOk";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string national
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "national";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap Ok32
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "Ok32";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string regSubKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "regSubKey";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap Reload32
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "Reload32";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string stn
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "stn";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string stn2
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "stn2";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static Bitmap T53
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "T53";
			return (Bitmap)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static string url1
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "url1";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string url2
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "url2";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string urlLocal
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "urlLocal";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string urlNews
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "urlNews";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string urlNotes
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "urlNotes";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string urlStep
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "urlStep";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal static string userKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "userKey";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal Class32()
	{
	}
}
