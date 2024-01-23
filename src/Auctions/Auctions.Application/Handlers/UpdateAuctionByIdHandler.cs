using System;
using Auctions.Application.Commands;
using Auctions.Application.DTOs;
using Auctions.Domain.Entites;
using Auctions.Domain.Exceptions;
using Auctions.Domain.RepositoryInterfaces;
using AutoMapper;
using MediatR;

namespace Auctions.Application.Handlers;

public class UpdateAuctionByIdHandler : IRequestHandler<UpdateAuctionCommand, AuctionDto>
{
    private readonly IAuctionsRepository _auctionsRepository;
    private readonly IMapper _mapper;

    public UpdateAuctionByIdHandler(IAuctionsRepository auctionsRepository, IMapper mapper)
	{
        _auctionsRepository = auctionsRepository;
        _mapper = mapper;
    }

    public async Task<AuctionDto> Handle(UpdateAuctionCommand request, CancellationToken cancellationToken)
    {
        // TODO: Impleamnt a Validation here using Fluent Validation

        var auction = await _auctionsRepository.GetAuctionByIdAsync(request.AuctionId);
        if (auction is null)
        {
            throw new RecordNotFoundException(request.AuctionId);
        }

        auction.Item.Make = request.Make ?? auction.Item.Make;
        auction.Item.Model = request.Model ?? auction.Item.Model;
        auction.Item.Color = request.Color ?? auction.Item.Color;
        auction.Item.Year = request.Year ?? auction.Item.Year;
        auction.Item.Mileage = request.Mileage ?? auction.Item.Mileage;

        var updatedAuction = await _auctionsRepository.UpdateAuctionAsync(auction);
        return _mapper.Map<AuctionDto>(updatedAuction);
    }
}

