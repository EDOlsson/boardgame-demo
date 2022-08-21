namespace Boardgames.DomainLayer.Managers.Gateways.Exceptions;

[Serializable]
public class BoardgameGeekSearchFailedException : Exception
{
    readonly System.Net.HttpStatusCode _statusCode;
    readonly string _message;
    readonly string _boardgameName;

    public BoardgameGeekSearchFailedException(System.Net.HttpStatusCode statusCode, string message, string boardgameName)
    {
        _statusCode = statusCode;
        _message = message;
        _boardgameName = boardgameName;
    }

    public override string ToString()
    {
        return $"Status code [{_statusCode}] when searching for game {_boardgameName}{Environment.NewLine}{_message}";
    }
}