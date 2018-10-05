using System.Collections.Generic;
using CFT.Standard.Domain.Models;

namespace CFT.Standard.Domain.Repositories
{
	public interface IBankRepository
	{
		void AddBank(Bank bank);

		List<Bank> GetBanks();
	}
}