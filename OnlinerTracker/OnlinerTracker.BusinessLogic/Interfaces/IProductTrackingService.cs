using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductTrackingService
	{
		IEnumerable<Product> Get(int userId);

		void Increase(int productId, int userId, bool track);

		void Decrease(int productId, int userId, bool track);

		void Track(int productId, int userId);

		void Untrack(int productId, int userId);

		void Remove(int productId, int userId);
	}
}
