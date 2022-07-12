using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Ladder : ITransport
{
    public ushort InitialPosition { get; set; }
    public ushort FinalPosition { get; set; }
    public IToken TransportToken(IToken token)
    {
        if(token.Position == InitialPosition)
            token.Position = FinalPosition;
        return token;
    }
    public Ladder(ushort initialPosition, ushort finalPosition)
    {
        if(initialPosition >= finalPosition)
            throw new ArgumentException("Initial position must be less than final position for a Ladder");
        InitialPosition = initialPosition;
        FinalPosition = finalPosition;
    }
}
