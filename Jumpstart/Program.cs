namespace Jumpstart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu menu = new Menu();
            //menu.ShowMenu();


            IFlyable x1 = new Bird();
            Bird c = new Bird(new Coordinate(), 22);
            c.GetFlyTime(new Coordinate(44,44,44));
            x1.GetFlyTime(new Coordinate(44, 44, 44), true);
            x1.GetFlyTime(new Coordinate(44, 44, 44), false);
            x1.GetFlyTime(new Coordinate(44, 44, 44));

            //IFlyable x2 = new Bird(new Coordinate(0, 0, 0));
            //x2.GetFlyTime(new Coordinate(), new Coordinate(190, 87, 65), false);

            //IFlyable drone = new Drone();
            //drone.FlyTo(new Coordinate(12, 6, 6), new Coordinate(12, 6, 6));
            //drone.GetFlyTime(new Coordinate(12, 6, 6), new Coordinate(10, 5, 3), 12);

        }
    }
}