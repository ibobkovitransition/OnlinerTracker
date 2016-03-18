using System;
using System.Diagnostics;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly EfDbContext context;

		public IRepository<User> UserRepository { get; }

		private bool disposed;

		public EfUnitOfWork(EfDbContext context, IRepository<User> userRepository)
		{
			this.context = context;
			UserRepository = userRepository;
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
