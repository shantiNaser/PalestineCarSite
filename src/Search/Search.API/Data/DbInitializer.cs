using System;
using MongoDB.Driver;
using MongoDB.Entities;
using Search.BusinessLogic.Service;
using Search.Domain.Models;

namespace Search.API.Data;

public class DbInitializer
{
	public static async Task InitDb(WebApplication app)
	{
        //TODO: Imporve this with log ..

        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));


        var count = await DB.CountAsync<Item>();

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();

        var items = await httpClient.GetItemsAsync();

        if (items.Count > 0)
        {
            await DB.SaveAsync(items);
        }

    }
}

