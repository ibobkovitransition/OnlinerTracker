using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OnlinerTracker.DataAccess.Enteties.Basis;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.DataAccess.Implementations.Ef
{
	public class EfGenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		internal readonly DbSet<TEntity> DbSet;
		internal readonly EfDbContext Context;

		public EfGenericRepository(EfDbContext context)
		{
			Context = context;
			DbSet = context.Set<TEntity>();
		}

		public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filters = null)
		{
			IQueryable<TEntity> query = DbSet;
			if (filters != null)
			{
				query = query.Where(filters);
			}

			return query.AsEnumerable();
		}

		public void Create(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public void Delete(TEntity entity)
		{
			if (Context.Entry(entity).State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}

			DbSet.Remove(entity);
		}

		public void Delete(int id)
		{
			var entity = DbSet.Find(id);
			Delete(entity);
		}

		public void Update(TEntity entity)
		{
			DbSet.Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
		}

		public TEntity FindBy(Expression<Func<TEntity, bool>> filters = null)
		{
			IQueryable<TEntity> query = DbSet;
			if (filters != null)
			{
				query = query.Where(filters);
			}

			return query.FirstOrDefault();
		}
	}
}
