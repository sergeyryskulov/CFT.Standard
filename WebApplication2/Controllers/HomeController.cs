using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
  public class TestViewModel
  {

    public TestViewModel(Service1 s)
    {
      ;
    }
  }

    public class HomeController : BaseController
    {

    public Service1 s1 { get; set; }

        public HomeController(Service1 s1, Service2 s2) : base(s1)
    {
      ;
    }
       
    }
}