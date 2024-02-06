using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class TicketService
    {
        public Ticket GenerateTicket(string vehicleNumber,VehicleType vehicleType,int slotNumber)
        {
            DateTime inTime = DateTime.Now;
            return new Ticket(vehicleNumber, vehicleType, slotNumber, inTime, default);
        }
        
        public void UpdateOutTime(List<Ticket> tickets,string vehicleNumber)
        {
            foreach(Ticket ticket in tickets)
            {
                if(ticket.VehicleNumber == vehicleNumber)
                {
                    ticket.OutTime = DateTime.Now;
                    ticket.DisplayTicket();
                    break;
                }
            }
        }
    }
}
