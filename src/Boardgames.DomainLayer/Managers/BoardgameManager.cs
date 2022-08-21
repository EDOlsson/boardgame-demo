using Boardgames.DomainLayer.Managers.DataLayer;
using Boardgames.DomainLayer.Managers.Gateways;
using Boardgames.DomainLayer.Managers.Models;

namespace Boardgames.DomainLayer.Managers;

sealed class BoardgameManager
{
    readonly ServiceLocator _serviceLocator;

    DataFacade? _dataFacade;
    DataFacade TheDataFacade => _dataFacade ??= _serviceLocator.CreateDataFacade();

    BoardgameGeekGateway? _boardgameGeekGateway;
    BoardgameGeekGateway TheBoardgameGeekGateway => _boardgameGeekGateway ??= _serviceLocator.CreateBoardgameGeekGateway();

    public BoardgameManager(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    public async Task<BoardgameForGet> CreateNewBoardgameAsync(BoardgameForCreate boardgameForCreate, AuthenticatedContext authContext)
    {
        var response = await TheBoardgameGeekGateway.SearchForGameAsync(boardgameForCreate.Name);

        var createdBoardgame = TheDataFacade.CreateBoardgame(boardgameForCreate);

        return createdBoardgame;
    }

    public IReadOnlyList<BoardgameForGet> GetAllBoardgames(AuthenticatedContext authContext)
    {
        var allBoardgames = TheDataFacade.GetAllBoardgames();

        return allBoardgames;
    }
}