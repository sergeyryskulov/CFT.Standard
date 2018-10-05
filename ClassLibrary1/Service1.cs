using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Services
{

  public class LayoutModel
  {
    public int t;
  }
  public class Service1 : IDisposable
  {

    BusinessLogic bl;
    public Service1(BusinessLogic bl)
    {
      this.bl=bl;
    }

    public LayoutModel GetLayout()
    {
      return new LayoutModel() { t = 1 };
    }

    public void Dispose()
    {
      var tt = 1;
    }
  }
}