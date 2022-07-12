namespace SnakesAndLaddersConsole;
public interface IInformationReaded
{
    void AddInformation(string informationName, string informationValue);
    string GetInformation(string informationName);
}