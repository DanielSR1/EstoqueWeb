using API.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mappings;

public class LojaMapping : IEntityTypeConfiguration<Loja>
{
    public void Configure(EntityTypeBuilder<Loja> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(cfg => cfg.Nome).IsRequired().HasColumnType("Varchar(50)");

        builder.Property(cfg => cfg.Endereco).IsRequired().HasColumnType("Varchar(150)");

        builder.ToTable("Lojas");
    }
}

