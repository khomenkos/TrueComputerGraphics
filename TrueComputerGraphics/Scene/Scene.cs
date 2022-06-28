﻿using System;
using System.Collections.Generic;
using System.Text;
using TrueComputerGraphics.Interfaces;
using TrueComputerGraphics.Objects;
using TrueComputerGraphics.Types;

namespace TrueComputerGraphics.Scene
{
    public class Scene
    {
        private List<IObject> objects = new List<IObject>();
        private Camera Camera;
        private Light light;
        private float[,] screen;

        public Scene(Camera camera, Light light)
        {
            this.light = light;
            Camera = camera;
            screen = new float[camera.width, camera.height];
        }

        public void AddObject(IObject newObject)
        {
            objects.Add(newObject);
        }


        public void AddObjects(List<IObject> newObjects)
        {
            for (int i = 0; i < newObjects.Count; i++)
            {
                objects.Add(newObjects[i]);
            }
        }

        public float[,] GetScreen()
        {
            var w = Camera.Direction;
            var u = Vector.Cross(w, Camera.Up);
            var v = Vector.Cross(u, w);

            var pixelHeight = Camera.RealPlaneHeight / Camera.height;
            var pixelWidth = Camera.RealPlaneWidht / Camera.width;

            var scanlineStart = Camera.PlaneOrigin - (Camera.width / 2) * pixelWidth * u + (pixelWidth / 2) * u +
                (Camera.height / 2) * pixelHeight * v - (pixelHeight / 2) * v;
            var scanlineStartPoint = new Point(scanlineStart.x, scanlineStart.y, scanlineStart.z);

            var pixelWidthU = pixelWidth * u;
            var pixelHeightV = pixelHeight * v;

            for (int x = 0; x < Camera.height; x++)
            {
                int yIterator = 0;
                var pixelCenter = new Point(scanlineStartPoint.x, scanlineStartPoint.y, scanlineStartPoint.z);

                for (int y = 0; y < Camera.width; y++)
                {
                    var ray = pixelCenter - Camera.Position;
                    var result = TheNearest(Camera.Position, ray, out Point IntersectionPoint, out IObject IntersectionObject);

                    if (result != null)
                    {
                        var a = light.Direction * Vector.Negate(Vector.Normilize(result));

                        if (isPointInShadow(IntersectionPoint, IntersectionObject))
                        {
                            a /= 2;
                        }

                        screen[x, yIterator] = a;
                    }
                    else
                    {
                        screen[x, yIterator] = 255;
                    }

                    yIterator++;

                    pixelCenter = new Point(pixelCenter.x + pixelWidthU.x, pixelCenter.y + pixelWidthU.y, +pixelCenter.z + pixelWidthU.z);
                }
                scanlineStartPoint = new Point(scanlineStartPoint.x - pixelHeightV.x, scanlineStartPoint.y - pixelHeightV.y, +scanlineStartPoint.z - pixelHeightV.z);
            }
            return screen;
        }

        public Vector TheNearest(Point start, Vector vector, out Point IntersectionPoint, out IObject IntersectionObject)
        {
            float minDistance = Int32.MaxValue;
            IntersectionObject = null;
            IntersectionPoint = null;
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].IsInterceptionWithRay(start, vector))
                {
                    Point tempIntercept = objects[i].WhereInterceptionWithRay(start, vector);
                    float distance = Point.Distance(tempIntercept, start);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        IntersectionObject = objects[i];
                        IntersectionPoint = tempIntercept;
                    }
                }
            }

            if (IntersectionObject != null)
                return IntersectionObject.GetNormalOnPoint(IntersectionPoint);

            return null;
        }

        public bool isPointInShadow(Point startPoint, IObject startObject)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (startObject == objects[i])
                {
                    continue;
                }
                if (objects[i].IsInterceptionWithRay(startPoint, Vector.Negate(light.Direction)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
