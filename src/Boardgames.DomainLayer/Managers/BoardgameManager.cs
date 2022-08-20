using Boardgames.DomainLayer.Managers.DataLayer;
using Boardgames.DomainLayer.Managers.Models;

namespace Boardgames.DomainLayer.Managers;

sealed class BoardgameManager
{
    readonly ServiceLocator _serviceLocator;

    DataFacade? _dataFacade;
    DataFacade TheDataFacade => _dataFacade ??= _serviceLocator.CreateDataFacade();

    public BoardgameManager(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    public BoardgameForGet CreateNewBoardgame(BoardgameForCreate boardgameForCreate, AuthenticatedContext authContext)
    {
        var createdBoardgame = TheDataFacade.CreateBoardgame(boardgameForCreate);

        return createdBoardgame;
    }

    public IReadOnlyList<BoardgameForGet> GetAllBoardgames(AuthenticatedContext authContext)
    {
        var allBoardgames = TheDataFacade.GetAllBoardgames();

        return allBoardgames;
    }
}