namespace Jumpstart
{
    class Plane 
    {
        public int Speed { get; }

        public Plane(int speed = 850)
        {
            this.Speed = speed;
        }


        public void GetFlyTime(Coordinate currentPosition, Coordinate nextPosition, double speed)
        {
            throw new System.NotImplementedException();
        }

        public void GetFlyTime(Coordinate currentPosition, Coordinate nextPosition, bool isWindy)
        {
            throw new System.NotImplementedException();
        }

        public void FlyTo(Coordinate destinationPoint)
        {
            throw new System.NotImplementedException();
        }
    }
}
