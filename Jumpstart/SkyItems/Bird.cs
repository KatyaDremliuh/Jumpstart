using System;

namespace Jumpstart
{
    class Bird : IFlyable
    {
        private Coordinate _currentPosition;
        private readonly double _speed = 50;

        public Bird() { }

        public Bird(Coordinate currentPosition)
        {
            this._currentPosition = currentPosition;
        }

        public Bird(Coordinate currentPosition, double speed)
        {
            this._currentPosition = currentPosition;
            this._speed = speed;
        }

        public void FlyTo(Coordinate destinationPoint)
        {
            Console.WriteLine(_currentPosition.Info("Start"));
            Console.WriteLine(destinationPoint.Info("End"));
        }

        public void GetFlyTime(Coordinate nextPosition)
        {
            double distance = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);
            Console.WriteLine($"{distance / _speed:F3}");
        }

        public void GetFlyTime(Coordinate nextPosition, bool isWindy)
        {
            double distance = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);

            double speed = СalculateFlyingSpeed(isWindy);
            
            Console.WriteLine($"{distance / speed:F3}");
        }

        private double СalculateFlyingSpeed(bool isWindy)
        {
            return isWindy ? _speed / 1.3 : _speed;
        }
    }
}
