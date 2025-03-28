﻿using CalculoImposto.Domain.Respositories.Inss.Interface;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using CalculoImposto.Infrastructure.Repositories.Inss;
using CalculoImposto.Infrastructure.Repositories.Irrf;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoImposto.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IInssRepository, InssRepository>();
        services.AddTransient<IIrrfRepository, IrrfRepository>();
        services.AddTransient<ISimplificadoRepository, SimplificadoRepository>();
        services.AddTransient<IDependenteRepository, DependenteRepository>();
        services.AddTransient<IDescontoMinimoRespository, DescontoMinimoRepository>();

        return services;
    }
}
