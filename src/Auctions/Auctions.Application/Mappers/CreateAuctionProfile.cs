using System;
using Auctions.Application.Commands;
using Auctions.Domain.Entites;
using AutoMapper;

namespace Auctions.Application.Mappers;

public class CreateAuctionProfile : Profile
{
	public CreateAuctionProfile()
	{
		CreateMap<CreateAuctionCommand, Auction>()
             .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));

        CreateMap<CreateAuctionCommand, Item>();
    }
}

