using Dados.Entidade;
using Logica.Contexto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Repositorio
{
    public class LogAcessoDal : Conexao
    {
        public void Inserir(LogAcesso log)
        {
            try
            {
                var strQuery = "INSERT INTO LogAcesso";
                strQuery += "(NomeMaquina, DataDeAcesso, Quantidade, Pagina) ";
                strQuery += "VALUES(@p1,NOW(),@p2,@p3)";

                AbrirConexao();
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Cmd.Parameters.AddWithValue("@p1", log.NomeMaquina);
                Cmd.Parameters.AddWithValue("@p2", log.Quantidade);
                Cmd.Parameters.AddWithValue("@p3", log.Pagina);
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

        //private void Alterar(LogAcesso l)
        //{
        //    try
        //    {
        //        var strQuery = "UPDATE LogAcesso SET ";
        //        strQuery += "Nome = @p1, IdTipo = @p2 ";
        //        strQuery += string.Format("WHERE IdMarca = {0} ", l.IdMarca);
        //        AbrirConexao();
        //        Cmd = new MySqlCommand(strQuery, minhaConexao);
        //        Cmd.Parameters.AddWithValue("@p1", l.Nome);
        //        Cmd.Parameters.AddWithValue("@p2", l.Quantidade);
        //        Cmd.ExecuteNonQuery();

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
        public LogAcesso Listar(string pagina, string dataInicio, string dataFim)
        {
            try
            {
                AbrirConexao();
                var strQuery = "select COUNT(a.Id) as Total from LogAcesso as a where ";
                strQuery += "a.DataDeAcesso BETWEEN '" + dataInicio + "' and '" + dataFim + "' and a.Pagina = '" + pagina + "'";
                Cmd = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = minhaConexao
                };
                Dr = Cmd.ExecuteReader();
                LogAcesso log = new LogAcesso();
                while (Dr.Read())
                {
                    log.Quantidade = Convert.ToInt32(Dr["Total"]);
                }
                
                return log;

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
