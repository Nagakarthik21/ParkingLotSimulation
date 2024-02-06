using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class StartUp
    {
        static void Main()
        {
            Console.Write(Constants.NoOfTwoWheeler);
            int twoWheelerSlots = Helper.Input<int>();
            Console.Write(Constants.NoOfFourWheeler);
            int fourWheelerSlots = Helper.Input<int>();
            Console.Write(Constants.NoOfHeavyVehicle);
            int heavyVehicleSlots = Helper.Input<int>();

            ParkingLotService parkingLotService = new ParkingLotService(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);
            while (true)
            {
                parkingLotService.DisplayAvailableSlots();
                Console.WriteLine("\nChoose your Option");
                Console.WriteLine("1. Park Vehicle");
                Console.WriteLine("2. UnPark Vehicle");
                Console.WriteLine("3. Exit");

                int choice = Helper.Input<int>();
                if(choice<1 || choice > 3)
                {
                    Console.WriteLine(Constants.ValidNumber);
                    choice = Helper.Input<int>();
                }
                switch (choice)
                {
                    case 1:
                        parkingLotService.ParkVehicle();
                        break;
                    case 2:
                        parkingLotService.UnparkVehicle();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Constants.ValidNumber);
                        break;
                }
            }
        }
    }
}
