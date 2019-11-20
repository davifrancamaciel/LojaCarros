
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{

    public class VeiculoVM
    {
        public VeiculoVM()
        {

        }
        public DateTime DataCadastro { get; set; }
        public int Pagina { get; set; }
        public int IdTipo { get; set; }
        public int IdCombustivel { get; set; }
        public int IdMarca { get; set; }
        public Boolean Ativo { get; set; }
        public Boolean Destaque { get; set; }
        [Display(Name = "Exibir Valor?:")]
        public Boolean ExibeValor { get; set; }
        public string NomeDaFotoAnterior { get; set; }
        public int IdVeiculo { get; set; }
        public int QtdAcesso { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo Modelo deve ter no minimo 2 e no maximo 50 caracteres.")]
        [Display(Name = "Modelo:")]
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }


        [Required(ErrorMessage = "O campo Descricao é obrigatório.")]
        [StringLength(3000, MinimumLength = 2, ErrorMessage = "O campo Descricao deve ter no minimo 2 e no maximo 3000 caracteres.")]
        [Display(Name = "Descricao:")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        //[StringLength(150, MinimumLength = 2, ErrorMessage = "O campo Valor deve ter no minimo 2 e no maximo 150 caracteres.")]
        [Range(0, 1000000, ErrorMessage = "O campo Valor deve ser entre R$ 0 e R$ 1000000")]
        [Display(Name = "Valor:")]
        public decimal Valor { get; set; }


    }
    
    public class BuscaModel
    {
        public string Termo { get; set; }
        //public string Tipo { get; set; }
        //public string Marca { get; set; }
        //public int? AnoInicio { get; set; }
        //public int? AnoFim { get; set; }

    }

    public class BuscaFilroVM
    {
        public string IdTipo { get; set; }
        public string IdMarca { get; set; }
        public string AnoInicio { get; set; }
        public string AnoFim { get; set; }

    }
    
    public class OrcamentoVM
    {

        public int IdOrcamento { get; set; }

        public Boolean Concluido { get; set; }

        [Display(Name = "Data de cadastro do orçamento:")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório.")]
        [StringLength(4000, MinimumLength = 2, ErrorMessage = "O Descricao deve ter no minimo 2 e no maximo 4000 caracteres.")]
        [Display(Name = "Descricao:")]
        public string Descricao { get; set; }

        [StringLength(4000, ErrorMessage = "O Observacao deve ter no maximo 4000 caracteres.")]
        [Display(Name = "Observacao:")]
        public string Observacao { get; set; }

        [StringLength(50, ErrorMessage = "O Observacao deve ter no maximo 50 caracteres.")]
        [Display(Name = "Ambiente:")]
        public string Ambiente { get; set; }
        public int IdCliente { get; set; }

        public ClienteVM Cliente { get; set; }
    }
}