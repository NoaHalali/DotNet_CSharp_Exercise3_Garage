using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        internal enum eMotorcycleLicenseType
        {
            A,
            A1,
            AA,
            B1
        }

        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const int k_WheelsNumber = 2;
        private const int k_MaxWheelAirPressure = 33;

        public Motorcycle(string i_LicensePlate) 
            : base(i_LicensePlate, k_WheelsNumber, k_MaxWheelAirPressure)
        {

        }
    }
}
