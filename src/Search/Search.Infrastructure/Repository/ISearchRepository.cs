using System;
using Search.Domain.Models;

namespace Search.Infrastructure.Repository;

public interface ISearchRepository
{
    /// <summary>
    /// Retrive the Item and Item Data from the collection, we also have the ability to apply the filter and sort
    /// on the final result
    /// </summary>
    /// <returns></returns>
    Task<IQueryable<Item>> SearchAsync();

    /// <summary>
    /// Get the date of the last Updated Item exsited on Serach service
    /// </summary>
    /// <returns></returns>
    Task<string> GetLastDateForUpdatedItem();
}

