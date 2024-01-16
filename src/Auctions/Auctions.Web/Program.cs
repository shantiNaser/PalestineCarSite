using System.Net;
using Auctions.Infrastructure;
using Auctions.Infrastructure.Data;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddTransient<AuctionDbContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();

        app.MapControllers();

        SeedDataToAuctionsServiceIfNotExsit(app);

        app.Run();
    }

    private static void SeedDataToAuctionsServiceIfNotExsit(WebApplication app)
    {
        try
        {
            DbInitializer.InitDb(app);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}