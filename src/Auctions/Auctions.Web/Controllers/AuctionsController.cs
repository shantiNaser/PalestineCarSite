using System;
using Auctions.Application.Commands;
using Auctions.Application.DTOs;
using Auctions.Application.Queries;
using Auctions.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.Web.Controllers;

/// <summary>
/// Represants the Auctions Controller
/// </summary>
[ApiController]
[Route("api/auctions")]
public sealed class AuctionsController : ControllerBase
{
    private readonly IMediator _mediater;

    public AuctionsController(IMediator mediater)
    {
        this._mediater = mediater;
    }


    /// <summary>
    /// Retrive all auctions that stored on the system 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<AuctionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAuctionsAsync([FromQuery] string? date)
    {
        var auctions = new GetAllAuctionsQuery(date);
        var result = await _mediater.Send(auctions);
        return Ok(result);
    }


    /// <summary>
    /// Get specific auction by auctionId
    /// </summary>
    /// <param name="auctionId"></param>
    /// <returns></returns>
    [HttpGet("{auctionId:guid}")]
    [ProducesResponseType(typeof(AuctionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAuctionByIdAsync(Guid auctionId)
    {
        var auction = new GetAuctionByIdQuery(auctionId);
        var result = await _mediater.Send(auction);
        return result != null ? Ok(result) : NotFound();
    }


    /// <summary>
    /// Create a new auction
    /// </summary>
    /// <param name="createAuctionCommand"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAuction([FromBody] CreateAuctionCommand createAuctionCommand)
    {
        var auction = await _mediater.Send(createAuctionCommand);
        return CreatedAtAction(nameof(CreateAuction), new { id = auction.Id }, auction);
    }


    /// <summary>
    /// update auction data by id
    /// </summary>
    /// <returns></returns>
    [HttpPut("{auctionId:guid}")]
    public async Task<IActionResult> UpdateAuctionAsync(Guid auctionId, UpdateAuctionCommand updateAuctionCommand)
    {
        if (auctionId != updateAuctionCommand.AuctionId)
            return BadRequest();

        try
        {
            var updatedAuction = await _mediater.Send(updateAuctionCommand);
            return Ok(updatedAuction);
        }
        catch (RecordNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    
    /// <summary>
    /// Delete specific auction by auctionId
    /// </summary>
    /// <param name="auctionID"></param>
    /// <returns></returns>
    [HttpDelete("{auctionId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAuctionAsync(Guid auctionID)
    {
        try
        {
            var auction = new DeleteAuctionByIdCommand(auctionID);
            await _mediater.Send(auction);
            return NoContent();
        }
        catch (RecordNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        
    }
}

