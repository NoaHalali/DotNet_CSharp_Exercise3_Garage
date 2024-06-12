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
        private int k_WheelsNumber = 2;
        private const int k_MaxAirPressure = 33;

        public FuelMotorcycle() :base(m_NumOfWheels)
        {
            for(int i=0; i<m_NumOfWheels; i++)
            {
                m_[i] = new Wheel(33,);
            }
        }

        public override void FillWheelsAirToMax()
        {
            
        }
    }
}
