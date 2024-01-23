using System;
using Auctions.Application.DTOs;
using MediatR;

namespace Auctions.Application.Queries;

public class GetAuctionByIdQuery : IRequest<AuctionDto>
{
	public Guid AuctionId { get; }

	public GetAuctionByIdQuery(Guid auctionId)
	{
		this.AuctionId = auctionId;
	}
}

