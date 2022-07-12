using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class GameRulesResult : IGameRulesResult
{
    private bool stopGame;
    private bool hasChanges;
    private bool playerHasWin;
    private bool turnHasBeenAfected;

    public bool HasChanges
    { 
        get => hasChanges;
        set
        {
            hasChanges = value;
            if(!hasChanges)
            {
                stopGame = false;
                hasChanges = false;
                playerHasWin = false;
                turnHasBeenAfected = false;
            }
        }
    }

    public bool StopGame
    {
        get => stopGame;
        set
        {
            stopGame = value;
            if(stopGame)
                HasChanges = true;
        }
    }
    public bool PlayerHasWin
    {
        get => playerHasWin;
        set
        {
            playerHasWin = value;
            if(playerHasWin)
                HasChanges = true;
        }
    }

    public bool TurnHasBeenAfected
    {
        get => turnHasBeenAfected;
        set
        {
            turnHasBeenAfected = value;
            if(turnHasBeenAfected)
                HasChanges = true;
        }
    }

    public string MessageForPlayer { get; set; }
    public GameRulesResult()
    {
        stopGame = false;
        playerHasWin = false;
        turnHasBeenAfected = false;
        hasChanges = false;
        MessageForPlayer = string.Empty;
    }
}