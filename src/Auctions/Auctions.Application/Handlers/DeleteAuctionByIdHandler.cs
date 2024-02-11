using Auctions.Domain.Exceptions;
using Auctions.Application.Commands;
using Auctions.Domain.RepositoryInterfaces;
using MediatR;

namespace Auctions.Application.Handlers;

public class DeleteAuctionByIdHandler : IRequestHandler<DeleteAuctionByIdCommand, bool>
{
    private readonly IAuctionsRepository _auctionsRepository;

    public DeleteAuctionByIdHandler(IAuctionsRepository auctionsRepository)
	{
        _auctionsRepository = auctionsRepository;
    }

    public async Task<bool> Handle(DeleteAuctionByIdCommand request, CancellationToken cancellationToken)
    {
        var auction = await _auctionsRepository.GetAuctionByIdAsync(request.AuctionId);
        // TODO: Impleamnt a Pipline to validate the state of the Auction before Delete it
        if(auction is null)
        {
            throw new RecordNotFoundException(request.AuctionId);
        }

        await _auctionsRepository.DeleteAuctionAsync(auction);
        return true;
    }
}

