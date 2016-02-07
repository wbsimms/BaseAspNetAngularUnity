using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BaseAspNetAngularUnity.DataAccess.Models;
using BaseAspNetAngularUnity.DataAccess.Repository;
using EHRProfiler.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace BaseAspNetAngularUnity.DataAccess
{
	public interface IUnitOfWork : IDisposable
	{
		IUserManagerProxy UserManager { get; }
		ICategoryLogRepository<CategoryLog> CategoryLogRepository { get; set; }
		int Commit();
	}

	public class UnitOfWork : IUnitOfWork
	{
		private DataAccessContext context;
		public IUserManagerProxy UserManager { get; set; }
		public ICategoryLogRepository<CategoryLog> CategoryLogRepository { get; set; }

		public UnitOfWork(IDataAccessContext context,
			IUserManagerProxy userManagerProxy,
			ICategoryLogRepository<CategoryLog> categoryLog
			)
		{
			this.context = context as DataAccessContext;
			this.UserManager = userManagerProxy;
			this.CategoryLogRepository = categoryLog;

		}

		public int Commit()
		{
			return this.context.SaveChanges();
		}

		public void Dispose()
		{
			if (context != null)
			{
				context.Dispose();
				context = null;
			}
		}
	}

	public interface IUnitOfWorkFactory
	{
		IUnitOfWork GetUnitOfWork();
	}

	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork GetUnitOfWork()
		{
			return DataAccessResolver.Instance.Container.Resolve<IUnitOfWork>();
		}
	}
}
