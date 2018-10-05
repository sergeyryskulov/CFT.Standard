using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharepointEmulator.Context;
using SharepointEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator.Context.Tests
{
	[TestClass()]
	public class ClientContextEmulatorTests
	{


		[TestMethod()]
		public void AddListTest()
		{
			var clientContext = new ClientContextEmulator();
			clientContext.AddList("TestList");
			Assert.IsTrue(clientContext.GetListByTitle("TestList") != null);
		}

		[TestMethod()]
		public void GetListByTitleTest()
		{
			var clientContext = new ClientContextEmulator();
			clientContext.AddList("TestList");
			Assert.IsTrue(clientContext.GetListByTitle("TestList") != null);
		}

		[TestMethod()]
		public void ClientContextEmulatorTest()
		{
			var clientContext = new ClientContextEmulator();
			clientContext.SiteUsers.AddItem(new UserEmulator() { Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович" });
			Assert.IsTrue(clientContext.SiteUsers.Count() == 1);
		}

		[TestMethod()]
		public void EnsureUserTest()
		{
			var clientContext = new ClientContextEmulator();
			clientContext.SiteUsers.AddItem(new UserEmulator() { Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович" });
			Assert.IsTrue(clientContext.EnsureUser("ftc\\testuser").DisplayName== "Иванов Иван Иванович");
		}
	}
}