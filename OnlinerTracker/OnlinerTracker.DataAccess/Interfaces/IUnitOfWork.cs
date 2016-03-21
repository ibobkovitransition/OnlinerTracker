﻿using System;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<User> UserRepository { get; }

		IRepository<Product> ProductRepository { get; }

		IRepository<TrackedProduct> TrackedProducts { get; } 

		void Commit();
	}
}
