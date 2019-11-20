using Logica.Contexto;
using Dados.Entidade;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Logica.Repositorio
{
    public class AnoModeloDal : Conexao
    {

        public List<AnoModelo> ListarAno(string marca)
        {
            AnoModelo anoMod = new AnoModelo();
            //if (idMarca != null)
            //{
            //idMarca = 0;
            anoMod = ListarAnoByMarca(marca);
            //}

            int datas = Convert.ToInt32(anoMod.AnoFim);
            List<AnoModelo> lista = new List<AnoModelo>();
            for (int i = datas; i >= anoMod.AnoInicio; i--)
            {
                AnoModelo ano = new AnoModelo();
                ano.AnoLista = i;
                lista.Add(ano);
            }

            return lista;
        }
        public AnoModelo ListarAnoByMarca(string marca)
        {
            try
            {
                AbrirConexao();
                //SELECT MIN(AnoFabricacao) AS AnoIncio, MAX(AnoFabricacao) AS AnoFim
                //FROM Veiculo AS V 
                //INNER JOIN Marca AS M ON M.IdMarca = V.IdMarca 
                //WHERE Ativo = 1 AND V.IdMarca = 1 

                var strQuery = "SELECT MIN(AnoFabricacao) AS AnoIncio, MAX(AnoFabricacao) AS AnoFim ";
                strQuery += "FROM Veiculo AS V ";
                strQuery += "INNER JOIN Marca AS M ON M.IdMarca = V.IdMarca ";
                strQuery += string.Format("WHERE Ativo = 1 AND M.Nome = '{0}'", marca);

                Cmd = new MySqlCommand(strQuery, minhaConexao);
                Dr = Cmd.ExecuteReader();


                AnoModelo ano = new AnoModelo();
                while (Dr.Read())
                {
                    ano.AnoInicio = Convert.ToInt32(Dr["AnoIncio"]);
                    ano.AnoFim = Convert.ToInt32(Dr["AnoFim"]);
                }
                Dr.Close();
                Dr.Dispose();
                return ano;

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
        public List<AnoModelo> ListarAnoFim(int anoInicio, string marca)
        {
            AnoModelo anoMod = new AnoModelo();
            //if (idMarca != null)
            //{
            //idMarca = 0;
            anoMod = ListarAnoByMarca(marca);
            //}

            int datas = Convert.ToInt32(anoMod.AnoFim);
            List<AnoModelo> lista = new List<AnoModelo>();
            for (int i = datas; i >= anoInicio; i--)
            {
                AnoModelo ano = new AnoModelo();
                ano.AnoLista = i;
                lista.Add(ano);
            }

            return lista;
        }

        public List<AnoModelo> ListarAno1(int anoIncio)
        {
            int anoFim = anoIncio + 1;
            List<AnoModelo> lista = new List<AnoModelo>();
            for (int i = anoIncio; i <= anoFim; i++)
            {
                AnoModelo ano = new AnoModelo();
                ano.AnoLista = i;
                lista.Add(ano);
            }

            return lista;
        }
        public List<AnoModelo> ListarAno2()
        {
            int datas = Convert.ToInt32(DateTime.Now.Year + 1);
            List<AnoModelo> lista = new List<AnoModelo>();
            for (int i = datas; i > datas - 100; i--)
            {
                AnoModelo ano = new AnoModelo();
                ano.AnoLista = i;
                lista.Add(ano);
            }

            return lista;
        }

        public static List<AnoModelo> ListarAnoFabricacao()
        {
            // usado na pagina de cadastro e editar
            int datas = Convert.ToInt32(DateTime.Now.Year);
            List<AnoModelo> lista = new List<AnoModelo>();
            for (int i = datas; i > datas - 100; i--)
            {
                AnoModelo ano = new AnoModelo();
                ano.AnoLista = i;
                lista.Add(ano);
            }

            return lista;
        }
    }
}
