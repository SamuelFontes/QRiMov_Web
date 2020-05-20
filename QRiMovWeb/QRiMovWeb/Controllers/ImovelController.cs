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
    public class ImovelController : Controller
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ImovelController(IImovelRepository imovelRepository,ICategoriaRepository categoriaRepository)
        {
            _imovelRepository = imovelRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Imovel> imoveis;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                imoveis = _imovelRepository.Imoveis.OrderBy(i => i.Id);
                categoria = "Todos os Imóveis";
            }
            else
            {
                if (string.Equals("Venda", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    imoveis = _imovelRepository.Imoveis.Where(i => i.Categoria.CategoriaNome.Equals("Venda")).OrderBy(i => i.Descricao);
                }
                else
                {
                    imoveis = _imovelRepository.Imoveis.Where(i => i.Categoria.CategoriaNome.Equals("Aluguel")).OrderBy(i => i.Descricao);
                }
                categoriaAtual = _categoria;
            }
            var imoveisListViewModel = new ImovelListViewModel
            {
                Imoveis = imoveis,
                CategoriaAtual = categoriaAtual
            };
            
            return View(imoveisListViewModel);
        }
        public IActionResult Details(int imovelId)
        {
            var imovel = _imovelRepository.Imoveis.FirstOrDefault(i => i.Id == imovelId);
            /*if (imovel == null)
            {
                return View("../Views/Error/Error.cshtml");
            }*/
            return View(imovel);
        }
        public IActionResult search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Imovel> imoveis;
            string _categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                imoveis = _imovelRepository.Imoveis.OrderBy(i => i.Id);
            }
            else
            {
                imoveis = _imovelRepository.Imoveis.Where(i => i.Descricao.ToLower().Contains(_searchString.ToLower()));
            }
            return View("~/Views/Imovel/List.cshtml", new ImovelListViewModel { Imoveis = imoveis, CategoriaAtual = "Todos os imóveis" });
        }
    }
}