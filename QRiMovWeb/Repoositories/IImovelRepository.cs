using QRiMovWeb.Models;
using System.Collections.Generic;

namespace QRiMovWeb.Repoositories
{
    public interface IImovelRepository
    {
        IEnumerable<Imovel> Imoveis { get; }
        IEnumerable<Imovel> ImoveisDestaque { get; }
        Imovel GetImovelById(int imovelId);
    }
}
