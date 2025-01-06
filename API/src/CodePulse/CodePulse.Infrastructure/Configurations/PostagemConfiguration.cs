using CodePulse.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodePulse.Infrastructure.Persistence.Configurations;

public class PostagemConfiguration : IEntityTypeConfiguration<Postagem>
{
    public void Configure(EntityTypeBuilder<Postagem> builder)
    {
        builder.ToTable("POSTAGENS");

        builder.HasKey(p => p.Id)
            .HasName("PK_POSTAGENS");

        builder.Property(p => p.Id)
            .HasColumnName("ID")
            .HasColumnOrder(1)
            .IsRequired()
            .HasComment("Chave primária da postagem");

        builder.Property(p => p.Titulo)
            .HasColumnName("TITULO")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Título da postagem");

        builder.Property(p => p.DescricaoCurta)
            .HasColumnName("DESCRICAO_CURTA")
            .HasColumnOrder(3)
            .HasColumnType("varchar(500)")
            .HasComment("Descrição curta da postagem");

        builder.Property(p => p.Conteudo)
            .HasColumnName("CONTEUDO")
            .HasColumnOrder(4)
            .HasColumnType("text")
            .IsRequired()
            .HasComment("Conteúdo da postagem");

        builder.Property(p => p.Autor)
            .HasColumnName("AUTOR")
            .HasColumnOrder(5)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Autor da postagem");

        builder.Property(p => p.UrlImagemDestaque)
            .HasColumnName("URL_IMAGEM_DESTAQUE")
            .HasColumnOrder(6)
            .HasColumnType("varchar(500)")
            .HasComment("URL da imagem de destaque da postagem");

        builder.Property(p => p.Slug)
            .HasColumnName("SLUG")
            .HasColumnOrder(7)
            .IsRequired()
            .HasColumnType("varchar(120)")
            .HasConversion(
                v => v.Valor,
                v => Slug.Criar(v)
            )
            .HasComment("Slug gerado automaticamente a partir do título da postagem");

        builder.Property(p => p.DataPublicacao)
            .HasColumnName("DATA_PUBLICACAO")
            .HasColumnOrder(8)
            .IsRequired()
            .HasColumnType("datetime2(3)")
            .HasComment("Data de publicação da postagem");

        builder.Property(p => p.Visivel)
            .HasColumnName("VISIVEL")
            .HasColumnOrder(9)
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .HasComment("Indica se a postagem está visível");

        builder.Property(p => p.DataCriacao)
            .HasColumnName("DATA_CRIACAO")
            .HasColumnOrder(10)
            .IsRequired()
            .HasColumnType("datetime2(3)")
            .HasDefaultValueSql("GETUTCDATE()")
            .HasComment("Data de criação da postagem");

        builder.Property(p => p.DataAlteracao)
            .HasColumnName("DATA_ALTERACAO")
            .HasColumnOrder(11)
            .HasColumnType("datetime2(3)")
            .IsRequired(false)
            .HasComment("Data da última alteração da postagem");
    }
}
