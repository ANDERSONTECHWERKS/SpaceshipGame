using System;
using System.Collections.Generic;
using SpaceshipGame;
using SpaceshipGame.Components;
using SpaceshipGame.Grid;
using SpaceshipGame.ShipAssembler;
using SpaceshipGame.SpaceGame.GameController;
using SpaceshipGame.SpaceGame.EnvironmentModifiers;
using SpaceshipGame.SpaceGame.Grid;

namespace SpaceshipGame
{
    class SpaceshipGame
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" S-P-A-C-E -----------------------------------");
            Console.WriteLine("---------- G-A-M-E ---------------------------");
            Console.WriteLine("--------------------- 8 8 --------------------");

            int SpaceGameTerm = 1;

            do
            {
                int newTermSignal = NewGame();
                SpaceGameTerm = newTermSignal;
            } while (SpaceGameTerm != 0);



        }

        //newGame: Prompts user for a new game, enters a do-while loop that loops until MainMenu() returns 0, where it will terminate.
        static int NewGame()
        {
            Console.WriteLine("New game? Y/N.");

            String response = Console.ReadLine();
            String responseToLower = response.ToLower();

            if (responseToLower.Equals("y"))
            {
                int NewGameTermSignal;

                do
                {
                    int termSignal = MainMenu();
                    NewGameTermSignal = termSignal;

                } while (NewGameTermSignal != 0);

                return 0;
            }

            if (responseToLower.Equals("n"))
            {
                return 0;
            }


            //If the parsed response isn't a y/n: Yell at them.
            while (!responseToLower.Equals("y") || !responseToLower.Equals("n"))
            {
                Console.WriteLine("Invalid selection. Please type Y or N.");
                return 1;
            }

            Console.WriteLine("Menu fallthrough: Returning 1");
            return 1;
        }

        static int MainMenu()
        {
            Console.WriteLine("----GAME SETTINGS----\n");
            Console.WriteLine("Map Size? (Enter number less than 100)\n");
            string userSizeString = Console.ReadLine();
            int userSizeInput = Int32.Parse(userSizeString);

            if (userSizeInput > 100)
            {
                Console.WriteLine($"Height Entered: {userSizeInput} is invalid. Must be less than 100.");
                return 0;
            }
            Console.WriteLine($"Creating Space Grid of ( {userSizeInput} x {userSizeInput} )\n");

            spaceGrid mainGrid = new spaceGrid(userSizeInput, userSizeInput);

            // Create Player, add them to a list (of 1, currently)
            Player mainPlayer = new Player();
            List<Player> playerList = new List<Player>(1);

            playerList.Add(mainPlayer);
            
            //Instantiate and apply a default environment
            //TODO: Make environments do things.
            SpaceGame.EnvironmentModifiers.Environment defaultEnv = new SpaceGame.EnvironmentModifiers.Environment();

            //Create new GameSentinel Object (Game arena) using the provided grid settings, PlayerList, and EnvironmentVariables.

            GameSentinel mainSentinel = new GameSentinel(mainGrid, defaultEnv,playerList);

            //Test DrawShipGrid, since I can't make it work with unit tests.

            int TermConfirm = -1;
            do
            {
                GridDraw.DrawShipGrid(mainGrid);
                int TermSignal = GameSentinel.PerformTurn(mainSentinel);
                TermConfirm = TermSignal;
            } while (TermConfirm != 0);

            Console.WriteLine("Exiting game!");

            return 0;
        }

    }
}



