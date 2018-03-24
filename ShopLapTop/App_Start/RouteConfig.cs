using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopLapTop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    "Comment",
            //    "{model}/{MaSP}",
            //    new { controller = "Comments", action = "AddComment", queryValues = UrlParameter.Optional },
            //    new[] { "ShopLapTop.Controllers" }
            //    );


            //routes.MapRoute(
            //    "SubComment",              
            //    "{controller}/{action}/ID",
            //    new { controler="Comments",action= "GetListSubComments", queryValues = UrlParameter.Optional },
            //    new[] { "ShopLapTop.Controllers"}
            //    );

            routes.MapRoute(
                 "Default",
                 "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                 new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                new[] {"ShopLapTop.Controllers"}
            );

            routes.MapRoute(
                 "Product search",
                "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                new { controller = "Product", action = "tim", id = UrlParameter.Optional },
                new[] { "ShopLapTop.Controllers" }
            );

            

            routes.MapRoute(
               name: "Product Detail",
               url: "{controller}/{action}/{id}",
               //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               defaults: new { controller = "Product", action = "chitietsanpham", id = UrlParameter.Optional },
               namespaces: new[] { "ShopLapTop.Controllers" }
           );
        }
    }
}
