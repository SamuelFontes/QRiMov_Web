using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QRiMovWeb.Context;
using QRiMovWeb.Models;

namespace QRiMovWeb.Repoositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly AppDbContext _context;

        public ImovelRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Imovel> Imoveis => _context.Imoveis.Include(c => c.Categoria);

        public IEnumerable<Imovel> ImoveisDestaque => _context.Imoveis.Where(p =>
        p.IsDestaque).Include(c => c.Categoria);

        public Imovel GetImovelById(int imovelId)
        {
           return _context.Imoveis.FirstOrDefault(i => i.ImovelId == imovelId);
        }
    }
}
