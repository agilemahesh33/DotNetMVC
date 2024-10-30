using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTestEmptyProject3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Students",
                url:"MMB/Students",
                defaults: new {Controller="Student", action =  "Index"}
                );
            routes.MapRoute(
                name: "Teachers",
                url: "MMB/Teachers",
                defaults: new { Controller = "Teacher", action = "Show" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
