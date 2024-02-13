using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Search.BusinessLogic.Service;

/// <summary>
/// Refit API referances to call Auction service 
/// </summary>
public interface IAuctionServiceHttpClient
{
	[Get("/api/auctions")]
	Task<HttpResponseMessage> GetAuctionAsync([FromQuery] string date);
}

