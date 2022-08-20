using Boardgames.DomainLayer.Managers.DataLayer.DataManagers;
using Boardgames.DomainLayer.Managers.Models;

namespace Boardgames.DomainLayer.Managers.DataLayer;

sealed class DataFacade
{
    BoardgameDataManager? _boardgameDataManager;
    BoardgameDataManager TheBoardgameDataManager => _boardgameDataManager ??= new BoardgameDataManager();

    public BoardgameForGet CreateBoardgame(BoardgameForCreate boardgame)
        => TheBoardgameDataManager.CreateBoardgame(boardgame);

    public BoardgameForGet GetBoardgame(Guid id)
        => TheBoardgameDataManager.GetBoardgame(id);

    public IReadOnlyList<BoardgameForGet> GetAllBoardgames()
        => TheBoardgameDataManager.GetAllBoardgames();
}