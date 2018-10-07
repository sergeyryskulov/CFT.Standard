using CFT.Standard.BL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CFT.Standard.BL.Services;
using CFT.Standard.Domain.Models;

namespace CFT.Standard.Web.Controllers
{
    public class BankController : Controller
    {

	    private BankService _bankService;

		public BankController(BankService bankService)
		{
			_bankService = bankService;
		}


	    public ActionResult Edit(int id)
	    {
		    return View("Bank", _bankService.GetBank(id));
	    }

	    [HttpPost]
	    public ActionResult Edit(Bank bank)
	    {
		    _bankService.UpdateBank(bank);
		    return Redirect("/Bank/All");
	    }

		public ActionResult Add()
	    {
		    return View("Bank", new Bank());
	    }

		[HttpPost]
	    public ActionResult Add(Bank bank)
	    {
		    _bankService.AddBank(bank);
			return Redirect("/Bank/All");
	    }	

		public ActionResult All()
		{			
			return View("AllBanks", _bankService.GetAllBanks(""));
		}

		[HttpPost]
	    public ActionResult All(AllBanksViewModel model)
	    {
		    return View("AllBanks", _bankService.GetAllBanks(model.Filter));
	    }
	}
}