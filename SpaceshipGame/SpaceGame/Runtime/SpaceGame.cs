using System;
using System.Collections.Generic;
namespace SpaceshipGame
{
    class SpaceGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" S-P-A-C-E -----------------------------------");
            Console.WriteLine("---------- G-A-M-E ---------------------------");
            Console.WriteLine("------------------ -- 8 8 --------------------");

            //assembledShip: Runs the user through the ship creation menu and assigns the current
            ShipAssembler.AssembledShip assembledShip = ShipAssembler.AssembledShip.AssembleMenu();

            assembledShip.ToString();
        }
    }
}



