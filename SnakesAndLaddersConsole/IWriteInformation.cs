namespace SnakesAndLaddersConsole;
public interface IWriteInformation
{
    void WriteMessage(string message, params object?[] parameters);
    void WriteError(string message, params object?[] parameters);
    void WriteWarning(string message, params object?[] parameters);
}