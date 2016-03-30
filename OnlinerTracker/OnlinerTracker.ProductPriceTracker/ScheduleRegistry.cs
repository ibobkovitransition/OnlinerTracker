using FluentScheduler;
using OnlinerTracker.BusinessLogic.Implementations.Tracking;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.ProductPriceTracker
{
	public class ScheduleRegistry : Registry
	{
		public ScheduleRegistry()
		{
			//Schedule(priceScheduleService.Execute).AndThen(notifyScheduleService.Execute)
			//	.ToRunNow().AndEvery(30).Seconds();

			Schedule<PriceScheduleService>().ToRunNow().AndEvery(30).Seconds();
		}
	}
}