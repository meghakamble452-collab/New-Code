using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IRCommDLL;

public class Shortcut
{
	[ComImport]
	[TypeLibType(4160)]
	[Guid("F935DC23-1CF0-11D0-ADB9-00C04FD58A0B")]
	private interface IWshShortcut
	{
		[DispId(0)]
		string FullName
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(1000)]
		string Arguments
		{
			[DispId(1000)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1000)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(1001)]
		string Description
		{
			[DispId(1001)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1001)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(1002)]
		string Hotkey
		{
			[DispId(1002)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1002)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(1003)]
		string IconLocation
		{
			[DispId(1003)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1003)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(1004)]
		string RelativePath
		{
			[DispId(1004)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(1005)]
		string TargetPath
		{
			[DispId(1005)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1005)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(1006)]
		int WindowStyle
		{
			[DispId(1006)]
			get;
			[DispId(1006)]
			[param: In]
			set;
		}

		[DispId(1007)]
		string WorkingDirectory
		{
			[DispId(1007)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1007)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(2000)]
		[TypeLibFunc(64)]
		void Load([In][MarshalAs(UnmanagedType.BStr)] string PathLink);

		[DispId(2001)]
		void Save();
	}

	private static Type type_0;

	private static object object_0;

	public static void Create(string fileName, string targetPath, string arguments, string workingDirectory, string description, string hotkey, string iconPath)
	{
		try
		{
			Type type = type_0;
			string name = "CreateShortcut";
			IWshShortcut wshShortcut = (IWshShortcut)type.InvokeMember(name, BindingFlags.InvokeMethod, null, object_0, new object[1] { fileName });
			wshShortcut.Description = description;
			wshShortcut.Hotkey = hotkey;
			wshShortcut.TargetPath = targetPath;
			wshShortcut.WorkingDirectory = workingDirectory;
			wshShortcut.Arguments = arguments;
			if (!string.IsNullOrEmpty(iconPath))
			{
				wshShortcut.IconLocation = iconPath;
			}
			wshShortcut.Save();
		}
		catch (Exception)
		{
		}
	}

	static Shortcut()
	{
		string progID = "WScript.Shell";
		type_0 = Type.GetTypeFromProgID(progID);
		object_0 = Activator.CreateInstance(type_0);
	}
}
