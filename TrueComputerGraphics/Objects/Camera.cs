using System;
using System.Collections.Generic;
using System.Text;
using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Objects
{
    public class Camera
    {
        public Point Position { get; }
        public Vector Direction { get; }

        public Vector Right { get; }

        public Vector Up { get; }
        public Vector PlaneOrigin { get; }

        public float RealPlaneHeight { get; }
        public float RealPlaneWidht { get; }

        public int height { get; }
        public int width { get; }

        public Camera(Point position, Vector direction, int height, int width, int fov)
        {
            PlaneOrigin = position + Vector.Normilize(direction);
            this.height = height;
            this.width = width;

            var fovInRad = fov / 180f * Math.PI;
            RealPlaneHeight = (float)Math.Tan(fovInRad);
            RealPlaneWidht = RealPlaneHeight / height * width;

            this.Position = position;
            this.Direction = Vector.Normilize(direction);

            Right = Vector.Normilize(Vector.Cross(direction, Vector.Normilize(new Vector(1, 0, 0))));
            Up = Vector.Cross(direction, Vector.Negate(Right));
        }
    }
}