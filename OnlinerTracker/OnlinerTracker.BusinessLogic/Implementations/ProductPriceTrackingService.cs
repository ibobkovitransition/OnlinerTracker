using System;
using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Interfaces;
using ProductPriceHistory = OnlinerTracker.BusinessLogic.Models.ProductPriceHistory;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductPriceTrackingService : IPriceTrackingService
	{
		private readonly IProductPriceHistoryService productPriceHistoryService;

		public ProductPriceTrackingService(IProductPriceHistoryService productPriceHistoryService)
		{
			this.productPriceHistoryService = productPriceHistoryService;
		}

		//private readonly IProductSearchService productSearchService;

		//public ProductPriceTrackingService(IUnitOfWork unitOfWork, IProductSearchService productSearchService)
		//{
		//	this.unitOfWork = unitOfWork;
		//	this.productSearchService = productSearchService;
		//}

		//private IEnumerable<ProductTracking> ExtractFromStore()
		//{
		//	return unitOfWork.ProductTrackingRepository.GetEntities(
		//		x => x.Enabled && (x.Decrease || x.Increase),
		//		x => x.Product, x => x.User).Select(x => x.ToModel());
		//}

		
		public IEnumerable<ProductPriceHistory> FindChangedPrices()
		{
			throw new NotImplementedException();
		}

		private IEnumerable<ProductPriceHistory> Extract()
		{
			return productPriceHistoryService.Get(1);
		} 
	}
}
