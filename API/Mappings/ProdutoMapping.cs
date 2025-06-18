using API.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(cfg => cfg.Nome).IsRequired().HasColumnType("Varchar(50)");

        builder.Property(cfg => cfg.PrecoCusto).IsRequired().HasColumnType("Decimal(18,2)");

        builder.Property(cfg => cfg.Descricao).IsRequired().HasColumnType("Varchar(150)");

        builder.HasMany(cfg => cfg.Lojas).WithMany(cfg => cfg.Produtos).UsingEntity<ItemEstoque>();

        builder.ToTable("Produtos");
    }
}

