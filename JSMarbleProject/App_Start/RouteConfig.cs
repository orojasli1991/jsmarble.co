using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JSMarbleProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
#region Services
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Chimneys",
            url: "Chimneys",
            defaults: new { controller = "Home", action = "Chimneys", id = UrlParameter.Optional }
    );
            routes.MapRoute(
            name: "RusticBars",
            url: "RusticBars",
            defaults: new { controller = "Home", action = "RusticBars", id = UrlParameter.Optional }
    );
            routes.MapRoute(
            name: "Sinks",
            url: "Sinks",
            defaults: new { controller = "Home", action = "Sinks", id = UrlParameter.Optional }
    );
            routes.MapRoute(
            name: "Mouldings",
            url: "Mouldings",
            defaults: new { controller = "Home", action = "Mouldings", id = UrlParameter.Optional }
    );
            routes.MapRoute(
            name: "MarbleTables",
            url: "MarbleTables",
            defaults: new { controller = "Home", action = "MarbleTables", id = UrlParameter.Optional }
    );
            routes.MapRoute(
            name: "Kitchens",
            url: "Kitchens",
            defaults: new { controller = "Home", action = "Kitchens", id = UrlParameter.Optional }
    );
            routes.MapRoute(
            name: "Floors",
            url: "Floors",
            defaults: new { controller = "Home", action = "Floors", id = UrlParameter.Optional }
    ); 
            routes.MapRoute(
            name: "MarblePlates",
            url: "MarblePlates",
            defaults: new { controller = "Home", action = "MablePlates", id = UrlParameter.Optional }
    );
            routes.MapRoute(
          name: "Columns",
          url: "Columns",
          defaults: new { controller = "Home", action = "Columns", id = UrlParameter.Optional }
    );
            #endregion           
            #region Default
            routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
     );
            #endregion
        }
    }
}
