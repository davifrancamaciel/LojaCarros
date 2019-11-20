using System.Web.Mvc;

namespace Site.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }

        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Excluir Arquivo Galeria",
                "excluir/{id}/{nome}/{idVeiculo}",
                new { controller = "Veiculos", action = "ExcluirArquivo", AreaName = "Admin" },
                 namespaces: new[] { "Site.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Veiculos", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Site.Areas.Admin.Controllers" }
            );
        }
    }
}