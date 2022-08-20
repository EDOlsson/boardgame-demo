using Boardgames.DomainLayer.Managers.Exceptions;
using Boardgames.DomainLayer.Managers.Models;

namespace Boardgames.DomainLayer.Managers.DataLayer.DataManagers;

sealed class BoardgameDataManager
{
    static readonly Dictionary<Guid, BoardgameForGet> _dummyDatastore = new Dictionary<Guid, BoardgameForGet>();

    public BoardgameDataManager()
    {

    }

    public BoardgameForGet CreateBoardgame(BoardgameForCreate boardgame)
    {
        var newId = Guid.NewGuid();
        var boardgameForGet = new BoardgameForGet(newId, boardgame.Name, boardgame.Category, boardgame.NumPlayers);

        _dummyDatastore[newId] = boardgameForGet;

        return boardgameForGet;
    }

    public IReadOnlyList<BoardgameForGet> GetAllBoardgames()
    {
        return _dummyDatastore.Values.ToList();
    }

    public BoardgameForGet GetBoardgame(Guid id)
    {
        if (_dummyDatastore.TryGetValue(id, out var foundBoardgame))
            return foundBoardgame;

        throw new BoardgameNotFoundException(id);
    }
}