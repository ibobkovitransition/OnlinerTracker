using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.ProductPriceTracker
{
	public class ScheduleRegistry : Registry
	{
		public ScheduleRegistry(IConfig config)
		{
			Schedule<IPriceScheduleService>().ToRunNow().AndEvery(config.PriceTrackingIntervalInMinutes).Minutes();
			Schedule<INotifyScheduleService>().ToRunEvery(config.EmailDeliveryIntervalInMinutes).Minutes();
		}
	}
}