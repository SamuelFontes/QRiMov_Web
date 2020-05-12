using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using QRiMov.Models;


namespace QRiMov.Models
{
    interface IUsuarioDAL
    {
        IEnumerable<Usuario> GetAllUsuarios();
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        Usuario GetUsuario(int? id);
        void DeleteUsuario(int? id);  
    }
}
