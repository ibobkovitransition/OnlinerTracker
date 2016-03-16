using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinerTracker.DataAccess.Abstract
{
	public interface IRepository<TEntity>
	{
		IEnumerable<TEntity> Get();
		void Create(TEntity entity);
		void Delete(TEntity entity);
		void Delete(int id);
		void Update(TEntity entity);
	}
}
