using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlinerTracker.DataAccess.Abstract;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Concrete
{
	public class UserRepository : IRepository<User>
	{
		public IEnumerable<User> Get()
		{
			throw new NotImplementedException();
		}

		public void Create(User entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(User entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
