using CamlexNET.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharepointEmulator;
using SharepointEmulator.Context;
using SharepointEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator.Tests
{
	[TestClass()]
	public class SharepointListEmulatorTests
	{



		private ClientContextEmulator GetNewClientContext()
		{
			var ctx = new ClientContextEmulator();
			ctx.AddList("TestList");
			return ctx;
		}

		[TestMethod()]
		public void SharepointListEmulatorTest()
		{

			var spList = new SharepointListEmulator<TestModel>("TestList", GetNewClientContext());
			Assert.IsTrue(spList.GetAllItems().Count == 0);
		}

		[TestMethod()]
		public void GetItemByIdTest()
		{
			var spList = new SharepointListEmulator<TestModel>("TestList", GetNewClientContext());
			var id = spList.AddItem(new TestModel()
			{
				Title = "test"
			});
			Assert.IsNotNull(spList.GetItemById(id));
		}

		[TestMethod()]
		public void GetItemsTest()
		{
			var spList = new SharepointListEmulator<TestModel>("TestList", GetNewClientContext());
			var id = spList.AddItem(new TestModel()
			{
				Title = "test"
			});
			var count = spList.GetItemById(id);
			IQuery q = CamlexNET.Camlex.Query();
			var test = spList.GetItems(CamlexNET.Camlex.Query().Where(
			m => ((string)m["Title"]).StartsWith("te"))).Count;
			Assert.IsTrue(test == 1);
		}

		[TestMethod()]
		public void AddItemTest()
		{
			var ctx = GetNewClientContext();
			var userId= ctx.SiteUsers.AddItem(new UserEmulator() { Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович" });
			
			var spList = new SharepointListEmulator<TestModel>("TestList", ctx);						
			var itemId= spList.AddItem(new TestModel()
			{
				Title = "test",
				Author = new SharepointLookupFieldEmulator() { LookupId = userId}
			});

			var itemAfterAdd= spList.GetItemById(itemId);
			Assert.IsTrue(spList.GetAllItems().Count == 1);
			Assert.IsTrue(itemAfterAdd.Author.LookupValue == "Иванов Иван Иванович");

		}

		[TestMethod()]
		public void DeleteItemTest()
		{
			var spList = new SharepointListEmulator<TestModel>("TestList", GetNewClientContext());
			var id = spList.AddItem(new TestModel()
			{
				Title = "test"
			});
			spList.DeleteItem(id);

			Assert.IsTrue(spList.GetAllItems().Count == 0);
		}

		[TestMethod()]
		public void UpdateItemTest()
		{
			var spList = new SharepointListEmulator<TestModel>("TestList", GetNewClientContext());
			var id = spList.AddItem(new TestModel()
			{
				Title = "test"
			});
			var itemToUpdate = spList.GetItemById(id);
			itemToUpdate.Title = "test1";
			spList.UpdateItem(itemToUpdate);

			Assert.IsTrue(spList.GetItemById(id).Title == "test1");
		}

		[TestMethod()]
		public void CountTest()
		{
			var spList = new SharepointListEmulator<TestModel>("TestList", GetNewClientContext());
			var id = spList.AddItem(new TestModel()
			{
				Title = "test"
			});

			Assert.IsTrue(spList.Count()==1);
		}
	}
}