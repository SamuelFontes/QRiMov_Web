using Microsoft.EntityFrameworkCore;
using QRiMovWeb.Models;

namespace QRiMovWeb.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FavoritoItem> FavoritoItems { get; set; }
    }
}
