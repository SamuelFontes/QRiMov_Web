using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRiMovWeb.Repoositories;

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

        public IActionResult List()
        {
            ViewBag.Imovel = "Imovel";
            ViewData["Categoria"] = "Categoria";
            var imoveis = _imovelRepository.Imoveis;
            return View(imoveis);
        }
    }
}