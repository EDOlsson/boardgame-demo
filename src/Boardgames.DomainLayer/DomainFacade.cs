using Boardgames.DomainLayer.Managers;
using Boardgames.DomainLayer.Managers.Models;

namespace Boardgames.DomainLayer;

public sealed class DomainFacade
{
    readonly ServiceLocator _serviceLocator;
    
    BoardgameManager? _boardgameManager;
    BoardgameManager TheBoardgameManager { get { return _boardgameManager ??= new BoardgameManager(_serviceLocator); } }

    public DomainFacade() : this(new ProductionServiceLocator()) { }

    internal DomainFacade(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    public BoardgameForGet CreateNewBoardgame(BoardgameForCreate boardgameForCreate, AuthenticatedContext authContext)
        => TheBoardgameManager.CreateNewBoardgame(boardgameForCreate, authContext);

    public IReadOnlyList<BoardgameForGet> GetAllBoardgames(AuthenticatedContext authContext)
        => TheBoardgameManager.GetAllBoardgames(authContext);
}