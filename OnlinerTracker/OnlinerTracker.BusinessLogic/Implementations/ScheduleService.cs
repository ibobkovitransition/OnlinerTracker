using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ScheduleService : IScheduleService, IJob
	{
		private readonly IProductPriceTrackingService productPriceTrackingService;
		private readonly IUserNotifyService userNotifyService;

		public ScheduleService(IUserNotifyService userNotifyService, IProductPriceTrackingService productPriceTrackingService)
		{
			this.userNotifyService = userNotifyService;
			this.productPriceTrackingService = productPriceTrackingService;
		}

		public void Execute()
		{
			userNotifyService.NotifyAll(productPriceTrackingService.FindProductsWithChangedPrice());
		}
	}
}