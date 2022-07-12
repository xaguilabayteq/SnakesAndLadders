namespace SnakesAndLaddersInterfaces;
public interface ITurns
{
    IPlayer? CurrentPlayer { get; set; }
    IPlayer? LastPlayer { get; set; }
    IPlayer? NextPlayer { get; set; }
    void AddNewPlayer(IPlayer player);
    IPlayer MoveToNextPlayer();
}
