using Logica.Contexto;
using Dados.Entidade;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Logica.Repositorio
{
    public class BannerDal : Conexao
    {
        private void Inserir(Banner b)
        {
            try
            {
                var strQuery = "INSERT INTO Banner";
                strQuery += "(Nome, DataInicio, DataFim, Ativo, NomeAnterior, Tamanho, DataCadastro) ";
                strQuery += "VALUES(@p1, @p2, @p3, @p4, @p5, @p6, NOW())";

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", b.Nome);
                Cmd.Parameters.AddWithValue("@p2", b.DataInicio);
                Cmd.Parameters.AddWithValue("@p3", b.DataFim);
                Cmd.Parameters.AddWithValue("@p4", b.Ativo);
                Cmd.Parameters.AddWithValue("@p5", b.NomeAnterior);
                Cmd.Parameters.AddWithValue("@p6", b.Tamanho);


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

        public void Salvar(Banner b)
        {
            if (b.Id > 0)
                Alterar(b);
            else
                Inserir(b);
        }

        private void Alterar(Banner b)
        {
            try
            {
                var strQuery = "UPDATE Banner SET ";
                strQuery += "Nome = @p1, DataInicio = @p2, ";
                strQuery += "DataFim = @p3, Ativo = @p4, ";
                strQuery += "NomeAnterior = @p5, Tamanho = @p6 ";
                strQuery += string.Format("WHERE Id = {0} ", b.Id);
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", b.Nome);
                Cmd.Parameters.AddWithValue("@p2", b.DataInicio);
                Cmd.Parameters.AddWithValue("@p3", b.DataFim);
                Cmd.Parameters.AddWithValue("@p4", b.Ativo);
                Cmd.Parameters.AddWithValue("@p5", b.NomeAnterior);
                Cmd.Parameters.AddWithValue("@p6", b.Tamanho);
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

        public List<Banner> Listar(bool somenteAtivos)
        {
            return Listar(null, somenteAtivos);
        }
        public List<Banner> Listar(int? id, bool somenteAtivos)
        {
            try
            {
                AbrirConexao();
                var strQuery = "SELECT * FROM Banner ";

                if (somenteAtivos)
                {
                    strQuery += "WHERE DataInicio <= @p1 AND DataFim >= @p1 AND Ativo = 1";
                }

                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = minhaConexao
                };
                Cmd.Parameters.AddWithValue("@p1", DateTime.Now);



                Dr = Cmd.ExecuteReader();

                List<Banner> lista = new List<Banner>();
                while (Dr.Read())
                {
                    Banner banner = new Banner();


                    banner.Id = Convert.ToInt32(Dr["Id"]);
                    banner.Nome = Convert.ToString(Dr["Nome"]);
                    banner.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                    banner.DataInicio = Convert.ToDateTime(Dr["DataInicio"]);
                    banner.DataFim = Convert.ToDateTime(Dr["DataFim"]);
                    banner.Ativo = Convert.ToBoolean(Dr["Ativo"]);
                    banner.Tamanho = Convert.ToInt32(Dr["Tamanho"]);
                    banner.NomeAnterior = Convert.ToString(Dr["NomeAnterior"]);

                    lista.Add(banner);
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




        public void Excluir(int id)
        {
            try
            {
                AbrirConexao();
                var strQuery = string.Format("DELETE FROM Banner WHERE Id = {0}", id);
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
