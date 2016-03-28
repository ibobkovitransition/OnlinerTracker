using System;
using System.Collections.Generic;
using System.Linq;
using FluentScheduler;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class PriceScheduleService : IScheduleService, IJob
	{
		private readonly IPriceTrackingService priceTrackingService;
		private readonly IProductPriceHistoryService productPriceHistoryService;
		private readonly IProductService productService;

		public PriceScheduleService(IPriceTrackingService priceTrackingService, IProductPriceHistoryService productPriceHistoryService, IProductService productService)
		{
			this.priceTrackingService = priceTrackingService;
			this.productPriceHistoryService = productPriceHistoryService;
			this.productService = productService;
		}

		public void Execute()
		{
			var result = priceTrackingService.FindChangedPrices();
			productPriceHistoryService.Add(result);


			//foreach (var item in result)
			//{
			//	var product = item.Product;
			//	product.Price.Min = item.MinPrice;
			//	product.Price.Max = item.MaxPrice;

			//	productService.Update(product);
			//}

			//productService.Update(result.Select(x =>
			//{
			//	var temp = x.Product;
			//	temp.Price.Min = x.MinPrice;
			//	temp.Price.Max = x.MaxPrice;
			//	return temp;
			//}));

			//productPriceHistoryService.Add(result);
			// add into table
			// here
			//throw new Exception();
		}
	}
}