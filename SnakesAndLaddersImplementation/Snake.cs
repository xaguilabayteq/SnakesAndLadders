using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Snake : ITransport
{
    public ushort InitialPosition { get; set; }
    public ushort FinalPosition { get; set; }
    public IToken TransportToken(IToken token)
    {
        if(token.Position == InitialPosition)
            token.Position = FinalPosition;
        return token;
    }
    public Snake(ushort initialPosition, ushort finalPosition)
    {
        if(initialPosition <= finalPosition)
            throw new ArgumentException("Initial position must be greater than final position for a Snake");
        InitialPosition = initialPosition;
        FinalPosition = finalPosition;
    }
}
