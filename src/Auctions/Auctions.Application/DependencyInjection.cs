using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Auctions.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.AsScoped(), assembly);

        services.AddSingleton<IMapper, Mapper>();

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}

