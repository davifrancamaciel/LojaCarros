using Dados.DTO;
using Dados.Entidade;
using Logica.Repositorio;
using Newtonsoft.Json;
using Site.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilidade;

namespace Site.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public string ActionCorrente()
        {
            var e = this.RouteData.Values;

            string controllerName = (string)e["controller"];
            string actionName = (string)e["action"];
            return actionName;
        }
        public void Aviso()
        {
            if (TempData["Mensagem"] != null)
            {
                var msg = TempData["Mensagem"];
                ViewBag.Mensagem = msg;
                Util.Alertar(ViewBag.Mensagem);
            }
        }
        public List<UnidadeFederativa> ListarEstado()
        {            
            return ViewBag.Estado = UnidadeFederativa.Listar();
        }

        public UsuarioDTO UsuarioCorrente()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuarioAltenticado = JsonConvert.DeserializeObject<UsuarioDTO>(User.Identity.Name);
                return usuarioAltenticado;
            }
            return null;
        }
        public void Diretorios()
        {
            ViewBag.Diretorio = Diretorio.ArquivoRedimencionados;
            ViewBag.DiretorioMin = Diretorio.ArquivoMin;
            ViewBag.DominioAppCliente = Diretorio.DominioAppCliente;
        }
    }
}