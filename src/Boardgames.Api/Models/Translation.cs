namespace Boardgames.Api.Models;

static class Translation
{
    public static Boardgames.DomainLayer.Managers.Models.BoardgameForCreate Translate(this Boardgames.Api.Models.BoardgameForCreate boardgame)
        => new DomainLayer.Managers.Models.BoardgameForCreate(boardgame.Name, boardgame.Category, boardgame.NumPlayers);
}