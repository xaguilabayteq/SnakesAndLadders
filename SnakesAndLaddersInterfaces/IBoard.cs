namespace SnakesAndLaddersInterfaces;
public interface IBoard
{
    ushort MinimalPosition { get; set; }
    ushort MaximalPosition { get; set; }
    ushort InitialPosition { get; set; }
    IDictionary<ushort, ITransport>? TransportPositions { get; set; }
    void AddTransport(ITransport transport);
    IMoveResult TryToMoveToken(IToken token, ushort numberPositions);
}