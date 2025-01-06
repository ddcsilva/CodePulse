using CodePulse.Domain.Entities;
using CodePulse.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodePulse.Infrastructure.Persistence.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("CATEGORIAS");

        builder.HasKey(c => c.Id)
            .HasName("PK_CATEGORIAS");

        builder.Property(c => c.Id)
            .HasColumnName("ID")
            .HasColumnOrder(1)
            .IsRequired()
            .HasComment("Chave primária da categoria");

        builder.Property(c => c.Nome)
            .HasColumnName("NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome da categoria");

        builder.Property(c => c.Slug)
            .HasColumnName("SLUG")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(120)")
            .HasConversion(
                v => v.Valor,
                v => Slug.Criar(v)
            )
            .HasComment("Slug gerado automaticamente a partir do nome da categoria");

        builder.Property(c => c.DataCriacao)
            .HasColumnName("DATA_CRIACAO")
            .HasColumnOrder(4)
            .IsRequired()
            .HasColumnType("datetime2(3)")
            .HasDefaultValueSql("GETUTCDATE()")
            .HasComment("Data de criação da categoria");

        builder.Property(c => c.DataAlteracao)
            .HasColumnName("DATA_ALTERACAO")
            .HasColumnOrder(5)
            .HasColumnType("datetime2(3)")
            .IsRequired(false)
            .HasComment("Data da última alteração da categoria");
    }
}
