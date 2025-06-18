using API.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mappings;

public class ItemEstoqueMapping : IEntityTypeConfiguration<ItemEstoque>
{
    public void Configure(EntityTypeBuilder<ItemEstoque> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(cfg => cfg.LojaId).IsRequired();

        builder.Property(cfg => cfg.ProdutoId).IsRequired();

        builder.Property(cfg => cfg.Quantidade).IsRequired();


        builder.ToTable("ItemEstoque");
    }
}

