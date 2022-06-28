using System;
using System.Collections.Generic;
using System.Text;
using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Interfaces
{
    public interface IObject
    {
        public bool IsInterceptionWithRay(Point start, Vector direction);

        public Point WhereInterceptionWithRay(Point start, Vector direction);

        public Vector GetNormalOnPoint(Point point);

        public object RotateX(float degree);

        public object RotateY(float degree);

        public object RotateZ(float degree);

        public object Scale(float kx, float ky, float kz);

        public object Translate(Vector direction);
    }
}
