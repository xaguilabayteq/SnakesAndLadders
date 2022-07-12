namespace SnakesAndLaddersImplementationTest;
using SnakesAndLaddersImplementation;

[TestClass]
public class TokenTester
{
    [TestMethod]
    public void CreateTokenValidatePositiono()
    {
        var board = new Board(1, 100, 1);
        var token = new Token(board);
        Assert.AreEqual<ushort>(1, token.Position);
    }

    [TestMethod]
    [DataRow((ushort)2)]
    [DataRow((ushort)4)]
    public void MoveTokenADeterminatedNumber(ushort numberPositions)
    {
        var board = new Board(1, 100, 1);
        var token = new Token(board);
        ushort initialPosition = token.Position;
        var moveResult = board.TryToMoveToken(token, numberPositions);
        Assert.IsTrue(moveResult.MoveCorrect);
        Assert.IsFalse(string.IsNullOrEmpty(moveResult.MessageForPlayer));
        Assert.IsNull(moveResult.PosibleTransport);
        ushort newPosition = (ushort)(initialPosition + numberPositions);
        Assert.AreEqual<ushort>(newPosition, token.Position);
    }
    [TestMethod]
    [DataRow((ushort)4)]
    public void TokenKeepsPositionWhenOverpassBoardLimit(ushort numberPositions)
    {
        var board = new Board(1, 100, 1);
        var token = new Token(board)
        {
            Position = 97
        };
        ushort initialPosition = token.Position;
        var moveResult = board.TryToMoveToken(token, numberPositions);
        Assert.IsFalse(moveResult.MoveCorrect);
        Assert.IsFalse(string.IsNullOrEmpty(moveResult.MessageForPlayer));
        Assert.IsNull(moveResult.PosibleTransport);
        Assert.AreEqual<ushort>(initialPosition, token.Position);
    }
 
}