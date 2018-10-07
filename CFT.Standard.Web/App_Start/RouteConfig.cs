﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CFT.Standard.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//			GlobalConfiguration.Configuration.MapHttpAttributeRoutes();

	        GlobalConfiguration.Configuration.Routes.MapHttpRoute(
		        name: "DefaultApi",
		        routeTemplate: "api/{controller}/{id}",
		        defaults: new { id = RouteParameter.Optional }
	        );

			routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bank", action = "All", id = UrlParameter.Optional }
            );
        }
    }
}
