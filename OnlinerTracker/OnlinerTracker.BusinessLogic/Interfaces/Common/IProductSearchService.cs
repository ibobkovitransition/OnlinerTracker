using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Interfaces.Common
{
	public interface IProductSearchService
	{
		SearchResult Search(string productName, int page, int size);
	}
}
