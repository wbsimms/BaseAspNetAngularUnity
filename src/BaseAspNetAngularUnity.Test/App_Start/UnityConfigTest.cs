using System;
using System.Linq;
using BaseAspNetAngularUnity.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.Test.App_Start
{
	[TestClass]
	public class UnityConfigTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			UnityConfig config = new UnityConfig();
			Assert.IsNotNull(config);
		}

		[TestMethod]
		public void SomeTest()
		{
			var container = UnityConfig.GetConfiguredContainer();
			Assert.IsNotNull(container);
			Assert.IsTrue(container.Registrations.Any());

		}
	}
}
