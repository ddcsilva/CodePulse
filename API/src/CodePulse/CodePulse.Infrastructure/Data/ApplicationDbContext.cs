using CodePulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Infrastructure.Context;

/// <summary>
/// Contexto principal da aplicação, gerenciando acesso ao banco de dados via Entity Framework Core.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Postagem> Postagens { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
