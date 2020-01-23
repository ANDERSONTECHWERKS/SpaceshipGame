using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipGame.SpaceGame;
using SpaceshipGame.Grid;
using SpaceshipGame.ShipAssembler;
using SpaceshipGame.ShipClasses;

namespace SpaceshipGameUnitTests
{
    [TestClass]
    public class spaceshipTests
    {
        [TestMethod]
        public void TestDefaultGrid()
        {
            spaceGrid testGrid = new spaceGrid();
            //Test for interior "empty" space
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Assert.IsFalse(testGrid.isAsteroid(i, j));
                }
            }

            //Test for asteroids bordering the maap

            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(testGrid.isAsteroid(i, 0));
                Assert.IsTrue(testGrid.isAsteroid(9, i));
                Assert.IsTrue(testGrid.isAsteroid(0, i));
                Assert.IsTrue(testGrid.isAsteroid(i, 9));

            }
        }

        [TestMethod]
        public void TestShipPlacement()
        {
            spaceGrid testGrid2 = new spaceGrid();
            AssembledShip testShip = new AssembledShip(new Frigate(), 5, 5);

            testGrid2.AddShip(testShip, 5, 5);

            Assert.IsTrue(testGrid2.isObstaclePresent(5, 5) == 1);

        }

        [TestMethod]
        public void TestShipMovement()
        {
            spaceGrid testGrid = new spaceGrid();
            AssembledShip testShip = new AssembledShip(new Frigate(), 5, 5);

            testGrid.AddShip(testShip, 5, 5);

            Assert.IsTrue(testGrid.isObstaclePresent(5, 5) == 1);

            spaceGrid.MoveShip(testShip, 4, 4, testGrid);
            Assert.IsTrue(testGrid.isObstaclePresent(5, 5) == 0);
            Assert.IsTrue(testGrid.isObstaclePresent(4, 4) == 1);

        }

        [TestMethod]

        public void TestGridDraw()
        {
            spaceGrid testGrid = new spaceGrid();
            AssembledShip testShip = new AssembledShip(new Frigate(), 5, 5);

            SpaceshipGame.SpaceGame.Grid.GridDraw.DrawShipGrid(testGrid);
           
        }

    }
}
