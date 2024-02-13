using System;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;
using Search.Domain.Models;
using Search.BusinessLogic.Service;
using Search.Domain;

namespace Search.API.Controllers;

/// <summary>
/// Represants the Search Controller
/// </summary>
[ApiController]
[Route("api/search")]
public sealed class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    // for development purpose only
    private readonly AuctionServiceHttpClient _auctionServiceHttpClient;

    public SearchController(ISearchService sieveProcessor, AuctionServiceHttpClient auctionServiceHttpClient)
    {
        _searchService = sieveProcessor;
        _auctionServiceHttpClient = auctionServiceHttpClient;
    }


    /// <summary>
    /// Get the Item and the Item details using sieve functionality.
    /// </summary>
    /// <param name="sieveModel"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(RetrieveListViewResponse<Item>), StatusCodes.Status200OK)]
    public async Task<RetrieveListViewResponse<Item>> SearchAsync([FromBody] SieveModel sieveModel) =>
        await _searchService.SearchAsync(sieveModel);

}

