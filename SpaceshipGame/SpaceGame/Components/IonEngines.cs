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
        private int NumberOfMoves = 1;
        private int WarpRange = 0;
        private bool CanWarp = false;
        private Boolean ProvidesComms = false;
        private Boolean ProvidesControl = false;
        private Boolean IsDestroyed = false;
        private Boolean IsDisabled = false;
        private Boolean ProvidesLifeSupport = false;
        private Boolean ProvidesPropulsion = true;
        private Boolean ProvidesWeapon = false;

        int IShipComponentInterface.Health { get => health; set => value = health; }
        int IShipComponentInterface.NumberOfMoves { get => NumberOfMoves; set => value = NumberOfMoves; }
        int IPropulsionComponentInterface.NumberOfMoves { get => NumberOfMoves; set => value = NumberOfMoves; }
        int IShipComponentInterface.WarpRange { get => WarpRange; set => value = WarpRange; }
        int IPropulsionComponentInterface.WarpRange { get => WarpRange; set => value = WarpRange; }
        bool IShipComponentInterface.CanWarp { get => CanWarp; set => value = CanWarp; }
        bool IPropulsionComponentInterface.CanWarp { get => CanWarp; set => value = CanWarp; }
        bool IShipComponentInterface.ProvidesComms { get => ProvidesComms; set => value = ProvidesComms; }
        bool IShipComponentInterface.ProvidesControl { get => ProvidesControl; set => value = ProvidesControl; }
        bool IShipComponentInterface.IsDestroyed { get => IsDestroyed; set => value = IsDestroyed; }
        bool IShipComponentInterface.IsDisabled { get => IsDisabled; set => value = IsDisabled; }
        bool IShipComponentInterface.ProvidesLifeSupport { get => ProvidesLifeSupport; set => value = ProvidesLifeSupport; }
        bool IShipComponentInterface.ProvidesPropulsion { get => ProvidesPropulsion; set => value = ProvidesPropulsion; }
        bool IShipComponentInterface.ProvidesWeapon { get => ProvidesWeapon; set => value = ProvidesWeapon; }
        string IPropulsionComponentInterface.Name { get => name; }

        string IShipComponentInterface.Name { get => name; }
    }
}
