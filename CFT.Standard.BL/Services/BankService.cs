﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.BL.Models.ViewModels;
using CFT.Standard.DAL.Repositories;
using CFT.Standard.Domain.Models;
using CFT.Standard.Domain.Repositories;

namespace CFT.Standard.BL.Services
{
	public class BankService
	{
		private IBankRepository _bankRepository;
		private ICurrentUserRepository _currentUserRepository;

		public BankService(IBankRepository bankRepository, ICurrentUserRepository currentUserRepository)
		{
			_bankRepository = bankRepository;
			_currentUserRepository = currentUserRepository;
		}

		public void AddBank(Bank bank)
		{
			bank.Author = _currentUserRepository.GetCurrentUserLookupValue();
			_bankRepository.AddBank(bank);
		}

		public AllBanksViewModel GetAllBanks()
		{			
			return new AllBanksViewModel()
			{
				Banks = _bankRepository.GetAllBanks()
			};
		}
	}
}
