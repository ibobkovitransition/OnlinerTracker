using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Interfaces
{
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filters = null);

		void Create(TEntity entity);

		void Delete(TEntity entity);

		void Delete(int id);

		void Update(TEntity entity);

		TEntity FindBy(Expression<Func<TEntity, bool>> filters = null);
	}
}
