using Boardgames.DomainLayer.Managers;
using Boardgames.DomainLayer.Managers.Models;

namespace Boardgames.DomainLayer;

public sealed class DomainFacade
{
    readonly ServiceLocator _serviceLocator;
    
    BoardgameManager? _boardgameManager;
    BoardgameManager TheBoardgameManager { get { return _boardgameManager ??= new BoardgameManager(_serviceLocator); } }

    public DomainFacade(IHttpClientFactory httpClientFactory) : this(new ProductionServiceLocator(httpClientFactory)) { }

    internal DomainFacade(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    public Task<BoardgameForGet> CreateNewBoardgameAsync(BoardgameForCreate boardgameForCreate, AuthenticatedContext authContext)
        => TheBoardgameManager.CreateNewBoardgameAsync(boardgameForCreate, authContext);

    public IReadOnlyList<BoardgameForGet> GetAllBoardgames(AuthenticatedContext authContext)
        => TheBoardgameManager.GetAllBoardgames(authContext);
}