using Site.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using Utilidade;
using Logica.Repositorio;
using Dados.Entidade;
using System.Linq;

namespace Site.Areas.Admin.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        ClienteDal clienteDal = new ClienteDal();

        #region Listar
        //public ActionResult Index(int? pagina, BuscaModel model)
        //{

        //    model.Termo = Convert.ToString(Request.Form["nomeCliente"]);
        //    var lista = clienteDal.Listar(model.Termo);
        //    int paginaTamanho = 10;
        //    int paginaNumero = (pagina ?? 1);

        //    Aviso();
        //    return View(lista.ToPagedList(paginaNumero, paginaTamanho));
        //}
        public ActionResult Index(string q, int? pagina, string so, string cs, int? pt, BuscaModel model)
        {

            model.Termo = q;
            var lista = clienteDal.Listar(model.Termo);
            int paginaTamanho = (pt ?? 10);
            int paginaNumero = (pagina ?? 1);

            Aviso();

            ViewBag.Action = ActionCorrente();
            ViewBag.Pagina = pagina;
            ViewBag.PaginaTamanho = pt;
            ViewBag.CurrentSort = so;
            ViewBag.SortOrder = so;
            ViewBag.Query = q;


            switch (so)
            {
                case "nome":

                    if (so.Equals(cs))
                        return View(lista.OrderByDescending(x => x.Nome).ToPagedList(paginaNumero, paginaTamanho));
                    else
                        return View(lista.OrderBy(x => x.Nome).ToPagedList(paginaNumero, paginaTamanho));
                    break;

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


        #region Cadastro

        public ActionResult Cadastro()
        {
            ListarEstado();
            Aviso();

            return View(new ClienteVM());
        }
        [HttpPost]
        public ActionResult Cadastro(ClienteVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente();
                    

                    cliente.IdCliente = model.IdCliente;
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.CEP = model.CEP;
                    cliente.Logradouro = model.Logradouro;
                    cliente.Cidade = model.Cidade;
                    cliente.Bairro = model.Bairro;
                    cliente.Telefone1 = model.Telefone1;
                    cliente.Telefone2 = model.Telefone2;
                    cliente.Estado = Convert.ToString(Request.Form["estado"]);
                    cliente.DataCadastro = DateTime.Now;

                    clienteDal.Salvar(cliente);

                    ModelState.Clear();
                    if (cliente.IdCliente <= 0)
                        TempData["Mensagem"] = cliente.Nome + ", cadastrado(a) com sucesso!";
                    else
                        TempData["Mensagem"] = cliente.Nome + ", Alterado(a) com sucesso!";

                    return RedirectToAction("Index");

                }
                ListarEstado();

                return View(model);

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion


        #region Editar
        public ActionResult Editar(int id)
        {

            var cliente = clienteDal.ListarPorId(id);
            ClienteVM model = new ClienteVM();

            model.IdCliente = cliente.IdCliente;
            model.Nome = cliente.Nome;
            model.Email = cliente.Email;
            model.CEP = cliente.CEP;
            model.Logradouro = cliente.Logradouro;
            model.Bairro = cliente.Bairro;
            model.Cidade = cliente.Cidade;
            model.Estado = cliente.Estado;
            model.Telefone1 = cliente.Telefone1;
            model.Telefone2 = cliente.Telefone2;

            ListarEstado();

            return View(model);
        }

        #endregion


        #region Detalhes
        public ActionResult Detalhes(int id)
        {

            var cliente = clienteDal.ListarPorId(id);
            ClienteVM model = new ClienteVM();

            model.IdCliente = cliente.IdCliente;
            model.Nome = cliente.Nome;
            model.Email = cliente.Email;
            model.CEP = cliente.CEP;
            model.Logradouro = cliente.Logradouro;
            model.Bairro = cliente.Bairro;
            model.Cidade = cliente.Cidade;
            model.Estado = cliente.Estado;
            model.Telefone1 = cliente.Telefone1;
            model.Telefone2 = cliente.Telefone2;
            model.DataCadastro = cliente.DataCadastro;


            Aviso();
            return View(model);
        }


        #endregion


        #region Excluir
        public JsonResult Excluir(int id)
        {
            try
            {
                clienteDal.Excluir(id);
                TempData["Mensagem"] = "Cliente EXCLUIDO com sucesso!";
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "Ocorreu um erro ao EXCLUIR!";
                return Json(false);
            }
        }






        #endregion


      
    }
}