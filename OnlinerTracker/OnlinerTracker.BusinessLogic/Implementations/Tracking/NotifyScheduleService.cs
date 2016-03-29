using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.BusinessLogic.Implementations.Tracking
{
	public class NotifyScheduleService : INotifyScheduleService
	{
		private readonly IProductTrackingService productTrackingService;

		public NotifyScheduleService(IProductTrackingService productTrackingService)
		{
			this.productTrackingService = productTrackingService;
		}

		public void Execute()
		{
			var stuff = (from item in productTrackingService.Get()
						 where
							 item.Enabled &&
							 (item.Decrease || item.Increase) &&
							 item.Product.PriceHistory.Any()
						 let lastLog = item.Product.PriceHistory.OrderBy(x => x.CreatedAt).Last()
						 select new
						 {
							 ProductTracking = item,
							 LastLog = lastLog
						 }).Where(x => x.ProductTracking.CreatedAt <= x.LastLog.CreatedAt);

			foreach (var item in stuff)
			{

			}
		}
	}
}