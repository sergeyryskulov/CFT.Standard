using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class BaseController : Controller
    {

    public BaseController(Service1 service)
    {
      ViewData["LayoutModel"]=service.GetLayout();
    }
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}