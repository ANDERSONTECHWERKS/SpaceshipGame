using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame
{
    public interface IShipClassInterface
    {
        String shipClassName
        {
            get;

        }

        int hullHealth
        {
            get;
            
        }

        int numComponents
        {
            get;

        }

        int locationRow
        {
            get;
            set;
        }

        int locationCol
        {
            get;
            set;
        }
    }
}
