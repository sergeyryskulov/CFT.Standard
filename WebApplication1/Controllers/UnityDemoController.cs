using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
  public class UnityDemoController : Controller
  {
    private ILocalWheatherServiceProvider _provider;
    private IFaceBookConnectionManager _manager;

    public UnityDemoController(
      ILocalWheatherServiceProvider provider,
      IFaceBookConnectionManager manager)
    {
      _provider = provider;
      _manager = manager;

    }

    public ActionResult Index()

    {
      if (_manager.AuthorizeUser())
      {
        string wheather = _provider.GetWheatherByZip("8889");
      }

      return View();
    }
  }
}