using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Dice : IDice
{
    public ushort Roll()
    {
        Random random = new((int) DateTime.Now.Ticks);
        
        return (ushort)random.Next(1, 7);
    }
}