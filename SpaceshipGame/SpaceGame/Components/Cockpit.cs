using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components
{
    class Cockpit : IShipComponentInterface
    {
        string name = "Standard Mk. 1 Cockpit";
        int health = 100;
        Boolean isComms = false;
        Boolean isControl = true;
        Boolean isDestroyed = false;
        Boolean isDisabled = false;
        Boolean isLifeSupport = false;
        Boolean isPropulsion = false;
        Boolean isWeapon = false;

        public string getName()
        {
            return name;
        }

        int IShipComponentInterface.getHealth()
        {
            return this.health;
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

        void IShipComponentInterface.setHealth(int healthSet)
        {
            this.health = healthSet;
        }
    }
}
