
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QRiMov.Controllers;

namespace QRiMov.Models
{
    
    public class UsuarioDAL : IUsuarioDAL
    {
        private bool var = false;
        SqlCommand cmd = new SqlCommand();
        Conexao conexao = new Conexao();
        SqlConnection conn = Conexao.abrirConexao();
        SqlDataReader dr;
        public void AddUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();

        }

        public Usuario GetUsuario(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
