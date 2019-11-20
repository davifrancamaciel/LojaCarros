using Logica.Contexto;
using Dados.Entidade;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Logica.Repositorio
{
    public class MarcaDal : Conexao
    {
        private void Inserir(Marca m)
        {
            try
            {
                var strQuery = "INSERT INTO Marca";
                strQuery += "(Nome, IdTipo, DataCadastro) ";
                strQuery += "VALUES(@p1, @p2,NOW())";

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", m.Nome);
                Cmd.Parameters.AddWithValue("@p2", m.Tipo.IdTipo);

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

        public void Salvar(Marca m)
        {
            if (m.IdMarca > 0)
                Alterar(m);
            else
                Inserir(m);
        }

        private void Alterar(Marca m)
        {
            try
            {
                var strQuery = "UPDATE Marca SET ";
                strQuery += "Nome = @p1, IdTipo = @p2 ";
                strQuery += string.Format("WHERE IdMarca = {0} ", m.IdMarca);
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", m.Nome);
                Cmd.Parameters.AddWithValue("@p2", m.Tipo.IdTipo);
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
        public List<Marca> Listar(int? idMarca)
        {
            try
            {
                AbrirConexao();
                var strQuery = "procMarcaSELECT";

                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.StoredProcedure,
                    Connection = minhaConexao
                };

                Cmd.Parameters.AddWithValue("idMarca", idMarca);


                Dr = Cmd.ExecuteReader();

                List<Marca> lista = new List<Marca>();
                while (Dr.Read())
                {
                    Marca marca = new Marca();
                    marca.Tipo = new Tipo();

                    marca.IdMarca = Convert.ToInt32(Dr["IdMarca"]);
                    marca.Nome = Convert.ToString(Dr["Nome"]).ToUpper();
                    marca.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                    marca.Tipo.Nome = Convert.ToString(Dr["NomeTipo"]).ToUpper();
                    marca.Tipo.IdTipo = Convert.ToInt32(Dr["IdTipo"]);
                    lista.Add(marca);
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
        //     SELECT COUNT(IdVeiculo) AS QtdVeiculo ,M.Nome
        //FROM Marca AS M
        //INNER JOIN Veiculo AS V ON M.IdMarca = V.IdMarca
        //WHERE V.Ativo = 1
        //GROUP BY M.IdMarca
        public List<Marca> ListarByTipo(string tipo, bool? ativo)
        {
            try
            {
                AbrirConexao();
                var strQuery = "procMarcaByTipoSELECT";

                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.StoredProcedure,
                    Connection = minhaConexao
                };

                Cmd.Parameters.AddWithValue("idTipo", tipo);
                Cmd.Parameters.AddWithValue("ativo", ativo);

                Dr = Cmd.ExecuteReader();

                List<Marca> lista = new List<Marca>();
                while (Dr.Read())
                {
                    Marca marca = new Marca();
                    marca.Tipo = new Tipo();
                    marca.IdMarca = Convert.ToInt32(Dr["IdMarca"]);
                    marca.Nome = Convert.ToString(Dr["Nome"]).ToUpper();
                    marca.QtdVeiculo = Convert.ToInt32(Dr["QtdVeiculo"]);
                    marca.Tipo.Nome = Convert.ToString(Dr["TipoNome"]);

                    lista.Add(marca);
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
        public List<Marca> ListarByIdTipo(int? IdTipo)
        {
            try
            {
                AbrirConexao();

                var strQuery = "procMarcaByIdTipoSELECT";

                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.StoredProcedure,
                    Connection = minhaConexao
                };

                Cmd.Parameters.AddWithValue("idTipo", IdTipo);

                Dr = Cmd.ExecuteReader();

                List<Marca> lista = new List<Marca>();
                while (Dr.Read())
                {
                    Marca marca = new Marca();
                    marca.IdMarca = Convert.ToInt32(Dr["IdMarca"]);
                    marca.Nome = Convert.ToString(Dr["Nome"]).ToUpper();

                    lista.Add(marca);
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
                var strQuery = string.Format("DELETE FROM Marca WHERE IdMarca = {0}", id);
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
