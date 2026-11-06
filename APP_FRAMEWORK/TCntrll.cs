using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace APP_FRAMEWORK;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class TCntrll
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
				string baseName = "Connect.TCntrl";
				resourceManager_0 = new ResourceManager(baseName, typeof(TCntrl).Assembly);
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

	internal static Point timer_0_TrayLocation
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "timer_0.TrayLocation";
			return (Point)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal static Point toolTip_0_TrayLocation
	{
		get
		{
			ResourceManager resourceManager = ResourceManager;
			string name = "toolTip_0.TrayLocation";
			return (Point)resourceManager.GetObject(name, cultureInfo_0);
		}
	}

	internal TCntrll()
	{
	}
}
