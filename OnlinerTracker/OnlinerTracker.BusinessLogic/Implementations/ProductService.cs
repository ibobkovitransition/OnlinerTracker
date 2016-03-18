using System;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductSearchService searchService;
		private readonly IUnitOfWork uow;

		public ProductService(IProductSearchService searchService, IUnitOfWork uow)
		{
			this.searchService = searchService;
			this.uow = uow;
		}

		public SearchResult Search(string productName, int page, int size)
		{
			return searchService.Search(productName, page, size);
		}

		public void Track(int id)
		{
			throw new NotImplementedException();
		}

		public void Untrack(int id)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}
