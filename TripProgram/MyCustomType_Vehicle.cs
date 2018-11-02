using System;
using System.Collections.Generic;
using System.Linq;

namespace TripProgram
{
    public class MyCustomType_Vehicle
    {
        public string VehicleName { get; private set; }
        public List<MyCustomType_Trip> VehicleTrips { get; private set; }
        public decimal TotalMPGForAllTrips => Math.Round(VehicleTrips.Sum(t => t.TotalMilesDriven) / VehicleTrips.Sum(t => t.TotalGallonsOfGasUsed), 2);
        public MyCustomType_Trip BestMPGTrip => VehicleTrips.OrderByDescending(t => t.TripMPG).FirstOrDefault();

        public MyCustomType_Vehicle(string vehicleName)
        {
            VehicleName = vehicleName;
            VehicleTrips = new List<MyCustomType_Trip>();
        }
    }
}
