using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductPriceHistoryService : IPriceHistoryService
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductPriceHistoryService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Add(IEnumerable<PriceHistory> productPriceHistoryList)
		{
			foreach (var productPriceHistory in productPriceHistoryList)
			{
				unitOfWork.PriceHistoryRepository.Attach(productPriceHistory.ToEntity());
			}

			unitOfWork.Commit();
		}

		public void Add(PriceHistory productPriceHistory)
		{
			unitOfWork.PriceHistoryRepository.Attach(productPriceHistory.ToEntity());
			unitOfWork.Commit();
		}
	}
}