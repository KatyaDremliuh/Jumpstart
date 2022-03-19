using System;
using System.Collections.Generic;

namespace Jumpstart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu menu = new Menu();
            //menu.ShowMenu();


            Coordinate destination = new Coordinate(44, 44, 44);

            IFlyable bird = new Bird();
            IFlyable plane = new Plane();
            IFlyable drone = new Drone(10);
            List<IFlyable> flyingObjects = new List<IFlyable>() { bird, plane, drone };

            bird.FlyTo(destination);
            foreach (var flyingObject in flyingObjects)
            {
                flyingObject.GetFlyTime(destination);
                Console.WriteLine();
            }
        }
    }
}