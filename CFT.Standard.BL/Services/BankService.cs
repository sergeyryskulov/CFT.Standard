using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.BL.Models.ViewModels;
using CFT.Standard.Domain.Models;
using CFT.Standard.Domain.Repositories;

namespace CFT.Standard.BL.Services
{
	public class BankService
	{
		private IBankRepository _bankRepository;

		public BankService(IBankRepository bankRepository)
		{
			this._bankRepository = bankRepository;
		}

		public AllBanksViewModel GetAllBanks()
		{			
			return new AllBanksViewModel()
			{
				Banks = _bankRepository.GetBanks()
			};
		}
	}
}
