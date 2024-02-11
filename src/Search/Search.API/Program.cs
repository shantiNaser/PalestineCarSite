
using MongoDB.Driver;
using MongoDB.Entities;
using Search.Domain.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));

var count = await DB.CountAsync<Item>();

// seed some data if there's no data here
await TrySeedDataToMongoCollection(count);

app.Run();

static async Task TrySeedDataToMongoCollection(long count)
{
    try
    {
        if (count == 0)
        {
            //TODO: Modify this with Logs
            Console.WriteLine("Seed some data from a json file");

            var itemData = await File.ReadAllTextAsync("Data/Auctions.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);

            await DB.SaveAsync(items);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}