using Microsoft.AspNetCore.Mvc;
using QRiMovWeb.Models;
using QRiMovWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMovWeb.Components
{
    public class FavoritoResumo : ViewComponent
    {
        private readonly Favorito _favorito;

        public FavoritoResumo(Favorito favorito)
        {
            _favorito = favorito;
        }
        public IViewComponentResult Invoke()
        {
            var itens = _favorito.GetFavoritoItems();
            _favorito.FavoritoItems = itens;
            var favoritoVM = new FavoritoViewModel
            {
                Favorito = _favorito,
                FavoritoTotal = _favorito.GetFavoritoTotal()
            };
            return View(favoritoVM);
        }
    }
}
