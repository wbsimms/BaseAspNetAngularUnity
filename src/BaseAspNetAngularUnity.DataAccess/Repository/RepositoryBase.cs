using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BaseAspNetAngularUnity.DataAccess.Models;

namespace BaseAspNetAngularUnity.DataAccess.Repository
{
	public interface IRepositoryBase<T> where T : Entity
	{
		IQueryable<T> GetAll();
		IQueryable<T> Get(Expression<Func<T, bool>> expression);
		T Add(T entity);
		IEnumerable<T> AddRange(IEnumerable<T> entities);
	}

	public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
	{
		protected DataAccessContext context;

		public IEnumerable<T> AddRange(IEnumerable<T> entities)
		{
			return context.Set<T>().AddRange(entities);
		}

		public T Add(T entity)
		{
			return context.Set<T>().Add(entity);
		}

		public IQueryable<T> GetAll()
		{
			return context.Set<T>();
		}

		public IQueryable<T> Get(Expression<Func<T, bool>> expression)
		{
			return context.Set<T>().Where(expression);
		}
		public RepositoryBase(IDataAccessContext dataAccessContext)
		{
			this.context = dataAccessContext as DataAccessContext;
		}
	}
}
