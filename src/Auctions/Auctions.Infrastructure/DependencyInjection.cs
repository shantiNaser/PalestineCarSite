using System;
using Auctions.Domain.RepositoryInterfaces;
using Auctions.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Auctions.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddScoped<IAuctionsRepository, AuctionsRepository>();

        return services;
    }
};

