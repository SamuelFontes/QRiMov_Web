using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
namespace QRiMov.Controllers
{
    public class Conexao
    {
        private static readonly string conexao = @"Data Source=ccstecno.ddns.net;Initial Catalog=QRiMov;Persist Security Info=True;User ID=qrimov;Password=123@biscoito";

        public static SqlConnection abrirConexao()
        {
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                conn = null;
                Console.Write(ex);
            }
            return conn;
        }
    }
}
