using System;
using System.Security.Cryptography.X509Certificates;
using BaseAspNetAngularUnity.DataAccess.Models;
using BaseAspNetAngularUnity.DataAccess.Repository;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.DataAccess.Test.Repository
{
	[TestClass]
	public class LogRepositoryTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var repo = DataAccessResolver.Instance.Container.Resolve<ILogRepository<Log>>();
			Assert.IsNotNull(repo);
		}
	}
}
