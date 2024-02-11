using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Entities;
using Search.Domain.Models;

namespace Search.Infrastructure.Repository;

public class SearchRepository : ISearchRepository
{
    private readonly IMongoCollection<Item> _collection;
    private const string collectionName = "Item";

    public SearchRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Item>(collectionName);
    }

    /// <inheritdoc/>
    public async Task<IQueryable<Item>> SearchAsync()
    {
        var result = await _collection.Find(_ => true).ToListAsync();
        return result.AsQueryable();
    }
}

