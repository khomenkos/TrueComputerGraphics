using System;
using System.Collections.Generic;
using System.Text;
using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Objects
{
    public class Light
    {
        public Vector Direction { get; set; }

        public Light(Vector direction)
        {
            this.Direction = direction;
        }
    }
}
