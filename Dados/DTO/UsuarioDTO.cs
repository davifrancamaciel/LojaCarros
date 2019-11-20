using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados.DTO
{
    /// <summary>
    /// Classe para manipulacao de dados transferidos como session 
    /// </summary>
    public class UsuarioDTO
    {
        public int IdPerfil { get; set; }
        public string Email { get; set; }
        public int IdUsuario { get; set; }
        public string Senha { get; set; }
    }
}
