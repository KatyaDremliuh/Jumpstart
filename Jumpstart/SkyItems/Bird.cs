using System;

namespace Jumpstart
{
    class Bird : IFlyable
    {
        private Coordinate _currentPosition;
        public bool IsWindy { get; set; }
        public static string FlyingObject => "Bird";
        private readonly Random _randomSpeed = new Random();
        private double _speed;

        public Bird(bool isWindy = false)
        {
            this.IsWindy = isWindy;
        }

        public Bird(Coordinate currentPosition)
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
            double distance = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);

            _speed = GetBirdSpeed();

            Console.WriteLine($"Distance: {distance:F2} km" +
                              $"\nSpeed: {_speed:F2} km/h" +
                              $"\nJourney time: {CalculateTime(distance):F2} h\n");
        }

        /// <summary>
        /// The method calculates bird's speed.
        /// The bird has random speed between 0 and 20 km/h.
        /// If the wind is blowing, the bird's speed decreases by 30%.
        /// </summary>
        /// <returns>Bird's speed.</returns>
        private double GetBirdSpeed()
        {
            _speed = _randomSpeed.Next(21);

            const double speedPercentage = 0.7;
            if (IsWindy)
            {
                _speed *= speedPercentage;
            }

            return _speed;
        }

        private double CalculateTime(double distance)
        {
            return distance / _speed;
        }
    }
}
