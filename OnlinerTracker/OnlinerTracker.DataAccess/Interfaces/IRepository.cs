using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Interfaces
{
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filters = null, params Expression<Func<TEntity, object>>[] includedProperties);

		void Attach(TEntity entity);

		void Detach(TEntity entity);

		void Detach(int id);

		void Update(TEntity entity);

		void Commit();

		TEntity FindBy(Expression<Func<TEntity, bool>> filters = null, params Expression<Func<TEntity, object>>[] includedProperties);
	}
}
