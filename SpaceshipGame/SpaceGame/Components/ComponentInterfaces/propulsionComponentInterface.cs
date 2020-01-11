using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipGame.Components.ComponentInterfaces
{
    public interface propulsionComponentInterface
    {
        // We want engines to define, at a minimum, whether they are a jump drive, how many moves they have, etc. More can be added here later.
       public int num_moves();

       public Boolean can_warp();

       public int warp_range();

        public string getName();
    }

}
