﻿using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    /// <summary>
    /// classe de Modelo para contato
    /// </summary>
    public class ContatoVM
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail incorreto")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Assunto")]
        [Required(ErrorMessage = "O campo Assunto é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        public string Asunto { get; set; }
        
        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "O campo Mensagem é obrigatório.")]        
        [StringLength(500, ErrorMessage = "Somente até 500 caracteres.")]
        [DataType(DataType.MultilineText)]
        public string Mensagem { get; set; }
    }
    public class ContatoSuporteModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail incorreto")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Assunto")]
        // aqui o assunto nao pode ser obrigatorio pois ele é preenchido com o select
        public string Asunto { get; set; }
        
        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "O campo Mensagem é obrigatório.")]
        [StringLength(500, ErrorMessage = "Somente até 500 caracteres.")]
        [DataType(DataType.MultilineText)]
        public string Mensagem { get; set; }
    }
    public class EsqueceuModel
    {
        [Required(ErrorMessage = "O campo Email de usuario é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        public string Email { get; set; }
    }
}