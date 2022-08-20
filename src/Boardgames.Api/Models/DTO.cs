namespace Boardgames.Api.Models;

public record BoardgameForCreate(string Name, string Category, int NumPlayers);
public record BoardgameForGet(Guid Id, string Name, string Category, int NumPlayers);
