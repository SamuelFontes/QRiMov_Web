using QRiMov.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMov.Models
{
    public class ImovelDAL : IImovelDAL
    {
        public void AddImovel(Imovel imovel)
        {
            string comandoSQL = "INSEREIMOVEL @Id,@Descricao,@Bairro,@CEP,@Comarca,@Complemento,@Logradouro,@Numero,@UF,@Valor";
            SqlConnection conn = Conexao.abrirConexao();
            SqlCommand cmd = new SqlCommand(comandoSQL, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", imovel.Id);
            cmd.Parameters.AddWithValue("@Descricao", imovel.Descricao);
            cmd.Parameters.AddWithValue("@Bairro", imovel.Bairro);
            cmd.Parameters.AddWithValue("@CEP", imovel.CEP);
            cmd.Parameters.AddWithValue("@Comarca", imovel.Comarca);
            cmd.Parameters.AddWithValue("@Complemento", imovel.Complemento);
            cmd.Parameters.AddWithValue("@Logradouro", imovel.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", imovel.Numero);
            cmd.Parameters.AddWithValue("@UF", imovel.UF);
            cmd.Parameters.AddWithValue("@Valor", imovel.Valor);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteImovel(int? id)
        {
            string comandoSQL = "DELETAIMOVEL @Id";
            SqlConnection conn = Conexao.abrirConexao();
            SqlCommand cmd = new SqlCommand(comandoSQL, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Imovel> GetAllImoveis()
        {
            List<Imovel> lstimoveis = new List<Imovel>();
            SqlConnection conn = Conexao.abrirConexao();
            SqlCommand cmd = new SqlCommand("SELECT *  FROM VIEW_IMOVEL", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Imovel imovel = new Imovel();
                imovel.Id = Convert.ToInt32(rdr["ID"]);
                imovel.Descricao = rdr["Descrição"].ToString();
                imovel.Bairro = rdr["Bairro"].ToString();
                imovel.CEP = rdr["CEP"].ToString();
                imovel.Comarca = rdr["Comarca"].ToString();
                imovel.Complemento = rdr["Complemento"].ToString();
                imovel.Logradouro = rdr["Logradouro"].ToString();
                imovel.Numero = rdr["Número"].ToString();
                imovel.UF = rdr["UF"].ToString();
                imovel.Valor = rdr["Valor"].ToString();
                lstimoveis.Add(imovel);
            }
            conn.Close();
            return lstimoveis;
        }

        public Imovel GetImovel(int? id)
        {
            Imovel imovel = new Imovel();
            SqlConnection conn = Conexao.abrirConexao();
            SqlCommand cmd = new SqlCommand("SELECT *  FROM VIEW_IMOVEL", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                imovel.Id = Convert.ToInt32(rdr["ID"]);
                imovel.Descricao = rdr["Descrição"].ToString();
                imovel.Bairro = rdr["Bairro"].ToString();
                imovel.CEP = rdr["CEP"].ToString();
                imovel.Comarca = rdr["Comarca"].ToString();
                imovel.Complemento = rdr["Complemento"].ToString();
                imovel.Logradouro = rdr["Logradouro"].ToString();
                imovel.Numero = rdr["Número"].ToString();
                imovel.UF = rdr["UF"].ToString();
                imovel.Valor = rdr["Valor"].ToString();
            }
            conn.Close();
            return imovel;
        }

        public void UpdateImovel(Imovel imovel)
        {
            string comandoSQL = "ALTERAIMOVEL @Id,@Descricao,@Bairro,@CEP,@Comarca,@Complemento,@Logradouro,@Numero,@UF,@Valor";
            SqlConnection conn = Conexao.abrirConexao();
            SqlCommand cmd = new SqlCommand(comandoSQL, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", imovel.Id);
            cmd.Parameters.AddWithValue("@Descricao", imovel.Descricao);
            cmd.Parameters.AddWithValue("@Bairro", imovel.Bairro);
            cmd.Parameters.AddWithValue("@CEP", imovel.CEP);
            cmd.Parameters.AddWithValue("@Comarca", imovel.Comarca);
            cmd.Parameters.AddWithValue("@Complemento", imovel.Complemento);
            cmd.Parameters.AddWithValue("@Logradouro", imovel.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", imovel.Numero);
            cmd.Parameters.AddWithValue("@UF", imovel.UF);
            cmd.Parameters.AddWithValue("@Valor", imovel.Valor);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
