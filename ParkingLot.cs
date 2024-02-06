using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class ParkingLot
    {
        public int twoWheelerSlots;
        public int fourWheelerSlots;
        public int heavyVehicleSlots;
        public ParkingLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
        {
            this.twoWheelerSlots = twoWheelerSlots;
            this.fourWheelerSlots = fourWheelerSlots;
            this.heavyVehicleSlots = heavyVehicleSlots;
        }

        public Dictionary<Vehicle,int> parkedVehicles = new Dictionary<Vehicle,int>();
        public List<Ticket> tickets = new List<Ticket>();
        
        public void OccupiedSlots()
        {
            var sortedParkedVehicles = parkedVehicles.OrderBy(vehicle=>vehicle.Key);
            foreach (var parked in sortedParkedVehicles)
            {
                Console.WriteLine(parked.Key.VehicleType + " Slot " + parked.Value + " is Occupied by " + parked.Key.VehicleNumber);
            }
        }
        public void AvailableSlots()
        {
            Console.WriteLine("\nParking Lot Available slots are");
            Console.WriteLine(VehicleType.TwoWheeler + " : " + (twoWheelerSlots - GetSlots(VehicleType.TwoWheeler)));
            Console.WriteLine(VehicleType.FourWheeler + " : " + (fourWheelerSlots - GetSlots(VehicleType.FourWheeler)));
            Console.WriteLine(VehicleType.HeavyVehicle + " : " + (heavyVehicleSlots - GetSlots(VehicleType.HeavyVehicle)));
        }
        public int GetSlots(VehicleType vehicleType)
        {
            return parkedVehicles.Count(v => v.Key.VehicleType == vehicleType);
        }

    }
}
