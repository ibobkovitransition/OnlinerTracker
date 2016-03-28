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
			var products = productTrackingService.Get();

			foreach (var product in products)
			{
				if (product.Product.PriceHistory.Any())
				{

				}
				
			}

			throw new System.NotImplementedException();
		}
	}
}