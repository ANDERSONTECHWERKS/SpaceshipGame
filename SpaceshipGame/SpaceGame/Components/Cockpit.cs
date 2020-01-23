using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components
{
    class Cockpit : IShipComponentInterface
    {
        string Name = "Standard Mk. 1 Cockpit";
        private int Health = 100;
        private int NumberOfMoves = 0;
        private int WarpRange = 0;
        private bool CanWarp = false;
        private Boolean ProvidesComms = false;
        private Boolean ProvidesControl = true;
        private Boolean IsDestroyed = false;
        private Boolean IsDisabled = false;
        private Boolean ProvidesLifeSupport = false;
        private Boolean ProvidesPropulsion = false;
        private Boolean ProvidesWeapon = false;

        int IShipComponentInterface.Health { get => Health; set => Health = value; }
        int IShipComponentInterface.NumberOfMoves { get => NumberOfMoves; set => NumberOfMoves = value; }
        int IShipComponentInterface.WarpRange { get => WarpRange; set => WarpRange = value; }
        bool IShipComponentInterface.CanWarp { get => CanWarp; set => CanWarp = value; }
        bool IShipComponentInterface.ProvidesComms { get => ProvidesComms; set => ProvidesComms = value; }
        bool IShipComponentInterface.ProvidesControl { get => ProvidesControl; set => ProvidesControl = value; }
        bool IShipComponentInterface.IsDestroyed { get => IsDestroyed; set => IsDestroyed = value; }
        bool IShipComponentInterface.IsDisabled { get => IsDisabled; set => IsDisabled = value; }
        bool IShipComponentInterface.ProvidesLifeSupport { get => ProvidesLifeSupport; set => ProvidesLifeSupport = value; }
        bool IShipComponentInterface.ProvidesPropulsion { get => ProvidesPropulsion; set => ProvidesPropulsion = value; }
        bool IShipComponentInterface.ProvidesWeapon { get => ProvidesWeapon; set => ProvidesWeapon = value; }

        string IShipComponentInterface.Name => Name;
    }
}
