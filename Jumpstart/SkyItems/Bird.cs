using System;

namespace Jumpstart
{
    class Bird : IFlyable
    {
        // птица летит все расстояние с постоянной скоростью в диапазоне 0-20 км/ч (заданной случайно)

        public string FlyingObject => "Bird";
        private readonly Random _randomSpeed = new Random();
        private Coordinate _currentPosition;

        public Bird() { }

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
            double speed = _randomSpeed.Next(21);

            Console.WriteLine($"Distance: {distance:F2} km" +
                              $"\nSpeed: {speed}" +
                              $"\nJourney time: {distance / speed:F2} h");
        }
    }
}
