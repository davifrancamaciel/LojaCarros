﻿using System;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ErrorsController : Controller
    {
        /// <summary>
        /// Controller que gerencia o tratamento de paginas de erro 
        /// criada em 20-05-2015
        /// </summary>

        public ActionResult Http404(Exception exception)
        {
            Response.StatusCode = 404;
            Response.ContentType = "text/html";
            return View(exception);
        }

        public ActionResult Http500(Exception exception)
        {
            Response.StatusCode = 500;
            Response.ContentType = "text/html";
            return View(exception);
        }

    }
}
