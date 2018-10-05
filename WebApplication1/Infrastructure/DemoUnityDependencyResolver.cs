using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace WebApplication1.Infrastructure
{
  public class DemoUnityDependencyResolver : IDependencyResolver
  {
    private IUnityContainer _c;

    public DemoUnityDependencyResolver(IUnityContainer c)
    {
      _c = c;
    }

    public object GetService(Type serviceType)
    {
      try
      {
        return _c.Resolve(serviceType);
      }
      catch
      {
        return null;
      }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      try
      {
        return _c.ResolveAll(serviceType);
      }
      catch
      {
        return new List<object>();
      }
    }
  }
}