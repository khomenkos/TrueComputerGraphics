using System.Collections.Generic;
using System.Drawing;
using TrueComputerGraphics.Interfaces;
using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Objects
{
    public class ComplexObject
    {
        public List<IObject> objects;

        public ComplexObject(List<IObject> objects)
        {
            this.objects = objects;
        }

    }
}
