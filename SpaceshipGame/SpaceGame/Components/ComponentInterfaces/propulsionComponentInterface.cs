using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components.ComponentInterfaces
{
    public interface IPropulsionComponentInterface
    {
        // We want engines to define, at a minimum, whether they are a jump drive, how many moves they have, etc. More can be added here later.
       public int NumMoves();

       public Boolean CanWarp();

       public int WarpRange();

        public string GetName();
    }

}
