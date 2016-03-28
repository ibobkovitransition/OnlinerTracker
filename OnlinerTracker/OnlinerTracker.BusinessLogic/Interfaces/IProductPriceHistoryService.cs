using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductPriceHistoryService
	{
		void Add(IEnumerable<ProductPriceHistory> productPriceHistoryList);

		void Add(ProductPriceHistory productPriceHistory);
	}
}