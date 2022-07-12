using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class PlayersTurnResult : IPlayersTurnResult
{
    public ushort DiceRollResult { get; set; }
    public IMoveResult MoveResult { get; set; }
    public IGameRulesResult RulesResult { get; set; }

    public PlayersTurnResult(ushort diceRollResult, IMoveResult moveResult, IGameRulesResult rulesResult)
    {
        DiceRollResult = diceRollResult;
        MoveResult = moveResult;
        RulesResult = rulesResult;
    }

}