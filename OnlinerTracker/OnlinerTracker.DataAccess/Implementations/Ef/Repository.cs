using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using OnlinerTracker.DataAccess.Enteties.Basis;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		internal readonly Context Context;

		public Repository(Context context)
		{
			Context = context;
		}

		public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filters = null, params Expression<Func<TEntity, object>>[] includedProperties)
		{
			IQueryable<TEntity> query = Context.Set<TEntity>();
			if (filters != null)
			{
				query = query.Where(filters);
			}

			query = query.AsNoTracking();
			query = includedProperties.Aggregate(query, (current, property) => current.Include(property)).AsNoTracking();

			return query.AsEnumerable();
		}

		public void Attach(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public void Detach(TEntity entity)
		{
			if (Context.Entry(entity).State == EntityState.Detached)
			{
				Context.Set<TEntity>().Attach(entity);
			}

			Context.Set<TEntity>().Remove(entity);
		}

		public void Detach(int id)
		{
			var entity = Context.Set<TEntity>().Find(id);
			Detach(entity);
		}

		public void Update(TEntity entity)
		{
			Context.Set<TEntity>().AddOrUpdate(entity);
			//DbSet.Attach(entity);
			//Context.Entry(entity).State = EntityState.Modified;
		}

		public void Commit()
		{
			Context.SaveChanges();
			//Context.Set<TEntity>().
		}

		public TEntity FindBy(Expression<Func<TEntity, bool>> filters = null, params Expression<Func<TEntity, object>>[] includedProperties)
		{
			IQueryable<TEntity> query = Context.Set<TEntity>();
			if (filters != null)
			{
				query = query.Where(filters);
			}

			query = query.AsNoTracking();
			query = includedProperties.Aggregate(query, (current, property) => current.Include(property));

			return query.FirstOrDefault(); 
		}
	}
}
