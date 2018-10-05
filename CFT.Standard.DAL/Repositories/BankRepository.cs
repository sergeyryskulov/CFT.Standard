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
			throw new NotImplementedException();
		}

		public List<Bank> GetBanks()
		{
			return _ctx.Banks.GetAllItems().ConvertAll(m=>m.ToDomain());
		}
	}
}
