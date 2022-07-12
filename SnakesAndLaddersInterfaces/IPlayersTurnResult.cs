namespace SnakesAndLaddersInterfaces;
public interface IPlayersTurnResult
{
    ushort DiceRollResult { get; set; }
    IMoveResult MoveResult { get; set; }
    IGameRulesResult RulesResult { get; set; }
}