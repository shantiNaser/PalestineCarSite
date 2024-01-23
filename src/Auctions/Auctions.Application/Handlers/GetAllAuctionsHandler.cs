using Auctions.Application.DTOs;
using Auctions.Application.Queries;
using Auctions.Domain.Entites;
using Auctions.Domain.RepositoryInterfaces;
using AutoMapper;
using MediatR;

namespace Auctions.Application.Handlers;

public class GetAllAuctionsHandler : IRequestHandler<GetAllAuctionsQuery, List<AuctionDto>>
{
    private readonly IAuctionsRepository _auctionsRepository;
    private readonly IMapper _mapper;

    public GetAllAuctionsHandler(IAuctionsRepository auctionsRepository, IMapper mapper)
    {
        _auctionsRepository = auctionsRepository;
        _mapper = mapper;
    }

    public async Task<List<AuctionDto>> Handle(GetAllAuctionsQuery request, CancellationToken cancellationToken)
    {
        var auctions = await _auctionsRepository.GetAllAuctionsAsync();
        return _mapper.Map<List<AuctionDto>>(auctions);
    }
}

