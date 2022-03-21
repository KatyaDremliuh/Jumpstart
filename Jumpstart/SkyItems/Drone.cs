using System;

namespace Jumpstart
{
    class Drone : IFlyable
    {
        private Coordinate _currentPosition;
        public static string FlyingObject => "Drone";
        private double Speed { get; }
        private const double MaxDistance = 1000;

        public Drone(double speed)
        {
            this.Speed = speed;
        }

        public Drone(Coordinate currentPosition, double speed)
        {
            this._currentPosition = currentPosition;
            this.Speed = speed;
        }

        public void FlyTo(Coordinate destinationPoint)
        {
            Console.WriteLine($"{FlyingObject}\n" + _currentPosition.Info("start"));
            Console.WriteLine(destinationPoint.Info("end"));
        }

        public void GetFlyTime(Coordinate nextPosition)
        {
            const int minutesInHour = 60;

            double distanceNeedToFly = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);

            if (!IsChargedBattery(distanceNeedToFly))
            {
                distanceNeedToFly = MaxDistance;
            }

            double idealJourneyTimeInHours = distanceNeedToFly / Speed;
            double idealJourneyTimeInMinutes = idealJourneyTimeInHours * minutesInHour;
            int wastedTime = (int)idealJourneyTimeInMinutes / 10;
            double realJourneyTimeInMinutes = idealJourneyTimeInMinutes + wastedTime;

            Console.WriteLine($"Distance: {distanceNeedToFly:F2} km" +
                              $"\nSpeed: {Speed:F2}" +
                              $"\nJourney time: {realJourneyTimeInMinutes / minutesInHour:F2} h\n");
        }

        /// <summary>
        /// The method verifies if the distance that a drone needs to fly is valid.
        /// The drone can fly only 1000 km. If the distance between the start-point
        /// and the destination-point is more than 1000 km the battery is low.
        /// </summary>
        /// <param name="distanceNeedToFly">The distance between point A and B.</param>
        /// <returns></returns>
        private static bool IsChargedBattery(double distanceNeedToFly)
        {
            bool isChargetBattery = distanceNeedToFly <= 1000;

            return isChargetBattery;
        }
    }
}
