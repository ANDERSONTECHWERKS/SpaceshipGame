using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame;
using SpaceshipGame.Grid;
using SpaceshipGame.ShipAssembler;
using SpaceshipGame.SpaceGame;
using SpaceshipGame.SpaceGame.EnvironmentModifiers;

namespace SpaceshipGame.SpaceGame.GameController
{
    class GameSentinel
    {
        ///GameSentinel: (Concept/Theory: GameSentinel will instantiate the spaceGrid object, manage turns, and handle victory / defeat conditions. The object itself will represent a "Game".
        //TODO: Implement CPU List

        private spaceGrid grid;
        private EnvironmentModifiers.Environment envMod;
        private List<Player> PlayerList;
        private List<CPU> CPUlist;


        //PerformTurn: Goes through each human player (ActivePlayer) and prompts them for their turn. Then moves through CPU players and performs their turn.

            //TODO:
            //Que CPU turn, implement CPU list. Think of more ways to play.
            //Populate switch menu. Player options are split between the driving method PerformTurn(this) and the presentation layer of PlayerTurnPrompt.

        public static int PerformTurn(GameSentinel activeGame)
        {
            foreach (Player ActivePlayer in activeGame.PlayerList)
            {
                int PlayerChoice = activeGame.PlayerTurnPrompt();

                //Verify only living players are taking turns!
                if (!ActivePlayer.IsPlayerDead())
                {

                    switch (PlayerChoice)
                    {
                        case 0:
                            return 0;

                        case 1:
                            foreach (AssembledShip PlayerShip in ActivePlayer.PlayerShips)
                            {
                                activeGame.PlayerMoveShip(PlayerShip);
                                return 1;
                            }
                            break;
                        

                    }
                }

            }

            //Catch-all exit.
            Console.WriteLine("Something Went wrong in GameSentinel. Exiting.");
            return 0;

            // Next we roll through CPU turns.
            //TODO: Complete CPU turns once you have finished writing CPU selection / Object

            //foreach (CPU ActiveCPU in activeGame.CPUlist)
            //{


            //    //Verify only living CPU's are taking turns!
            //    if (!ActiveCPU.IsCPUDead())
            //    {


            //    }

            //}



            Console.WriteLine("End of turn!");
        }

        //The Menu of options presented to a player. Returns 0 to exit. responseConf verifies that a valid option has been chosen.
        //TODO: Find a better menu management system than response codes.
        private int PlayerTurnPrompt()
        {
            int responseConf = 0;


                Console.WriteLine("Choose an action:\n1.Move\n2.Exit.");

                //Parse string to int
                string response = Console.ReadLine();
                int response0 = Int32.Parse(response);

            while (responseConf != 1)
            {

                if (response0 == 1)
                {
                    responseConf = 1;
                    return response0;
                }

                if (response0 == 2)
                {
                    responseConf = 1;
                    return 0;
                }

                Console.WriteLine("INVALID INPUT! Please make a selection.");

            } 

            return 0;
        }

        private void PlayerMoveShip( AssembledShip currentShip)
        {
            Console.WriteLine($"You selected 'MOVE'. Moving {0}\n",currentShip);
            Console.WriteLine("Enter destination Column:");

            string responseColString = Console.ReadLine();
            int responseCol = Int32.Parse(responseColString);



            Console.WriteLine("Enter destination Row:");

            string responseRowString = Console.ReadLine();
            int responseRow = Int32.Parse(responseRowString);


            Console.WriteLine($"Moving to Column {responseCol}, Row: {responseRow}");

            spaceGrid.MoveShip(currentShip, responseRow, responseRow, grid);

            Console.WriteLine($"Moved to Column {responseCol}, Row: {responseRow}");

            return;
        }

        public GameSentinel(spaceGrid gridInput, EnvironmentModifiers.Environment envModInput, List<Player> humanPlayers)
        {
            grid = gridInput;
            envMod = envModInput;
            PlayerList = humanPlayers;
        }

        public int GetPlayerCount()
        {
            int count = 0;

            foreach (Player playerCount in this.PlayerList)
            {
                if (playerCount != null)
                {
                    count++;
                }
            }
            return count;
        }

        public List<Player> GetPlayerList()
        {
            return this.PlayerList;
        }

        public EnvironmentModifiers.Environment GetCurrentEnvironment()
        {
            return this.envMod;
        }

    }
}
