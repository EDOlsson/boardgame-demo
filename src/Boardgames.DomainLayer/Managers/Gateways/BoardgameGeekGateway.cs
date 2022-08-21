using Boardgames.DomainLayer.Managers.Gateways.Exceptions;

namespace Boardgames.DomainLayer.Managers.Gateways;

sealed class BoardgameGeekGateway
{
    static readonly Uri _baseUri = new Uri("https://boardgamegeek.com/xmlapi/");

    readonly IHttpClientFactory _httpClientFactory;

    public BoardgameGeekGateway(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> SearchForGameAsync(string gameName)
    {
        var urlEncodedName = System.Uri.EscapeDataString(gameName);

        var uri = new System.Uri(_baseUri, $"search?search={urlEncodedName}");

        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        throw new BoardgameGeekSearchFailedException(response.StatusCode, response.ReasonPhrase ?? "(no reason)", gameName);
    }
}