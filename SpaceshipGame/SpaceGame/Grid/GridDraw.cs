using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame.Grid;

namespace SpaceshipGame.SpaceGame.Grid
{
    public class GridDraw
    {
        public static void DrawShipGrid(spaceGrid currentGrid)
        {
            spaceGrid GridToDraw = currentGrid;
            
            for (int i = 0; i < GridToDraw.GetGridRowSize(); i++)
            {
                for (int j = 0; j < GridToDraw.GetGridColSize(); j++)
                {
                    int GridResult = GridToDraw.isObstaclePresent(i, j);

                    Console.Write(GridResult + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
