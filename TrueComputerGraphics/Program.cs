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

            string path = @"/Users/anymacstore/Downloads/Учеба/3 Курс - Семестр 2/Комп'ютерна графіка та обробка зображень/cow.obj";
            ComplexObject objectsasd = new ComplexObject(FileWorker.FileWorker.ReadObject(path));
            objectsasd.RotateY(90);
            objectsasd.RotateX(30);
            objectsasd.Scale(2, 2, 2);
            scene.AddObjects(objectsasd.objects);

            Plane plane = new Plane(new Point(-1, 0, 0), new Vector(1, 0, 0));
            scene.AddObject(plane);

            float[,] screen = scene.GetScreen();

            string imagePath = @"/Users/anymacstore/Downloads/cow.ppm";
            FileWorker.FileWorker.WriteImage(imagePath, screen);
        }
    }
}