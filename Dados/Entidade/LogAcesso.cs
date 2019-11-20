using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Entidade
{
    public class LogAcesso
    {
        public int Id { get; set; }
        public string NomeMaquina { get; set; }
        public DateTime DataDeAcesso { get; set; }
        public string Pagina { get; set; }
        public int Quantidade { get; set; }
    }
}
