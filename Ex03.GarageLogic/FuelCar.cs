using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        private eCarColor m_Color;
        private eCarNumberOfDoors m_DoorsAmount;
        private const int k_WheelsNumber = 5;
        private const int k_MaxWheelAirPressure = 31;
        private const float k_MaxFuelAmount = 45f;

        public FuelCar() : base(k_WheelsNumber, k_MaxWheelAirPressure,
            eFuelType.Octan95, k_MaxFuelAmount)
        { 
        }

        public override void FillWheelsAirToMax()
        {
            
        }
    }
}
