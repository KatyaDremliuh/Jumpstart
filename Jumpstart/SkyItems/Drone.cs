using System;

namespace Jumpstart
{
    class Drone : IFlyable
    {
        // дрон зависает в воздухе каждые 10 минут полета на 1 минуту

        private static string FlyingObject => "Drone";
        private double Speed { get; set; }
        private Coordinate _currentPosition;

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

            double distance = _currentPosition.DistanceBetweenTwoPoints(_currentPosition, nextPosition);

            double idealJourneyTimeInHours = distance / Speed;
            double idealJourneyTimeInMinutes = idealJourneyTimeInHours * minutesInHour;
            int wastedTime = (int)idealJourneyTimeInMinutes / 10;
            double realJourneyTimeInMinutes = idealJourneyTimeInMinutes + wastedTime;

            Console.WriteLine($"Distance: {distance:F2} km" +
                              $"\nSpeed: {Speed}" +
                              $"\nJourney time: {realJourneyTimeInMinutes / minutesInHour:F2} h");
        }
    }
}
