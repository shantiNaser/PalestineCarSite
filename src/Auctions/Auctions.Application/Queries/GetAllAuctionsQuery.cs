using MediatR;
using Auctions.Application.DTOs;

namespace Auctions.Application.Queries;

public class GetAllAuctionsQuery : IRequest<List<AuctionDto>>
{
	public string Date { get; }

	public GetAllAuctionsQuery(string date)
	{
		this.Date = date;
	}
}

