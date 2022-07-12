using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class MoveResult : IMoveResult
{
    public bool MoveCorrect { get; set; }
    public ITransport? PosibleTransport { get; set; }
    public string? MessageForPlayer { get; set; }

    public MoveResult(bool moveCorrect, ITransport? posibleTransport, string messageForPlayer)
    {
        MoveCorrect = moveCorrect;
        PosibleTransport = posibleTransport;
        MessageForPlayer = messageForPlayer;
    }
}