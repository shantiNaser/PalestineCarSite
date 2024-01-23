using System;
using Auctions.Application.DTOs;
using Auctions.Domain.Entites;
using AutoMapper;

namespace Auctions.Application.Mappers;

public class AuctionsDtoProfile : Profile
{
	public AuctionsDtoProfile()
	{
        CreateMap<Auction, AuctionDto>();

        CreateMap<Item, ItemDto>();
    }
}

