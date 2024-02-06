using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class Vehicle: IComparable<Vehicle>
    {
        public string VehicleNumber { get; }
        public VehicleType VehicleType { get; }
        public Vehicle(string vehicleNumber,VehicleType type)
        {
            VehicleNumber = vehicleNumber;
            VehicleType = type;
        }
        public int CompareTo(Vehicle vehicle)
        {
            return VehicleType.CompareTo(vehicle.VehicleType);
        }
    }
}
