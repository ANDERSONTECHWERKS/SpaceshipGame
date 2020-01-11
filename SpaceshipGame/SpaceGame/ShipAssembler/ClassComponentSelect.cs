using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace SpaceshipGame.ShipAssembler
{
    class ClassComponentSelect
    {
        //selectClass: A switch-menu prompting user for a class/hull selection. Currently defaulted to Frigate.
        //TODO: Design a better menu here. This is cheap and shoddy.
        public static shipClassInterface selectClass()
        {
            shipClassInterface selectedClass;

            Console.WriteLine("Select a ship class: ");
            Console.WriteLine("1. Frigate");
            string response = Console.ReadLine();
            
                switch (response)
                {
                    case "1":
                        Console.WriteLine("Frigate Selected");
                        selectedClass = new ShipClasses.Frigate();
                        return selectedClass;
                    default:
                        Console.WriteLine("Bad input! Selecting Frigate.");
                    selectedClass = new ShipClasses.Frigate();
                    return selectedClass;
                }
            
        }
        // TODO: This is throwing an "ArgumentOutOfRange". (Must be non-negative and less than size of collection. Maybe try using collection.add?)
        //selectComponents: For every slot, asks the user what component to insert.
        public static List<shipComponentInterface> selectComponents(shipClassInterface selectedClass)
        {
            List <shipComponentInterface> chosenComponents = new List<shipComponentInterface>(selectedClass.numComponents);

            for (int i = 0; i < chosenComponents.Capacity; i++)
            {
                Console.WriteLine("Please select a component for slot " + i);
                Console.WriteLine("Select 1 for Cockpit. ");
                Console.WriteLine("Select 2 for Ion Engine. ");

                string response = Console.ReadLine();
                int responseInt = Int32.Parse(response);

                if (responseInt == 1)
                {
                    Console.WriteLine("Selecting Cockpit.");
                    chosenComponents.Add(new Components.Cockpit());
                    Console.WriteLine("Component Slot " + i + " set to Cockpit.");
                    
                }
                if (responseInt == 2)
                {
                    Console.WriteLine("Selecting Ion Engine.");
                    chosenComponents.Add(new Components.IonEngines());
                    Console.WriteLine("Component Slot " + i + " set to Ion Engine.");
                }
            }

            return chosenComponents;
        }

        //confirmSelection: Confirmation window. Returns "0" if the loadout is correct, returns 1 if not.
        public static int confirmSelection(List<shipComponentInterface> chosenComponents, shipClassInterface chosenClass)
        {
            List<shipComponentInterface> confirmComponents = chosenComponents;
            shipClassInterface confirmClass = chosenClass;

            Console.WriteLine("Confirm your choices:");
            Console.WriteLine("Ship Class: " + chosenClass.shipClassName);
            Console.WriteLine("Itemized List of Ship Components: ");

            int counter = 1;
            foreach (shipComponentInterface thisComponent in chosenComponents)
            {
                Console.WriteLine("SLOT: " + counter + " COMPONENT: " + thisComponent.getName());
                counter++;
            }

            Console.Write("Is this loadout correct? Y/N");
            string response = Console.ReadLine();
            response.ToUpper();
            if (response.Equals("Y"))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static Boolean hasPropulsion(List<shipComponentInterface> shipComponentList)
        {
            //TODO: Consider checking for disabled engines and thinking how you want to handle them.

            //This loop and set of if-statements determines whether the ship has propulsion
            //by counting the number of components with the "isPropulsion" flag set.
            int engineCount = 0;

            foreach (shipComponentInterface enumComponent in shipComponentList)
            {
                if (enumComponent.isPropulsion())
                {
                    engineCount++;
                }
            }

            if (engineCount > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public static Boolean hasWeapons(List<shipComponentInterface> shipComponentList)
        {
            //TODO: Consider checking for disabled weapons and thinking what you want to do with them.

            //This loop and set of if-statements determines whether the ship has weapons
            //by counting the number of components with the "isWeapon" flag set.
            int weaponCount = 0;

            foreach (shipComponentInterface enumComponent in shipComponentList)
            {
                if (enumComponent.isWeapon())
                {
                    weaponCount++;
                }
            }

            if (weaponCount > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static Boolean hasLifeSupport(List<shipComponentInterface> shipComponentList)
        {
            //TODO: Consider checking for disabled life support and thinking what you want to do with it.

            //This loop and set of if-statements determines whether the ship has life support
            //by counting the number of components with the "isLifeSupport" flag set.
            int lifeSupportCount = 0;

            foreach (shipComponentInterface enumComponent in shipComponentList)
            {
                if (enumComponent.isLifeSupport())
                {
                    lifeSupportCount++;
                }
            }

            if (lifeSupportCount > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public static Boolean hasControl(List<shipComponentInterface> shipComponentList)
        {
            //TODO: Consider checking for disabled controllers and thinking what you want to do with them.

            //This loop and set of if-statements determines whether the ship has a method of control
            //by counting the number of components with the "isControl" flag set.
            int controllerCount = 0;

            foreach (shipComponentInterface enumComponent in shipComponentList)
            {
                if (enumComponent.isControl())
                {
                    controllerCount++;
                }
            }

            if (controllerCount > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public static Boolean hasComms(List<shipComponentInterface> shipComponentList)
        {
            //TODO: Consider checking for disabled comms and thinking what you want to do with them.

            //This loop and set of if-statements determines whether the ship has communications
            //by counting the number of components with the "isComms" flag set.
            int commsCount = 0;

            foreach (shipComponentInterface enumComponent in shipComponentList)
            {
                if (enumComponent.isComms())
                {
                    commsCount++;
                }
            }

            if (commsCount > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
