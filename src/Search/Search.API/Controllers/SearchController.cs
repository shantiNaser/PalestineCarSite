using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
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

    public SearchController(ISearchService sieveProcessor)
    {
        _searchService = sieveProcessor;
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

