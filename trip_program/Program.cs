using System;
using System.Collections.Generic;
using System.Linq;

namespace trip_program
{
    public class Program
    {
        private static List<MyCustomType_Vehicle> _myVehicles = new List<MyCustomType_Vehicle>();

        public static void Main()
        {
            bool doneAddingVehicles = false;

            do
            {
                MyCustomType_Vehicle vehicleToAdd = UserPrompts.InputNewVehicle();

                if (vehicleToAdd == null)
                    doneAddingVehicles = true;
                else
                    _myVehicles.Add(vehicleToAdd);

            } while (!doneAddingVehicles);

            Console.Clear();

            if (_myVehicles.Any())
            {
                DisplaySingleBestMPGTrip();
                DisplayVehicleWithTheBestMPG();
                DumpAllData();
            }
            else
            {
                Console.WriteLine("No vehicles with trips entered");
                UserPrompts.Exit();
            }
        }

        #region Private Methods

        private static void DumpAllData()
        {
            Console.WriteLine();
            Console.WriteLine("Press \"Y\" to display all stored data");
            Console.Write("Press any other key to exit ");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
            {
                Console.Clear();

                foreach (var vehicle in _myVehicles)
                {

                    Console.WriteLine($"{nameof(MyCustomType_Vehicle.VehicleName)}: {vehicle.VehicleName}");
                    Console.WriteLine($"{nameof(MyCustomType_Vehicle.TotalMPGForAllTrips)}: {vehicle.TotalMPGForAllTrips}");

                    for (int i = 0; i < vehicle.VehicleTrips.Count; i++)
                    {
                        Console.WriteLine($"\nTrip #{i + 1}");
                        Console.WriteLine($"{nameof(MyCustomType_Trip.TotalMilesDriven)}: {vehicle.VehicleTrips[i].TotalMilesDriven}");
                        Console.WriteLine($"{nameof(MyCustomType_Trip.TotalGallonsOfGasUsed)}: {vehicle.VehicleTrips[i].TotalGallonsOfGasUsed}");
                        Console.WriteLine($"{nameof(MyCustomType_Trip.TripMPG)}: {vehicle.VehicleTrips[i].TripMPG}");
                    }
                }

                UserPrompts.Exit();
            }
        }

        private static void DisplaySingleBestMPGTrip()
        {
            MyCustomType_Vehicle vehicleWithBestMPGTrip = _myVehicles
                .OrderByDescending(v => v.BestMPGTrip.TripMPG)
                .First();

            Console.WriteLine($"The best MPG trip was in the {vehicleWithBestMPGTrip.VehicleName} with {vehicleWithBestMPGTrip.BestMPGTrip.TripMPG}");
        }

        private static void DisplayVehicleWithTheBestMPG()
        {
            MyCustomType_Vehicle vehicleWithBestMPG = _myVehicles
                .OrderByDescending(v => v.TotalMPGForAllTrips)
                .First();

            Console.WriteLine($"The {vehicleWithBestMPG.VehicleName} had the best total MPG at {vehicleWithBestMPG.TotalMPGForAllTrips}");
        }

        #endregion
    }
}
