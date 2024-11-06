using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoDependancyInjection.DIGameManager;

namespace DemoDependancyInjection
{
    public class HumanPlayer : IPlayer
    {
        public Choice GetChoice()
        {
            //Player 1 (Human)
            Choice p1;
            do
            {
                Console.WriteLine("Enter Choice : (R)Rock,(P)Paper, (S)Scissors : ");
                string strInput = Console.ReadLine().ToUpper();
                if (strInput == "R")
                {
                    p1 = Choice.Rock;
                    break;
                }
                else if (strInput == "P")
                {
                    p1 = Choice.Paper;
                    break;
                }
                else if (strInput == "S")
                {
                    p1 = Choice.Scissors;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice ! Try Again ");
                }
            } while (true);
            return p1;
        }
    }
}
