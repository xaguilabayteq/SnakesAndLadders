namespace SnakesAndLaddersInterfaces;
public interface IMoveResult
{
    bool MoveCorrect { get; set; }
    ITransport? PosibleTransport { get; set; }
    string? MessageForPlayer { get; set; }
}