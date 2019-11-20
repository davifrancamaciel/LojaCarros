using Logica.Repositorio;
using System.Web.Mvc;
using PagedList;
using System;
using System.Linq;
using Dados.Entidade;

using Site.Areas.Admin.Controllers;




using Site.classes;
namespace Site.Controllers
{
    public class VeiculosController : BaseController
    {

        VeiculoDal veiculoDal;
        TipoDal tipoDal;
        ArquivoDal arquivodal;
        MarcaDal marcaDal;
        AnoModeloDal anoModeloDal;
        public VeiculosController()
        {
            veiculoDal = new VeiculoDal();
            tipoDal = new TipoDal();
            arquivodal = new ArquivoDal();
            marcaDal = new MarcaDal();
            anoModeloDal = new AnoModeloDal();
        }



        #region Acoes


        public ActionResult Index(string q, string tipo, string marca, int? anoInicio, int? anoFim, int? pagina, int? pt)
        {

            try
            {
                Helpers.RegistraLogDeAcesso("VEICULOS");
                Aviso();
                Diretorios();
                ViewBag.MarcaF = marca;
                ViewBag.TipoF = tipo;
                ViewBag.AnoInicioF = anoInicio;
                ViewBag.AnoFimF = anoFim;


                ViewBag.Tipo = tipoDal.Listar().OrderBy(x => x.Nome);

                //var lista = veiculoDal.ListarByFilto(tipo, marca, anoInicio, anoFim);
                Random rnd = new Random();
                IOrderedEnumerable<Veiculo> lista = veiculoDal.ListarByFilto(tipo, marca, anoInicio, anoFim).AsEnumerable().OrderBy((i => rnd.Next()));


                int paginaTamanho = (pt ?? 12);
                int paginaNumero = (pagina ?? 1);


                var e = this.RouteData.Values;
                string actionName = (string)e["action"];

                ViewBag.Action = actionName;
                ViewBag.Pagina = pagina;
                ViewBag.PaginaTamanho = pt;

                return View(lista.ToPagedList(paginaNumero, paginaTamanho));
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult Detalhes(string modelo, int id)
        {
            try
            {
                Helpers.RegistraLogDeAcesso("DETALHES_VEICULO_" + id + "_" + modelo.ToUpper());
                Diretorios();


                Random rnd = new Random();
                IOrderedEnumerable<Veiculo> Items = veiculoDal.Listar(null, true).AsEnumerable().OrderBy((i => rnd.Next()));
                ViewBag.Popular = Items.Where(x => x.Arquivo.Nome != "_semfoto.jpg").Take(4);


                ViewBag.Arquivos = arquivodal.ListarArquivosByIdVeiculo(id);

                VeiculoDal vd = new VeiculoDal();
                Veiculo veiculo = new Veiculo();

                veiculo = vd.ListarById(id, true);

                if (veiculo == null)
                {
                    TempData["Mensagem"] = "Este Veiculo não está mais disponivel ou foi vendido.";
                    return RedirectToAction("index");
                }
                veiculo.QtdAcesso = veiculo.QtdAcesso + 1;
                veiculoDal.Salvar(veiculo);
                return View(veiculo);
            }
            catch (Exception)
            {
                throw;
            }


        }


        public ActionResult Busca(string q, Exception exception)
        {
            try
            {
                return RedirectToAction("index", new { q = q });
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region Metodos



        public JsonResult ListMarca(string tipo)
        {
            try
            {
                //Thread.Sleep(1500);

                return Json(marcaDal.ListarByTipo(tipo, true).OrderBy(x => x.Nome), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        public JsonResult ListAnoFiltro(string marca)
        {
            try
            {

                return Json(anoModeloDal.ListarAno(marca).OrderBy(z => z.AnoLista), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        public JsonResult ListAnoMax(int anoMin, string marca)
        {
            try
            {

                if (anoMin != null)
                    return Json(anoModeloDal.ListarAnoFim(anoMin, marca), JsonRequestBehavior.AllowGet);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }


        #endregion

    }
}