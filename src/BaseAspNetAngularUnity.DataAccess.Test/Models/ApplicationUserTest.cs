using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseAspNetAngularUnity.DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BaseAspNetAngularUnity.DataAccess.Test.Models
{
	[TestClass]
	public class ApplicationUserTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			ApplicationUser user = new ApplicationUser()
			{
				Active = true,
				FirstName = "blah",
				LastName = "blah",
				TimeZone = "UTC"
			};

			Assert.IsNotNull(user);
			Assert.AreEqual("blah",user.FirstName);
			Assert.IsTrue(user.Active);
			Assert.AreEqual("blah",user.LastName);
			Assert.AreEqual("UTC",user.TimeZone);
		}
	}
}
