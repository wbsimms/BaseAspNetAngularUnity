using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.Test
{
	[TestClass]
	public class BaseAspNetAngularUnityResolverTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var resolver = BaseAspNetAngularUnityResolver.Instance;
			Assert.IsNotNull(resolver);
		}
	}
}
