using System;
using System.Collections.Generic;
using Dados.Entidade;
using Logica.Contexto;
using MySql.Data.MySqlClient;

namespace Logica.Repositorio
{
    public class ClienteDal : Conexao
    {

        private void Inserir(Cliente c)
        {
            try
            {
                var strQuery = "INSERT INTO Cliente(Nome, Email, CEP, Logradouro, Bairro, Cidade, Estado, DataCadastro, Telefone1, Telefone2) ";
                strQuery += "VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", c.Nome);
                Cmd.Parameters.AddWithValue("@p2", c.Email);
                Cmd.Parameters.AddWithValue("@p3", c.CEP);
                Cmd.Parameters.AddWithValue("@p4", c.Logradouro);
                Cmd.Parameters.AddWithValue("@p5", c.Bairro);
                Cmd.Parameters.AddWithValue("@p6", c.Cidade);
                Cmd.Parameters.AddWithValue("@p7", c.Estado);
                Cmd.Parameters.AddWithValue("@p8", c.DataCadastro);
                Cmd.Parameters.AddWithValue("@p9", c.Telefone1);
                Cmd.Parameters.AddWithValue("@p10", c.Telefone2);
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

        public void Salvar(Cliente cliente)
        {
            if (cliente.IdCliente > 0)
                Alterar(cliente);
            else
                Inserir(cliente);
        }

        private void Alterar(Cliente c)
        {
            try
            {
                var strQuery = "UPDATE Cliente SET ";
                strQuery += "Nome = @p1, Email = @p2, CEP = @p3 ,Logradouro = @p4 ,Bairro = @p5, ";
                strQuery += "Cidade = @p6, Estado = @p7, Telefone1 = @p8,Telefone2 = @p9 ";
                strQuery += string.Format("WHERE IdCliente = {0}", c.IdCliente);

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", c.Nome);
                Cmd.Parameters.AddWithValue("@p2", c.Email);
                Cmd.Parameters.AddWithValue("@p3", c.CEP);
                Cmd.Parameters.AddWithValue("@p4", c.Logradouro);
                Cmd.Parameters.AddWithValue("@p5", c.Bairro);
                Cmd.Parameters.AddWithValue("@p6", c.Cidade);
                Cmd.Parameters.AddWithValue("@p7", c.Estado);
                Cmd.Parameters.AddWithValue("@p8", c.Telefone1);
                Cmd.Parameters.AddWithValue("@p9", c.Telefone2);
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

        /// <summary>
        /// lista os todos os servicos ativos na pagina de servicos listar servicos do administrador
        /// </summary>
        /// <returns></returns>
        public List<Cliente> Listar(string nome)
        {
            try
            {
                var strQuery = "SELECT ";
                strQuery += "IdCliente, Nome, Email, Telefone1, DataCadastro ";
                strQuery += "FROM Cliente ";
                strQuery += string.Format("WHERE Nome LIKE '{0}' ", "%" + nome + "%");
                strQuery += "ORDER BY Nome ASC";
                AbrirConexao();

                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();
                while (Dr.Read())
                {
                    Cliente c = new Cliente();
                    

                    c.IdCliente = Convert.ToInt32(Dr["IdCliente"]);
                    c.Nome = Convert.ToString(Dr["Nome"]);
                    c.Email = Convert.ToString(Dr["Email"]);
                    c.Telefone1 = Convert.ToString(Dr["Telefone1"]);
                    c.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                    lista.Add(c);
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


        public Cliente ListarPorId(int id)
        {
            try
            {
                var strQuery = "SELECT ";
                strQuery += "IdCliente, Nome, Email, CEP, Logradouro, Cidade, Bairro, C.Estado, Telefone1, Telefone2, DataCadastro  ";
                strQuery += "FROM Cliente AS C ";
                strQuery += string.Format("WHERE IdCliente = {0}", id);
                AbrirConexao();

                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();

                Cliente cliente = new Cliente();

                while (Dr.Read())
                {
                    

                    cliente.IdCliente = Convert.ToInt32(Dr["IdCliente"]);
                    cliente.Nome = Convert.ToString(Dr["Nome"]);
                    cliente.Email = Convert.ToString(Dr["Email"]);
                    cliente.CEP = Convert.ToString(Dr["CEP"]);
                    cliente.Logradouro = Convert.ToString(Dr["Logradouro"]);
                    cliente.Bairro = Convert.ToString(Dr["Bairro"]);
                    cliente.Cidade = Convert.ToString(Dr["Cidade"]);
                    cliente.Estado = Convert.ToString(Dr["Estado"]);
                    cliente.Telefone1 = Convert.ToString(Dr["Telefone1"]);
                    cliente.Telefone2 = Convert.ToString(Dr["Telefone2"]);
                    cliente.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);

                }
                Dr.Close();
                Dr.Dispose();
                return cliente;

            }
            catch (Exception)
            { throw; }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                AbrirConexao();
                var strQuery = string.Format("DELETE FROM Cliente WHERE IdCliente = {0}", id);
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
    }
}
