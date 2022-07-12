using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementationTest;
public class DiceFixed : IDice
{
    public ushort ResponseValue { get; set; }
    public ushort Roll()
    {
        return ResponseValue;
    }
}