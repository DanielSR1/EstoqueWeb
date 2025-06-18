using EstoqueWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<ItemEstoque> ItensEstoque { get; set; }
    }
}
