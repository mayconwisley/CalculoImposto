using CalculoImposto.Domain.Respositories.Inss.Interface;
using CalculoImposto.Infrastructure.Repositories.Inss;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoImposto.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IInssRepository, InssRepository>();

        return services;
    }
}
