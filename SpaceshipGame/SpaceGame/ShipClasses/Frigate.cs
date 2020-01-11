using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.ShipClasses
{
    class Frigate : shipClassInterface
    {
        private int hullHealth = 100;

        public int numComponents => 7;

        public int locationRow { get =>  locationRow; set => locationRow = value; }
        public int locationCol { get => locationCol; set => locationCol = value; }

        public string shipClassName => "Frigate";

        int shipClassInterface.hullHealth => hullHealth;
    }
}
