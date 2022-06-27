using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Interfaces
{
    public interface IObject
    {
        public bool IsInterceptionWithRay(Point start, Vector direction);

        public Point WhereInterceptionWithRay(Point start, Vector direction);

        public Vector GetNormalOnPoint(Point point);
    }
}