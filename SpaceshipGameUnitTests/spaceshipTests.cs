using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceshipGame;
using SpaceshipGame.Grid;
using SpaceshipGame.ShipAssembler;

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
                Assert.IsTrue(testGrid.isAsteroid(i,0));
                Assert.IsTrue(testGrid.isAsteroid(9, i));
                Assert.IsTrue(testGrid.isAsteroid(0, i));
                Assert.IsTrue(testGrid.isAsteroid(i, 9));

            }
        }

        [TestMethod]

        public void TestShipPlacement()
        {
            spaceGrid testGrid2 = new spaceGrid();
            AssembledShip testShip = new AssembledShip(new SpaceshipGame.ShipClasses.Frigate(),5,5);

            testGrid2.AddShip(testShip,5,5);

            Assert.IsTrue(testGrid2.isObstaclePresent(5, 5) == 1);
            
        }

        
    }
}
