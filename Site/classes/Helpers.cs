using Dados.Entidade;
using Logica.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Site.classes
{
    public class Helpers
    {
        public static void RegistraLogDeAcesso(string pagina)
        {
            
            LogAcesso log = new LogAcesso();
            
            log.NomeMaquina = Environment.MachineName;

            log.Pagina = pagina;
            log.Quantidade = 1;
            LogAcessoDal d = new LogAcessoDal();
            d.Inserir(log);
        }
    }
}