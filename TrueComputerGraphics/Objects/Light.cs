using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueComputerGraphics.Objects;

namespace TrueComputerGraphics.Objects
{
    class Light
    {
        public Vector Direction { get; set; }

        public Light(Vector direction)
        {
            this.Direction = direction;
        }
    }
}
