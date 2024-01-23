using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Auctions.Application.Commands;

public class DeleteAuctionByIdCommand : IRequest<bool>
{
    [Required]
    public Guid AuctionId { get; }

    public DeleteAuctionByIdCommand(Guid id)
    {
        this.AuctionId = id;
    }
}

