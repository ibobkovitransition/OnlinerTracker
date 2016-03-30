using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.ProductPriceTracker
{
	public class ScheduleRegistry : Registry
	{
		private readonly IPriceScheduleService priceScheduleService;
		private readonly INotifyScheduleService notifyScheduleService;

		public ScheduleRegistry(IPriceScheduleService priceScheduleService, INotifyScheduleService notifyScheduleService)
		{
			this.priceScheduleService = priceScheduleService;
			this.notifyScheduleService = notifyScheduleService;

			Schedule(priceScheduleService.Execute).AndThen(notifyScheduleService.Execute)
				.ToRunNow().AndEvery(30).Seconds();

			//Schedule(priceScheduleService.Execute).ToRunNow().AndEvery(5).Seconds();
		}
	}
}