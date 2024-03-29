﻿using Site.Areas.Admin.Controllers;
using Site.classes;
using Site.Models;
using System.Web.Mvc;
using Utilidade;

namespace Site.Controllers
{
    public class ContatoController : BaseController
    {


        public ActionResult Index(string assunto)
        {
            Helpers.RegistraLogDeAcesso("CONTATO");
            var model = new ContatoVM();

            if (!string.IsNullOrEmpty(assunto))
                model.Asunto = assunto.ToUpper().Replace("-", " ");

            Aviso();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ContatoVM model)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "contato@enriqueautomoveis.com.br";
                string smtpPassword = "147258mudar";
                string smtpHost = "smtp.enriqueautomoveis.com.br";
                int smtpPort = 587;//gmail a porta é 25

                string emailTo = "contato@enriqueautomoveis.com.br"; // Quando o contato será enviado para o seu e-mail
                string comCopia = "enrique.automoveis@hotmail.com";
                string subject = model.Asunto;
                string body = string.Format("Esta mensagem foi enviada de : <b>{0}</b><br/>Email: {1}<br/><br/>Conteudo: </br>{2}",
                    model.NomeUsuario, model.Email, model.Mensagem);


                EnviarEmail servico = new EnviarEmail();

                bool kq = servico.Enviar(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body, comCopia);


                //if (kq) ModelState.AddModelError("", "Obrigado por entrar em contatato conosco.");
                //else ModelState.AddModelError("", "ocorreu um erro ao enviar mensagem tente novamente");
                if (kq) TempData["Mensagem"] = "Obrigado por entrar em contatato conosco.";
                else TempData["Mensagem"] = "ocorreu um erro ao enviar mensagem tente novamente.";


            }

            ModelState.Clear();
            return RedirectToAction("Index");
        }
    }
}