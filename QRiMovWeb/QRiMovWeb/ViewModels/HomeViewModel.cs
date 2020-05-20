using QRiMovWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMovWeb.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Imovel> ImoveisEmDestaque { get; set; }
    }
}
