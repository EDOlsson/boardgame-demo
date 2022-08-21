using Boardgames.DomainLayer.Managers.DataLayer;
using Boardgames.DomainLayer.Managers.Gateways;

namespace Boardgames.DomainLayer;

class ProductionServiceLocator : ServiceLocator
{
    readonly IHttpClientFactory _httpClientFactory;

    public ProductionServiceLocator(IHttpClientFactory httpClientFactory) : base()
    {
        _httpClientFactory = httpClientFactory;
    }

    protected override BoardgameGeekGateway CreateBoardgameGeekGatewayCore()
    {
        return new BoardgameGeekGateway(_httpClientFactory);
    }

    protected override DataFacade CreateDataFacadeCore()
    {
        return new DataFacade();
    }

    protected override IHttpClientFactory CreateHttpClientFactoryCore()
    {
        return _httpClientFactory;
    }
}