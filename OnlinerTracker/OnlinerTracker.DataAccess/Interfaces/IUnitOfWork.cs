using System;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<User> UserRepository { get; }

		IRepository<Product> ProductRepository { get; }

		IRepository<ProductTracking> TrackedProducts { get; } 

		void Commit();
	}
}
