using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IPriceHistoryService
	{
		void Add(IEnumerable<PriceHistory> priceHistoryList);

		void Add(PriceHistory priceHistory);

		void Update(IEnumerable<PriceHistory> priceHistoryList);

		void Update(PriceHistory priceHistory);
	}
}