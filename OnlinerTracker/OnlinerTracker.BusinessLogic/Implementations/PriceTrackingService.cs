using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class PriceTrackingService : IProductPriceTrackingService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IProductSearchService productSearchService;

		public PriceTrackingService(IUnitOfWork unitOfWork, IProductSearchService productSearchService)
		{
			this.unitOfWork = unitOfWork;
			this.productSearchService = productSearchService;
		}

		IEnumerable<ProductTracking> IProductPriceTrackingService.FindProductsWithChangedPrice()
		{
			throw new System.NotImplementedException();
		}
	}
}