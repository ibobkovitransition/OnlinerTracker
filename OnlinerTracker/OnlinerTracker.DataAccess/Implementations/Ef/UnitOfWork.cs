﻿using System;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class UnitOfWork : IUnitOfWork
	{
		public IRepository<User> UserRepository { get; }

		public IRepository<Product> ProductRepository { get; }
		public IRepository<ProductTracking> ProductTrackingRepository { get; }

		private readonly Context context;
		private bool disposed;

		public UnitOfWork(Context context, IRepository<User> userRepository, IRepository<Product> productRepository, IRepository<ProductTracking> productTrackingRepository)
		{
			this.context = context;
			UserRepository = userRepository;
			ProductRepository = productRepository;
			ProductTrackingRepository = productTrackingRepository;
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
