using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFT.Standard.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.DAL.Repositories;
using CFT.Standard.DAL.Contexts;
using CFT.Standard.Domain.Models;
using SharepointEmulator.Models;

namespace CFT.Standard.BL.Services.Tests
{
	[TestClass()]
	public class BankServiceTests
	{
		[TestMethod()]
		public void GetAllBanksTest()
		{
			var ctx = new StandardListsContext(false);
			ctx.ClientContext.SiteUsers.AddItem(new UserEmulator()
				{ Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович" });

			var authorId = ctx.ClientContext.EnsureUser("ftc\\testuser").Id;

			ctx.Banks.AddItem(
				new DAL.Models.Bank() { Title = "test1", Author = new SharepointLookupFieldEmulator() { LookupId = authorId } });		
			
			var bankRepository=new BankRepository(ctx);
			var bankService = new BankService(bankRepository);
			Assert.IsTrue(bankService.GetAllBanks().Banks.Count == 1);
		}
	}
}