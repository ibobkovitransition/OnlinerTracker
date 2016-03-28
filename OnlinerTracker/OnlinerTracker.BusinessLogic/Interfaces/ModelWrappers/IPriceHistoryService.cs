using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IPriceHistoryService
	{
		void Add(IEnumerable<PriceHistory> productPriceHistoryList);

		void Add(PriceHistory productPriceHistory);
	}
}