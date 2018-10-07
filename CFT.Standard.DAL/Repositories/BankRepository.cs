using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.DAL.Constants;
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

		public Bank GetBank(int id)
		{
			return _ctx.Banks.GetItemById(id);
		}

		public void UpdateBank(Bank bank)
		{
			_ctx.Banks.UpdateItem(bank);
		}

		public void DeleteBank(int id)
		{
			_ctx.Banks.DeleteItem(id);
		}

		public List<Bank> GetAllBanks(string filter)
		{
			if ("" + filter == "")
			{
				return _ctx.Banks.GetAllItems();
			}

			return _ctx.Banks.GetItems(CamlexNET.Camlex.Query()
				.Where(
					m => ((string) m[BankFields.Title]).Contains(filter) ||
						 ((string)m[BankFields.Bik]).Contains(filter)));
		}
	}
}
