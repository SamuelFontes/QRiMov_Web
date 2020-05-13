using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRiMov.Models;


namespace QRiMov.Models
{
    interface IUsuarioDAL
    {

        bool verificaLogin(string login, string senha);
        string verificaPrermissoes(string login, string senha);
        bool salvarUsuarioProc(Usuario usr);
        //bool AlterasuarioProc(Usuario usr);
        bool AlteraSenha(Usuario usr, string id);
        bool DeletausuarioProc(Usuario usr);
        List<string> DadosUsuarios(string id);
    }
}
