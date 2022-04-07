using System;
using System.Collections.Generic;

namespace Jumpstart.SkyItems
{
    public static class ControlOfTheSkyItems
    {
        public static void CreateSkyItems(string command)
        {
            Console.Clear();

            Coordinate destination = new Coordinate(44, 44, 44);

            Bird birdNoWind = new Bird();
            Bird birdWithWind = new Bird(true);
            Drone drone = new Drone(78);
            Plane plane = new Plane();

            List<IFlyable> flyingObjects = new() { birdNoWind, birdWithWind, drone, plane };

            flyingObjects[0].FlyTo(destination);
            foreach (var flyingObject in flyingObjects)
            {
                Console.WriteLine($"----- {RecognizeFlyingObjectType(flyingObject)} -----");
                flyingObject.GetFlyTime(destination);
            }
        }

        private static string RecognizeFlyingObjectType(IFlyable flyingObject)
        {
            string fullName = flyingObject.GetType().ToString();
            return fullName[(fullName.LastIndexOf('.') + 1)..];
        }
    }
}
