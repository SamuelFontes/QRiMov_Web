using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QRiMovWeb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRiMovWeb.Models
{
    public class Favorito
    {
        private readonly AppDbContext _context;

        public Favorito(AppDbContext contexto)
        {
            _context = contexto;
        }
        public string FavoritoId { get; set; }
        public List<FavoritoItem> FavoritoItems { get; set; }
        public static Favorito GetFavorito(IServiceProvider services)
        {
            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string favoritoId = session.GetString("FavoritoId") ?? Guid.NewGuid().ToString();
            session.SetString("FavoritoId", favoritoId);
            return new Favorito(context)
            {
                FavoritoId = favoritoId
            };
        }
        public void AdicionarFavorito(Imovel imovel, int quantidade)
        {
            var favoritoItem =
                _context.FavoritoItems.SingleOrDefault(
                    s => s.Imovel.Id == imovel.Id && s.FavoritoId == FavoritoId);
            if (favoritoItem == null)
            {
                favoritoItem = new FavoritoItem
                {
                    FavoritoId = FavoritoId,
                    Imovel = imovel,
                    Quantidade = 1
                };
                _context.FavoritoItems.Add(favoritoItem);
            }
            else
            {
                //favoritoItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public int RemoverFavorito(Imovel imovel)
        {
            var favoritoItem =
                _context.FavoritoItems.SingleOrDefault(
                    s => s.Imovel.Id == imovel.Id && s.FavoritoId == FavoritoId);
            var quantidadeLocal = 0;
            if(favoritoItem != null)
            {
                if(favoritoItem.Quantidade > 1)
                {
                    favoritoItem.Quantidade--;
                    quantidadeLocal = favoritoItem.Quantidade;
                }
                else
                {
                    _context.FavoritoItems.Remove(favoritoItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }
        public List<FavoritoItem> GetFavoritoItems()
        {
            return FavoritoItems ??
                (FavoritoItems =
                    _context.FavoritoItems.Where(f => f.FavoritoId == FavoritoId).Include(
                        f => f.Imovel).ToList());
        }
        public void LimparFavoritos()
        {
            var favoritoItem =
                _context.FavoritoItems.Where(
                    imovel => imovel.FavoritoId == FavoritoId);
            _context.FavoritoItems.RemoveRange(favoritoItem);
            _context.SaveChanges();
        }
        public decimal GetFavoritoTotal()
        {
            //NAO USAR
            var total = _context.FavoritoItems.Where(f => f.FavoritoId == FavoritoId)
                .Select(f => f.Imovel.Valor * f.Quantidade).Sum();
            return total;
        }
    }
}
