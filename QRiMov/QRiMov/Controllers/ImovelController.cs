using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRiMov.Models;

namespace QRiMov.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelDAL imv;
        public ImovelController(IImovelDAL imovel)
        {
            imv = imovel;
        }
        public IActionResult Index()
        {
            List<Imovel> listaImoveis = new List<Imovel>();
            listaImoveis = imv.GetAllImoveis().ToList();
            return View(listaImoveis);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Imovel imovel = imv.GetImovel(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return View(imovel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                imv.AddImovel(imovel);
                return RedirectToAction("Index");
            }
            return View(imovel);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Imovel imovel = imv.GetImovel(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return View(imovel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                imv.UpdateImovel(imovel);
                return RedirectToAction("Index");
            }
            return View(imovel);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Imovel imovel = imv.GetImovel(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return View(imovel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            imv.DeleteImovel(id);
            return RedirectToAction("Index");
        }
    }
}