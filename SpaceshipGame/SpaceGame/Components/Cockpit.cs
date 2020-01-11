using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components
{
    class Cockpit : shipComponentInterface
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

        int shipComponentInterface.getHealth()
        {
            return this.health;
        }

        bool shipComponentInterface.isComms()
        {
            return isComms;
        }

        bool shipComponentInterface.isControl()
        {
            return isControl;
        }

        bool shipComponentInterface.isDestroyed()
        {
            return isDestroyed;
        }

        bool shipComponentInterface.isDisabled()
        {
            return isDisabled;
        }

        bool shipComponentInterface.isLifeSupport()
        {
            return isLifeSupport;
        }

        bool shipComponentInterface.isPropulsion()
        {
            return isPropulsion;
        }

        bool shipComponentInterface.isWeapon()
        {
            return isWeapon;
        }

        void shipComponentInterface.setHealth(int healthSet)
        {
            this.health = healthSet;
        }
    }
}
