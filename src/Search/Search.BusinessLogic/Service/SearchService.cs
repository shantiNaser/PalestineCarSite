using Search.Domain;
using Search.Domain.Models;
using Search.Infrastructure.Repository;
using Search.Infrastructure.Sieve;
using Sieve.Models;

namespace Search.BusinessLogic.Service;

public class SearchService : ISearchService
{
	private readonly ISearchRepository _searchRepository;
	private readonly ApplicationSieveProcessor _sieveProcessor;

    public SearchService(
		ISearchRepository searchRepository,
        ApplicationSieveProcessor sieveProcessor)
	{
		_searchRepository = searchRepository;
		_sieveProcessor = sieveProcessor;
	}

    /// <summary>
    /// Retrive the Item and Item Data from the collection, we also have the ability to apply the filter and sort
    /// on the final result
    /// </summary>
    /// <param name="sieveModel"></param>
    /// <returns></returns>
    public async Task<RetrieveListViewResponse<Item>> SearchAsync(SieveModel sieveModel)
	{
		var items = await _searchRepository.SearchAsync();
		var searchResults = _sieveProcessor.Apply(sieveModel, items);

        return new()
        {
            Entities = searchResults.ToList(),
            TotalCount = searchResults.Count()
        };
	}
}

