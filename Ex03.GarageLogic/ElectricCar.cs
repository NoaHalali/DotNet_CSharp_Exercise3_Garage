using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        eCarColor m_Color;
        eCarNumberOfDoors m_NumOfDoors;
        private const int k_WheelsNumber = 5;
        private const int k_MaxWheelAirPressure = 31;
        private const float k_MaxBatteryTime = 3.5f;

        public ElectricCar() :base(k_WheelsNumber, k_MaxWheelAirPressure, k_MaxBatteryTime)
        {
        }

        public override void FillWheelsAirToMax()
        {
            
        }
    }
}
