using Microsoft.Extensions.Options;
using Search.Domain.Models;
using Sieve.Models;
using Sieve.Services;

namespace Search.Infrastructure.Sieve;

public class ApplicationSieveProcessor : SieveProcessor
{
    public ApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.Property<Item>(p => p.Data.Make)
            .CanFilter();

        mapper.Property<Item>(p => p.Data.Model)
            .CanFilter();

        mapper.Property<Item>(p => p.Data.Color)
            .CanFilter();

        mapper.Property<Item>(p => p.Data.Year)
            .CanFilter()
            .CanSort();

        mapper.Property<Item>(p => p.Data.Mileage)
            .CanFilter()
            .CanSort();

        return mapper;
    }
}

