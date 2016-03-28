using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductPriceHistoryService : IProductPriceHistoryService
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductPriceHistoryService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Add(IEnumerable<ProductPriceHistory> productPriceHistoryList)
		{
			foreach (var productPriceHistory in productPriceHistoryList)
			{
				unitOfWork.ProductPriceHistoryRepository.Attach(productPriceHistory.ToEntity());
			}

			unitOfWork.Commit();
		}

		public void Add(ProductPriceHistory productPriceHistory)
		{
			unitOfWork.ProductPriceHistoryRepository.Attach(productPriceHistory.ToEntity());
			unitOfWork.Commit();
		}
	}
}