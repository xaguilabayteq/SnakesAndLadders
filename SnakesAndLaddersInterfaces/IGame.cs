namespace SnakesAndLaddersInterfaces;
public interface IGame
{
    IPlayersTurnResult PlayPlayersTurn(ITurns turn, IDice gameDice, IBoard gameBoard);
}