using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductService
	{
		SearchResult Search(string productName, int page, int userId);

		void Add(Product product, int userId);

		void Delete(int productId);

		void Update(Product product);
	}
}