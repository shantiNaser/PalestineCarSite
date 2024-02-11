
using MongoDB.Driver;
using MongoDB.Entities;
using Search.BusinessLogic.Service;
using Search.Domain.Models;
using Search.Infrastructure.Repository;
using Search.Infrastructure.Sieve;
using Sieve.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add MongoDB configuration
var connectionUrl = builder.Configuration.GetConnectionString("MongoDbConnection");
var client = new MongoClient(connectionUrl);
if (client == null)
{
    Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
    Environment.Exit(0);
}
var database = client.GetDatabase("SearchDb");

// Register the repository and MongoDB connection
builder.Services.AddSingleton(database);

// register the Sieve service
builder.Services
    .AddScoped<ApplicationSieveProcessor>()
    .AddScoped<ISearchService, SearchService>()
    .AddScoped<ISearchRepository, SearchRepository>();

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