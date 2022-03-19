namespace Jumpstart
{
    public interface IFlyable
    {
        void GetFlyTime(Coordinate nextPosition);
        void GetFlyTime(Coordinate nextPosition, bool isWindy);
        void FlyTo(Coordinate destinationPoint);
    }
}
