using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Grid
{
    public class spaceGrid
    {
        //Creates a 2d grid of true/false where false represents asteroids and true represents open space.
        //A second 2d grid of spaceship objects exist alongside. This one will be populated with ship objects and nulls (For empty space)

            //TODO: Someday, turn the grid into an array of ints that can represent multiple hazards (Black holes, wormholes, etc.)

        private bool[,] grid = new bool[10,10];


        private shipClassInterface[,] shipGrid = new shipClassInterface[10,10];
        

        //Default grid: 10x10 empty grid with asteroids bordering the sides.
        public spaceGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i , j] = true;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                grid[i,0] = false;
                grid[0,i] = false;
                grid[9,i] = false;
                grid[i,9] = false;
                
            }
        }

        public Boolean isAsteroid(int row,int col)
        {
            if (grid[row,col] == false)
            {
                return true;
            }
            return false;
        }

        public void addAsteroid(int row, int col)
        {
            this.grid[row,col] = false;
        }
        public void removeAsteroid(int row, int col)
        {
            this.grid[row,col] = true;
        }

        public void AddShip(shipClassInterface ship, int row, int col)
        {
            if (grid[row,col] == false && (shipGrid[row,col] == null))
            {
                shipGrid[row, col] = ship;
                ship.locationRow = row;
                ship.locationCol = col;
            }

        }
        public void RemoveShip(int row, int col)
        {
            if (grid[row, col] == true && (shipGrid[row, col] != null))
            {
                shipGrid[row, col] = null;
            }

        }


    }
}
