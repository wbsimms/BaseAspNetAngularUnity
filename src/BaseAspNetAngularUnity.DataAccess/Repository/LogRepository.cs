using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAspNetAngularUnity.DataAccess.Models;

namespace BaseAspNetAngularUnity.DataAccess.Repository
{
	public interface ILogRepository<T> : IRepositoryBase<T> where T : Entity
	{
	}

	public class LogRepository<T> : RepositoryBase<T>, ILogRepository<T> where T : Entity
	{
		public LogRepository(IDataAccessContext context) : base(context)
		{
		}
	}

	public interface ICategoryLogRepository<T> : IRepositoryBase<T> where T : Entity
	{
	}

	public class CategoryLogRepository<T> : RepositoryBase<T>, ICategoryLogRepository<T> where T : Entity
	{
		public CategoryLogRepository(IDataAccessContext context)
			: base(context)
		{
		}
	}
}
