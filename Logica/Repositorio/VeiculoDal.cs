using System;
using System.Collections.Generic;
using Dados.Entidade;
using Logica.Contexto;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace Logica.Repositorio
{
    public class VeiculoDal : Conexao
    {

        private int Inserir(Veiculo veiculo)
        {
            try
            {
                var strQuery = "INSERT INTO Veiculo(Modelo, Descricao, AnoFabricacao, Valor, DataCadastro, Ativo, IdMarca, AnoModelo, Destaque, IdCombustivel, ExibeValor, QtdAcesso) ";
                strQuery += "VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10, @p11, @p12)";
                long ultimoIdServico;
                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", veiculo.Modelo);
                Cmd.Parameters.AddWithValue("@p2", veiculo.Descricao);
                Cmd.Parameters.AddWithValue("@p3", veiculo.AnoFabricacao);
                Cmd.Parameters.AddWithValue("@p4", veiculo.Valor);
                Cmd.Parameters.AddWithValue("@p5", veiculo.DataCadastro);
                Cmd.Parameters.AddWithValue("@p6", veiculo.Ativo);
                Cmd.Parameters.AddWithValue("@p7", veiculo.Marca.IdMarca);
                Cmd.Parameters.AddWithValue("@p8", veiculo.AnoModelo);
                Cmd.Parameters.AddWithValue("@p9", veiculo.Destaque);
                Cmd.Parameters.AddWithValue("@p10", veiculo.Combustivel.IdCombustivel);
                Cmd.Parameters.AddWithValue("@p11", veiculo.ExibeValor);
                Cmd.Parameters.AddWithValue("@p12", veiculo.QtdAcesso);
                Cmd.ExecuteNonQuery();
                ultimoIdServico = Cmd.LastInsertedId;

                return veiculo.IdVeiculo = Convert.ToInt32(ultimoIdServico);

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

        public int Salvar(Veiculo v)
        {
            if (v.IdVeiculo > 0)
                Alterar(v);
            else
                Inserir(v);
            return v.IdVeiculo;
        }

        private int Alterar(Veiculo veiculo)
        {
            try
            {
                //var strQuery = " UPDATE Veiculo SET ";
                //strQuery += "Modelo = @p1, Descricao = @p2, AnoFabricacao = @p3, Valor = @p4, ";
                //strQuery += "Ativo = @p5, IdMarca = @p6, AnoModelo = @p7, ";
                //strQuery += "Destaque = @p8, IdCombustivel = @p9, ";
                //strQuery += "ExibeValor = @p10 ";
                //strQuery += string.Format("WHERE IdVeiculo = {0}", veiculo.IdVeiculo);
                var strQuery = " UPDATE Veiculo SET ";
                strQuery += "Modelo = IFNULL(@p1, Modelo), Descricao = IFNULL(@p2, Descricao), AnoFabricacao = IF(@p3 > 0,@p3, AnoFabricacao), Valor = IF(@p4 > 0,@p4, Valor), ";
                strQuery += "Ativo = IFNULL(@p5, Ativo), IdMarca = IF(@p6 > 0,@p6, IdMarca), AnoModelo = IF(@p7 > 0,@p7, AnoModelo), ";
                strQuery += "Destaque = IFNULL(@p8, Destaque), IdCombustivel = IF(@p9 > 0, @p9, IdCombustivel), ";
                strQuery += "ExibeValor = IFNULL(@p10, ExibeValor), QtdAcesso = IF(@p11 > 0, @p11, QtdAcesso)";
                strQuery += string.Format("WHERE IdVeiculo = {0}", veiculo.IdVeiculo);

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", veiculo.Modelo);
                Cmd.Parameters.AddWithValue("@p2", veiculo.Descricao);
                Cmd.Parameters.AddWithValue("@p3", veiculo.AnoFabricacao);
                Cmd.Parameters.AddWithValue("@p4", veiculo.Valor);
                Cmd.Parameters.AddWithValue("@p5", veiculo.Ativo);
                Cmd.Parameters.AddWithValue("@p6", veiculo.Marca.IdMarca);
                Cmd.Parameters.AddWithValue("@p7", veiculo.AnoModelo);
                Cmd.Parameters.AddWithValue("@p8", veiculo.Destaque);
                Cmd.Parameters.AddWithValue("@p9", veiculo.Combustivel.IdCombustivel);
                Cmd.Parameters.AddWithValue("@p10", veiculo.ExibeValor);
                Cmd.Parameters.AddWithValue("@p11", veiculo.QtdAcesso);

                Cmd.ExecuteNonQuery();


                return veiculo.IdVeiculo;

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

        public List<Veiculo> ListarByFilto(string tipo, string marca, int? anoInicio, int? anoFim)
        {
            try
            {

                var strQuery = "procVeiculoByFiltroSELECT";//(TipoV,MarcaV,anoInicio,anoFim)";

                AbrirConexao();
                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.StoredProcedure,
                    Connection = minhaConexao
                };

                Cmd.Parameters.AddWithValue("TipoV", tipo);
                Cmd.Parameters.AddWithValue("MarcaV", marca);
                Cmd.Parameters.AddWithValue("anoInicio", anoInicio);
                Cmd.Parameters.AddWithValue("anoFim", anoFim);

                Dr = Cmd.ExecuteReader();

                List<Veiculo> lista = new List<Veiculo>();
                while (Dr.Read())
                {
                    Veiculo v = new Veiculo();
                    v.Arquivo = new Arquivo();
                    v.Combustivel = new Combustivel();
                    v.Marca = new Marca();

                    v.IdVeiculo = Convert.ToInt32(Dr["IdVeiculo"]);
                    v.Modelo = Convert.ToString(Dr["Modelo"]);
                    v.ExibeValor = Convert.ToBoolean(Dr["ExibeValor"]);
                    v.AnoFabricacao = Convert.ToInt32(Dr["AnoFabricacao"]);
                    v.AnoModelo = Convert.ToInt32(Dr["AnoModelo"]);
                    v.Valor = Convert.ToDecimal(Dr["Valor"]);
                    v.Combustivel.Nome = Convert.ToString(Dr["CombustivelNome"]);
                    v.Arquivo.Nome = Convert.ToString(Dr["aNome"]);
                    v.Marca.Nome = Convert.ToString(Dr["MarcaNome"]);

                    if (string.IsNullOrEmpty(Convert.ToString(Dr["aNome"])))
                        v.Arquivo.Nome = Convert.ToString("_semfoto.jpg");

                    lista.Add(v);
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

        public List<Veiculo> Listar(int? id, bool? ativo)
        {
            try
            {
                var strQuery = "procVeiculoSELECT";

                AbrirConexao();
                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.StoredProcedure,
                    Connection = minhaConexao
                };

                Cmd.Parameters.AddWithValue("idVeiculo", id);
                Cmd.Parameters.AddWithValue("ativo", ativo);

                Dr = Cmd.ExecuteReader();

                List<Veiculo> lista = new List<Veiculo>();
                while (Dr.Read())
                {
                    Veiculo v = new Veiculo();

                    v.Marca = new Marca();
                    v.Marca.Tipo = new Tipo();
                    v.Arquivo = new Arquivo();
                    v.Combustivel = new Combustivel();


                    v.QtdAcesso = Convert.ToInt32(Dr["QtdAcesso"]);
                    v.IdVeiculo = Convert.ToInt32(Dr["IdVeiculo"]);
                    v.Modelo = Convert.ToString(Dr["Modelo"]);
                    v.Descricao = Convert.ToString(Dr["Descricao"]);
                    v.AnoFabricacao = Convert.ToInt32(Dr["AnoFabricacao"]);
                    v.AnoModelo = Convert.ToInt32(Dr["AnoModelo"]);
                    v.Valor = Convert.ToDecimal(Dr["Valor"]);
                    v.Destaque = Convert.ToBoolean(Dr["Destaque"]);
                    v.Marca.Nome = Convert.ToString(Dr["MarcaNome"]);
                    v.Marca.IdMarca = Convert.ToInt32(Dr["IdMarca"]);
                    v.Arquivo.Nome = Convert.ToString(Dr["aNome"]);
                    v.Destaque = Convert.ToBoolean(Dr["Destaque"]);
                    v.Ativo = Convert.ToBoolean(Dr["Ativo"]);
                    v.ExibeValor = Convert.ToBoolean(Dr["ExibeValor"]);
                    v.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                    v.Combustivel.Nome = Convert.ToString(Dr["CombustivelNome"]);
                    v.Combustivel.IdCombustivel = Convert.ToInt32(Dr["idCombustivel"]);
                    v.Marca.Tipo.IdTipo = Convert.ToInt32(Dr["idTipo"]);
                    if (string.IsNullOrEmpty(Convert.ToString(Dr["aNome"])))
                        v.Arquivo.Nome = Convert.ToString("_semfoto.jpg");



                    lista.Add(v);
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

        public Veiculo ListarById(int? id, bool? ativo)
        {
            try
            {
                return Listar(id, ativo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(int id)
        {
            try
            {
                AbrirConexao();
                var strQuery = string.Format("DELETE FROM Veiculo WHERE IdVeiculo = {0}", id);
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
