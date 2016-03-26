using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseAspNetAngularUnity.DataAccess.Models;

namespace BaseAspNetAngularUnity.DataAccess.Test.Models
{
	[TestClass]
	public class CategoryTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			Category category = new Category()
			{
				CategoryId = 1,
				CategoryName = "blah"
			};
			Assert.IsNotNull(category);
			Assert.IsNotNull(category.CategoryName);
			Assert.AreEqual(1,category.CategoryId);
		}
	}
}
