using System;
using System.IO;
using System.Web;
using System.Web.Optimization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BaseAspNetAngularUnity.Test.App_Start
{
	[TestClass]
	public class BundleConfigTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			BundleConfig bc = new BundleConfig();
			Assert.IsNotNull(bc);
		}

		[TestMethod]
		public void RegisterBundlesTest()
		{
			BundleCollection bc = new BundleCollection(); 
			BundleConfig.RegisterBundles(bc);
			Assert.IsNotNull(bc);
			var bundle = bc.GetBundleFor("~/bundles/jquery");
			Assert.IsNotNull(bundle);
		}

		[TestInitialize]
		public void Setup()
		{
			HttpRequest httpRequest = new HttpRequest("", "http://localhost/", "");
			StringWriter stringWriter = new StringWriter();
			HttpResponse httpResponse = new HttpResponse(stringWriter);
			HttpContext httpContextMock = new HttpContext(httpRequest, httpResponse);
			HttpContext.Current = httpContextMock;
		}

	}
}
