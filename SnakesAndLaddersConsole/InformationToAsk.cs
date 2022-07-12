using SnakesAndLaddersConsole;
public class InformationToAsk : IInformationToAsk
{
    private List<IInformationAsked> _information;
    public void AddInformationToAsk(string prompt, string valueIdToAsk)
    {
        _information.Add(new InformationAsked(prompt, valueIdToAsk));
    }
    public IEnumerable<IInformationAsked> GetInformationToAsk()
    {
        foreach(InformationAsked item in _information)
        {
            yield return item;
        }
    }
    public InformationToAsk()
    {
        _information = new List<IInformationAsked>();
    }
}