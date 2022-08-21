using Boardgames.DomainLayer.Managers.DataLayer;
using Boardgames.DomainLayer.Managers.Gateways;

namespace Boardgames.DomainLayer;

abstract class ServiceLocator
{
    public DataFacade CreateDataFacade() => CreateDataFacadeCore();

    public IHttpClientFactory CreateHttpClientFactory() => CreateHttpClientFactoryCore();

    public BoardgameGeekGateway CreateBoardgameGeekGateway() => CreateBoardgameGeekGatewayCore();

    protected abstract DataFacade CreateDataFacadeCore();
    protected abstract IHttpClientFactory CreateHttpClientFactoryCore();
    protected abstract BoardgameGeekGateway CreateBoardgameGeekGatewayCore();
}