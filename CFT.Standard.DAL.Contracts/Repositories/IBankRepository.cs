using System.Collections.Generic;
using CFT.Standard.Domain.Models;

namespace CFT.Standard.Domain.Repositories
{
	public interface IBankRepository
	{
		void AddBank(Bank bank);

		void DeleteBank(int id);

		Bank GetBank(int id);

		void UpdateBank(Bank bank);

		List<Bank> GetAllBanks(string filter);
	}
}