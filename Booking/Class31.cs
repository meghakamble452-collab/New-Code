using System.Globalization;
using System.Resources;

namespace Booking;

internal class Class31
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				string baseName = "NEXUS.Booking.Class31";
				resourceManager_0 = new ResourceManager(baseName, typeof(Class31).Assembly);
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

	internal static string chanceKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "chanceKey";
			return resourceManager.GetString(name, cultureInfo_0);
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

	internal static string dsName1
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "dsName1";
			return resourceManager.GetString(name, cultureInfo_0);
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

	internal static string key => "Yuks68bd98";

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

	internal static string regSubKey
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "regSubKey";
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

	internal Class31()
	{
	}
}
