namespace Jumpstart.VehicleFleet.Specs
{
    public class Engine
    {
        public int Power { get; set; }
        public double EngineCapacity { get; set; }
        public EngineType EngineType { get; set; }
        public string VinNumber { get; set; }

        public Engine(int power, double engineCapacity, string vinNumber, EngineType engineType = EngineType.Petrol)
        {
            this.Power = power;
            this.EngineCapacity = engineCapacity;
            this.EngineType = engineType;
            this.VinNumber = vinNumber;
        }

        public Engine() { }
    }
}
