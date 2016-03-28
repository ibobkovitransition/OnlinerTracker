using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductPriceHistoryService
	{
		IEnumerable<ProductPriceHistory> Get(int productId);

		void Add(ProductPriceHistory productPriceHistory);
	}
}