using System;
using Auctions.Application.Commands;
using Auctions.Application.DTOs;
using Auctions.Domain.Entites;
using Auctions.Domain.RepositoryInterfaces;
using AutoMapper;
using MediatR;

namespace Auctions.Application.Handlers;

public class CreateAuctionHandler : IRequestHandler<CreateAuctionCommand, AuctionDto>
{
    private readonly IAuctionsRepository _auctionsRepository;
    private readonly IMapper _mapper;

    public CreateAuctionHandler(IAuctionsRepository auctionsRepository, IMapper mapper)
	{
        _auctionsRepository = auctionsRepository;
        _mapper = mapper;
    }

    public async Task<AuctionDto> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
    {
        // TODO: Modify this to a SignalR
        // TODO: add Logging here if there's an issue
        // TODO: add curent user as a seller from Login Inforamtion for now let add test
        // TODO: add a generic Pipline to handle the Vaildation using Fluent Validation
        // TODO: Use the actual user for the seller here

        var entity = _mapper.Map<Auction>(request);
        
        entity.Seller = "test";
        var result = await _auctionsRepository.CreateAuctionAsync(entity);
        return _mapper.Map<AuctionDto>(result);

    }
}

