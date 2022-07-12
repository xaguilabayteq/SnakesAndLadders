namespace SnakesAndLaddersConsole;
public class InformationReaded : IInformationReaded
{
    Dictionary<string, string> information;
    public void AddInformation(string informationName, string informationValue)
    {
        information.Add(informationName, informationValue);
    }
    public string GetInformation(string informationName)
    {
        return information[informationName];
    }

    public InformationReaded()
    {
        information = new Dictionary<string, string>();
    }
}