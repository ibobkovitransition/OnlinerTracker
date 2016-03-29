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
			var products = productTrackingService.Get()
				.Where(x => x.Enabled && (x.Decrease || x.Increase));

			foreach (var product in products)
			{
				var orderedEnumerable = product.Product.PriceHistory.OrderBy(x => x.Product.PriceHistory);
			}

			throw new System.NotImplementedException();
		}
	}
}