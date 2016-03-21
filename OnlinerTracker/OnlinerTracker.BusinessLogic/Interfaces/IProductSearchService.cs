using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductSearchService
	{
		SearchResult Search(string productName, int page);
	}
}
