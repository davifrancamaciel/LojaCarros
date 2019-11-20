using Logica.Contexto;
using Dados.Entidade;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Logica.Repositorio
{
    public class CombustivelDal : Conexao
    {
        public List<Combustivel> Listar()
        {
            try
            {
                AbrirConexao();

                var strQuery = "SELECT * FROM Combustivel";
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();


                List<Combustivel> lista = new List<Combustivel>();
                while (Dr.Read())
                {
                    Combustivel c = new Combustivel();
                    c.IdCombustivel = Convert.ToInt32(Dr["IdCombustivel"]);
                    c.Nome = Convert.ToString(Dr["Nome"]).ToUpper();

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
    }
}
