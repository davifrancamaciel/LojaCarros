using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Entidade
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nome { get; set; }
        public Tipo Tipo { get; set; }
        public int QtdVeiculo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
