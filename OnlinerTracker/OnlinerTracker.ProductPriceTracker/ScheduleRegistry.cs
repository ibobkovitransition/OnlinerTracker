﻿using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.ProductPriceTracker
{
	public class ScheduleRegistry : Registry
	{
		public ScheduleRegistry()
		{
			Schedule<IPriceScheduleService>().ToRunNow().AndEvery(10).Minutes();
			Schedule<INotifyScheduleService>().ToRunEvery(30).Seconds();
		}
	}
}