using SnakesAndLaddersConsole;
using SnakesAndLaddersImplementation;
using SnakesAndLaddersInterfaces;

InformationGetter getter = new();
getter.MinimalNumberPlayers = 1;
getter.MaximalNumberPlayers = 10;
IBoard board = new Board(1, 100, 1);
IWriteInformation informationWriter = new WriteInformation();
IReadInformation informationReader = new ReadInformation();
ITurns turns = getter.CreateTurns(board, informationWriter, informationReader);
IDice dice = new Dice();
IGame game = new Game();
IPlayersTurnResult playersTurnResult;
do
{
    var player = turns.MoveToNextPlayer();
    InformationGetter.WaitForPlayerAction(player, informationWriter, informationReader);
    playersTurnResult = game.PlayPlayersTurn(turns, dice, board);
    informationWriter.WriteMessage("{1}:{2}> Dice's roll result: {0}", playersTurnResult.DiceRollResult, player.Name, player.Token.Position);
    if(playersTurnResult.MoveResult.MoveCorrect)
    {
        if(playersTurnResult.MoveResult.PosibleTransport != null)
            informationWriter.WriteWarning(player.Name + ":" + player.Token.Position + "> " + playersTurnResult.MoveResult.MessageForPlayer);
        else
            informationWriter.WriteMessage(player.Name + ":" + player.Token.Position + "> " + playersTurnResult.MoveResult.MessageForPlayer);
    }
    else
        informationWriter.WriteError(player.Name + ":" + player.Token.Position + "> " + playersTurnResult.MoveResult.MessageForPlayer);
    if(playersTurnResult.RulesResult.HasChanges)
        informationWriter.WriteWarning(player.Name + ":" + player.Token.Position + "> " + playersTurnResult.RulesResult.MessageForPlayer);
} while (!playersTurnResult.RulesResult.StopGame);

informationWriter.WriteMessage("Game is over...!!");
