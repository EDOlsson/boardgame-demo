using System.Net.Http;
using DomainFacadeTests.TestDoubles.Spies;
using DomainFacadeTests.TestMediators;

namespace DomainFacadeTests.TestDoubles.Fakes;

sealed class FakeHttpClientFactory : IHttpClientFactory
{
    readonly TestMediator _testMediator;

    public FakeHttpClientFactory(TestMediator testMediator)
    {
        _testMediator = testMediator;
    }
    public HttpClient CreateClient(string name)
    {
        var handlerSpy = new HttpMessageHandlerSpy(_testMediator);

        return new HttpClient(handlerSpy);
    }
}