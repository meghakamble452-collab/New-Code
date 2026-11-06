using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

internal class Class47
{
	public static Func<int, MethodBase> func_0;

	static Class47()
	{
		smethod_0();
	}

	private static void smethod_0()
	{
		int num = -172;
		MethodInfo meth = null;
		ILGenerator iLGenerator = null;
		DynamicMethod dynamicMethod = null;
		MethodInfo meth2 = null;
		while (true)
		{
			Assembly assembly = typeof(object).Assembly;
			string name = "System.Diagnostics.StackFrameHelper";
			Type type = assembly.GetType(name);
			int num2 = num + 62;
			while (true)
			{
				switch (num = num2 - 44)
				{
				default:
					return;
				case -154:
				{
					string name4 = "GetMethodBase";
					meth = type.GetMethod(name4, BindingFlags.Instance | BindingFlags.Public);
					num2 = num + 34;
					continue;
				}
				case -155:
					iLGenerator.Emit(OpCodes.Ldnull);
					num2 = num + 39;
					continue;
				case -156:
					func_0 = (Func<int, MethodBase>)dynamicMethod.CreateDelegate(typeof(Func<int, MethodBase>));
					num2 = num + 47;
					continue;
				case -157:
					iLGenerator.Emit(OpCodes.Ldc_I4_1);
					num2 = num + 33;
					continue;
				case -158:
					iLGenerator.Emit(OpCodes.Callvirt, meth);
					num2 = num + 39;
					continue;
				case -159:
					iLGenerator.Emit(OpCodes.Ldarg_0);
					num2 = num + 45;
					continue;
				case -160:
				{
					int num5 = num;
					while (true)
					{
						int num6;
						switch (num6 = num5 + 194)
						{
						case 34:
							iLGenerator.Emit(OpCodes.Newobj, type.GetConstructor(new Type[1] { typeof(Thread) }));
							num5 = num + num6 - 33;
							continue;
						case 35:
							num5 = (num2 = num + 39) + num6 - 72;
							continue;
						}
						break;
					}
					continue;
				}
				case -161:
				{
					int num3 = num;
					while (true)
					{
						int num4;
						switch (num4 = num3 - 222)
						{
						case -384:
							num3 = (num2 = num + 39) + num4 + 346;
							continue;
						case -383:
						{
							string name3 = "FastStackTrace";
							dynamicMethod = new DynamicMethod(name3, typeof(MethodBase), new Type[1] { typeof(int) }, typeof(StackTrace), skipVisibility: true);
							num3 = num + num4 + 382;
							continue;
						}
						}
						break;
					}
					continue;
				}
				case -162:
					iLGenerator.Emit(OpCodes.Ldloc_0);
					num2 = num + 47;
					continue;
				case -163:
					iLGenerator.Emit(OpCodes.Ret);
					num2 = num + 51;
					continue;
				case -164:
				{
					string typeName = "System.Diagnostics.StackTrace, mscorlib";
					Type type2 = Type.GetType(typeName);
					string name2 = "GetStackFramesInternal";
					meth2 = type2.GetMethod(name2, BindingFlags.Static | BindingFlags.NonPublic);
					num2 = num + 47;
					continue;
				}
				case -165:
					iLGenerator.Emit(OpCodes.Stloc_0);
					num2 = num + 39;
					continue;
				case -166:
					iLGenerator = dynamicMethod.GetILGenerator();
					num2 = num + 43;
					continue;
				case -167:
					iLGenerator.DeclareLocal(type);
					num2 = num + 56;
					continue;
				case -168:
					iLGenerator.Emit(OpCodes.Ldc_I4_0);
					num2 = num + 43;
					continue;
				case -169:
					iLGenerator.Emit(OpCodes.Ldnull);
					num2 = num + 42;
					continue;
				case -170:
					iLGenerator.Emit(OpCodes.Ldloc_0);
					num2 = num + 57;
					continue;
				case -171:
					iLGenerator.Emit(OpCodes.Call, meth2);
					num2 = num + 53;
					continue;
				case -172:
					break;
				}
				break;
			}
		}
	}

	public static bool smethod_1()
	{
		int num = 277;
		string text = null;
		while (true)
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			int num2 = num - 96;
			while (true)
			{
				switch (num = num2 + 97)
				{
				default:
					return true;
				case 281:
				{
					string text2 = text;
					string value = "AssemblyServer";
					if (text2.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1)
					{
						return true;
					}
					goto case 282;
				}
				case 282:
				{
					string text3 = text;
					string value2 = "SimpleAssemblyExplorer";
					if (text3.IndexOf(value2, StringComparison.OrdinalIgnoreCase) != -1)
					{
						return true;
					}
					goto case 279;
				}
				case 279:
				{
					string text5 = text;
					string value4 = "babelvm";
					if (text5.IndexOf(value4, StringComparison.OrdinalIgnoreCase) != -1)
					{
						return true;
					}
					goto case 280;
				}
				case 280:
				{
					string text4 = text;
					string value3 = "smoketest";
					return text4.IndexOf(value3, StringComparison.OrdinalIgnoreCase) != -1;
				}
				case 278:
					goto IL_0104;
				case 277:
					break;
				}
				break;
				IL_0104:
				text = entryAssembly.FullName;
				num2 = num - 94;
			}
		}
	}
}
