using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Grid
{
    public class spaceGrid
    {
        //Creates a 2d spacegrid of true/false where false represents asteroids and true represents open space.
        //TODO: Someday, turn the spacegrid into an array of ints that can represent multiple hazards (Black holes, wormholes, etc.)
        private bool[,] spacegrid = new bool[10,10];

        //Establish named constants for use in 'spacegrid'
        public const bool ASTEROID = false;
        public const bool SPACE = true;


        //A second 2d spacegrid of spaceship objects exist alongside. This one is populated with ship objects and nulls (For empty space)
        private shipClassInterface[,] shipGrid = new shipClassInterface[10,10];
        

        //Default spacegrid: 10x10 empty spacegrid with asteroids bordering the sides.
        public spaceGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    spacegrid[i , j] = true;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                spacegrid[i,0] = false;
                spacegrid[0,i] = false;
                spacegrid[9,i] = false;
                spacegrid[i,9] = false;
                
            }
        }

        //isAsteroid: Checks for Asteroid (Boolean: False) at the row / col specified.
        public Boolean isAsteroid(int row,int col)
        {
            if (spacegrid[row,col] == false)
            {
                return true;
            }
            return false;
        }

        //addAsteroid: Adds asteroid at the row / col specified
        //TODO: Add check for whether or not an asteroid already exists, as well as a ship.
        public void addAsteroid(int row, int col)
        {
            this.spacegrid[row,col] = false;
        }
        public void removeAsteroid(int row, int col)
        {
            this.spacegrid[row,col] = true;
        }

        //AddShip: adds a ship object at the selected row / col in the ShipGrid.
        //TODO: Check for existing ship or asteroid at row / col.
        public void AddShip(shipClassInterface ship, int row, int col)
        {
            if (spacegrid[row,col] == false && (shipGrid[row,col] == null))
            {
                shipGrid[row, col] = ship;
                ship.locationRow = row;
                ship.locationCol = col;
            }

        }

        //RemoveShip: sets the specified row / col to null, effectively "Removing" the ship.
        //TODO: Create a check that ensures we are actually removing a ship.
        public void RemoveShip(int row, int col)
        {
            if (spacegrid[row, col] == true && (shipGrid[row, col] != null))
            {
                shipGrid[row, col] = null;
            }

        }


    }
}
