using System;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly EfDbContext context;
		private IRepository<User> userRepository;
		private bool disposed;

		public EfUnitOfWork(EfDbContext context)
		{
			this.context = context;
		}

		public IRepository<User> UserRepository => userRepository ?? new EfUserRepository(context);

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
			GC.SuppressFinalize(this); // где-то у меня без этого были траблы
		}
	}
}
