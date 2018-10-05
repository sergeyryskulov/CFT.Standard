using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharepointEmulator.Context;
using SharepointEmulator.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator.Context.Tests
{
	[TestClass()]
	public class SharepointListsContextEmulatorTests
	{
		[TestMethod()]
		public void SharepointListsContextEmulatorTest()
		{
			var context = new MyListsContext();
			Assert.IsNotNull(context.News);
			Assert.IsNotNull(context.ClientContext);
			Assert.IsNotNull(context.ClientContext.GetListByTitle("TestList"));
		}

		
	}
}