using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace Booking;

internal class Class31_Hdfc
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				string baseName = "NEXUS.Booking.Class31_Hdfc";
				resourceManager_0 = new ResourceManager(baseName, typeof(Class31_Hdfc).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
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

	internal Class31_Hdfc()
	{
	}
}
