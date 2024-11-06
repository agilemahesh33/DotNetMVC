using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoDependancyInjection.DIGameManager;

namespace DemoDependancyInjection
{
    public class ComputerPlayer : IPlayer
    {
        Random _rand = new Random();
        public Choice GetChoice()
        {
            //Player 2 (Computer)
            Choice p2 = (Choice)_rand.Next(0, 3);
            //Console.WriteLine("Player 2 Picked : " + p2.ToString());
            return p2;
        }        
    }
}
