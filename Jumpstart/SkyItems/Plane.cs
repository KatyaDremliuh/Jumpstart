using System;

namespace Jumpstart
{
    class Plane : IFlyable
    {
        // самолет увеличивает скорость на 10 км/ч каждые 10 км полета от начальной скорости 200 км/ч

        private static string FlyingObject => "Plane";
        private double _speed = 200;
        private Coordinate _currentPosition;

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
            double distance = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);

            double route = distance;
            while (route > 0)
            {
                route -= 10;
                _speed += 10;
            }

            Console.WriteLine($"Distance: {distance:F2} km" +
                              $"\nSpeed: {_speed}" +
                              $"\nJourney time: {distance / _speed:F2} h");
        }
    }
}
