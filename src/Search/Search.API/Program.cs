
using MongoDB.Driver;
using MongoDB.Entities;
using Search.BusinessLogic.Service;
using Search.Domain.Models;
using Search.Infrastructure.Repository;
using Search.Infrastructure.Sieve;
using Sieve.Services;
using System.Text.Json;
using Refit;
using Search.API.Data;

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

try
{
    await DbInitializer.InitDb(app);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

app.Run();