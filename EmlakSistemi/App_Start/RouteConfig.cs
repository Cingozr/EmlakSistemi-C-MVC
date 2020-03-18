using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace EmlakSistemi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Anasayfa", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "EmlakSistemi.Controllers" }
            );
            routes.MapRoute(
                name: "Ilanlar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Emlak", action = "Ilanlar", id = UrlParameter.Optional },
                namespaces: new string[] { "EmlakSistemi.Controllers" }
            );
            routes.MapRoute(
               name: "IlanDetay",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Emlak", action = "IlanDetay", id = UrlParameter.Optional },
               namespaces: new string[] { "EmlakSistemi.Controllers" }
           );
        }
    }
}
