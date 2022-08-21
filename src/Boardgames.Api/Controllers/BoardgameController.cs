using Boardgames.Api.Models;
using Boardgames.DomainLayer;
using Microsoft.AspNetCore.Mvc;

namespace Boardgames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class BoardgameController : BaseController
{
    public BoardgameController(DomainFacade domainFacade) : base(domainFacade)
    {
    }

    [HttpPost]
    public ActionResult CreateBoardgame(BoardgameForCreate boardgame)
    {
        var newBoardgame = boardgame.Translate();
        var createdBoardgame = TheDomainFacade.CreateNewBoardgame(newBoardgame, BoardgameCaller);

        return CreatedAtAction(nameof(GetBoardgame), new { boardgameId = createdBoardgame.Id }, createdBoardgame);
    }

    [HttpGet("{boardgameId}")]
    public ActionResult GetBoardgame(Guid boardgameId)
    {
        // todo: get boardgame

        return Ok();
    }

    [HttpGet]
    public ActionResult GetAllBoardgames()
    {
        var allBoardgames = TheDomainFacade.GetAllBoardgames(BoardgameCaller);

        return Ok(allBoardgames);
    }
}