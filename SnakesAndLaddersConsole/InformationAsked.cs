namespace SnakesAndLaddersConsole;
public class InformationAsked : IInformationAsked
{
    public string InformationPrompt { get; set; }
    public string InformationName { get; set; }
    public InformationAsked(string informationPrompt, string informationName)
    {
        InformationPrompt = informationPrompt;
        InformationName = informationName;
    }
}