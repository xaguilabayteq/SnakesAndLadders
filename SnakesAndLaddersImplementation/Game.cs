
using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Game : IGame
{
    private static IGameRulesResult ApplyGameRules(IBoard board, ITurns turn)
    {
        if(turn.CurrentPlayer == null)
            throw new CurrentPlayerDoesntExistException("Error, current player doesn't exists");
        if(turn.CurrentPlayer.Token == null)
            throw new TokenIsNullException("Error, Token is null");
        var result = new GameRulesResult();
        
        if(turn != null && turn.CurrentPlayer != null && turn.CurrentPlayer.Token.Position == board.MaximalPosition)
        {
            result.PlayerHasWin = true;
            result.StopGame = true;
            result.MessageForPlayer = string.Format("Player {0} wins...", turn.CurrentPlayer.Name);
        }
        return result;
    }

    public IPlayersTurnResult PlayPlayersTurn(ITurns turn, IDice gameDice, IBoard gameBoard)
    {
        if(turn.CurrentPlayer == null)
            throw new CurrentPlayerDoesntExistException("Error, current player doesn't exists");
        if(turn.CurrentPlayer.Token == null)
            throw new TokenIsNullException("Error, Token is null");
        var diceRollResult = gameDice.Roll();
        var moveResult = gameBoard.TryToMoveToken(turn.CurrentPlayer.Token, diceRollResult);
        var gameRulesResult = ApplyGameRules(gameBoard, turn);
        return new PlayersTurnResult(diceRollResult, moveResult, gameRulesResult);
    }
 
}