
using MongoDB.Driver;
using MongoDB.Entities;
using Search.BusinessLogic.Service;
using Search.Domain.Models;
using Search.Infrastructure.Repository;
using Search.Infrastructure.Sieve;
using Sieve.Services;
using System.Text.Json;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add MongoDB configuration
var connectionUrl = builder.Configuration.GetConnectionString("MongoDbConnection");
var client = new MongoClient(connectionUrl);
if (client == null)
{
    Console.WriteLine("There's an issue while reading the Conection String. or it does not set corectly");
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

builder.Services
    .AddRefitClient<IAuctionServiceHttpClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:7001"));


builder.Services.AddScoped<AuctionServiceHttpClient>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));


var count = await DB.CountAsync<Item>();


using var scope = app.Services.CreateScope();

var httpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();

var items = await httpClient.GetItemsAsync();

if(items.Count > 0)
{
    await DB.SaveAsync(items);
}

app.Run();