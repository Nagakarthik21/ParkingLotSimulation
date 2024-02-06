using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class Ticket
    {
        public string VehicleNumber {  get; }
        public VehicleType VehicleType { get; }
        public int SlotNumber {  get; }
        public DateTime InTime { get; } 

        public DateTime OutTime { get; set; }

        public Ticket(string vehicleNumber, VehicleType vehicleType,int slotNumber, DateTime inTime,DateTime outTime)
        {
            VehicleNumber = vehicleNumber;
            VehicleType = vehicleType;
            SlotNumber = slotNumber;
            InTime = inTime;
            OutTime = outTime;
        }

        public void DisplayTicket()
        {
            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine("|Vehicle Number : " + VehicleNumber);
            Console.WriteLine("|Vehicle Type : " + VehicleType);
            Console.WriteLine("|Slot Number : " + SlotNumber);
            Console.WriteLine("|InTime : " + InTime);
            Console.WriteLine("|OutTime : " + OutTime);
            Console.WriteLine("---------------------------------------------------------------------\n");
        }
    }
}
