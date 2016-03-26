using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.DataAccess.Test
{
	[TestClass]
	public class DataAccessResolverTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			DataAccessResolver resolver = DataAccessResolver.Instance;
			Assert.IsNotNull(resolver);
		}

		[TestMethod]
		public void RestTest()
		{
			DataAccessResolver.Instance.Reset();
		}
	}
}
