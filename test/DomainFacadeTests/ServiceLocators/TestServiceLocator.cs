using System.Net.Http;
using Boardgames.DomainLayer;
using Boardgames.DomainLayer.Managers.DataLayer;
using Boardgames.DomainLayer.Managers.Gateways;
using DomainFacadeTests.TestDoubles.Fakes;
using DomainFacadeTests.TestMediators;

namespace DomainFacadeTests.ServiceLocators;

sealed class TestServiceLocator : ServiceLocator
{
    readonly TestMediator _testMediator;

    public TestServiceLocator(TestMediator testMediator)
    {
        _testMediator = testMediator;
    }

    protected override BoardgameGeekGateway CreateBoardgameGeekGatewayCore()
    {
        return new BoardgameGeekGateway(this);
    }

    protected override DataFacade CreateDataFacadeCore()
    {
        return new DataFacade();
    }

    protected override IHttpClientFactory CreateHttpClientFactoryCore()
    {
        return new FakeHttpClientFactory(_testMediator);
    }
}