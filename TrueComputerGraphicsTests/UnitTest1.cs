using NUnit.Framework;
using TrueComputerGraphics.Objects;
using TrueComputerGraphics.Types;


namespace TrueComputerGraphicsTests
{
    public class Tests
    {
        [Test]
        public void IsIntersectionOfVectorAndPlaneReturnCorrectValue()
        {
            Plane plane1 = new Plane(new TrueComputerGraphics.Types.Point(0, 0, 0), new Vector(1, 0, 0));
            Plane plane2 = new Plane(new TrueComputerGraphics.Types.Point(0, 0, 5), new Vector(0, 0, -1));
            Point start = new Point(0, 0, 0);
            Vector forward = new Vector(0, 0, 1);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(false, plane1.IsInterceptionWithRay(start, forward));
                Assert.AreEqual(true, plane2.IsInterceptionWithRay(start, forward));
            });
        }

        [Test]
        public void IsIntersectionOfVectorAndSphereReturnCorrectValue()
        {
            Sphere sphere1 = new Sphere(new TrueComputerGraphics.Types.Point(3, 0, 5), 3);
            Sphere sphere2 = new Sphere(new TrueComputerGraphics.Types.Point(0, 0, 5), 3);
            Sphere sphere3 = new Sphere(new TrueComputerGraphics.Types.Point(4, 0, 5), 3);

            Point start = new Point(0, 0, 0);
            Vector forward = new Vector(0, 0, 1);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, sphere1.IsInterceptionWithRay(start, forward));
                Assert.AreEqual(true, sphere2.IsInterceptionWithRay(start, forward));
                Assert.AreEqual(false, sphere3.IsInterceptionWithRay(start, forward));
            });
        }
    }
}