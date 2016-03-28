using System;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

// TODO: ИЛИ ВЫПИЛИТЬ ИЗ ПРОЕКТА И СОХРАНЯТЬ ЧЕРЕЗ РЕПОЗИТОРИЙ, ИЛИ УБРАТЬ СИНГЛЕТНЫЙ КОНТЕКСТ И СОЗДАВАТЬ ЗДЕСЬ
namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class UnitOfWork : IUnitOfWork
	{
		public IRepository<User> UserRepository { get; }

		public IRepository<Product> ProductRepository { get; }

		public IRepository<ProductTracking> ProductTrackingRepository { get; }

		public IRepository<PriceHistory> PriceHistoryRepository { get; } 

		private readonly Context context;
		private bool disposed;

		public UnitOfWork(Context context, IRepository<User> userRepository, IRepository<Product> productRepository, IRepository<ProductTracking> productTrackingRepository, IRepository<PriceHistory> priceHistoryRepository)
		{
			this.context = context;
			UserRepository = userRepository;
			ProductRepository = productRepository;
			ProductTrackingRepository = productTrackingRepository;
			PriceHistoryRepository = priceHistoryRepository;
		}

		public void Commit()
		{
			context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}

			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
