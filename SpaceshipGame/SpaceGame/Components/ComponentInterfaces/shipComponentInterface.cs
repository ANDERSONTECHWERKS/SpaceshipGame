using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame
{
    public interface shipComponentInterface
    {
        public int getHealth();
        public void setHealth(int healthSet);

        public Boolean isDestroyed();

        public Boolean isDisabled();
        public Boolean isPropulsion();

        public Boolean isWeapon();

        public Boolean isLifeSupport();

        public Boolean isControl();

        public Boolean isComms();

        public string getName();
    }   
}
