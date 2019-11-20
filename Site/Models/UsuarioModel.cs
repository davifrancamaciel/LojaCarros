using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class UsuarioModelCadastro
    {
        public UsuarioModelCadastro()
        {
            
        }
       
        
        

        public int IdUsuario { get; set; }

        //[Required(ErrorMessage = "O campo Termo de Uso é obrigatório.")]
        //[Display(Name = "Aceito os termos de uso:")]
        //public bool TermoUso { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "Somente até 150 caracteres.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório.")]
        [StringLength(65, ErrorMessage = "Somente até 65 caracteres.")]
        [Display(Name = "Nome Fantasia:")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail incorreto")]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "preencha um e-mail válido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "O campo Confirme sua Senha é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Confirme sua Senha:")]
        public string SenhaConf { get; set; }


        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [StringLength(9, ErrorMessage = "Somente até 9 caracteres. Ex.: 25601-234")]
        [Display(Name = "CEP:")]
        public string CEP { get; set; }


        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        [StringLength(200, ErrorMessage = "Somente até 200 caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "Somente até 50 caracteres.")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }

        //[Required(ErrorMessage = "O campo Email é obrigatório.")]
        //[Phone]
        //[Display(Name = "Telefone:")]
        //public string Telefone { get; set; }
    }
    
    public class UsuarioModelEditar
    {

        public int IdUsuario { get; set; }

        public string NomeDaFotoAnterior { get; set; }
        //public FotoVM Foto { get; set; }

        [Required(ErrorMessage = "O campo Termo de Uso é obrigatório.")]
        [Display(Name = "Aceito os termos de uso:")]
        public bool TermoUso { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(150, ErrorMessage = "Somente até 150 caracteres.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório.")]
        [StringLength(65, ErrorMessage = "Somente até 65 caracteres.")]
        [Display(Name = "Nome Fantasia:")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail incorreto")]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage="preencha um e-mail válido")]
        public string Email { get; set; }
                

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [StringLength(9, ErrorMessage = "Somente até 9 caracteres. Ex.: 25601-234")]
        [Display(Name = "CEP:")]
        public string CEP { get; set; }


        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(200, ErrorMessage = "Somente até 200 caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }

        //[Required(ErrorMessage = "O campo Email é obrigatório.")]
        //[StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        //[Display(Name = "Telefone:")]
        //public string Telefone { get; set; }
    }
    
    public class UsuarioModelLogin
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }
        public string Url { get; set; }
    }

    public class UsuarioModelCadastroAdminstrador
    {
                
        public int IdUsuario { get; set; }
       
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(40, ErrorMessage = "Somente até 40 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail incorreto")]
        [Display(Name = "Email:")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "O campo Confirme sua Senha é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Confirme sua Senha:")]
        public string SenhaConf { get; set; }

    }

    public class UsuarioModelAlterarSenha
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo Senha atual é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Senha atual:")]
        public string SenhaAtual { get; set; }


        [Required(ErrorMessage = "O campo Nova Senha é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Nova Senha:")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "O campo Confirme sua nova Senha é obrigatório.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Sua senha deve ter no minimo 2 e no maximo 10 caracteres.")]
        [Display(Name = "Confirme sua Senha:")]
        public string SenhaConf { get; set; }
    }

   
}
