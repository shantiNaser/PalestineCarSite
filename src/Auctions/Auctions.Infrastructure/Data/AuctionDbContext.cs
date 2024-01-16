using System;
using Auctions.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Auctions.Infrastructure.Data;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext()
    {
        
    }

    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Server=localhost:5432;User Id=postgres;Password=postgrespw;Database=Auctions");
        }
    }
}

