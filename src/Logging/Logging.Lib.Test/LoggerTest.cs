using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logging.Lib.Test
{
	[TestClass]
	public class LoggerTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			Logger log = Logger.Instance;
			Assert.IsNotNull(log);
		}

		[TestMethod]
		public void LogMessageTest()
		{
			Logger.Instance.Writer.Write("Testing Message",LogCategories.General.ToString(),9,0,TraceEventType.Verbose);
		}
	}
}
