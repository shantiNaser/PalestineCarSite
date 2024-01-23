using System;
using Auctions.Application.DTOs;
using MediatR;

namespace Auctions.Application.Commands;

public class UpdateAuctionCommand : IRequest<AuctionDto>
{
    public Guid AuctionId { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? Color { get; set; }
    public int? Mileage { get; set; }
}

