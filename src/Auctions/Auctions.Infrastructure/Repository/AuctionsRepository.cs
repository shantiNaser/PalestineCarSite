using Auctions.Application.Commands;
using Auctions.Domain.Entites;
using Auctions.Domain.RepositoryInterfaces;
using Auctions.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Infrastructure.Repository;

public class AuctionsRepository : IAuctionsRepository
{
    private readonly AuctionDbContext _dbContext;

    public AuctionsRepository(AuctionDbContext dbContext) => this._dbContext = dbContext;

    public async Task<List<Auction>> GetAllAuctionsAsync()
    {
        return await this._dbContext.Auctions.Include(x => x.Item).AsNoTracking().ToListAsync();
    }

    public async Task<Auction?> GetAuctionByIdAsync(Guid auctionId)
    {
        return await this._dbContext.Auctions
            .Include(x => x.Item)
            .Where(i => i.Id == auctionId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<Auction> CreateAuctionAsync(Auction auction)
    {
        await this._dbContext.AddAsync(auction);
        await this._dbContext.SaveChangesAsync();
        return auction;
    }

    public async Task DeleteAuctionAsync(Auction auction)
    {
        this._dbContext.Remove(auction);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<Auction> UpdateAuctionAsync(Auction auction)
    {
        if (!_dbContext.Entry(auction).IsKeySet)
        {
            _dbContext.Attach(auction);
        }

        _dbContext.Entry(auction).State = EntityState.Modified;
        await this._dbContext.SaveChangesAsync();
        return auction;
    }
}

