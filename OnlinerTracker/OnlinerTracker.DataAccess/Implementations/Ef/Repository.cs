using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using OnlinerTracker.DataAccess.Enteties.Basis;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		internal readonly DbSet<TEntity> DbSet;
		internal readonly Context Context;

		public Repository(Context context)
		{
			Context = context;
			DbSet = context.Set<TEntity>();
		}

		public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filters = null, params Expression<Func<TEntity, object>>[] includedProperties)
		{
			IQueryable<TEntity> query = DbSet;
			if (filters != null)
			{
				query = query.Where(filters);
			}

			query = includedProperties.Aggregate(query, (current, property) => current.Include(property)).AsNoTracking();

			return query.AsEnumerable();
		}

		public void Attach(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public void Detach(TEntity entity)
		{
			if (Context.Entry(entity).State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}

			DbSet.Remove(entity);
		}

		public void Detach(int id)
		{
			var entity = DbSet.Find(id);
			Detach(entity);
		}

		public void Update(TEntity entity)
		{
			DbSet.AddOrUpdate(entity);
			//DbSet.Attach(entity);
			//Context.Entry(entity).State = EntityState.Modified;
		}

		public TEntity FindBy(Expression<Func<TEntity, bool>> filters = null, params Expression<Func<TEntity, object>>[] includedProperties)
		{
			IQueryable<TEntity> query = DbSet;
			if (filters != null)
			{
				query = query.Where(filters);
			}

			query = includedProperties.Aggregate(query, (current, property) => current.Include(property)).AsNoTracking();

			return query.FirstOrDefault(); 
		}
	}
}
