using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Token : IToken
{
    public TokenColor Color { get; set; }
    public ushort Position { get; set; }
    public Token(IBoard board)
    {
        Position = board.InitialPosition;
    }
}
