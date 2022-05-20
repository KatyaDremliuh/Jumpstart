namespace Jumpstart.VehicleFleet.Vehicle
{
    public interface IHolder
    {
        void AddVehicleToDictionary(VehicleRecord record);
        void UpdateDictionary(VehicleRecord record);
        void RemoveVehicleFromDictionary(VehicleRecord record);
    }
}