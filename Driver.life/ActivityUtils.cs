using Driver.intern.hook;
using Driver.util;

namespace Driver.life;

internal class ActivityUtils
{
	private static string LOGIN_ACTIVITY_SEQUENCES;

	private static string AVL_ACTIVITY_SEQUENCES;

	internal string getRandomActivityData(HookEvent hookEvent, ChromeUser akamaiUser)
	{
		string result = null;
		switch (hookEvent)
		{
		case HookEvent.Webmtoken:
		case HookEvent.ValidateUser:
		{
			long num2 = System2.currentTimeMillis() - akamaiUser.getTimeBeginSession();
			result = string.Format(LOGIN_ACTIVITY_SEQUENCES, akamaiUser.getTimeBeginSession() + Random.nextInt(100, 400), akamaiUser.getTimeBeginSession() + 4 * num2 / 6, akamaiUser.getTimeBeginSession() + 5 * num2 / 6);
			break;
		}
		case HookEvent.AvlFarenquiry:
		{
			long num = System2.currentTimeMillis() - akamaiUser.getTimeBeginSession();
			akamaiUser.getTimeBeginSession();
			result = string.Format(AVL_ACTIVITY_SEQUENCES, akamaiUser.getTimeBeginSession() + 5 * num / 20, akamaiUser.getTimeBeginSession() + 6 * num / 20, akamaiUser.getTimeBeginSession() + 8 * num / 20, akamaiUser.getTimeBeginSession() + 9 * num / 20, akamaiUser.getTimeBeginSession() + 10 * num / 20, akamaiUser.getTimeBeginSession() + 11 * num / 20, akamaiUser.getTimeBeginSession() + 14 * num / 20, akamaiUser.getTimeBeginSession() + 17 * num / 20, akamaiUser.getTimeBeginSession() + 18 * num / 20, akamaiUser.getTimeBeginSession() + 19 * num / 20);
			break;
		}
		case HookEvent.Universal:
			result = "";
			break;
		}
		return result;
	}

	static ActivityUtils()
	{
		string lOGIN_ACTIVITY_SEQUENCES = "3,{0};2,{1};3,{2};";
		LOGIN_ACTIVITY_SEQUENCES = lOGIN_ACTIVITY_SEQUENCES;
		string aVL_ACTIVITY_SEQUENCES = "2,{0};3,{1};2,{2};3,{3};2,{4};3,{5};2,{6};3,{7};2,{8};3,{9};";
		AVL_ACTIVITY_SEQUENCES = aVL_ACTIVITY_SEQUENCES;
	}
}
