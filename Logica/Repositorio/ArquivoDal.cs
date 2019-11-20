using System;
using System.Collections.Generic;
using Dados.Entidade;
using Logica.Contexto;
using MySql.Data.MySqlClient;

namespace Logica.Repositorio
{
    public class ArquivoDal : Conexao
    {

        public void Inserir(Arquivo a)
        {
            try
            {
                var strQuery = "INSERT INTO Arquivo(Nome,NomeAnterior,Tamanho,DataCadastro,IdVeiculo) ";
                strQuery += "VALUES(@p1,@p2,@p3,@p4,@p5)";
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", a.Nome);
                Cmd.Parameters.AddWithValue("@p2", a.NomeAnterior);
                Cmd.Parameters.AddWithValue("@p3", a.Tamanho);
                Cmd.Parameters.AddWithValue("@p4", a.DataCadastro);
                Cmd.Parameters.AddWithValue("@p5", a.IdVeiculo);
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

        public  void up(Arquivo a)
        {
            try
            {
                var strQuery = "update  images_imovel set nome = @p1";
                
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", a.Nome);
                
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
        /// lista todos arquivos por id do tipo e usado pelo modal que exibe as fotos em tamanho maior
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Arquivo> ListarArquivosByIdVeiculo(int id)
        {
            try
            {
                var strQuery = "SELECT * FROM Arquivo AS A ";
                strQuery += "INNER JOIN Veiculo AS V ON A.IdVeiculo = V.IdVeiculo ";
                strQuery += string.Format("WHERE A.IdVeiculo = {0} ", id);


                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();
                List<Arquivo> lista = new List<Arquivo>();
                while (Dr.Read())
                {
                    Arquivo arquivo = new Arquivo();
                    arquivo.IdArquivo = Convert.ToInt32(Dr["IdArquivo"]);
                    arquivo.Nome = Convert.ToString(Dr["Nome"]);
                    arquivo.NomeAnterior = Convert.ToString(Dr["NomeAnterior"]);
                    arquivo.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                    arquivo.Tamanho = Convert.ToInt32(Dr["Tamanho"]);
                    arquivo.IdVeiculo = Convert.ToInt32(Dr["IdVeiculo"]);

                    lista.Add(arquivo);
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

        //public List<Arquivo> Listar()
        //{
        //    try
        //    {
        //        var strQuery = "SELECT * FROM Arquivo ";


        //        AbrirConexao();
        //        Cmd = new MySqlCommand(strQuery, minhaConexao);
        //        Dr = Cmd.ExecuteReader();
        //        List<Arquivo> lista = new List<Arquivo>();
        //        while (Dr.Read())
        //        {
        //            Arquivo arquivo = new Arquivo();
        //            arquivo.IdArquivo = Convert.ToInt32(Dr["IdArquivo"]);
        //            arquivo.Nome = Convert.ToString(Dr["Nome"]);
        //            arquivo.NomeAnterior = Convert.ToString(Dr["NomeAnterior"]);
        //            arquivo.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
        //            arquivo.Tamanho = Convert.ToInt32(Dr["Tamanho"]);
        //            arquivo.IdVeiculo = Convert.ToInt32(Dr["IdVeiculo"]);

        //            lista.Add(arquivo);
        //        }

        //        return lista;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        FecharConexao();
        //    }

        //}

        public List<Arquivo> Listar()
        {
            try
            {
                var strQuery = "SELECT * FROM images_imovel ";


                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();
                List<Arquivo> lista = new List<Arquivo>();
                while (Dr.Read())
                {
                    Arquivo arquivo = new Arquivo();
                    arquivo.IdArquivo = Convert.ToInt32(Dr["id"]);
                    arquivo.Nome = Convert.ToString(Dr["nome"]);
                    arquivo.NomeAnterior = Convert.ToString(Dr["nome"]);
                    arquivo.DataCadastro = Convert.ToDateTime(Dr["created_at"]);
                    arquivo.Tamanho = Convert.ToInt32(Dr["imovel_id"]);
                    arquivo.IdVeiculo = Convert.ToInt32(Dr["imovel_id"]);

                    lista.Add(arquivo);
                }

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

        /// <summary>
        /// lista todos arquivos por id do tipo e usado pelo modal que exibe as fotos em tamanho maior
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Arquivo> ListarPorId(int id, int idArquivo)
        {



            // ainda nao pode ser excluido pois esta sendo usado pelo metodo de exibir fotos do modal 
            try
            {
                var strQuery = "SELECT * FROM Arquivo AS A ";
                strQuery += "INNER JOIN Tipo AS T ON A.IdTipo = T.IdTipo ";
                strQuery += string.Format("WHERE A.IdTipo = {0} ", id);
                strQuery += string.Format("ORDER BY A.IdArquivo = {0} DESC", idArquivo);
                AbrirConexao();

                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();

                List<Arquivo> lista = new List<Arquivo>();
                while (Dr.Read())
                {
                    Arquivo arquivo = new Arquivo();
                    arquivo.IdArquivo = Convert.ToInt32(Dr["IdArquivo"]);
                    arquivo.Nome = Convert.ToString(Dr["Nome"]);
                    arquivo.NomeAnterior = Convert.ToString(Dr["NomeAnterior"]);
                    arquivo.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                    arquivo.Tamanho = Convert.ToInt32(Dr["Tamanho"]);
                    arquivo.IdVeiculo = Convert.ToInt32(Dr["IdTipo"]);

                    lista.Add(arquivo);
                }

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
                var strQuery = string.Format("DELETE FROM Arquivo WHERE IdArquivo = {0}", id);

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
