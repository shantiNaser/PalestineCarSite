using System;
using Auctions.Application.DTOs;
using Auctions.Application.Queries;
using Auctions.Domain.RepositoryInterfaces;
using AutoMapper;
using MediatR;

namespace Auctions.Application.Handlers;

public class GetAuctionByIdHandler : IRequestHandler<GetAuctionByIdQuery, AuctionDto>
{
    private readonly IAuctionsRepository _auctionsRepository;
    private readonly IMapper _mapper;

    public GetAuctionByIdHandler(IAuctionsRepository auctionsRepository, IMapper mapper)
	{
        this._auctionsRepository = auctionsRepository;
        this._mapper = mapper;
    }

    public async Task<AuctionDto> Handle(GetAuctionByIdQuery request, CancellationToken cancellationToken)
    {
        var auction = await _auctionsRepository.GetAuctionByIdAsync(request.AuctionId);
        // TODO: improve this with Logging 
        return _mapper.Map<AuctionDto>(auction);
    }
}

