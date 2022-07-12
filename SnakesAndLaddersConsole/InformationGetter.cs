using SnakesAndLaddersImplementation;
using SnakesAndLaddersInterfaces;
namespace SnakesAndLaddersConsole;

public class InformationGetter
{
    public ushort MinimalNumberPlayers { get; set; }
    public ushort MaximalNumberPlayers { get; set; }
    public static IPlayer CreatePlayer(IBoard board, IWriteInformation informationWriter, IReadInformation informationReader)
    {
        IToken token = new Token(board);
        IPlayer player = new Player(token);
        try
        {
            informationWriter.WriteMessage("Please enter players's information:");
            
            InformationToAsk informationToAsk = new();
            informationToAsk.AddInformationToAsk("Please enter Users's name:", "name");

            bool enterOk = false;
            do
            {
                var response = informationReader.AskInformation(informationToAsk);
                if(response == null)
                {
                    informationWriter.WriteError("Error getting information, please try again...");
                    continue;
                }
                var name = response.GetInformation("name");
                if(enterOk = !string.IsNullOrWhiteSpace(name))
                    player.Name = name.Trim();
            } while (!enterOk);
            player.Token.Color = AskTokenInformation(informationWriter, informationReader);
            
        }catch(Exception ex)
        {
            informationWriter.WriteError("Exception getting Token's color: ({0}) {1}", ex.Message, ex.StackTrace);
            throw;
        }
        return player;

    }
    private static void PrintColorOptions(IWriteInformation informationWriter)
    {
        foreach(var item in Enum.GetNames<TokenColor>())
        {
            informationWriter.WriteMessage("\t\t[{0}]", item);
        }

    }
    private static TokenColor AskTokensColor(IWriteInformation informationWriter, IReadInformation informationReader)
    {
        TokenColor color = TokenColor.None;
        InformationToAsk informationToAsk = new();
        informationToAsk.AddInformationToAsk("Please enter Token's color:", "color");

        bool transformOk = false;
        do
        {
            var response = informationReader.AskInformation(informationToAsk);
            if(response == null)
            {
                informationWriter.WriteError("Error getting information, please try again...");
                continue;
            }
            var colorString = response.GetInformation("color");
            
            transformOk = Enum.TryParse<TokenColor>(colorString, true, out color);
            if(!transformOk)
                informationWriter.WriteError("Error, option {0} doesn't exists, please try again...", colorString);
        } while (!transformOk);
        return color;
    }

    private static TokenColor AskTokenInformation(IWriteInformation informationWriter, IReadInformation informationReader)
    {
        TokenColor result;
        try
        {
            informationWriter.WriteMessage("Please enter token's information:");
            informationWriter.WriteMessage("\tEnter token's color:");
            PrintColorOptions(informationWriter);
            result = AskTokensColor(informationWriter, informationReader);
            
        }catch(Exception ex)
        {
            informationWriter.WriteError("Exception getting Token's color: ({0}) {1}", ex.Message, ex.StackTrace);
            throw;
        }
        return result;
    }

    public ushort GetPlayersNumber(IWriteInformation informationWriter, IReadInformation informationReader)
    {
        
        InformationToAsk informationToAsk = new();
        informationToAsk.AddInformationToAsk(string.Format("Enter player's number [{0} - {1}]:", MinimalNumberPlayers, MaximalNumberPlayers), "NumPlayers");
        string numberAsString;
        ushort numberOfPlayers = MinimalNumberPlayers;
        bool errorGettingPlayersNumber;
        do
        {
            var infoEntered = informationReader.AskInformation(informationToAsk);
            if (infoEntered == null)
            {
                errorGettingPlayersNumber = true;
                continue;
            }
            numberAsString = infoEntered.GetInformation("NumPlayers");
            if (!ushort.TryParse(numberAsString, out numberOfPlayers))
            {
                informationWriter.WriteWarning("Error, \"{0}\" can't be transformed, please try again...", numberAsString);
                errorGettingPlayersNumber = true;
                continue;
            }
            if (numberOfPlayers < MinimalNumberPlayers || numberOfPlayers > MaximalNumberPlayers)
            {
                informationWriter.WriteWarning("Error, \"{0}\" is not between {1} and {2}...", numberOfPlayers, MinimalNumberPlayers, MaximalNumberPlayers);
                errorGettingPlayersNumber = true;
                continue;
            }

            errorGettingPlayersNumber = false;
        } while (errorGettingPlayersNumber);

        return numberOfPlayers;
    }

    public ITurns CreateTurns(IBoard board, IWriteInformation informationWriter, IReadInformation informationReader)
    {
        ITurns turn = new Turns();
        try
        {
            ushort numPlayers;
            informationWriter.WriteMessage("~#~#~#~#~#~# Welcome to Snakes and Ladders ~#~#~#~#~#~#");
            numPlayers = GetPlayersNumber(informationWriter, informationReader);
            for (int i = 1; i <= numPlayers; i++)
            {
                informationWriter.WriteMessage("ENTER INFORMATION FOR PLAYER {0}", i);
                var player = CreatePlayer(board, informationWriter, informationReader);
                turn.AddNewPlayer(player);
            }
        }
        catch (Exception ex)
        {
            informationWriter.WriteError("Exception preparing game: ({0}) {1}", ex.Message, ex.StackTrace);
            throw;
        }

        return turn;
    }

    public static void WaitForPlayerAction(IPlayer player, IWriteInformation messageWriter, IReadInformation informationReader)
    {
        ArgumentNullException.ThrowIfNull(player, nameof(player));
        messageWriter.WriteMessage("Turn of Player {0}", player.Name);
        InformationToAsk informationToAsk = new();
        informationToAsk.AddInformationToAsk(player.Name + ":" + player.Token.Position +  "> Press [ENTER] to roll the dice...", "Nothing");

        _ = informationReader.AskInformation(informationToAsk);
    }

}