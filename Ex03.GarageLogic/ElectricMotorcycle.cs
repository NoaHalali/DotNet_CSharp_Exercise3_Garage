using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        eMotorcycleLicenseType m_LicenseType;
        int m_EngineVolume;
        private const int k_WheelsNumber = 2;
        private const int k_MaxWheelAirPressure = 33;
        private const float k_MaxBatteryTime = 2.5f;

        public ElectricMotorcycle() :base(k_WheelsNumber, k_MaxWheelAirPressure, k_MaxBatteryTime)
        {
        }

    }
}
