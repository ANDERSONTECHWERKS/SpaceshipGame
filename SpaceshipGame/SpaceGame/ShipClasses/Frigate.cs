using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame;

namespace SpaceshipGame.ShipClasses
{
    public class Frigate : IShipClassInterface
    {
        private int hullHealth = 100;

        public int numComponents => 7;

        public int locationRow { get ; set ; }
        public int locationCol { get; set; }

        public string shipClassName => "Frigate";

        int IShipClassInterface.hullHealth { get ; }
    }
}
