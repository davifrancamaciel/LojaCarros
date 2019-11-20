using System.Linq;
using System;
using System.Web.Mvc;
using PagedList;
using Utilidade;
using Logica.Repositorio;
using Dados.Entidade;
using System.Web;
using System.IO;

namespace Site.Areas.Admin.Controllers
{
    [Authorize]
    public class BannersController : BaseController
    {
        BannerDal bannerDal = new BannerDal();
        public string arquivosNormais = "~/arquivos/banner/normais/";
        public string arquivosRedimencionados = "~/arquivos/banner/redimensionados/";
        public string arquivosMin = "~/arquivos/banner/miniaturas/";


        public ActionResult Index(string q, int? pagina, string so, string cs, int? pt)
        {
            ViewBag.Diretorio = arquivosNormais;
            Aviso();

            if (q == null)
                q = "";

            var lista = bannerDal.Listar(false).Where(x => x.Nome.ToLower().Contains(q.ToLower()));
            int paginaTamanho = (pt ?? 10);
            int paginaNumero = (pagina ?? 1);

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

                case "data-inicio":

                    if (so.Equals(cs))
                        return View(lista.OrderByDescending(x => x.DataInicio).ToPagedList(paginaNumero, paginaTamanho));
                    else
                        return View(lista.OrderBy(x => x.DataInicio).ToPagedList(paginaNumero, paginaTamanho));
                    break;
                case "data-fim":

                    if (so.Equals(cs))
                        return View(lista.OrderByDescending(x => x.DataFim).ToPagedList(paginaNumero, paginaTamanho));
                    else
                        return View(lista.OrderBy(x => x.DataFim).ToPagedList(paginaNumero, paginaTamanho));
                    break;
                case "data-cadastro":

                    if (so.Equals(cs))
                        return View(lista.OrderByDescending(x => x.DataCadastro).ToPagedList(paginaNumero, paginaTamanho));
                    else
                        return View(lista.OrderBy(x => x.DataCadastro).ToPagedList(paginaNumero, paginaTamanho));
                    break;
                default:
                    return View(lista.ToPagedList(paginaNumero, paginaTamanho));
                    break;
            }
        }


        //[HttpPost]
        //public ActionResult Cadastro(FormCollection model)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(Request.Form["tipoMarca"]) ||
        //            string.IsNullOrEmpty(Request.Form["txtNome"]) ||
        //            string.IsNullOrEmpty(Request.Form["hddIdMarca"]))
        //        {
        //            TempData["Mensagem"] = "Preecha todos os campos!";
        //            return RedirectToAction("index");
        //        }
        //        else
        //        {
        //            Marca marca = new Marca();
        //            marca.Tipo = new Tipo();

        //            marca.Tipo.IdTipo = Convert.ToInt32(Request.Form["tipoMarca"]);
        //            marca.Nome = Convert.ToString(Request.Form["txtNome"]).Replace(" ", "-");
        //            marca.IdMarca = Convert.ToInt32(Request.Form["hddIdMarca"]);

        //            bannerDal.Salvar(marca);
        //            if (marca.IdMarca == 0)
        //                TempData["Mensagem"] = "Marca " + marca.Nome + " cadastrada com sucesso!";
        //            else
        //                TempData["Mensagem"] = "Marca " + marca.Nome + " alterada com sucesso!";
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        public JsonResult Editar(int id)
        {
            try
            {
                return Json(bannerDal.Listar(id, false), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                var banner = bannerDal.Listar(false).FirstOrDefault(x => x.Id == id);
                if (banner != null)
                    AcessoPastaArquivos(banner.Nome);
                bannerDal.Excluir(id);
                TempData["Mensagem"] = "Banner EXCLUIDO com sucesso!";
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                //   TempData["Mensagem"] = "Certifique-se que tenha excluido todos veiculos relacionados a esta Marca. E tente novamente.";
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #region Upload


        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                HttpPostedFileBase file = Request.Files["myfile"];
                string nome = Guid.NewGuid().ToString() + ".jpg";
                int tamanho = file.ContentLength;
                string nomeAnterior = file.FileName;

                string extensao = Path.GetExtension(file.FileName);

                extensao = extensao.ToLower();

                if (extensao.Equals(".jpg") || extensao.Equals(".jpeg") || extensao.Equals(".gif") || extensao.Equals(".png"))
                {
                    if (file.ContentLength <= Math.Pow(1024, 2) * 2)
                    {
                        Banner a = new Banner
                        {
                            Nome = nome,
                            NomeAnterior = nomeAnterior,
                            Tamanho = tamanho,
                            DataCadastro = DateTime.Now,
                        };

                        bannerDal.Salvar(a);
                        string folder = Server.MapPath(arquivosNormais);
                        //file.SaveAs(Server.MapPath("~/") + "arquivos/normais/" + nome);
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        file.SaveAs(folder + nome);

                        //RedimensionarImagens(nome, 600, 400, "arquivos\\redimensionados\\");
                        //RedimensionarImagens(nome, 300, 200, "arquivos\\miniaturas\\");
                        //ExcluiArquivosNormais(nome);
                    }
                    else
                    {
                        TempData["Mensagem"] = "Sua imagem ultrapassou o limite de 2 MB suportado pelo sistema.<br /> Referente ao VEÍCULO <label class='label label-danger'>" + "</label>";
                        return Json(false);
                    }
                }
                else
                {
                    TempData["Mensagem"] = "Algum arquivo não foi gravado com sucesso.<br /> Verifique se o mesmo possui as extenções de imagem (.jpeg, .png, .jpg ou .gif) que são suportadas pelo sistema.<br />Referente ao VEÍCULO <label class='label label-danger'>ID " + "</label>";
                    return Json(false);
                }

                return Json(new { success = true });
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        public void Aviso()
        {
            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"];
                Util.Alertar(ViewBag.Mensagem);
            }
        }
        public void AcessoPastaArquivos(string nome)
        {
            //AcessoPastaArquivos para exclusao dos mesmos na pasta
            string fileName = nome;
            //string targetPath = @"~/arquivos/normais/";
            string targetPath = arquivosNormais;
            string destFile = Path.Combine(targetPath, fileName);
            System.IO.File.Delete(Server.MapPath(destFile));

            //string targetPathRedimencionados = arquivosRedimencionados;
            ////string targetPathRedimencionados = @"~/arquivos/redimencionados/";
            //string destFileRedimencionados = Path.Combine(targetPathRedimencionados, fileName);
            //System.IO.File.Delete(Server.MapPath(destFileRedimencionados));

            //string targetPathMin = arquivosMin;
            ////string targetPathRedimencionados = @"~/arquivos/redimencionados/";
            //string destFileMin = Path.Combine(targetPathMin, fileName);
            //System.IO.File.Delete(Server.MapPath(destFileMin));

        }
    }
}