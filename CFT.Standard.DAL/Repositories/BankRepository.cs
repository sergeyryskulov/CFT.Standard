using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.DAL.Contexts;
using CFT.Standard.Domain.Models;
using CFT.Standard.Domain.Repositories;

namespace CFT.Standard.DAL.Repositories
{
	public class BankRepository : IBankRepository
	{
		private StandardListsContext _ctx;

		public BankRepository(StandardListsContext ctx)
		{
			_ctx = ctx;
		}
		public void AddBank(Bank bank)
		{			
			_ctx.Banks.AddItem(bank);
		}

		public List<Bank> GetAllBanks()
		{
			return _ctx.Banks.GetAllItems();
		}
	}
}
