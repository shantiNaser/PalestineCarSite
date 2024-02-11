using System;
using Search.Domain;
using Search.Domain.Models;
using Sieve.Models;

namespace Search.BusinessLogic.Service;

public interface ISearchService
{
    Task<RetrieveListViewResponse<Item>> SearchAsync(SieveModel sieveModel);
}

