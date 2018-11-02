using System;

namespace TripProgram
{
    public class MyCustomType_Trip
    {
        public decimal TotalGallonsOfGasUsed { get; set; }
        public decimal TotalMilesDriven { get; set; }
        public decimal TripMPG => Math.Round(TotalMilesDriven / TotalGallonsOfGasUsed, 2);
    }
}
