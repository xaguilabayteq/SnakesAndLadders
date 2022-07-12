namespace SnakesAndLaddersInterfaces;
public interface IPlayer
{
    string? Name { get; set; }
    IToken Token { get; set; }
}
