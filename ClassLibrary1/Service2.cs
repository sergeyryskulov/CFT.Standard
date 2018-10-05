using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Services
{
  public class Service2 : IDisposable
  {
    BusinessLogic bl;
    public Service2(BusinessLogic bl){
      this.bl = bl;
    }
      
    public void Dispose()
    {
      ;
    }
  }
}