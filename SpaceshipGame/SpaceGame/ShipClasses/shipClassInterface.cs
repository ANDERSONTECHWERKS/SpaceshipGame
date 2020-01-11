using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame
{
    public interface shipClassInterface
    {
        public String shipClassName
        {
            get;

        }

        public int hullHealth
        {
            get;

        }

        public int numComponents
        {
            get;

        }

        public int locationRow
        {
            get;
            set;
        }

        public int locationCol
        {
            get;
            set;
        }
    }
}
