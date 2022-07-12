using SnakesAndLaddersInterfaces;

namespace SnakesAndLaddersImplementation;
public class Board : IBoard
{
    
    public ushort MinimalPosition { get; set; }
    public ushort MaximalPosition { get; set; }
    public ushort InitialPosition { get; set; }
    public IDictionary<ushort, ITransport>? TransportPositions { get; set; }
    public void AddTransport(ITransport transport)
    {
        if(TransportPositions == null)
            throw new Exception("Error, transport dictionary is null.");
        TransportPositions.Add(transport.InitialPosition, transport);
    }
    public IMoveResult TryToMoveToken(IToken token, ushort numberPositions)
    {
        
        if((token.Position + numberPositions) > MaximalPosition)
            return new MoveResult(false, null, string.Format("Token's position {0} plus {1}, is bigger than {2}, so token keeps the initial position.",
                token.Position, numberPositions, MaximalPosition));
        token.Position += numberPositions;
        if(TransportPositions == null || !TransportPositions.ContainsKey(token.Position))
            return new MoveResult(true, null, string.Format("Token's new position is: {0}",
                token.Position));
        var transport = TransportPositions[token.Position];
        token = transport.TransportToken(token);
        return new MoveResult(true, transport, string.Format("Token falls over a {0} its new position is: {1}", transport.GetType().Name,
                token.Position));
    }
    private void AddPredefinedLaddersToBoard()
    {
        ArgumentNullException.ThrowIfNull(TransportPositions, "TransportPositions");
        AddTransport(new Ladder(2, 38));
        AddTransport(new Ladder(7, 14));
        AddTransport(new Ladder(8, 31));
        AddTransport(new Ladder(15, 26));
        AddTransport(new Ladder(28, 84));
        AddTransport(new Ladder(36, 44));
        AddTransport(new Ladder(51, 67));
        AddTransport(new Ladder(60, 64));
        AddTransport(new Ladder(71, 91));
    }

    private void AddPredefinedSnakesToBoard()
    {
        ArgumentNullException.ThrowIfNull(TransportPositions, "TransportPositions");
        AddTransport(new Snake(16, 6));
        AddTransport(new Snake(49, 11));
        AddTransport(new Snake(46, 25));
        AddTransport(new Snake(62, 19));
        AddTransport(new Snake(74, 53));
        AddTransport(new Snake(89, 68));
        AddTransport(new Snake(92, 88));
        AddTransport(new Snake(95, 75));
        AddTransport(new Snake(99, 80));
    }
    public Board(ushort minimalPosition, ushort maximalPosition, ushort initialPosition)
    {
        MinimalPosition = minimalPosition;
        MaximalPosition = maximalPosition;
        InitialPosition = initialPosition;
        TransportPositions = new Dictionary<ushort, ITransport>();
        AddPredefinedLaddersToBoard();
        AddPredefinedSnakesToBoard();
    }
}