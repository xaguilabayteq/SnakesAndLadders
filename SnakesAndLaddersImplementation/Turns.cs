using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Turns : ITurns
{
    private Queue<IPlayer> Players { get; set; }
    private IPlayer? _currentPlayer;
    public IPlayer? CurrentPlayer { 
        get
        {
            return _currentPlayer;
        }
        set
        { 
            LastPlayer = _currentPlayer;
            _currentPlayer = value;
        }
    }
    public IPlayer? LastPlayer { get; set; }
    public IPlayer? NextPlayer { get; set; }
    public void AddNewPlayer(IPlayer player)
    {
        foreach(var actualPlayer in Players)
            if(!string.IsNullOrEmpty(actualPlayer.Name) && actualPlayer.Name.Equals(player.Name))
                throw new PlayerAlreadyExistException(string.Format("Player {0} already exist.", player.Name));
        Players.Enqueue(player);
    }

    public IPlayer MoveToNextPlayer()
    {
        CurrentPlayer = Players.Dequeue();
        Players.Enqueue(CurrentPlayer);
        NextPlayer = Players.Peek();
        return CurrentPlayer;
    }
    public Turns()
    {
        Players = new Queue<IPlayer>();
    }
}