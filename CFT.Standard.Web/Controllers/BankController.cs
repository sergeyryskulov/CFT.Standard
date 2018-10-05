using CFT.Standard.BL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CFT.Standard.BL.Services;

namespace CFT.Standard.Web.Controllers
{
    public class BankController : Controller
    {

	    private BankService _bankService;

		public BankController(BankService bankService)
		{
			_bankService = bankService;
		}
		
		
		public ActionResult All()
		{			
			return View("AllBanks", _bankService.GetAllBanks());
		}
	}
}