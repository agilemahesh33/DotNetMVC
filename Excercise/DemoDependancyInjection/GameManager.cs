using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDependancyInjection
{
    public class GameManager
    {
        Random _rand = new Random();
        public RoundResult PlayRound()
        {
            //Player 1 (Human)
            Choice p1;
            do
            {
                Console.WriteLine("Enter Choice : (R)Rock,(P)Paper, (S)Scissors : ");
                string strInput = Console.ReadLine().ToUpper();
                if(strInput =="R")
                {
                    p1 = Choice.Rock;
                    break;
                }
                else if(strInput=="P")
                {
                    p1=Choice.Paper; 
                    break;
                }
                else if (strInput=="S")
                {
                    p1 = Choice.Scissors; 
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice ! Try Again ");
                }
            } while (true);

            //Player 2 (Computer)
            Choice p2 =(Choice)_rand.Next(0,3);
            Console.WriteLine("Player 2 Picked : " + p2.ToString());
            if(p1 == p2)
            {
                Console.WriteLine(RoundResult.Draw);
            }
            if(((p1 == Choice.Rock) && (p2==Choice.Scissors))||
                ((p1==Choice.Paper) && (p2==Choice.Rock)) ||
                ((p1 == Choice.Scissors) &&(p2==Choice.Paper)))
            {
                return RoundResult.Player1Win;
            }
            return RoundResult.Player2Win;            
        }
        public enum Choice
        {
            Rock,
            Paper,
            Scissors
        }
        public enum RoundResult
        {
            Player1Win,
            Player2Win,
            Draw
        }
    }
}
