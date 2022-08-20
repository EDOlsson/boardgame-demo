namespace Boardgames.DomainLayer.Managers.Exceptions;

[Serializable]
public class BoardgameNotFoundException : Exception
{
    readonly Guid _notFoundId;

    public BoardgameNotFoundException(Guid id) : base()
    {
        _notFoundId = id;
    }

    public override string ToString() => $"Unable to find the boardgame with the Id : {_notFoundId}";
}