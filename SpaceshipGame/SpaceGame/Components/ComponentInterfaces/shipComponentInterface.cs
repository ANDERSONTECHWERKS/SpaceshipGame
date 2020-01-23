using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame
{
    public interface IShipComponentInterface
    {
        String Name
        {
            get;

        }
        int Health
        {
            get;set;
        }
        int NumberOfMoves
        {
            get;set;
        }
        int WarpRange
        {
            get;set;
        }
        bool CanWarp
        {
            get;set;
        }
        Boolean ProvidesComms {
            get;set;
        }
        Boolean ProvidesControl
        {
            get;set;
        }
        Boolean IsDestroyed
        {
            get;set;
        }
        Boolean IsDisabled
        {
            get;set;
        }
        Boolean ProvidesLifeSupport
        {
            get;set;
        }
        Boolean ProvidesPropulsion
        {
            get;set;
        }
        Boolean ProvidesWeapon
        {
            get;set;
        }
    }   
}
