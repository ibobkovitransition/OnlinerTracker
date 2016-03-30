using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.DataAccess.Interfaces;
using PriceHistory = OnlinerTracker.DataAccess.Enteties.PriceHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductPriceHistoryService : IPriceHistoryService
	{
		private readonly IRepository<PriceHistory> priceHistoryRepository;

		public ProductPriceHistoryService(IRepository<PriceHistory> priceHistoryRepository)
		{
			this.priceHistoryRepository = priceHistoryRepository;
		}

		public void Add(IEnumerable<Models.PriceHistory> productPriceHistoryList)
		{
			foreach (var productPriceHistory in productPriceHistoryList)
			{
				priceHistoryRepository.Attach(productPriceHistory.ToEntity());
			}

			priceHistoryRepository.Commit();
		}

		public void Add(Models.PriceHistory productPriceHistory)
		{
			priceHistoryRepository.Attach(productPriceHistory.ToEntity());
			priceHistoryRepository.Commit();
		}

		public void Update(IEnumerable<Models.PriceHistory> priceHistoryList)
		{
			foreach (var productPriceHistory in priceHistoryList)
			{
				priceHistoryRepository.Update(productPriceHistory.ToEntity());
			}

			priceHistoryRepository.Commit();
		}

		public void Update(Models.PriceHistory priceHistory)
		{
			priceHistoryRepository.Update(priceHistory.ToEntity());
			priceHistoryRepository.Commit();
		}
	}
}