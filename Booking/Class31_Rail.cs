using System.Globalization;
using System.Resources;

namespace Booking;

internal class Class31_Rail
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				string baseName = "NEXUS.Booking.Class31_Rail";
				resourceManager_0 = new ResourceManager(baseName, typeof(Class31_Rail).Assembly);
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

	internal static string national
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "national";
			return resourceManager.GetString(name, cultureInfo_0);
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

	internal static string trnlist
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "trnlist";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal Class31_Rail()
	{
	}
}
