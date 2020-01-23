using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame;
using SpaceshipGame.ShipAssembler;

namespace SpaceshipGame.SpaceGame.GameController
{
    class CPU
    {

        private string CPUName = "Default CPU Name";
        public List<AssembledShip> CPUships = new List<AssembledShip>();


        public CPU(String CPUname, List<AssembledShip> CPUships)
        {
            Console.WriteLine("Enter player name:");
            CPUName = Console.ReadLine();

            Console.WriteLine("----SHIP ASSEMBLY----");
            CPUships.Add(AssembledShip.AssembleMenu());
        }

        public Boolean IsCPUDead()
        {
            if (this.CPUships.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<AssembledShip> GetCPUShipList()
        {
            List<AssembledShip> tempShips = new List<AssembledShip>(this.CPUships);
            return tempShips;
        }

        public void DetectEnemy()
        {
            foreach (AssembledShip CPUship in CPUships)
            {

            }
        }


    }
}
