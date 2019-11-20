using Logica.Contexto;
using Dados.Entidade;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Logica.Repositorio
{
    public class TipoDal : Conexao
    {


        public List<Tipo> Listar()
        {// lista todos usuarios da base de dados
            try
            {
                AbrirConexao();

                var strQuery = "SELECT * FROM Tipo";
                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();
                List<Tipo> lista = new List<Tipo>();
                while (Dr.Read())
                {
                    Tipo tipo = new Tipo();
                    tipo.IdTipo = Convert.ToInt32(Dr["IdTipo"]);
                    tipo.Nome = Convert.ToString(Dr["Nome"]).ToUpper();

                    lista.Add(tipo);
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
