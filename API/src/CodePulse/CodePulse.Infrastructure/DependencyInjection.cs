using CodePulse.Domain.Interfaces;
using CodePulse.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CodePulse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostagemRepository, PostagemRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //services.AddScoped<IPostagemService, PostagemService>();
        //services.AddScoped<ICategoriaService, CategoriaService>();
        return services;
    }
}

