using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMovWeb.Models
{
    public class FavoritoItem
    {
        public int FavoritoItemId { get; set; }
        public Imovel Imovel { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string FavoritoId { get; set; }
    }
}
