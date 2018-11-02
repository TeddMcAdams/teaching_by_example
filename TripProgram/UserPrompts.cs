using System;
using System.Linq;

namespace TripProgram
{
    internal static class UserPrompts
    {
        internal static void Exit()
        {
            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }

        internal static MyCustomType_Vehicle InputNewVehicle()
        {
            MyCustomType_Vehicle vehicleToAdd = null;

            string userInputVehicleName = AskUserForVehicleName();

            // If user enters anything aside from 'done' we will create a new vehicle
            if (!string.Equals(userInputVehicleName, "done", StringComparison.OrdinalIgnoreCase))
            {
                vehicleToAdd = new MyCustomType_Vehicle(userInputVehicleName);

                bool doneAddingTrips = false;
                bool showWarning = false;
                do
                {
                    MyCustomType_Trip tripToAdd = InputNewTrip(showWarning);

                    if (tripToAdd == null && !vehicleToAdd.VehicleTrips.Any())
                    {
                        showWarning = true;
                    }
                    else if (tripToAdd == null)
                    {
                        doneAddingTrips = true;
                    }
                    else
                    {
                        showWarning = false;
                        vehicleToAdd.VehicleTrips.Add(tripToAdd);
                    }

                } while (!doneAddingTrips);
            }

            return vehicleToAdd;
        }

        #region Private Methods

        private static MyCustomType_Trip InputNewTrip(bool showWarning)
        {
            MyCustomType_Trip tripToAdd = null;

            decimal tripLength = AskUserForTripLength(showWarning);

            if (tripLength > 0)
            {
                tripToAdd = new MyCustomType_Trip() { TotalMilesDriven = tripLength };
                tripToAdd.TotalGallonsOfGasUsed = AskUserForGallonsOfGasUsed();
                Console.WriteLine($"MPG for this trip is {tripToAdd.TripMPG}");
                Console.WriteLine("Press any key to continue . . . ");
                Console.ReadKey();
            }

            return tripToAdd;
        }

        private static string AskUserForVehicleName()
        {
            string vehicleName = null;
            bool validUserInput = true;

            do
            {
                Console.Clear();
                if (!validUserInput)
                    Console.WriteLine("Please enter a valid vehicle name");

                Console.WriteLine("Enter vehicle name (\"done\" to stop) : ");
                string userInputVehicleName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInputVehicleName))
                    validUserInput = false;
                else
                    vehicleName = userInputVehicleName;

            } while (!validUserInput);

            return vehicleName;
        }

        private static decimal AskUserForTripLength(bool showWarning)
        {
            decimal tripLength = 0;
            bool validUserInput = true;

            do
            {
                Console.Clear();
                if (showWarning)
                    Console.WriteLine("You must enter at least one trip");

                if (!validUserInput)
                    Console.WriteLine("Invalid input, please enter a number");

                Console.WriteLine("Trip Length (negative to finish) : ");
                string userInputTripLength = Console.ReadLine();

                validUserInput = decimal.TryParse(userInputTripLength, out tripLength);

            } while (!validUserInput);

            return tripLength;
        }

        private static decimal AskUserForGallonsOfGasUsed()
        {
            decimal gallonsOfGasUsed = 0;
            bool validUserInput = true;

            do
            {
                if (!validUserInput)
                    Console.WriteLine("Invalid input, please enter a number greater than zero");

                Console.WriteLine("Gallons : ");
                string userInputGallonsOfGasUsed = Console.ReadLine();

                validUserInput = decimal.TryParse(userInputGallonsOfGasUsed, out gallonsOfGasUsed) &&
                    gallonsOfGasUsed > 0;

            } while (!validUserInput);

            return gallonsOfGasUsed;
        }

        #endregion

    }
}
