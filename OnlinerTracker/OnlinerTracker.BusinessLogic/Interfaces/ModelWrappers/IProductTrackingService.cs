using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IProductTrackingService
	{
		IEnumerable<ProductTracking> Get();

		IEnumerable<Product> Get(int userId);

		IEnumerable<ProductTracking> Get(IEnumerable<Product> products); 

		void Increase(int productId, int userId, bool track);

		void Decrease(int productId, int userId, bool track);

		void Track(int productId, int userId);

		void Untrack(int productId, int userId);

		void Remove(int productId, int userId);
	}
}
