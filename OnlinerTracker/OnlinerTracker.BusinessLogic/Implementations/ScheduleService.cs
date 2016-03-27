using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ScheduleService : IScheduleService, IJob
	{
		private readonly IPriceChangedTrackingService priceChangedTrackingService;
		private readonly IUserNotificationService userNotificationService;

		public ScheduleService(IUserNotificationService userNotificationService, IPriceChangedTrackingService priceChangedTrackingService)
		{
			this.userNotificationService = userNotificationService;
			this.priceChangedTrackingService = priceChangedTrackingService;
		}

		public void Execute()
		{
			userNotificationService.Notify(priceChangedTrackingService.Products);
		}
	}
}