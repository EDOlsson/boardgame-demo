using Boardgames.DomainLayer.Managers.DataLayer;

namespace Boardgames.DomainLayer;

class ProductionServiceLocator : ServiceLocator
{
    protected override DataFacade CreateDataFacadeCore()
    {
        return new DataFacade();
    }
}