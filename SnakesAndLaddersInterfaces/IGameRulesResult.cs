namespace SnakesAndLaddersInterfaces;
public interface IGameRulesResult
{
    bool HasChanges { get; set; }
    bool StopGame { get; set; }
    bool PlayerHasWin { get; set; }
    bool TurnHasBeenAfected { get; set; }
    string MessageForPlayer { get; set; }
}