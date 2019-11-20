using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Entidade
{
   public class Banner
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string NomeAnterior { get; set; }
        public int Tamanho { get; set; }
    }
}
