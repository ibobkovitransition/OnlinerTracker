using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductPriceTrackingService
	{
		IEnumerable<ProductTracking> FindProductsWithChangedPrice();
	}
}