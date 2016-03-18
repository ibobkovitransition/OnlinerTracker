using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductService
	{
		SearchResult Search(string productName, int page, int size);

		void Track(int id);

		void Untrack(int id);

		void Remove(int id);
	}
}
