using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces.Tracking
{
	public interface IPriceTrackingService
	{
		IEnumerable<ProductPriceHistory> FindChangedPrices();
	}
}