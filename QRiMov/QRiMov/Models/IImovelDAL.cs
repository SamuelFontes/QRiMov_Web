using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMov.Models
{
    interface IImovelDAL
    {
        IEnumerable<Imovel> GetAllImoveis();
        void AddImovel(Imovel imovel);
        void UpdateImovel(Imovel imovel);
        Imovel GetImovel(int? id);
        void DeleteImovel(int? id);
    }
}
