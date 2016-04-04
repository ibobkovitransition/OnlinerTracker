using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.ProductPriceTracker
{
	public class ScheduleRegistry : Registry
	{
		public ScheduleRegistry(IDeliveryConfig config)
		{
			Schedule<IPriceScheduleService>().ToRunNow().AndEvery(config.PriceTrackingInterval).Minutes();
			Schedule<INotifyScheduleService>().ToRunEvery(config.DeliveryInterval).Minutes();
		}
	}
}