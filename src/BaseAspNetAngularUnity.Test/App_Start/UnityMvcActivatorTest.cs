using System;
using System.Web.Mvc;
using BaseAspNetAngularUnity.App_Start;
using Microsoft.Practices.Unity.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAspNetAngularUnity.Test.App_Start
{
	[TestClass]
	public class UnityMvcActivatorTest
	{
		[TestMethod]
		public void StartStopTest()
		{
			Assert.IsFalse(DependencyResolver.Current is UnityDependencyResolver);
			UnityWebActivator.Start();
			Assert.IsTrue(DependencyResolver.Current is UnityDependencyResolver);
		}
	}
}
