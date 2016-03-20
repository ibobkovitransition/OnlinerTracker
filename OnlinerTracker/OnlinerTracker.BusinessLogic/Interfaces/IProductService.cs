using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductService
	{
		SearchResult Search(string productName, int page, string hashedSocNetworkUserId);

		void Add(Product product);

		void AddIfNotExsists(Product product);

		void Delete(int productId);

		void Update(Product product);
	}
}