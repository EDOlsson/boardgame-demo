using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DomainFacadeTests.Exceptions;

namespace DomainFacadeTests.TestMediators;

sealed class TestMediator
{
    readonly List<HttpRequestMessage> _receivedRequests = new List<HttpRequestMessage>();

    public void AddReceivedRequest(HttpRequestMessage message)
    {
        _receivedRequests.Add(message);
    }

    public HttpRequestMessage GetLastReceivedRequest()
    {
        if (_receivedRequests.Count == 0)
            throw new NoRequestsReceivedException();

        return _receivedRequests.Last();
    }
}