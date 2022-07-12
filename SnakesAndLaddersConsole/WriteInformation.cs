namespace SnakesAndLaddersConsole;
public class WriteInformation : IWriteInformation
{
    public void WriteMessage(string message, params object?[] parameters)
    {
        ConsoleWriter.WriteMessage(message, parameters);
    }
    public void WriteError(string message, params object?[] parameters)
    {
        ConsoleWriter.WriteError(message, parameters);
    }
    public void WriteWarning(string message, params object?[] parameters)
    {
        ConsoleWriter.WriteWarning(message, parameters);
    }

}
