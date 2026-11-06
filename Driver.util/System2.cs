using System;

namespace Driver.util;

internal class System2
{
	private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static long currentTimeMillis()
	{
		if (!ChromeUser.isTest)
		{
			return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
		}
		return 1671194485028L;
	}
}
