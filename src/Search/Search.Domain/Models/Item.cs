using MongoDB.Entities;
using Newtonsoft.Json;
using Sieve.Attributes;

namespace Search.Domain.Models;

public class Item : Entity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int ReservePrice { get; set; }

    [Sieve(CanFilter = true)]
    public string Seller { get; set; }

    [Sieve(CanFilter = true)]
    public string Winner { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public int SoldAmount { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public int CurrentHighBid { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string Status { get; set; }

    [Sieve(CanSort = true)]
    public DateTime CreatedAt { get; set; }

    [Sieve(CanSort = true)]
    public DateTime UpdatedAt { get; set; }

    [Sieve(CanSort = true)]
    public DateTime AuctionEnd { get; set; }

    [JsonProperty(propertyName: "Item")]
    public ItemData Data { get; set; }
}

