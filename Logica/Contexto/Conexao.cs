using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Logica.Contexto
{
    public class Conexao
    {
        protected MySqlConnection minhaConexao;
        protected MySqlCommand Cmd;
        protected MySqlDataReader Dr;
        protected MySqlTransaction Tr;

        protected void AbrirConexao()
        {
            try
            {
                minhaConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
                minhaConexao.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void FecharConexao()
        {
            try
            {
                minhaConexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
