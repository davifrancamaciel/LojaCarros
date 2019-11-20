using Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using PagedList;
using System.Web;
using Utilidade;
using Logica.Repositorio;
using Dados.Entidade;
using System.Drawing;
using System.Linq;



namespace Site.Areas.Admin.Controllers
{
    [Authorize]
    public class VeiculosController : BaseController
    {


        VeiculoDal veiculoDal;
        CombustivelDal combustivelDal;
        TipoDal tipoDal;
        AnoModeloDal anoModeloDal;
        MarcaDal marcaDal;
        ArquivoDal arquivoDal;
        public VeiculosController()
        {
            veiculoDal = new VeiculoDal();
            combustivelDal = new CombustivelDal();
            tipoDal = new TipoDal();
            anoModeloDal = new AnoModeloDal();
            marcaDal = new MarcaDal();
            arquivoDal = new ArquivoDal();
        }
        public string arquivosNormais = "~/arquivos/normais/";
        public string arquivosRedimencionados = "~/arquivos/redimensionados/";
        public string arquivosMin = "~/arquivos/miniaturas/";

        #region Listar


        public ActionResult Index(string q, int? pagina, string so, string cs, int? pt)
        {

            try
            {
                Diretorios();
                Aviso();
                if (q == null)
                    q = "";
                var lista = veiculoDal.Listar(null, null).Where(x => x.Modelo.ToLower().Contains(q.ToLower()) || x.Marca.Nome.ToLower().Contains(q.ToLower()));

                int paginaTamanho = (pt ?? 10);
                int paginaNumero = (pagina ?? 1);

                ViewBag.Action = ActionCorrente();
                ViewBag.Pagina = pagina;
                ViewBag.PaginaTamanho = pt;
                ViewBag.CurrentSort = so;
                ViewBag.SortOrder = so;
                ViewBag.Query = q;
                ViewBag.Total = lista.Count();


                switch (so)
                {
                    case "modelo":

                        if (so.Equals(cs))
                            return View(lista.OrderByDescending(x => x.Modelo).ToPagedList(paginaNumero, paginaTamanho));
                        else
                            return View(lista.OrderBy(x => x.Modelo).ToPagedList(paginaNumero, paginaTamanho));
                        break;

                    case "ano":

                        if (so.Equals(cs))
                            return View(lista.OrderByDescending(x => x.AnoFabricacao).ToPagedList(paginaNumero, paginaTamanho));
                        else
                            return View(lista.OrderBy(x => x.AnoFabricacao).ToPagedList(paginaNumero, paginaTamanho));
                        break;
                    default:
                        return View(lista.ToPagedList(paginaNumero, paginaTamanho));
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Tabela()
        {

            try
            {
                List<Veiculo> lista = new List<Veiculo>();
                lista = veiculoDal.Listar(null, null);
                lista = lista.OrderBy(x => x.Marca.Nome).ToList();
                ViewBag.Total = lista.Count();
                return View(lista);


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Cadastro

        public ActionResult Cadastro()
        {
            try
            {
                Aviso();
                CarregarDropDowns();
            }
            catch (Exception)
            {

                throw;
            }

            return View(new VeiculoVM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(VeiculoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.Combustivel = new Combustivel();
                    veiculo.Tipo = new Tipo();
                    veiculo.Marca = new Marca();

                    veiculo.IdVeiculo = model.IdVeiculo;
                    veiculo.DataCadastro = DateTime.Now;
                    veiculo.Modelo = NormalizeTextExtension.RemoveSpecialCharacters(model.Modelo);
                    veiculo.AnoFabricacao = Convert.ToInt32(Request.Form["anoFabricacao"]);
                    veiculo.AnoModelo = Convert.ToInt32(Request.Form["anoModelo"]);
                    veiculo.Valor = model.Valor;
                    veiculo.Descricao = model.Descricao;
                    veiculo.Tipo.IdTipo = Convert.ToInt32(Request.Form["tipo"]);
                    veiculo.Marca.IdMarca = Convert.ToInt32(Request.Form["marca"]);
                    veiculo.Ativo = Convert.ToBoolean(Request.Form["ckAtivo"]);
                    veiculo.Destaque = Convert.ToBoolean(Request.Form["ckDestaque"]);
                    veiculo.ExibeValor = model.ExibeValor;
                    veiculo.Combustivel.IdCombustivel = Convert.ToInt32(Request.Form["combustivel"]);

                    veiculoDal.Salvar(veiculo);

                    int id = veiculo.IdVeiculo;
                    if (model.IdVeiculo == 0)
                        return RedirectToAction("uploadgaleria/" + id);

                    else
                    {
                        TempData["Mensagem"] = "Veiculo " + model.Modelo + " Editado com sucesso.";
                        return RedirectToAction("index", new { pagina = model.Pagina });
                    }

                    return RedirectToAction("index");
                }
                CarregarDropDowns();
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion



        #region Editar

        public ActionResult Editar(int id, int p)
        {
            try
            {
                Diretorios();
                ViewBag.Arquivos = arquivoDal.ListarArquivosByIdVeiculo(id);

                var veiculo = veiculoDal.ListarById(id, null);
                VeiculoVM model = new VeiculoVM();

                model.IdVeiculo = veiculo.IdVeiculo;
                model.Modelo = veiculo.Modelo;
                model.Descricao = veiculo.Descricao;
                model.Ativo = veiculo.Ativo;
                model.Destaque = veiculo.Destaque;
                model.AnoFabricacao = veiculo.AnoFabricacao;
                model.AnoModelo = veiculo.AnoModelo;
                model.Valor = veiculo.Valor;
                model.IdCombustivel = veiculo.Combustivel.IdCombustivel;
                model.IdTipo = veiculo.Marca.Tipo.IdTipo;
                model.IdMarca = veiculo.Marca.IdMarca;
                model.DataCadastro = veiculo.DataCadastro;
                model.ExibeValor = veiculo.ExibeValor;
                model.QtdAcesso = veiculo.QtdAcesso;


                if (p > 0)
                    model.Pagina = p;

                CarregarDropDowns();

                ViewBag.Marcas = marcaDal.ListarByIdTipo(model.IdTipo).OrderBy(m => m.Nome);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion


        #region Excluir
        public JsonResult Excluir(int id)
        {
            try
            {
                List<Arquivo> lista = new List<Arquivo>();

                lista = arquivoDal.ListarArquivosByIdVeiculo(id);
                foreach (var item in lista)
                {
                    AcessoPastaArquivos(item.Nome);
                }

                veiculoDal.Excluir(id);
                TempData["Mensagem"] = "Veiculo EXCLUIDO com sucesso!";
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "Ocorreu um erro ao EXCLUIR!";
                return Json(false);
            }
        }


        public ActionResult ExcluirArquivo(int id, string nome, int idVeiculo, int pg)
        {
            try
            {
                AcessoPastaArquivos(nome);

                arquivoDal.Excluir(id);

                return RedirectToAction("editar", new { id = idVeiculo, p = pg });
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion


        #region Upload

        public ActionResult UploadGaleria(int id)
        {
            try
            {
                Aviso();
                VeiculoVM model = new VeiculoVM();
                model.IdVeiculo = id;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Upload(int id)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["myfile"];
                string nome = Guid.NewGuid().ToString() + ".jpg";
                int tamanho = file.ContentLength;
                string nomeAnterior = file.FileName;
                int idVeiculo = id;
                string extensao = Path.GetExtension(file.FileName);

                extensao = extensao.ToLower();

                if (extensao.Equals(".jpg") || extensao.Equals(".jpeg") || extensao.Equals(".gif") || extensao.Equals(".png"))
                {
                    if (file.ContentLength <= Math.Pow(1024, 2) * 2)
                    {
                        Arquivo a = new Arquivo
                        {
                            Nome = nome,
                            NomeAnterior = nomeAnterior,
                            Tamanho = tamanho,
                            DataCadastro = DateTime.Now,
                            IdVeiculo = idVeiculo
                        };

                        arquivoDal.Inserir(a);

                        //file.SaveAs(Server.MapPath("~/") + "arquivos/normais/" + nome);
                        file.SaveAs(Server.MapPath(arquivosNormais) + nome);

                        RedimensionarImagens(nome, 600, 400, "arquivos\\redimensionados\\");
                        RedimensionarImagens(nome, 300, 200, "arquivos\\miniaturas\\");
                        ExcluiArquivosNormais(nome);
                    }
                    else
                    {
                        TempData["Mensagem"] = "Sua imagem ultrapassou o limite de 2 MB suportado pelo sistema.<br /> Referente ao VEÍCULO <label class='label label-danger'>" + idVeiculo + "</label>";
                        return Json(false);
                    }
                }
                else
                {
                    TempData["Mensagem"] = "Algum arquivo não foi gravado com sucesso.<br /> Verifique se o mesmo possui as extenções de imagem (.jpeg, .png, .jpg ou .gif) que são suportadas pelo sistema.<br />Referente ao VEÍCULO <label class='label label-danger'>ID " + idVeiculo + "</label>";
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


        #region metodos
        public JsonResult ListMarca(int tipo)
        {
            try
            {
                return Json(marcaDal.ListarByIdTipo(tipo).OrderBy(x => x.Nome), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public JsonResult ListAnoMax(int anoMin)
        {
            try
            {
                return Json(anoModeloDal.ListarAno1(anoMin), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        public void RedimensionarImagens(string nome, int width, int height, string caminho)
        {
            Size tamanhos = new Size();
            tamanhos.Height = height;// 400;
            tamanhos.Width = width;//600;
            string filePath = Server.MapPath(arquivosNormais) + nome;
            // string filePath = Server.MapPath(arquivosRedimencionados.ToString()) + nome; // descomentar para o metoddo robo

            Bitmap b = Util.GetResizedImage(filePath, tamanhos.Width, tamanhos.Height);
            System.Drawing.Image resizedimg2 = (System.Drawing.Image)b;
            //string imageSavePath = arquivosRedimencionados;
            string imageSavePath = caminho; //"arquivos\\redimencionados\\"; //funfa            
            string relativePath = imageSavePath + nome;
            resizedimg2.Save(Request.PhysicalApplicationPath + relativePath);//fim

        }
        

       
        public JsonResult RoboRedimensionador()
        {
            try
            {
                var lista = arquivoDal.Listar();
                foreach (var item in lista)
                {
                    RedimensionarImagens(item.Nome, 300, 200, "arquivos\\imoveis\\");
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(false + " " + ex.Message, JsonRequestBehavior.AllowGet);
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

            string targetPathRedimencionados = arquivosRedimencionados;
            //string targetPathRedimencionados = @"~/arquivos/redimencionados/";
            string destFileRedimencionados = Path.Combine(targetPathRedimencionados, fileName);
            System.IO.File.Delete(Server.MapPath(destFileRedimencionados));

            string targetPathMin = arquivosMin;
            //string targetPathRedimencionados = @"~/arquivos/redimencionados/";
            string destFileMin = Path.Combine(targetPathMin, fileName);
            System.IO.File.Delete(Server.MapPath(destFileMin));

        }
        //public void AcessoPastaArquivos(string nome)
        //{
        //    //AcessoPastaArquivos para exclusao dos mesmos na pasta
        //    string fileName = nome;
        //    //string targetPath = @"~/arquivos/normais/";
        //    string targetPath = arquivosNormais;
        //    string destFile = Path.Combine(targetPath, fileName);
        //    System.IO.File.Delete(Server.MapPath(destFile));

        //    string targetPathRedimencionados = arquivosRedimencionados;
        //    //string targetPathRedimencionados = @"~/arquivos/redimencionados/";
        //    string destFileRedimencionados = Path.Combine(targetPathRedimencionados, fileName);
        //    System.IO.File.Delete(Server.MapPath(destFileRedimencionados));

        //    string targetPathMin = arquivosMin;
        //    //string targetPathRedimencionados = @"~/arquivos/redimencionados/";
        //    string destFileMin = Path.Combine(targetPathMin, fileName);
        //    System.IO.File.Delete(Server.MapPath(destFileMin));

        //}

        public void ExcluiArquivosNormais(string nome)
        {
            //AcessoPastaArquivos para exclusao dos mesmos na pasta
            string fileName = nome;
            //string targetPath = Diretorio.ArquivoNormais;
            string targetPath = arquivosNormais.ToString();
            string destFile = Path.Combine(targetPath, fileName);
            System.IO.File.Delete(Server.MapPath(destFile));
        }
        public void CarregarDropDowns()
        {
            ViewBag.Combustivel = combustivelDal.Listar().OrderBy(x => x.Nome);
            ViewBag.Tipo = tipoDal.Listar().OrderBy(x => x.Nome);
            ViewBag.Ano = anoModeloDal.ListarAno2();
            ViewBag.AnoFabricacao = AnoModeloDal.ListarAnoFabricacao();
        }

        #endregion
    }
}
