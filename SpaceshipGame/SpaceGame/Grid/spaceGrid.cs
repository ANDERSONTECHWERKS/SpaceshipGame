using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame;
using SpaceshipGame.ShipAssembler;
using SpaceshipGame.Grid;
namespace SpaceshipGame.Grid
{
    public class spaceGrid
    {
        //Creates a 2d spacegrid of true/false where false represents asteroids and true represents open space.
        //TODO: Someday, turn the spacegrid into an array of ints that can represent multiple hazards (Black holes, wormholes, etc.)
        //TODO: Turn shipGrid into a 3D array to handle multiple ships.
        private bool[,] spacegrid;

        ///Establish named constants for use in 'spacegrid'
        public const bool ASTEROID = false;
        public const bool SPACE = true;


        //A second 2d spacegrid of spaceship objects exist alongside. This one is populated with ship objects and nulls (For empty space)
        private AssembledShip[,] shipGrid = new AssembledShip[10,10];
        

        ///Default spacegrid: 10x10 empty spacegrid with asteroids bordering the sides.
        public spaceGrid()
        {
            spacegrid = new bool[10, 10];

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

        ///spaceGrid(sizeRow,sizeCol): pre-determined spacegrid, filled with empty space and bordering rocks.
        public spaceGrid(int sizeRow, int sizeCol)
        {
            spacegrid = new bool[sizeRow, sizeCol];

            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    spacegrid[i, j] = SPACE;
                }
            }
            
            // The following two loops creates a border of asteroids around the map
            for (int i = 0; i < sizeCol-1; i++)
            {
                spacegrid[0, i] = ASTEROID;
                spacegrid[sizeRow, i] = ASTEROID;
            }

            for (int i = 0; i < sizeRow-1; i++)
            {
                spacegrid[i, 0] = ASTEROID;
                spacegrid[sizeCol, sizeRow] = ASTEROID;
            }
        }

        ///isValidMove: Checks if the interrogated row / col is occupied by a ship or asteroid, returns true / false.
        public static Boolean isValidMove(int row, int col, spaceGrid gameGrid)
        {
            int obstacleCheckResult = gameGrid.isObstaclePresent(row, col);

            if (obstacleCheckResult == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        ///isAsteroid: Checks for Asteroid (Boolean: False) at the row / col specified.
        public Boolean isAsteroid(int row,int col)
        {
            if (spacegrid[row,col] == false)
            {
                return true;
            }
            return false;
        }

        ///addAsteroid: Adds asteroid at the row / col specified
        //TODO: Add check for whether or not an asteroid already exists, as well as a ship.
        public void addAsteroid(int row, int col)
        {
            this.spacegrid[row,col] = ASTEROID;
        }

        ///removeAsteroid: Removes an asteroid.
        //TODO: Create check verifying object in row / col is an asteroid ONLY first! No ships! (For whatever reason.)
        public void removeAsteroid(int row, int col)
        {
            this.spacegrid[row,col] = SPACE;
        }

        ///AddShip: adds a ship object at the selected row / col in the ShipGrid.
        //TODO: Check for existing ship or asteroid at row / col.
        public void AddShip(AssembledShip ship, int row, int col)
        {

            if (ship != null)
            {

                if (spacegrid[row, col] == true && (shipGrid[row, col] == null))
                {
                    shipGrid[row, col] = ship;

                    ship.setLocationRow(row);

                    ship.setLocationCol(col);

                }
            }


        }

        ///RemoveShip: sets the specified row / col to null, effectively "Removing" the ship.
        //TODO: Create a check that ensures we are actually removing a ship.
        public void RemoveShip(int row, int col)
        {
            if (spacegrid[row, col] == true && (shipGrid[row, col] != null))
            {
                shipGrid[row, col] = null;
            }

        }

        

        ///isObstaclePresent: Returns 0 if both the spaceGrid and shipGrid at the selected location is empty. 
        //Returns a value other than 0 if an obstacle is in either grid. Currently: 1 if AssembledShip, 2 if Asteroid
        public int isObstaclePresent(int row, int col)
        {
            if (this.shipGrid[row, col] is AssembledShip)
            {
                return 1;
            }

            if (this.spacegrid[row,col] == ASTEROID)
            {
                return 2;
            }

            else
            {
                //Assuming empty space
                return 0;
            }
        }

        //TODO: Finish implementing this method, make design decisions on how to move a vessel.
        public void MoveShip(AssembledShip selectedShip, int destRow, int destCol, spaceGrid gameGrid)
        {
            //Null-Check before assigning variables based off the selectedShip and gameGrid
            if (selectedShip != null && gameGrid != null)
            {
                //Determine current position of object (ship).
                int currentRow = selectedShip.getLocationRow();
                int currentCol = selectedShip.getLocationCol();

                if (isValidMove(destRow, destCol, gameGrid) == true)
                {
                    gameGrid.shipGrid[destRow, destCol] = selectedShip;
                    gameGrid.shipGrid[currentRow, currentCol] = null;

                }
            }
        }
    }
}
