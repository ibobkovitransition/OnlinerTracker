﻿using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;
using EntityPriceHistory = OnlinerTracker.DataAccess.Enteties.PriceHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductPriceHistoryService : IPriceHistoryService
	{
		private readonly IRepository<EntityPriceHistory> priceHistoryRepository;

		public ProductPriceHistoryService(IRepository<EntityPriceHistory> priceHistoryRepository)
		{
			this.priceHistoryRepository = priceHistoryRepository;
		}

		public void Add(IEnumerable<PriceHistory> productPriceHistoryList)
		{
			foreach (var productPriceHistory in productPriceHistoryList)
			{
				priceHistoryRepository.Attach(productPriceHistory.ToEntity());
			}

			priceHistoryRepository.Commit();
		}

		public void Add(PriceHistory productPriceHistory)
		{
			priceHistoryRepository.Attach(productPriceHistory.ToEntity());
			priceHistoryRepository.Commit();
		}

		public void Update(IEnumerable<PriceHistory> priceHistoryList)
		{
			foreach (var productPriceHistory in priceHistoryList)
			{
				priceHistoryRepository.Update(productPriceHistory.ToEntity());
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