using System;
using System.Collections.Generic;
using System.Text;
using TrueComputerGraphics.Interfaces;
using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Objects
{
    public class Sphere : IObject
    {
        public Point Center { get; private set; }
        public float Radius { get; set; }

        public Sphere(Point center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool IsInterceptionWithRay(Point start, Vector direction)
        {
            Vector k = start - Center;
            var a = direction * direction;
            var b = 2 * (direction * k);
            var c = k * k - Radius * Radius;
            var D = b * b - 4 * a * c;

            if (D < 0)
                return false;
            var t = (-b - Math.Sqrt(D)) / (2 * a);

            if (t >= 0)
                return true;
            return false;
        }

        public Point WhereInterceptionWithRay(Point start, Vector direction)
        {
            Vector k = start - Center;
            var a = direction * direction;
            var b = 2 * (direction * k);
            var c = k * k - Radius * Radius;
            var D = b * b - 4 * a * c;

            if (D < 0)
                return null;

            var t = (-b - Math.Sqrt(D)) / (2 * a);

            if (t < 0)
                return null;

            var x = (float)(start.x + t * direction.x);
            var y = (float)(start.y + t * direction.y);
            var z = (float)(start.z + t * direction.z);
            return new Point(x, y, z);
        }

        public Vector GetNormalOnPoint(Point point)
        {
            return Vector.GetVectorWithPoints(Center, point);
        }
        public object RotateX(float degree)
        {
            return this;
        }

        public object RotateY(float degree)
        {
            return this;
        }

        public object RotateZ(float degree)
        {
            return this;
        }

        public object Scale(float kx, float ky, float kz)
        {
            Radius = kx;
            return this;
        }

        public object Translate(Vector direction)
        {
            Center = (Point)Center.Translate(direction);
            return this;
        }
    }
}
