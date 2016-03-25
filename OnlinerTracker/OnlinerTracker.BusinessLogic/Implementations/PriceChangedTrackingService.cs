using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class PriceChangedTrackingService : IPriceChangedTrackingService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IProductSearchService productSearchService;

		public PriceChangedTrackingService(IUnitOfWork unitOfWork, IProductSearchService productSearchService)
		{
			this.unitOfWork = unitOfWork;
			this.productSearchService = productSearchService;
		}

		public IEnumerable<ProductTracking> Products { get; }
	}
}