using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseAspNetAngularUnity.Controllers;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;

namespace BaseAspNetAngularUnity
{
	public class BaseAspNetAngularUnityResolver
	{
		private IUnityContainer container;

		public static BaseAspNetAngularUnityResolver Instance { get; } = new BaseAspNetAngularUnityResolver();

		private BaseAspNetAngularUnityResolver()
		{
			Init();
		}

		public void Init()
		{
			this.container = new UnityContainer();
			Register(container);
		}

		public void Register(IUnityContainer container)
		{
			container.RegisterType<AccountController>(new InjectionConstructor());
			container.RegisterType<ManageController>(new InjectionConstructor());
		}

		public void Reset()
		{
			this.Init();
		}
	}
}