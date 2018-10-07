using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CFT.Standard.BL.Services;

namespace CFT.Standard.Api.Controllers
{
    public class DeleteBankController : ApiController
    {
	    private BankService _bankService;
	    public DeleteBankController(BankService bankService)
	    {
		    _bankService = bankService;
	    }

	    public void Post(int id)
	    {
		    _bankService.DeleteBank(id);
	    }

		public void Get(int id)
	    {
			_bankService.DeleteBank(id);		    
	    }
    }
}
