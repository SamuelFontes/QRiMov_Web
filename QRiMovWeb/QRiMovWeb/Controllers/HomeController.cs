using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRiMovWeb.Models;
using QRiMovWeb.Repoositories;
using QRiMovWeb.ViewModels;

namespace QRiMovWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImovelRepository _imovelRepository;

        public HomeController(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ImoveisEmDestaque = _imovelRepository.ImoveisDestaque
            };

            return View(homeViewModel);
        }

        
    }
}
