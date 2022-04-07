namespace Jumpstart.VehicleFleet.TechnicalSpecs
{
    public class Engine
    {
        public ushort Power { get; set; } // л.с. мощность
        public double Capacity { get; set; } // л объем
        public EngineType Type { get; set; } // тип
        public string VinNumber { get; set; } // серийный номер

        public Engine(ushort power, double capacity, string vinNumber, EngineType type = EngineType.Petrol)
        {
            this.Power = power;
            this.Capacity = capacity;
            this.Type = type;
            this.VinNumber = vinNumber;
        }

        public Engine() { }
    }
}
