using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const int k_WheelsNumber = 2;
        private const int k_MaxAirPressure = 33;
        private const float k_MaxFuelAmount = 5.5f;

        public FuelMotorcycle() :base(k_WheelsNumber, k_MaxAirPressure, eFuelType.Octan98, k_MaxFuelAmount)
        {
            
            //List<Wheel> list = Wheels;
            //m_Wheels = new List<Wheel>(i_NumOfWheels);
            //for (int i = 0; i < i_NumOfWheels; i++)
            //{
            //    m_Wheels.Add(new Wheel(i_MaxAirPressure));
            //}
            //            const int k_WheelsNumber = 2;
            //const int k_MaxAirPressure = 33;

            //base.
        }

        public override void FillWheelsAirToMax()
        {
            
        }
    }
}
