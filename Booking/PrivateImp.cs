namespace Booking;

internal sealed class PrivateImp
{
	internal static readonly long long_0;

	internal static readonly long long_1;

	internal static uint ComputeStringHash(string s)
	{
		uint num = 0u;
		if (s != null)
		{
			num = 2166136261u;
			for (int i = 0; i < s.Length; i++)
			{
				num = (s[i] ^ num) * 16777619;
			}
		}
		return num;
	}
}
