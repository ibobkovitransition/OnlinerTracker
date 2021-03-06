﻿using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IProductService
	{
		SearchResult Search(string productName, int page, int size, int userId);

		IEnumerable<Product> Get();

		void Add(Product product, int userId);

		void Delete(int productId);

		void Update(Product product);

		void Update(IEnumerable<Product> products);
	}
}