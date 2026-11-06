using System;
using System.Collections.Generic;
using System.Threading;

namespace APP_FRAMEWORK;

public class SchedulerService
{
	private static SchedulerService _instance;

	private List<Timer> timers = new List<Timer>();

	public static SchedulerService Instance
	{
		get
		{
			SchedulerService result;
			if ((result = _instance) == null)
			{
				result = (_instance = new SchedulerService());
			}
			return result;
		}
	}

	private SchedulerService()
	{
	}

	public void ScheduleTask(int hour, int min, double intervalInHour, Action task)
	{
		DateTime now = DateTime.Now;
		DateTime dateTime = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);
		if (now > dateTime)
		{
			dateTime = dateTime.AddDays(1.0);
		}
		TimeSpan timeSpan = dateTime - now;
		if (timeSpan <= TimeSpan.Zero)
		{
			timeSpan = TimeSpan.Zero;
		}
		timers.Add(new Timer(delegate
		{
			task();
		}, null, timeSpan, TimeSpan.FromHours(intervalInHour)));
	}
}
