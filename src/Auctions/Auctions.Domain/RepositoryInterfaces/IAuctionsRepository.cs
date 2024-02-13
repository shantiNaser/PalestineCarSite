using Auctions.Domain.Entites;

namespace Auctions.Domain.RepositoryInterfaces;

public interface IAuctionsRepository
{
    /// <summary>
    /// Get All Auctions 
    /// </summary>
    /// <returns></returns>
    Task<List<Auction>> GetAllAuctionsAsync(string? date);

    /// <summary>
    /// Get Auction By Id
    /// </summary>
    /// <param name="auctionId"></param>
    /// <returns></returns>
    Task<Auction?> GetAuctionByIdAsync(Guid auctionId);

    /// <summary>
    /// Create new auction 
    /// </summary>
    /// <param name="auction"></param>
    /// <returns></returns>
    Task<Auction> CreateAuctionAsync(Auction auction);

    /// <summary>
    /// Delete auction By Id 
    /// </summary>
    /// <param name="auction"></param>
    /// <returns></returns>
    Task DeleteAuctionAsync(Auction auction);

    /// <summary>
    /// update specific auction by Id
    /// </summary>
    /// <param name="auction"></param>
    /// <returns></returns>
    Task<Auction> UpdateAuctionAsync(Auction auction);
}

