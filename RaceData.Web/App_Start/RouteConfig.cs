﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RaceData.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Meetings", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RaceDetails",
                url: "Race/{action}/{id}/{tabid}",
                defaults: new { controller = "Race", action = "RaceDetails", id = UrlParameter.Optional, tabid=UrlParameter.Optional }
            );

        }
    }
}