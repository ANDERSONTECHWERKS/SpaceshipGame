using SpaceshipGame.Components.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components
{
    class IonEngines : shipComponentInterface, ComponentInterfaces.propulsionComponentInterface
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

        bool propulsionComponentInterface.can_warp()
        {
            return can_warp;
        }

        int shipComponentInterface.getHealth()
        {
            return health;
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

        int propulsionComponentInterface.num_moves()
        {
            return num_moves;
        }

        void shipComponentInterface.setHealth(int healthSet)
        {
            health = healthSet;
            Console.WriteLine("Health set to:" + healthSet);
        }

        int propulsionComponentInterface.warp_range()
        {
            return warp_range;
        }
    }
}
