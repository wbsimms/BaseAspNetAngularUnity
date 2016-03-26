using BaseAspNetAngularUnity.DataAccess.Models;
using BaseAspNetAngularUnity.DataAccess.Repository;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.DataAccess.Test.Repository
{
	[TestClass]
	public class CategoryLogRepositoryTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var repo = DataAccessResolver.Instance.Container.Resolve<ICategoryLogRepository<CategoryLog>>();
			Assert.IsNotNull(repo);
		}
	}
}