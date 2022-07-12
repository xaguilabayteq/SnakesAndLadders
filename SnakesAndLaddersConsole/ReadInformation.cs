namespace SnakesAndLaddersConsole;

public class ReadInformation : IReadInformation
{
    private string TakeInformation(string informationPrompt)
    {
        ConsoleWriter.WritePrompt("{0} ", informationPrompt);
        var value = Console.ReadLine();
        if(value == null)
        {
            var message = string.Format("Error getting value for \"{0}\"", informationPrompt);
            ConsoleWriter.WriteError(message);
            throw new TakingInformationException(message);
        }
        return value;
    }
    public IInformationReaded AskInformation(IInformationToAsk informationAsked)
    {
        IInformationReaded result = new InformationReaded();
        try
        {
            foreach(var information in informationAsked.GetInformationToAsk())
            {
                if(string.IsNullOrEmpty(information.InformationPrompt) || string.IsNullOrEmpty(information.InformationName))
                    continue;
                var value = TakeInformation(information.InformationPrompt);
                
                result.AddInformation(information.InformationName, value);
            }
        }
        catch(Exception ex)
        {
            ConsoleWriter.WriteError("Exception getting information: ({0}) {1}", ex.Message, ex.StackTrace);
            throw;
        }
        return result;
    }
}