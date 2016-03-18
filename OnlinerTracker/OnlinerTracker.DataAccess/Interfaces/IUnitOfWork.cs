using System;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<User> UserRepository { get; }

		void Commit();
	}
}
