namespace SnakesAndLaddersImplementationTest;

using SnakesAndLaddersImplementation;
using SnakesAndLaddersInterfaces;
[TestClass]
public class TurnTester
{
    [TestMethod]
    [DataRow("Player's name")]
    public void PutAPlayerInTurn(string name)
    {
        IBoard board = new Board(1, 100, 1);
        IToken token1 = new Token(board);
        IPlayer player = new Player(token1)
        {
            Name = name
        };


        player.Token.Color = TokenColor.Black;
        ITurns turn = new Turns();
        turn.AddNewPlayer(player);
        var gettedPlayer = turn.MoveToNextPlayer();
        Assert.AreSame(player, gettedPlayer);
    }

    [TestMethod]
    [DataRow("Player's name")]
    public void PutTheSamePlayerInTurn(string name)
    {
        var board = new Board(1, 100, 1);
        IToken token1 = new Token(board);
        IPlayer player = new Player(token1)
        {
            Name = name
        };


        player.Token.Color = TokenColor.Black;
        ITurns turn = new Turns();
        IToken token2 = new Token(board);
        IPlayer player2 = new Player(token2)
        {
            Name = name
        };
        player2.Token.Color = TokenColor.Blue;

        turn.AddNewPlayer(player);
        Assert.ThrowsException<PlayerAlreadyExistException>(delegate {turn.AddNewPlayer(player2); });
        var gettedPlayer = turn.MoveToNextPlayer();
        Assert.AreSame(player, gettedPlayer);
    }
    [TestMethod]
    [DataRow("Player 1's name", "Player 2's name")]
    public void Put2PlayerInTurn(string name1, string name2)
    {
        var board = new Board(1, 100, 1);
        IToken token1 = new Token(board);
        IPlayer player = new Player(token1)
        {
            Name = name1
        };
        player.Token.Color = TokenColor.Black;
        ITurns turn = new Turns();
        IToken token2 = new Token(board);
        IPlayer player2 = new Player(token2)
        {
            Name = name2
        };
        player2.Token.Color = TokenColor.Blue;

        turn.AddNewPlayer(player);
        turn.AddNewPlayer(player2);
        var gettedPlayer = turn.MoveToNextPlayer();
        Assert.AreSame(player, gettedPlayer);
        gettedPlayer = turn.MoveToNextPlayer();
        Assert.AreSame(player2, gettedPlayer);
    }
}