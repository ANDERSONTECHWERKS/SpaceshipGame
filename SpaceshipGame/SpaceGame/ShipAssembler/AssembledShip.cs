using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.ShipAssembler
{
    class AssembledShip

    {           
        //TODO: Check all getters and setters!

        //Current name of ship, should never change. 

        private string shipName = "Default Shipname";

        //Current class of ship, should never change.

        private shipClassInterface currentShipClass;

        //Current list of ship components. Should be imported into constructor below.
        List<shipComponentInterface> currentShipComponents;

        //Current ship health. Should be derived from ship class in constructor below.
        int shipHealth;

        //Current ship location, tracked here for future use. Ship object will be stored in it's coordinate.
        private int locationRow;
        private int locationCol;

        //TODO: Make getters / setters for every flag

        //Current ship status flags
        private Boolean isDestroyed;
        private Boolean isDisabled;
        private Boolean hasPropulsion;
        private Boolean hasWeapon;
        private Boolean hasLifeSupport;
        private Boolean hasControl;
        private Boolean hasComms;

        public static AssembledShip AssembleMenu()
        {
            shipClassInterface selectedClass;
            List<shipComponentInterface> selectedComponents;

            Console.WriteLine("CONSTRUCT YOUR SHIP:");

                selectedClass = ClassComponentSelect.selectClass();

                selectedComponents = ClassComponentSelect.selectComponents(selectedClass);

                ShipAssembler.AssembledShip selectedShip = new ShipAssembler.AssembledShip(selectedClass, 0, 0, selectedComponents);

                return selectedShip;
            

 


        }

        //Ship asssembly constructor. Requires ship class, ship component list, and location col/row as input.
        //TODO: Figure out default ship positions, continue making static methods for determining has<Flags>, and eventually figure out ToString
        public AssembledShip(shipClassInterface shipClass,int locationRowInp,int locationColInp, List<shipComponentInterface> shipComponentList){
            shipHealth = shipClass.hullHealth;
            currentShipClass = shipClass;
            currentShipComponents = shipComponentList;
            locationRow = locationRowInp;
            locationCol = locationColInp;
            isDestroyed = false;
            isDisabled = false;
            hasPropulsion = ClassComponentSelect.hasPropulsion(shipComponentList);
            hasWeapon = ClassComponentSelect.hasWeapons(shipComponentList);
            hasLifeSupport = ClassComponentSelect.hasLifeSupport(shipComponentList);
            hasControl = ClassComponentSelect.hasControl(shipComponentList);
            hasComms = ClassComponentSelect.hasComms(shipComponentList);
            
            }

        public override string ToString()
        {
            
            return "Ship Name: " + shipName + "Ship Class: " + currentShipClass;
        }
    }
}
