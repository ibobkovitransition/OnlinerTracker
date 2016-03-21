using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductSearchService searchService;
		private readonly IHashService hashService;
		private readonly IUnitOfWork uow;

		public ProductService(IProductSearchService searchService, IHashService hashService, IUnitOfWork uow)
		{
			this.searchService = searchService;
			this.hashService = hashService;
			this.uow = uow;
		}

		public SearchResult Search(string productName, int page, string hashedSocNetworkUserId)
		{
			var userId = GetUserIdByHashedId(hashedSocNetworkUserId);
			var result = searchService.Search(productName, page);
			MarkTrackedProducts(userId, result.Products);

			return result;
		}

		public void Add(Product product)
		{
			uow.ProductRepository.Attach(CreateEntityProduct(product));
			uow.Commit();
		}

		public void AddIfNotExsists(Product product)
		{
			var entry = uow.ProductRepository.FindBy(x => x.Id == product.Id);
			if (entry == null)
			{
				Add(product);
			}
		}

		public void Delete(int productId)
		{
			uow.ProductRepository.Detach(productId);
			uow.Commit();
		}

		public void Update(Product product)
		{
			uow.ProductRepository.Update(CreateEntityProduct(product));
			uow.Commit();
		}

		private DataAccess.Enteties.Product CreateEntityProduct(Product product)
		{
			return new DataAccess.Enteties.Product
			{
				Id = product.Id,
				CreatedOn = DateTime.Now,
				Name = product.Name,
				FullName = product.FullName,
				Description = product.Description,
				HtmlUrl = product.HtmlUrl,
				MinPrice = product.Price?.Min ?? 0,
				MaxPrice = product.Price?.Max ?? 0,
				ImageUrl = product.Image != null ?
					!string.IsNullOrWhiteSpace(product.Image.Icon) ? 
						product.Image.Icon : 
						product.Image.Header :
					string.Empty
			};
		}

		private int GetUserIdByHashedId(string hashedSocNetworkUserId)
		{
			var socialId = hashService.Decrypt(hashedSocNetworkUserId);
			var result = uow.UserRepository.FindBy(x => x.SocialId == socialId);
			return result.Id;
		}

		private void MarkTrackedProducts(int userId, IEnumerable<Product> productsToMark)
		{
			var trackedProducts = uow.TrackedProducts.GetEntities(x => x.UserId == userId);

			foreach (var product in productsToMark)
			{
				var entry = trackedProducts.FirstOrDefault(x => x.ProductId == product.Id);
				if (entry != null)
				{
					product.IsTracked = entry.IsTracked;
					product.IsAdded = true;
				}
			}
		}
	}
}