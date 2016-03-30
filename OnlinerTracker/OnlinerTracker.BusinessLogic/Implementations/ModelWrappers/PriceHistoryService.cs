using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;
using EntityPriceHistory = OnlinerTracker.DataAccess.Enteties.PriceHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class PriceHistoryService : IPriceHistoryService
	{
		private readonly IRepository<EntityPriceHistory> priceHistoryRepository;

		public PriceHistoryService(IRepository<EntityPriceHistory> priceHistoryRepository)
		{
			this.priceHistoryRepository = priceHistoryRepository;
		}

		public void Add(IEnumerable<PriceHistory> priceHistoryList)
		{
			foreach (var priceHistory in priceHistoryList)
			{
				priceHistoryRepository.Attach(priceHistory.ToEntity());
			}

			priceHistoryRepository.Commit();
		}

		public void Add(PriceHistory priceHistory)
		{
			priceHistoryRepository.Attach(priceHistory.ToEntity());
			priceHistoryRepository.Commit();
		}

		public void Update(IEnumerable<PriceHistory> priceHistoryList)
		{
			foreach (var priceHistory in priceHistoryList)
			{
				priceHistoryRepository.Update(priceHistory.ToEntity());
			}

			priceHistoryRepository.Commit();
		}

		public void Update(PriceHistory priceHistory)
		{
			priceHistoryRepository.Update(priceHistory.ToEntity());
			priceHistoryRepository.Commit();
		}
	}
}