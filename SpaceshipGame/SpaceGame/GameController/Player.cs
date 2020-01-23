using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame;
using SpaceshipGame.ShipAssembler;
using SpaceshipGame.Grid;

namespace SpaceshipGame.SpaceGame.GameController
{
    class Player
    {
        string PlayerName = "Default Player Name";
        public List<AssembledShip> PlayerShips = new List<AssembledShip>();


        public Player()
        {
            Console.WriteLine("Enter player name:");
            PlayerName = Console.ReadLine();

            Console.WriteLine("----SHIP ASSEMBLY----");
            PlayerShips.Add(AssembledShip.AssembleMenu());
        }

        public Boolean IsPlayerDead()
        {
            if (this.PlayerShips.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

 
        }
    }
}
