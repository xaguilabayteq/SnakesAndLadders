using System.Diagnostics.CodeAnalysis;
using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersImplementation;
public class Player : IPlayer
{
    private readonly IToken _token;

    public string? Name { get; set; }
    public IToken Token
    {
        get
        {
            return _token;
        }

        set
        {
            
            if (_token == null || value == null)
                throw new ArgumentNullException("Token");
            _token.Color = value.Color;
            _token.Position = value.Position;
        }
    }

    public Player([NotNull] IToken token) => _token = token;
}