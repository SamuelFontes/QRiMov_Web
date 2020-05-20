using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRiMovWeb.Models;
using QRiMovWeb.Repoositories;
using QRiMovWeb.ViewModels;

namespace QRiMovWeb.Controllers
{
    public class FavoritoController : Controller
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly Favorito _favorito;

        public FavoritoController(IImovelRepository imovelRepository,Favorito favorito)
        {
            _imovelRepository = imovelRepository;
            _favorito = favorito;
        }

        public IActionResult Index()
        {
            var itens = _favorito.GetFavoritoItems();
            _favorito.FavoritoItems = itens;

            var favoritoViewModel = new FavoritoViewModel
            {
                Favorito = _favorito,
                FavoritoTotal = _favorito.GetFavoritoTotal()
            };
            return View(favoritoViewModel);
        }
        public RedirectToActionResult AdicionarItemNosFavoritos(int imovelId)
        {
            var imovelSelecionado = _imovelRepository.Imoveis.FirstOrDefault(p => p.Id == imovelId);
            if (imovelSelecionado != null)
                _favorito.AdicionarFavorito(imovelSelecionado, 1);
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemDosFavoritos(int imovelId)
        {
            var imovelSelecionado = _imovelRepository.Imoveis.FirstOrDefault(p => p.Id == imovelId);
            if (imovelSelecionado != null)
                _favorito.RemoverFavorito(imovelSelecionado);
            return RedirectToAction("Index");
        }
    }
}