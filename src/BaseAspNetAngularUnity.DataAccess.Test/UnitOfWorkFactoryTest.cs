using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.DataAccess.Test
{
	[TestClass]
	public class UnitOfWorkFactoryTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var factory = new UnitOfWorkFactory();
			Assert.IsInstanceOfType(factory,typeof(UnitOfWorkFactory));
		}
	}
}