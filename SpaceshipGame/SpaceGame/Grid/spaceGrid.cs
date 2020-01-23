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

        //Establish named constants for common navigation references
        //TODO: implement navigation system
        public const int UP = 0;
        public const int DOWN = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;
        public const int UP_AND_LEFT = 4;
        public const int UP_AND_RIGHT = 5;
        public const int DOWN_AND_LEFT = 6;
        public const int DOWN_AND_RIGHT = 7;
        public const int CENTER = 8;




        //A second 2d spacegrid of spaceship objects exist alongside. This one is populated with ship objects and nulls (For empty space)
        private AssembledShip[,] shipGrid;
        

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

            shipGrid = new AssembledShip[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    shipGrid[i, j] = null;
                }
            }

        }

        //spaceGrid copy constructor
        public spaceGrid(spaceGrid copyGrid)
        {
            this.shipGrid = (AssembledShip[,])copyGrid.shipGrid.Clone();
            this.spacegrid = (bool[,])copyGrid.spacegrid.Clone();
        }

        ///spaceGrid(sizeRow,sizeCol): user-determined spacegrid, filled with empty space and bordering rocks.
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
                spacegrid[sizeRow-1, i] = ASTEROID;
            }

            for (int i = 0; i < sizeRow-1; i++)
            {
                spacegrid[i, 0] = ASTEROID;
                spacegrid[i, sizeRow-1] = ASTEROID;
            }

            //Create shipGrid with desired dimensions
            shipGrid = new AssembledShip[sizeRow, sizeCol];

            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    shipGrid[i, j] = null;
                }
            }
        }

        //This constructor clones a spaceGrid via it's current shipGrid/spaceGrid (Taken as parameters)
        //TODO: Null checking.
        public spaceGrid (AssembledShip[,] shipGridInput, bool[,] spacegridInput)
        {
            shipGrid = (AssembledShip[,])shipGrid.Clone();
            spacegrid = (bool[,])spacegridInput.Clone();

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
        ///Returns a value other than 0 if an obstacle is in either grid. Currently: 1 if AssembledShip, 2 if Asteroid. Returns 0 if empty space.
        public int isObstaclePresent(int row, int col)
        {
            int correctedRow = row;
            int correctedCol = col;

            if (this.shipGrid[correctedRow, correctedCol] is AssembledShip)
            {
                return 1;
            }

            if (this.spacegrid[correctedRow, correctedCol] == ASTEROID)
            {
                return 2;
            }

            else
            {
                //Assuming empty space
                return 0;
            }
        }

        public void MoveShipDirection(AssembledShip selectedShip, int Direction)
        {
            int shipLocationCol = selectedShip.getLocationCol();
            int shipLocationRow = selectedShip.getLocationRow();


            if (Direction == UP)
            {
                selectedShip.setLocationCol(shipLocationCol);
                selectedShip.setLocationRow(shipLocationRow - 1);
                this.shipGrid[shipLocationRow - 1, shipLocationCol] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;

            }

            if (Direction == DOWN)
            {
                selectedShip.setLocationCol(shipLocationCol);
                selectedShip.setLocationRow(shipLocationRow + 1);
                this.shipGrid[shipLocationRow + 1, shipLocationCol] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == LEFT)
            {
                selectedShip.setLocationCol(shipLocationCol - 1);
                selectedShip.setLocationRow(shipLocationRow);
                this.shipGrid[shipLocationRow, shipLocationCol - 1] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == RIGHT)
            {
                selectedShip.setLocationCol(shipLocationCol + 1);
                selectedShip.setLocationRow(shipLocationRow);
                this.shipGrid[shipLocationRow, shipLocationCol + 1] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == UP_AND_LEFT)
            {
                selectedShip.setLocationCol(shipLocationCol - 1);
                selectedShip.setLocationRow(shipLocationRow - 1);
                this.shipGrid[shipLocationRow - 1, shipLocationCol - 1] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == UP_AND_RIGHT)
            {
                selectedShip.setLocationCol(shipLocationCol + 1);
                selectedShip.setLocationRow(shipLocationRow - 1);
                this.shipGrid[shipLocationRow - 1, shipLocationCol + 1] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == DOWN_AND_LEFT)
            {
                selectedShip.setLocationCol(shipLocationCol - 1);
                selectedShip.setLocationRow(shipLocationRow + 1);
                this.shipGrid[shipLocationRow + 1, shipLocationCol - 1] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == DOWN_AND_RIGHT)
            {
                selectedShip.setLocationCol(shipLocationCol + 1);
                selectedShip.setLocationRow(shipLocationRow + 1);
                this.shipGrid[shipLocationRow + 1, shipLocationCol + 1] = selectedShip;
                this.shipGrid[shipLocationRow, shipLocationCol] = null;
            }

            if (Direction == CENTER)
            {
                //Staying put. No action.
                return;
            }
        }

        //TODO: Finish implementing this method, make design decisions on how to move a vessel.
        public static void MoveShip(AssembledShip selectedShip, int destRow, int destCol, spaceGrid gameGrid)
        {
            //Null-Check before assigning variables based off the selectedShip and gameGrid
            if (selectedShip != null && gameGrid != null)
            {
                //Determine current position of object (ship).
                int currentRow = selectedShip.getLocationRow();
                int currentCol = selectedShip.getLocationCol();

                if (isValidMove(destRow, destCol, gameGrid) == true)
                {
                    //place selectedShip in desired Col/Row
                    gameGrid.shipGrid[destRow, destCol] = selectedShip;
                    gameGrid.shipGrid[currentRow, currentCol] = null;

                    //set the location on each ship object
                    selectedShip.setLocationCol(destCol);
                    selectedShip.setLocationRow(destRow);

                }
            }
        }

        public static int DirectionGridToRel(int CurrentRow, int CurrentCol, int DestRow, int DestCol)
        {
            if (CurrentRow > DestRow && CurrentCol == DestCol)
            {
                return UP;
            }

            if (CurrentRow < DestRow && CurrentCol == DestCol)
            {
                return DOWN;
            }

            if (CurrentRow == DestRow && CurrentCol > DestCol)
            {
                return LEFT;
            }

            if (CurrentRow == DestRow && CurrentCol < DestCol)
            {
                return RIGHT;
            }

            if (CurrentRow < DestRow && CurrentCol > DestCol)
            {
                return DOWN_AND_LEFT;
            }

            if (CurrentRow < DestRow && CurrentCol < DestCol)
            {
                return DOWN_AND_RIGHT;
            }

            if (CurrentRow < DestRow && CurrentCol == DestCol)
            {
                return UP_AND_LEFT;
            }

            if (CurrentRow < DestRow && CurrentCol == DestCol)
            {
                return UP_AND_RIGHT;
            }

            //If none of these work, assume center. Uncomment for debug.
            //Console.WriteLine("DirectionGridToRel: returning default (CENTER)");
            return CENTER;
        }



        public int GetGridRowSize()
        {
            return spacegrid.GetLength(0);
        }
        public int GetGridColSize()
        {
            return spacegrid.GetLength(1);
        }
    }
}
