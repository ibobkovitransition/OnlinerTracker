using System.Collections.Generic;
using System.Linq;
using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Implementations.Tracking
{
	public class PriceScheduleService : IScheduleService, IJob
	{
		private readonly IPriceTrackingService priceTrackingService;
		private readonly IPriceHistoryService productPriceHistoryService;
		private readonly IProductService productService;

		public PriceScheduleService(IPriceTrackingService priceTrackingService, IPriceHistoryService productPriceHistoryService, IProductService productService)
		{
			this.priceTrackingService = priceTrackingService;
			this.productPriceHistoryService = productPriceHistoryService;
			this.productService = productService;
		}

		public void Execute()
		{
			var result = priceTrackingService.FindChangedPrices();
			productPriceHistoryService.Add(result);
			UpdateChanged(result);
		}

		private void UpdateChanged(IEnumerable<PriceHistory> productPriceHistoryList)
		{
			productService.Update(productPriceHistoryList.Select(x =>
			{
				var product = x.Product;
				product.Price.Min = x.MinPrice;
				product.Price.Max = x.MaxPrice;
				return product;
			}));
		}
	}
}