namespace SnakesAndLaddersConsole;
public static class ConsoleWriter
{
    public static void WritePrompt(string message, params object?[] parameters)
    {
        if(string.IsNullOrEmpty(message)) return;
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(message, parameters);
        Console.ForegroundColor = originalColor;
    }
    public static void WriteMessage(string message, params object?[] parameters)
    {
        if(string.IsNullOrEmpty(message)) return;
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message, parameters);
        Console.ForegroundColor = originalColor;
    }
    public static void WriteError(string message, params object?[] parameters)
    {
        if(string.IsNullOrEmpty(message)) return;
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message, parameters);
        Console.ForegroundColor = originalColor;
    }
    public static void WriteWarning(string message, params object?[] parameters)
    {
        if(string.IsNullOrEmpty(message)) return;
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message, parameters);
        Console.ForegroundColor = originalColor;
    }

}