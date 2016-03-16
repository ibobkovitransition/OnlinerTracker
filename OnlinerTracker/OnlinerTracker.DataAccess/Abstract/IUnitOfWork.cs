using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Abstract
{
	public interface IUnitOfWork
	{ 
		IRepository<User> UserRepository { get; } 
	}
}
