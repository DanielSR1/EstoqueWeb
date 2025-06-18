using API.Entidade;
using Microsoft.EntityFrameworkCore;

namespace API.DBContext;

public class ApiDBContext : DbContext
{
    public DbSet<Produto> Produtos {get ; set;}
    public DbSet<Loja> Lojas {get ; set;}
    public DbSet<ItemEstoque> ItemEstoque {get ; set;}

    



    public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDBContext).Assembly);
    }
}

