using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.ProductPriceTracker
{
	public class ScheduleRegistry : Registry
	{
		public ScheduleRegistry()
		{
			//Schedule<IPriceScheduleService>().AndThen<INotifyScheduleService>().ToRunNow().AndEvery(2).Hours();
			Schedule<IPriceScheduleService>().ToRunNow().AndEvery(5).Minutes();

		}
	}
}