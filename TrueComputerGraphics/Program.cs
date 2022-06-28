using System;
using TrueComputerGraphics.Objects;
using TrueComputerGraphics.Types;


namespace TrueComputerGraphics
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(new Point(0, 0, -2), new Vector(0, 0, 1), 100, 100, 60);
            Light light = new Light(Vector.Normilize(new Vector(-1, 1, 1)));

            Scene.Scene scene = new Scene.Scene(camera, light);

            string path = @" ";
            ComplexObject objectsasd = new ComplexObject(FileWorker.FileWorker.ReadObject(path));
            scene.AddObjects(objectsasd.objects);

            Sphere sphere = new Sphere(new Point(0, 0, 3), 1);
            scene.AddObject(sphere);

            Triangle triangle = new Triangle(new Point(0, 0, 30), new Point(-2, -2, 30), new Point(-2, 2, 3), new Vector(1, 0, -1), new Vector(1, 0, -1), new Vector(-1, 0, -1));
            //Triangle triangle = new Triangle(new Point(0, 0, 0), new Point(-2, -2, 0), new Point(-2, 2, 0));
            scene.AddObject(triangle);

            Plane plane = new Plane(new Point(-1, 0, 0), new Vector(1, 0, 0));
            scene.AddObject(plane);

            float[,] screen = scene.GetScreen();

            string imagePath = @" ";
            FileWorker.FileWorker.WriteImage(imagePath, screen);
        }
    }
}