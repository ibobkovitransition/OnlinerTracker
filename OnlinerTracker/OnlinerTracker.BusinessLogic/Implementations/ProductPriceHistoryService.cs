using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductPriceHistoryService : IProductPriceHistoryService
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductPriceHistoryService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IEnumerable<ProductPriceHistory> Get(int productId)
		{
			return unitOfWork.ProductPriceHistoryRepository.GetEntities(x => x.ProductId == productId, x => x.Product).Select(x => x.ToModel());
		}

		public void Add(ProductPriceHistory productPriceHistory)
		{
			unitOfWork.ProductPriceHistoryRepository.Attach(productPriceHistory.ToEntity());
			unitOfWork.Commit();
		}
	}
}