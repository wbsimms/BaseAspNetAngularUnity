using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAspNetAngularUnity.DataAccess.Models;
using BaseAspNetAngularUnity.DataAccess.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace BaseAspNetAngularUnity.DataAccess
{
	public class DataAccessResolver
	{
		static DataAccessResolver INSTANCE = new DataAccessResolver();
		private UnityContainer container;


		private DataAccessResolver()
		{
			Init();
		}

		private void Init()
		{
			container = new UnityContainer();
			Register(container);
		}

		public void Register(IUnityContainer container)
		{
			container.RegisterType<IDataAccessContext, DataAccessContext>(new PerResolveLifetimeManager());
			container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
			container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();
			container.RegisterType<IUserManagerProxy, UserManagerProxy>();
			container.RegisterType<ILogRepository<Log>, LogRepository<Log>>();
		}

		public UnityContainer Container
		{
			get { return this.container; }
		}

		public static DataAccessResolver Instance
		{
			get { return INSTANCE; }
		}

		public void Reset()
		{
			this.Init();
		}
	}
}

