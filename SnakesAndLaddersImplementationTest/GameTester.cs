namespace SnakesAndLaddersImplementationTest;
using SnakesAndLaddersImplementation;
using SnakesAndLaddersInterfaces;
[TestClass]
public class GameTester
{
    [TestMethod]
    [DataRow((ushort)97, (ushort)3)]
    public void PlayersWinTokenArriveBoardLimit(ushort initialPosition, ushort numberPositions)
    {
        var board = new Board(1, 100, 1);
        IToken token1 = new Token(board);
        IPlayer player = new Player(token1)
        {
            Name = "Player 1"
        };
        player.Token.Color = TokenColor.Black;
        ITurns turn = new Turns();
        IToken token2 = new Token(board);
        IPlayer player2 = new Player(token2)
        {
            Name = "Player 2"
        };
        player.Token.Color = TokenColor.Blue;
        player.Token.Position = initialPosition;
        turn.AddNewPlayer(player);
        turn.AddNewPlayer(player2);
        DiceFixed dice = new()
        {
            ResponseValue = numberPositions
        };
        var game = new Game();
        var firstPlayer = turn.MoveToNextPlayer();
        var playersTurnResult = game.PlayPlayersTurn(turn, dice, board);
        Assert.IsTrue(playersTurnResult.MoveResult.MoveCorrect);
        Assert.IsFalse(string.IsNullOrEmpty(playersTurnResult.MoveResult.MessageForPlayer));
        Assert.IsNull(playersTurnResult.MoveResult.PosibleTransport);
        if(firstPlayer.Token == null)
            throw new TokenIsNullException("Token is null");
        Assert.AreEqual<ushort>(board.MaximalPosition, firstPlayer.Token.Position);
        Assert.IsTrue(playersTurnResult.RulesResult.HasChanges);
        Assert.IsTrue(playersTurnResult.RulesResult.MessageForPlayer.Contains(" wins..."));
        Assert.IsTrue(playersTurnResult.RulesResult.PlayerHasWin);
        Assert.IsTrue(playersTurnResult.RulesResult.StopGame);
    }
    [TestMethod]
    [DataRow((ushort)1, (ushort)3)]
    [DataRow((ushort)1, (ushort)4)]
    public void PlayersRollDice(ushort initialPosition, ushort numberPositions)
    {
        var board = new Board(1, 100, 1);
        IToken token1 = new Token(board);
        IPlayer player = new Player(token1)
        {
            Name = "Player 1"
        };
        player.Token.Color = TokenColor.Black;
        ITurns turn = new Turns();
        IToken token2 = new Token(board);
        IPlayer player2 = new Player(token2)
        {
            Name = "Player 2"
        };
        player.Token.Position = initialPosition;
        turn.AddNewPlayer(player);
        turn.AddNewPlayer(player2);
        DiceFixed dice = new()
        {
            ResponseValue = numberPositions
        };
        var game = new Game();
        var firstPlayer = turn.MoveToNextPlayer();
        var playersTurnResult = game.PlayPlayersTurn(turn, dice, board);
        Assert.IsTrue(playersTurnResult.MoveResult.MoveCorrect);
        Assert.IsFalse(string.IsNullOrEmpty(playersTurnResult.MoveResult.MessageForPlayer));
        if(playersTurnResult.MoveResult.PosibleTransport == null)
        {
            if(firstPlayer.Token == null)
                throw new TokenIsNullException("Token is null");
            Assert.AreEqual<ushort>((ushort)(initialPosition + numberPositions), firstPlayer.Token.Position);
        }else
        {
            if(firstPlayer.Token == null)
                throw new TokenIsNullException("Token is null");
            Assert.AreEqual<ushort>(playersTurnResult.MoveResult.PosibleTransport.FinalPosition, firstPlayer.Token.Position);
        }
        Assert.IsFalse(playersTurnResult.RulesResult.HasChanges);
        Assert.IsTrue(string.IsNullOrEmpty(playersTurnResult.RulesResult.MessageForPlayer));
        Assert.IsFalse(playersTurnResult.RulesResult.PlayerHasWin);
        Assert.IsFalse(playersTurnResult.RulesResult.StopGame);
    }
}