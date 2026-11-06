using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Booking;

[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[CompilerGenerated]
internal class Class31_Air
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				string baseName = "NEXUS.Booking.Class31_Air";
				resourceManager_0 = new ResourceManager(baseName, typeof(Class31_Air).Assembly);
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

	internal static string vendors_
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "vendors_";
			return resourceManager.GetString(name, cultureInfo_0);
		}
	}

	internal Class31_Air()
	{
	}
}
