internal sealed class Class67
{
	private sealed class Class68
	{
		public static readonly Class68 class68_0 = new Class68();

		private Class68()
		{
		}

		public string method_0(string string_0, int int_0)
		{
			int num = string_0.Length;
			char[] array = string_0.ToCharArray();
			while (--num >= 0)
			{
				array[num] = (char)(array[num] ^ int_0);
			}
			return new string(array);
		}
	}

	public static string smethod_0(string string_0, int int_0)
	{
		return Class68.class68_0.method_0(string_0, int_0);
	}
}
