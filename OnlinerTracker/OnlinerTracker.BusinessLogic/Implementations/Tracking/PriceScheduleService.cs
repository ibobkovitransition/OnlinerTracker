using System.Linq;
using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;

namespace OnlinerTracker.BusinessLogic.Implementations.Tracking
{
	public class PriceScheduleService : IPriceScheduleService, IJob
	{
		private readonly IPriceTrackingService priceTrackingService;
		private readonly IPriceHistoryService productPriceHistoryService;
		private readonly IProductService productService;
		private readonly object syncRoot = new object();

		public PriceScheduleService(IPriceTrackingService priceTrackingService, IPriceHistoryService productPriceHistoryService, IProductService productService)
		{
			this.priceTrackingService = priceTrackingService;
			this.productPriceHistoryService = productPriceHistoryService;
			this.productService = productService;
		}

		public void Execute()
		{
			lock (syncRoot)
			{
				var result = priceTrackingService.FindChangedPrices();
				productPriceHistoryService.Add(result);
				productService.Update(result.Select(x => x.Product));
			}
		}
	}
}