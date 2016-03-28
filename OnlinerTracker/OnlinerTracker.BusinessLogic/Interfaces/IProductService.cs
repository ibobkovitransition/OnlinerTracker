﻿using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IProductService
	{
		SearchResult Search(string productName, int page, int size, int userId);

		IEnumerable<Product> Get();

		void Add(Product product, int userId);

		void Delete(int productId);

		void Update(Product product);
	}
}