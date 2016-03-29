using System.Collections.Generic;
using OnlinerTracker.DataAccess.Enteties;
using Product = OnlinerTracker.BusinessLogic.Models.Onliner.Product;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IProductTrackingService
	{
		IEnumerable<Product> Get(int userId);

		IEnumerable<ProductTracking> Get(); 

		void Increase(int productId, int userId, bool track);

		void Decrease(int productId, int userId, bool track);

		void Track(int productId, int userId);

		void Untrack(int productId, int userId);

		void Remove(int productId, int userId);
	}
}
