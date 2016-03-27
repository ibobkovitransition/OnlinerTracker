using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IPriceChangedTrackingService
	{
		IEnumerable<ProductTracking> Products { get; } 
	}
}