namespace Jumpstart.VehicleFleet.Vehicle
{
    public class Bus : VehicleRecord
    {
        public override string VehicleType => "Bus";
        public byte NumberOfPassengersSeats { get; set; }

        public Bus() { }

        public override string ToString()
        {
            return base.ToString() + $"---Further details---\n\tNumber of passengers seats: {NumberOfPassengersSeats}";
        }
    }
}