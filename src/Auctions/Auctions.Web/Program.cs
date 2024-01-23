using System.Net;
using System.Text.Json.Serialization;
using Auctions.Application;
using Auctions.Application.Mappers;
using Auctions.Infrastructure;
using Auctions.Infrastructure.Data;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        builder.Services.AddTransient<AuctionDbContext>();

        builder.Services.AddAutoMapper(typeof(AuctionsDtoProfile));

        builder.Services
            .AddApplication()
            .AddInfrastructure();

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