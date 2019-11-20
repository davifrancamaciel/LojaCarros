using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dados.Entidade;
using Logica.Contexto;
using Dados.DTO;

namespace Logica.Repositorio
{
    public class UsuarioDal : Conexao
    {


        private void Inserir(Usuario u)
        {
            try
            {
                var strQuery = "INSERT INTO Usuario";
                strQuery += "(Email, Senha) ";
                strQuery += "VALUES(@p1, @p2)";

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", u.Email);
                Cmd.Parameters.AddWithValue("@p2", u.Senha);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Salvar(Usuario u)
        {
            if (u.IdUsuario > 0)
                AlterarSenha(u);
            else
                Inserir(u);
        }

        private void AlterarSenha(Usuario u)
        {
            try
            {
                var strQuery = "UPDATE Usuario SET ";
                strQuery += "Senha = @p1 ";
                strQuery += string.Format("WHERE IdUsuario = {0} ", u.IdUsuario);
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", u.Senha);
                Cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int idUsuario)
        {
            try
            {
                AbrirConexao();
                var strQuery = string.Format("DELETE FROM Usuario WHERE IdUsuario = {0}", idUsuario);
                // ver se funciona de fora                
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }

        }

        public List<Usuario> Listar()
        {// lista todos usuarios da base de dados
            try
            {
                var strQuery = "SELECT IdUsuario, Email FROM Usuario WHERE Email <> 'davi' ORDER BY Email ASC";
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);

                Dr = Cmd.ExecuteReader();
                List<Usuario> lista = new List<Usuario>();
                while (Dr.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = Convert.ToInt32(Dr["IdUsuario"]);
                    usuario.Email = Convert.ToString(Dr["Email"]);
                    lista.Add(usuario);
                }
                Dr.Close();
                Dr.Dispose();
                return lista;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }

        }

        public bool Existe(string Email)
        {// verifica se existe antes de alterar senha enviar emaiil etc
            try
            {
                AbrirConexao();
                var strQuery = string.Format("SELECT Email FROM Usuario WHERE Email = '{0}'", Email);
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    Dr.Close();
                    Dr.Dispose();
                    return true;
                }
                else { return false; }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool VerificarSenhaAtual(string senha, int idUsuario)
        {//VerificarSenhaAtual antes de trocar pela nova
            try
            {
                AbrirConexao();
                var strQuery = "SELECT IdUsuario, Senha FROM Usuario WHERE Senha = @p1 AND IdUsuario = @p2";
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", senha);
                Cmd.Parameters.AddWithValue("@p2", idUsuario);
                Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    //Dr.Close();
                    //Dr.Dispose();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public UsuarioDTO Altenticar(string email, string senha)
        {
            try
            {
                var strQuery = string.Format("SELECT IdUsuario, Email, Senha FROM Usuario WHERE Email = '{0}' AND Senha = '{1}'", email, senha);
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();

                UsuarioDTO dto = null;
                if (Dr.Read())
                {
                    dto = new UsuarioDTO();
                    dto.Email = Convert.ToString(Dr["Email"]);
                    dto.IdUsuario = Convert.ToInt32(Dr["IdUsuario"]);

                }
                Dr.Close();
                Dr.Dispose();
                return dto;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public Usuario ListarPorId(int id)
        {// lista todos usuarios da base de dados
            try
            {

                AbrirConexao();

                var strQuery = "SELECT ";
                strQuery += "IdUsuario, Email ";
                strQuery += "FROM Usuario ";
                strQuery += string.Format("WHERE IdUsuario = {0}", id);

                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();
                Usuario usuario = new Usuario();
                while (Dr.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(Dr["IdUsuario"]);
                    usuario.Email = Convert.ToString(Dr["Email"]);
                }
                Dr.Close();
                Dr.Dispose();
                return usuario;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }




        #region Metodo Alterar no momento nao esta sendo usado

        //private void Alterar(Usuario u)
        //{
        //    try
        //    {
        //        var strQuery = "UPDATE Usuario SET ";
        //        strQuery += "Email = @p1, Nome = @p2, IdConta = @p3 ,CEP = @p4 ,Logradouro = @p5, ";
        //        strQuery += "Cidade = @p6, NomeFantasia = @p7, Bairro = @p8 ";
        //        strQuery += string.Format("WHERE IdUsuario = {0} ", u.IdUsuario);

        //        using (contexto = new Contexto())
        //        {
        //            Cmd = new MySqlCommand(strQuery, minhaConexao);
        //            Cmd.Parameters.AddWithValue("@p1", u.Email);
        //            Cmd.Parameters.AddWithValue("@p2", u.Nome);
        //            Cmd.Parameters.AddWithValue("@p4", u.CEP);
        //            Cmd.Parameters.AddWithValue("@p5", u.Logradouro);
        //            Cmd.Parameters.AddWithValue("@p6", u.Cidade);
        //            Cmd.Parameters.AddWithValue("@p7", u.NomeFantasia);
        //            Cmd.Parameters.AddWithValue("@p8", u.Bairro);

        //            Cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //} 
        #endregion
    }
}
