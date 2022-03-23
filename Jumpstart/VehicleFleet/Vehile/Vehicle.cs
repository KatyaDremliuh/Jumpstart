using System;

namespace Jumpstart.VehicleFleet.Vehile
{
    /*
     * Для создания программы по управлению автопарком нужно реализовать следующие сущности в виде отдельных классов:
     * "Двигатель"(включает в себя поля мощность, объем, тип, серийный номер),
     * "Шасси"(количество колес, номер, допустимая нагрузка),
     * "Трансмиссия" (тип, количество передач, производитель).
     *
     * С использованием этих классов реализовать сущности
     * "Легковой автомобиль",
     * "Грузовик",
     * "Автобус",
     * "Скутер" (отличающиеся уникальными полями),
     * и обеспечить вывод полной информации об объектах этих типов.
     */

    public abstract class Vehicle : Specs.Specs
    {
        public abstract string VehicleType { get; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"\tVehicle type: {VehicleType} **{CarModel}**" +
                              $"\n---Chassis description---" +
                              $"\n\tWheel: {Chassis.Wheel}" +
                              $"\n\tChassis Vin number: {Chassis.VinChassis}" +
                              $"\n\tChassis safe load: {Chassis.SafeLoad}" +
                              $"\n---Engine description---" +
                              $"\n\tPower: {Engine.Power}" +
                              $"\n\tCapacity: {Engine.EngineCapacity}" +
                              $"\n\tEngine type: {Engine.EngineType}" +
                              $"\n\tEngine Vin number: {Engine.VinNumber}" +
                              $"\n---Transmission description---" +
                              $"\n\tTransmission type: {Transmission.TransmissionType}" +
                              $"\n\tNumber of transmission: {Transmission.NumberOfTransmission}" +
                              $"\n\tVendor: {Transmission.Vendor}\n");
        }
    }
}
