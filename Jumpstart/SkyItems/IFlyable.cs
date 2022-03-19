namespace Jumpstart
{
    public interface IFlyable
    {
        void GetFlyTime(Coordinate nextPosition);
        void FlyTo(Coordinate destinationPoint);
    }
}
