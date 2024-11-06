// See https://aka.ms/new-console-template for more information

using DemoDependancyInjection;
using static DemoDependancyInjection.DIGameManager;

//Normal Rock Paper Scissor Program
//GameManager gm = new GameManager();

// Dependency Injection Program
DIGameManager gm = new DIGameManager(new HumanPlayer(), new ComputerPlayer());
do
{

    string[] color = { "Red", "Green", "Yelow" };
    //Console.WriteLine(color[-1]);  //Index Out of Bound Exception during Compile time

    RoundResult result = gm.PlayRound();   

    if (result == RoundResult.Player1Win)
    {
        Console.WriteLine("Player 1 Wins! ");
    }
    else if (result == RoundResult.Player2Win)
    {
        Console.WriteLine("Player 2 Wins! ");
    }
    else
    {
        Console.WriteLine("Its a Draw!");
    }
    Console.WriteLine("Play Again (Y/N) : ");
} while (Console.ReadLine().ToUpper() == "Y");
