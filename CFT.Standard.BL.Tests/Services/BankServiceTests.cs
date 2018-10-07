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
using CFT.Standard.Domain.Repositories;
using SharepointEmulator.Models;
using Moq;

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
				new Bank() { Title = "test1", Author = new SharepointLookupFieldEmulator() { LookupId = authorId } });		
			
			var bankRepository=new BankRepository(ctx);
		//	var bankService = new BankService(bankRepository, new HttpRepository());
		//	Assert.IsTrue(bankService.GetAllBanks().Banks.Count == 1);
		}


		[TestMethod()]
		public void AddBankTest()
		{
			var ctx = new StandardListsContext(false);
			ctx.ClientContext.SiteUsers.AddItem(new UserEmulator()
				{ Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович" });

			var currentUser= ctx.ClientContext.EnsureUser("ftc\\testuser");
						
			var bankRepository = new BankRepository(ctx);
			var httpRepositoryStub= new Mock<IHttpRepository>();
			httpRepositoryStub.Setup(m => m.GetCurrentUserLogin()).Returns(
				"ftc\\testuser"
			);
			var bankService = new BankService(bankRepository, new CurrentUserRepository(httpRepositoryStub.Object, ctx) );
			bankService.AddBank(new Bank() {Title = "test bank1"});
			Assert.IsTrue(ctx.Banks.Count()==1);
		}


	}
}