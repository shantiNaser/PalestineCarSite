using System;
using System.Xml.Linq;

namespace Auctions.Domain.Exceptions;

public class RecordNotFoundException : Exception
{
	public Guid AuctionId { get; set; }

	public RecordNotFoundException(Guid auctionId) : base(String.Format("Record Not Founded, There's No Auction With This Id {0} Exist.", auctionId))
	{
		this.AuctionId = auctionId;
	}
}