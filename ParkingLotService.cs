using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class ParkingLotService
    {
        private ParkingLot parkingLot;
        TicketService ticketService = new TicketService();
        public ParkingLotService(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
        {
            parkingLot = new ParkingLot(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);
        }

        public void DisplayAvailableSlots()
        {
            parkingLot.OccupiedSlots();
            parkingLot.AvailableSlots();
        }
        public bool IsSlotAvailable(VehicleType vehicleType)
        {
            int c = parkingLot.GetSlots(vehicleType);
            if (vehicleType == VehicleType.TwoWheeler)
            {
                return c < parkingLot.twoWheelerSlots;
            }
            else if (vehicleType == VehicleType.FourWheeler)
            {
                return c < parkingLot.fourWheelerSlots;
            }
            else if (vehicleType == VehicleType.HeavyVehicle)
            {
                return c < parkingLot.heavyVehicleSlots;
            }
            else
            {
                return false;
            }
        }
        public int GetNextAvailableSlot(VehicleType vehicleType)
        {
            int slotNumber = 1;
            while (parkingLot.parkedVehicles.Any(v => v.Value == slotNumber && v.Key.VehicleType == vehicleType))
            {
                slotNumber++;
            }
            return slotNumber;
        }
        
        public bool ParkVehicle()
        {
            Console.Write(Constants.VehicleNumber);
            String vehicleNumber = Helper.Input<string>();
            Console.WriteLine(Constants.VehicleType);
            int option = Helper.Input<int>();
            VehicleType vehicleType = default;
            switch (option)
            {
                case 1:
                    vehicleType = VehicleType.TwoWheeler;
                    break;
                case 2:
                    vehicleType = VehicleType.FourWheeler;
                    break;
                case 3:
                    vehicleType = VehicleType.HeavyVehicle;
                    break;
                default:
                    Console.WriteLine(Constants.ValidNumber);
                    break;
            }
            if (IsSlotAvailable(vehicleType))
            {
                int slotNumber = GetNextAvailableSlot(vehicleType);
                Ticket ticket = ticketService.GenerateTicket(vehicleNumber, vehicleType,slotNumber);
                parkingLot.tickets.Add(ticket);
                parkingLot.parkedVehicles.Add(new Vehicle(vehicleNumber, vehicleType), slotNumber);
                Console.WriteLine("\nVehicle " + vehicleNumber +" parked successfully");
                ticket.DisplayTicket();
                return true;
            }
            else
            {
                Console.WriteLine("\nNo available Slots for the vehicle\n");
                return false;
            }
        }

        public void UnparkVehicle()
        {
            Console.Write(Constants.VehicleNumberToUnpark);
            string vehicleNumber = Helper.Input<string>();
            Vehicle parkedVehicle = parkingLot.parkedVehicles.Keys.FirstOrDefault(v => v.VehicleNumber == vehicleNumber);
            if (parkedVehicle != null)
            {
                parkingLot.parkedVehicles.Remove(parkedVehicle);
                Console.WriteLine("\nVehicle "+vehicleNumber+" Unparked Successfully");
                ticketService.UpdateOutTime(parkingLot.tickets, vehicleNumber);
            }
            else
            {
                Console.WriteLine("\nVehicle Not Found\n");
            }
        }
    }
}
