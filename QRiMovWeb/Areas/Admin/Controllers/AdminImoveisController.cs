using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QRiMovWeb.Context;
using QRiMovWeb.Models;

namespace QRiMovWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImoveisController : Controller
    {
        private readonly AppDbContext _context;

        public AdminImoveisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminImoveis
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Imoveis.Include(i => i.Categoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminImoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .SingleOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Admin/AdminImoveis/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId");
            return View();
        }
        // POST: Admin/AdminImoveis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImovelId,Descricao,Detalhes,Valor,CEP,Logradouro,Numero,Complemento,Bairro,UF,Comarca,ImgMiniaturaUrl,ImgUrl,IsDestaque,CategoriaId")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                string ImgQRCode = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=samuguel-001-site1.gtempurl.com/Imovel/Details?ImovelId=" + imovel.ImovelId.ToString();
                _context.Database.ExecuteSqlCommand("UPDATE IMOVEIS SET ImgQRCode = '" + ImgQRCode + "' where imovelID = " + imovel.ImovelId.ToString());
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Admin/AdminImoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.SingleOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", imovel.CategoriaId);
            return View(imovel);
        }

        // POST: Admin/AdminImoveis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,Descricao,Detalhes,Valor,CEP,Logradouro,Numero,Complemento,Bairro,UF,Comarca,ImgMiniaturaUrl,ImgUrl,IsDestaque,CategoriaId")] Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                    string ImgQRCode = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=samuguel-001-site1.gtempurl.com/Imovel/Details?ImovelId=" + imovel.ImovelId.ToString();
                    _context.Database.ExecuteSqlCommand("UPDATE IMOVEIS SET ImgQRCode = '" + ImgQRCode + "' where imovelID = " + imovel.ImovelId.ToString());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Admin/AdminImoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .SingleOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Admin/AdminImoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Database.ExecuteSqlCommand("Delete from favoritoItems where imovelID = " + id.ToString());
            var imovel = await _context.Imoveis.SingleOrDefaultAsync(m => m.ImovelId == id);
            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.ImovelId == id);
        }
    }
}
