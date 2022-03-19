namespace Jumpstart.VehicleFleet.Specs
{
  public  class Transmission
    {
        public TransmissionType TransmissionType { get; set; }
        public byte NumberOfTransmission { get; set; }
        public string Vendor { get; set; }

        public Transmission(string vendor, byte numberOfTransmission = 5, TransmissionType transmissionType = TransmissionType.Mechanical)
        {
            TransmissionType = transmissionType;
            NumberOfTransmission = numberOfTransmission;
            Vendor = vendor;
        }

        public Transmission() { }
    }
}
