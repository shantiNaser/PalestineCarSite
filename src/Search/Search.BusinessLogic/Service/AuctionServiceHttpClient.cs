using System;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Newtonsoft.Json;
using Search.BusinessLogic.Extension;
using Search.Domain.Models;
using Search.Infrastructure.Repository;

namespace Search.BusinessLogic.Service;

public class AuctionServiceHttpClient
{
	private readonly IAuctionServiceHttpClient _httpClient;
	private readonly ISearchRepository _searchRepository;

	public AuctionServiceHttpClient(
		IAuctionServiceHttpClient httpClient,
		ISearchRepository searchRepository)
	{
		_httpClient = httpClient;
		_searchRepository = searchRepository;
	}

	/// <summary>
	/// Make an Http Request to the auction Service to get the Data
	/// </summary>
	/// <returns></returns>
	public async Task<List<Item>> GetItemsAsync()
	{
		var date = await _searchRepository.GetLastDateForUpdatedItem();
		var response = await this._httpClient.GetAuctionAsync(date);

        return await response.DeserializeJsonContentAsync<List<Item>>();
    }
}

