﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();


            //  routes.MapRoute(
            //    name: "rota Renvan",
            //    url: "renavan/",
            //    defaults: new { controller = "Detran", action = "Rj" },
            //    namespaces: new[] { "Site.Controllers" }
            //);
            routes.MapRoute(
              name: "rota Sobre",
              url: "sobre/",
              defaults: new { controller = "Home", action = "Sobre" },
              namespaces: new[] { "Site.Controllers" }
          );
            routes.MapRoute(
            name: "rota contato",
            url: "contato-{assunto}",
            defaults: new { controller = "contato", action = "index" },
            namespaces: new[] { "LojaCarrosV2.Web.Controllers" }
        );
            routes.MapRoute(
             name: "rota detalhes",
             url: "{modelo}-{id}/",
             defaults: new { controller = "Veiculos", action = "Detalhes" },
             namespaces: new[] { "Site.Controllers" }
         );
            //    routes.MapRoute(
            //    name: "rota tipo",
            //    url: "veiculos/{tipo}/",
            //    defaults: new { controller = "veiculos", action = "Index"},
            //    namespaces: new[] { "Site.Controllers" }
            //);
            //    routes.MapRoute(
            //   name: "rota marca",
            //   url: "veiculos/{tipo}/{marca}/",
            //   defaults: new { controller = "veiculos", action = "Index"  },
            //   namespaces: new[] { "Site.Controllers" }
            //);
            //  routes.MapRoute(
            //    name: "busca",
            //    url: "{termo}/",
            //    defaults: new { controller = "veiculos", action = "Busca" },
            //    namespaces: new[] { "Site.Controllers" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Site.Controllers" }
            );

            routes.MapRoute(
          name: "rota ano",
          url: "veiculos/{tipo}/{marca}/{anoInicio}/{anoFim}/",
          defaults: new
          {
              controller = "veiculos",
              action = "Index",
              tipo = UrlParameter.Optional,
              marca = UrlParameter.Optional,
              anoInicio = UrlParameter.Optional,
              anoFim = UrlParameter.Optional
          },
          namespaces: new[] { "Site.Controllers" }
      );

        }
    }
}
