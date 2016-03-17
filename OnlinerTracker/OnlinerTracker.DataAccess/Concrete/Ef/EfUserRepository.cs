using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using OnlinerTracker.DataAccess.Abstract;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.DataAccess.Concrete.Ef
{
	public class EfUserRepository : IRepository<User>
	{

		internal readonly DbSet<User> DbSet;
		internal readonly EfDbContext Context;

		public EfUserRepository(EfDbContext context)
		{
			DbSet = context.Set<User>();
			Context = context;
		}

		public IEnumerable<User> GetEntities(Expression<Func<User, bool>> filters = null)
		{
			IQueryable<User> query = DbSet;
			if (filters != null)
			{
				query = query.Where(filters);
			}

			return query.AsEnumerable();
		}

		public void Create(User entity)
		{
			DbSet.Add(entity);
		}

		public void Delete(User entity)
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
			//if (entity == null)
			//	throw new ArgumentException($"Ilegal id {id}");
			Delete(entity);
		}

		public void Update(User entity)
		{
			DbSet.Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
		}

		public User FindBy(Expression<Func<User, bool>> filters = null)
		{
			IQueryable<User> query = DbSet;
			if (filters != null)
			{
				query = query.Where(filters);
			}

			return query.FirstOrDefault();
		}
	}
}
