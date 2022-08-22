using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DomainFacadeTests.TestMediators;

namespace DomainFacadeTests.TestDoubles.Spies;

sealed class HttpMessageHandlerSpy : HttpMessageHandler
{
    readonly TestMediator _testMediator;

    public HttpMessageHandlerSpy(TestMediator testMediator)
    {
        _testMediator = testMediator;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _testMediator.AddReceivedRequest(request);

        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent("test response") };
        return Task.FromResult(response);
    }

}