using System;
using System.Collections.Generic;
using System.Text;
using TrueComputerGraphics.Types;
using TrueComputerGraphics.Interfaces;

namespace TrueComputerGraphics.Objects
{
    public class Plane : IObject
    {
        public Point Center { get; }
        public Vector Normal { get; }

        public Plane(Point center, Vector vector)
        {
            this.Center = center;
            this.Normal = Vector.Normilize(vector);
        }

        public Vector GetNormalOnPoint(Point point)
        {
            return Normal;
        }

        public bool IsInterceptionWithRay(Point start, Vector direction)
        {
            float denom = -(Normal * direction);

            if (denom > 0)
            {
                Vector k = Center - start;
                var t = -(k * Normal) / denom;
                return (t >= 0);
            }

            return false;
        }

        public Point WhereInterceptionWithRay(Point start, Vector direction)
        {
            float denom = -(Normal * direction);

            if (denom < 0)
                return null;

            Vector k = Center - start;
            var t = -(k * Normal) / denom;

            if (t < 0)
                return null;

            var x = start.x + t * direction.x;
            var y = start.y + t * direction.y;
            var z = start.z + t * direction.z;

            return new Point(x, y, z);
        }
        public object RotateX(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            Center.RotateX(degree);
            Normal.RotateX(degree);
            return this;
        }

        public object RotateY(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            Center.RotateY(degree);
            Normal.RotateY(degree);
            return this;
        }

        public object RotateZ(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            Center.RotateZ(degree);
            Normal.RotateZ(degree);
            return this;
        }

        public object Scale(float kx, float ky, float kz)
        {
            return this;
        }

        public object Translate(Vector direction)
        {
            Center.Translate(direction);
            Normal.Translate(direction);
            return this;
        }
    }
}
