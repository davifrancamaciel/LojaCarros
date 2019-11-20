using Dados.Entidade;
using Logica.Repositorio;
using Site.Areas.Admin.Controllers;
using Site.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                //BannerDal d = new BannerDal();
                //List<Banner> banners = d.Listar(true);
               
                Helpers.RegistraLogDeAcesso("HOME");
               
                //string versao_frame;
                //int arq_bits;
                //arq_bits = IntPtr.Size * 8;
                //versao_frame = Environment.Version.ToString();

                //ViewBag.Mensagem = "Sua hospedagem está configurada em: " + arq_bits + " bits" + "Sua hospedagem está configurada para utilizar o framework: " + versao_frame;

                Diretorios();
                TipoDal td = new TipoDal();
                ViewBag.Tipo = td.Listar();
                MarcaDal mdc = new MarcaDal();
                ViewBag.MarcaCarro = mdc.ListarByTipo("carro", true);
                MarcaDal mdm = new MarcaDal();
                ViewBag.MarcaMoto = mdm.ListarByTipo("moto", true);

                Random rnd = new Random();
                VeiculoDal vd = new VeiculoDal();
                IOrderedEnumerable<Veiculo> Items = vd.Listar(null, true).AsEnumerable().OrderBy((i => rnd.Next()));
                //List<Veiculo> Itens2 = new List<Veiculo>();
                //Itens2 = vd.Listar(null, true);
                ViewBag.Popular = Items.Where(x => x.Arquivo.Nome != "_semfoto.jpg").Where(x => x.Destaque == true).Take(4);

                //return View(banners);
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Sobre()
        {
            Helpers.RegistraLogDeAcesso("SOBRE");
            return View();
        }

    }
}