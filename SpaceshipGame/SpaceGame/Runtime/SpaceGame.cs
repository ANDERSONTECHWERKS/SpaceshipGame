using System;
using System.Collections.Generic;
using SpaceshipGame;
using SpaceshipGame.Components;
using SpaceshipGame.Grid;
using SpaceshipGame.ShipAssembler;
namespace SpaceshipGame
{
    class SpaceGame
    {
        static void Main(string[] args)
        {
            int confirmMenuResult;

            Console.WriteLine(" S-P-A-C-E -----------------------------------");
            Console.WriteLine("---------- G-A-M-E ---------------------------");
            Console.WriteLine("------------------ -- 8 8 --------------------");

            //gameGrid: Instantiate a new, default 10x10 spacegrid
            spaceGrid gameGrid = new spaceGrid();

            //assembledShip: Runs the user through the ship creation menu and assigns the current
            AssembledShip assembledShip = AssembledShip.AssembleMenu();

            //confirmMenuResult: Prompts user to verify the prior selection by making calls to assembledShip getters.
            confirmMenuResult = ClassComponentSelect.confirmSelection(assembledShip.getName(),assembledShip.getComponents(),assembledShip.getShipClassObject());

            Console.WriteLine(assembledShip.ToString());
        }
    }
}



