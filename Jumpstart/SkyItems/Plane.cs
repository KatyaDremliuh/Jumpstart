using System;

namespace Jumpstart
{
    class Plane : IFlyable
    {
        private Coordinate _currentPosition;
        private static string FlyingObject => "Plane";
        private ushort _speed = 200;
        private const ushort MaxPlaneSpeed = 900;

        public Plane() { }

        public Plane(Coordinate currentPosition)
        {
            this._currentPosition = currentPosition;
        }

        public void FlyTo(Coordinate destinationPoint)
        {
            Console.WriteLine($"{FlyingObject}\n" + _currentPosition.Info("start"));
            Console.WriteLine(destinationPoint.Info("end"));
        }

        public void GetFlyTime(Coordinate nextPosition)
        {
            double distanceNeedToFly = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);
            double fullJourneyTime = CalculateFullTime(distanceNeedToFly);

            Console.WriteLine($"Distance: {distanceNeedToFly:F2} km" +
                              $"\nMax speed: {_speed:F2} km/h" +
                              $"\nJourney time: {fullJourneyTime:F2} h\n");
        }

        /// <summary>
        /// The method calculates the full travel time.
        /// The initial plane's speed is 200 km/h.
        /// The speed grows every 10 km of flight by 10 km/h.
        /// If the plane has reached its maximum speed
        /// it flies the rest of the way with the maximum speed, that is 900 km/h.
        /// </summary>
        /// <param name="distanceNeedToFly">The distance between point A and B.</param>
        /// <returns></returns>
        private double CalculateFullTime(double distanceNeedToFly)
        {
            const double pastDistance = 10;
            double spentTime = 0;

            if (distanceNeedToFly <= pastDistance)
            {
                return distanceNeedToFly / _speed;
            }

            do
            {
                spentTime += pastDistance / _speed;

                if (!IsSpeedMax(_speed))
                {
                    _speed += 10;
                }
                else
                {
                    _speed = MaxPlaneSpeed;
                }

                distanceNeedToFly -= 10;
            }
            while (distanceNeedToFly >= pastDistance && _speed != MaxPlaneSpeed);

            return (distanceNeedToFly / _speed) + spentTime;
        }

        private static bool IsSpeedMax(ushort currentSpeed)
        {
            return currentSpeed >= MaxPlaneSpeed;
        }
    }
}
