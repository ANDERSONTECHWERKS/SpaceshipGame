using SpaceshipGame.Components.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components
{
    class IonEngines : IShipComponentInterface, ComponentInterfaces.IPropulsionComponentInterface
    {
        string name = "Standard Type-I Ion Engines";
        private int health = 100;
        private int num_moves = 1;
        private int warp_range = 0;
        private bool can_warp = false;
        private Boolean isComms = false;
        private Boolean isControl = false;
        private Boolean isDestroyed = false;
        private Boolean isDisabled = false;
        private Boolean isLifeSupport = false;
        private Boolean isPropulsion = true;
        private Boolean isWeapon = false;

        public string getName()
        {
            return name;
        }

        bool IPropulsionComponentInterface.CanWarp()
        {
            return can_warp;
        }

        int IShipComponentInterface.getHealth()
        {
            return health;
        }

        string IPropulsionComponentInterface.GetName()
        {
            return name;
        }

        bool IShipComponentInterface.isComms()
        {
            return isComms;
        }

        bool IShipComponentInterface.isControl()
        {
            return isControl;
        }

        bool IShipComponentInterface.isDestroyed()
        {
            return isDestroyed;
        }

        bool IShipComponentInterface.isDisabled()
        {
            return isDisabled;
        }

        bool IShipComponentInterface.isLifeSupport()
        {
            return isLifeSupport;
        }

        bool IShipComponentInterface.isPropulsion()
        {
            return isPropulsion;
        }

        bool IShipComponentInterface.isWeapon()
        {
            return isWeapon;
        }

        int IPropulsionComponentInterface.NumMoves()
        {
            return num_moves;
        }

        void IShipComponentInterface.setHealth(int healthSet)
        {
            health = healthSet;
            Console.WriteLine("Health set to:" + healthSet);
        }

        int IPropulsionComponentInterface.WarpRange()
        {
            return warp_range;
        }
    }
}
