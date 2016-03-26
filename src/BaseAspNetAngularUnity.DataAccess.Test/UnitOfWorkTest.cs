using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.DataAccess.Test
{
	[TestClass]
	public class UnitOfWorkTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var uow = DataAccessResolver.Instance.Container.Resolve<IUnitOfWork>();
			Assert.IsNotNull(uow);
		}
	}
}
