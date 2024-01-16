using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions.Domain.Entites;

[Table("Items")]
public class Item
{
    public Guid Id { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    public string Color { get; set; }

    public int Mileage { get; set; }

    public string ImageUrl { get; set; }

    // nav Proprity to manually define the relashionship for Entity framework
    public Auction Auction { get; set; }

    public Guid AuctionId { get; set; }
}

