using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlinerTracker.DataAccess.Abstract;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		public IRepository<User> UserRepository { get { return new UserRepository(); } }
	}
}
