using Boardgames.DomainLayer.Managers.DataLayer;

namespace Boardgames.DomainLayer;

abstract class ServiceLocator
{
    public DataFacade CreateDataFacade() => CreateDataFacadeCore();

    protected abstract DataFacade CreateDataFacadeCore();
}