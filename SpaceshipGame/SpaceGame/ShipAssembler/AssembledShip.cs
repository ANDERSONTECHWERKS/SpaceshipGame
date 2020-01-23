using System;
using System.Collections.Generic;
using System.Text;
using SpaceshipGame.ShipClasses;
using SpaceshipGame.ShipAssembler;
using SpaceshipGame;

namespace SpaceshipGame.ShipAssembler
{
    public class AssembledShip

    {           
        //TODO: Check all getters and setters!

        //Current name of ship, should never change. 

        private string shipName = "Default Shipname";

        //Current class of ship, should never change.

        private IShipClassInterface currentShipClass;

        //Current list of ship components. Should be imported into constructor below.

        private List<IShipComponentInterface> currentShipComponents;

        //Current ship health. Should be derived from ship class in constructor below.
        private int shipHealth;

        //Current ship location, tracked here for future use. Ship object will be stored in it's coordinate.
        private int locationRow;
        private int locationCol;

        //Current number of moves based off of currentShipComponents move enumeration
        private int numberMoves;

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
            IShipClassInterface selectedClass;
            List<IShipComponentInterface> selectedComponents;

            Console.WriteLine("CONSTRUCT YOUR SHIP:");

                selectedClass = ClassComponentSelect.selectClass();

                selectedComponents = ClassComponentSelect.selectComponents(selectedClass);

            Console.WriteLine("Name this ship:");
            string shipName = Console.ReadLine();



                ShipAssembler.AssembledShip selectedShip = new ShipAssembler.AssembledShip(shipName,selectedClass, 0, 0, selectedComponents);

                return selectedShip;
            

 


        }

        //Default ship constructor: Will construct a simple frigate.
        //TODO: Go through each member and create defaults
        public AssembledShip (IShipClassInterface selectedShipClass, int locationRowInput, int locationColInput)
        {
            //ERROR-CATCH: 
            // If the input class is null, or otherwise erroneous, this method will fail.
            if (selectedShipClass == null)
            {
                throw new ArgumentException("CreateDefaultShip: selectedShipClass cannot be null!");
            }
               
            currentShipClass = selectedShipClass;
            shipName = $"Default {currentShipClass}";
            shipHealth = currentShipClass.hullHealth;
            currentShipComponents = new List<IShipComponentInterface>(currentShipClass.numComponents);

            //Populting Default Ship:
            //Interrupting object creation flow in order to populate the default ship with components dynamically.

            int numComponents = currentShipComponents.Capacity;

            for (int i = 0; i < numComponents-1; i++)
            {
                currentShipComponents.Add(new Components.IonEngines());
            }

            currentShipComponents.Add(new Components.Cockpit());

            locationRow = locationRowInput;
            locationCol = locationColInput;
            isDestroyed = false;
            isDisabled = false;
            hasPropulsion = ClassComponentSelect.hasPropulsion(currentShipComponents);
            hasWeapon = ClassComponentSelect.hasWeapons(currentShipComponents);
            hasLifeSupport = ClassComponentSelect.hasLifeSupport(currentShipComponents);
            hasControl = ClassComponentSelect.hasControl(currentShipComponents);
            hasComms = ClassComponentSelect.hasComms(currentShipComponents);
        }

        //Ship asssembly constructor. Requires ship class, ship component list, and location col/row as input.
        //TODO: Figure out default ship positions, continue making static methods for determining has<Flags>, and eventually figure out ToString
         AssembledShip(string shipNameInp, IShipClassInterface shipClass,int locationRowInp,int locationColInp, List<IShipComponentInterface> shipComponentList){
            shipName = shipNameInp;
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
            
            return "Ship Name: " + shipName + ", Ship Class: " + currentShipClass + " Ship ID:" + this.GetHashCode();
        }

        public string getName()
        {
            return shipName;
        }

        public void setName(string newName)
        {
            this.shipName = newName;
        }

        public List<IShipComponentInterface> getComponents()
        {
            return this.currentShipComponents;
        }

        public IShipClassInterface getShipClassObject()
        {
            return this.currentShipClass;
        }

        public int getLocationRow()
        {
            return locationRow;
        }
        public int getLocationCol()
        {
            return locationCol;
        }
        public void setLocationRow(int row)
        {
            Console.WriteLine("Setting Location Row to:" + row);
            locationRow = row;
        }
        public void setLocationCol(int col)
        {
            Console.WriteLine("Setting Location Column to:" + col);
            locationCol = col;
        }
    }
}
