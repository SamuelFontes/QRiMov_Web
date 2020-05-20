using QRiMovWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMovWeb.ViewModels
{
    public class ImovelListViewModel
    {
        public IEnumerable<Imovel> Imoveis { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
