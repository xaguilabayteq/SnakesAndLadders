namespace SnakesAndLaddersInterfaces;
public interface ITransport
{
    ushort InitialPosition { get; set; }
    ushort FinalPosition { get; set; }
    IToken TransportToken(IToken token);
}
