using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using WebApplication1.Infrastructure;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
  public static class IocConfigurator
  {

    public static void ConfigureUnityContainer()
    {
      IUnityContainer c = new UnityContainer();
      registerServices(c);
      DependencyResolver.SetResolver(new DemoUnityDependencyResolver(c));
    }

    private static void registerServices(IUnityContainer c)
    {
      c.RegisterType<ILocalWheatherServiceProvider, LocalServiceProvider>(
        );
      c.RegisterType<IFaceBookConnectionManager, FaceBookConnectionManager>(
        //new PerRequestLifetimeManager(),
        new InjectionConstructor("" + System.Configuration.ConfigurationManager.AppSettings["test1"],
        "" + System.Configuration.ConfigurationManager.AppSettings["test2"],
        "" + System.Configuration.ConfigurationManager.AppSettings["test3"]

        ));
      


  }
  }
}