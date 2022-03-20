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
            Coordinate destination1 = new Coordinate(1144, 1144, 1144);


            IFlyable bird = new Bird();
            IFlyable plane = new Plane();
            Drone drone = new Drone(10);
            drone.GetFlyTime(destination);

            Drone drone1 = new Drone(10);
            drone1.GetFlyTime(destination1);

            List<IFlyable> flyingObjects = new List<IFlyable>() { bird, plane, drone };

            bird.FlyTo(destination);
            foreach (var flyingObject in flyingObjects)
            {
                string type = string.Empty;
                if (flyingObject is Drone)
                {
                    type = drone.FlyingObject;
                }

                Console.WriteLine(type);
                flyingObject.GetFlyTime(destination);
                Console.WriteLine();
            }
        }

        
    }
}