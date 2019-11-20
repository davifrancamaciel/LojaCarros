using Dados.DTO;
using Logica.Repositorio;
using Newtonsoft.Json;
using Site.Areas.Admin.Controllers;
using Site.classes;
using Site.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Utilidade;

namespace Site.Controllers
{
    public class LoginController : BaseController
    {
        UsuarioDal usuarioDal = new UsuarioDal();
        public ActionResult Index()
        {
            Helpers.RegistraLogDeAcesso("LOGIN");
            try
            {
                LogAcessoDal d= new LogAcessoDal();
                var quantidade = d.Listar("LOGIN", "2017-06-01", "2017-06-30").Quantidade;
                var quantidadeHome = d.Listar("HOME", "2017-06-01", "2017-06-30").Quantidade;
                var quantidadeContato = d.Listar("CONTATO", "2017-06-01", "2017-06-30").Quantidade;
                UsuarioModelLogin model = new UsuarioModelLogin();
                Aviso();
                string url = Request.QueryString["ReturnUrl"];
                model.Url = url;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public ActionResult AutenticarUsuario(UsuarioModelLogin model)
        {
            try
            {
                if (ModelState.IsValid)
                {
         
                    UsuarioDTO usuario = usuarioDal.Altenticar(model.Email, Criptografia.Encriptar(model.Senha));

                    if (usuario != null)
                    {
                        var jsonUsuario = JsonConvert.SerializeObject(usuario);
                        // conceder permissão ao usuario   // tickete de acesso
                        // false define que o tiket e destruido quando o navegador for fechado
                        FormsAuthentication.SetAuthCookie(jsonUsuario, false);

                       
                        
                        // armazenar os dados do usuario em sessao//a sessao e um espaco  de memorioa mantido enquanto o navegador estiver aberto
                        //Session.Add("usuario", usuario);

                        if (model.Url != null)
                            return Redirect(model.Url);
                        else
                            return RedirectToAction("index", "veiculos", new { area = "admin", controller = "veiculos" });
                    }
                    else
                    {
                        TempData["Mensagem"] = "Acesso negado! Verifique se seu Email ou Senha estão corretos.";
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View("Index");
        }        
    }
}