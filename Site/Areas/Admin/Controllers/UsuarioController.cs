using Dados.Entidade;
using Logica.Repositorio;
using Site.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Utilidade;
using PagedList;
using System.Linq;

namespace Site.Areas.Admin.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        UsuarioDal usuarioDal = new UsuarioDal();

        #region Listar todos usuarios

        public ActionResult Index(string q, int? pagina, string so, string cs, int? pt)
        {
            if (q == null)
                q = "";
            var usuarioAutenticado = UsuarioCorrente();
            var lista = usuarioDal.Listar().Where(x => x.IdUsuario != usuarioAutenticado.IdUsuario && x.Email.ToLower().Contains(q.ToLower()));
            int paginaTamanho = (pt ?? 10);
            int paginaNumero = (pagina ?? 1);

            ViewBag.Action = ActionCorrente();
            ViewBag.Pagina = pagina;
            ViewBag.PaginaTamanho = pt;
            ViewBag.CurrentSort = so;
            ViewBag.SortOrder = so;
            ViewBag.Query = q;

            Aviso();

            switch (so)
            {
                case "email":

                    if (so.Equals(cs))
                        return View(lista.OrderByDescending(x => x.Email).ToPagedList(paginaNumero, paginaTamanho));
                    else
                        return View(lista.OrderBy(x => x.Email).ToPagedList(paginaNumero, paginaTamanho));
                    break;

                default:
                    return View(lista.ToPagedList(paginaNumero, paginaTamanho));
                    break;
            }
        }
        #endregion


        #region Alterar minha senha

        public ActionResult Alterar()
        {
            try
            {
                Aviso();

                Dados.Entidade.Usuario u = new Usuario();
                UsuarioModelAlterarSenha model = new UsuarioModelAlterarSenha();

                u = usuarioDal.ListarPorId(UsuarioCorrente().IdUsuario);
                model.IdUsuario = u.IdUsuario;
                model.Email = u.Email;

                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult AlterarSenha(UsuarioModelAlterarSenha model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuarioDal.VerificarSenhaAtual(Criptografia.Encriptar(model.SenhaAtual), model.IdUsuario))
                    {
                        if (model.Senha.Equals(model.SenhaConf))
                        {
                            Usuario u = new Usuario();
                            u.IdUsuario = model.IdUsuario;
                            u.Senha = Criptografia.Encriptar(model.Senha);
                            usuarioDal.Salvar(u);

                            TempData["Mensagem"] = model.Email + ", Alterado(a) com sucesso!";
                            return RedirectToAction("Alterar");
                        }
                        else
                        {
                            TempData["Mensagem"] = "As senhas não conferem!";
                            return RedirectToAction("Alterar");
                        }
                    }
                    else
                    {
                        TempData["Mensagem"] = "A Senha atual está incorreta.";
                        return RedirectToAction("Alterar");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }            
            return View("Alterar");

        }
        #endregion


        #region Cadastrar Usuario

        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(UsuarioModelCadastroAdminstrador model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (!usuarioDal.Existe(model.Email))
                    {
                        if (model.Senha.Equals(model.SenhaConf))
                        {
                            Usuario u = new Usuario();
                            u.Email = model.Email;
                            u.Senha = Criptografia.Encriptar(model.Senha);
                            usuarioDal.Salvar(u);
                            ViewBag.Mensagem = u.Email + ", cadastrado(a) com sucesso!";

                            return RedirectToAction("index");
                        }
                        else
                        {
                            ViewBag.Mensagem = "As senhas não conferem!";
                            Util.Alertar(ViewBag.Mensagem);
                            return View(model);
                        }
                    }
                    else
                    {
                        ViewBag.Mensagem = "Este Email ja se encontra em nossa base de dados por favor utilize outro";
                        Util.Alertar(ViewBag.Mensagem);
                        return View(model);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            ModelState.Clear();
            Util.Alertar(ViewBag.Mensagem);
            return View("Cadastro");
        }
        #endregion


        #region Excluir Usuario
        public JsonResult Excluir(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (UsuarioCorrente().IdUsuario != id)
                    {
                        usuarioDal.Excluir(id);
                        TempData["Mensagem"] = "Usuário EXCLUIDO com sucesso!";
                    }
                    else
                        TempData["Mensagem"] = "Ocorreu um erro! Você não pode se excluir!";
                }                
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "Ocorreu um erro ao EXCLUIR!";
                return Json(false);
            }
        }

        #endregion


        #region Logout

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("usuario");
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("index", "login", new { area = "", controller = "login" });
        }

        #endregion



    }
}
