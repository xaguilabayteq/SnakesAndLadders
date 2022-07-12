namespace SnakesAndLaddersConsole;
public interface IInformationToAsk
{
    void AddInformationToAsk(string prompt, string valueIdToAsk);
    IEnumerable<IInformationAsked> GetInformationToAsk();
}