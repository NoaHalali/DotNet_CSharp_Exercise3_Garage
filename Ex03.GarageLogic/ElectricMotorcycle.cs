using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const int k_WheelsNumber = 2;
        private const int k_MaxWheelAirPressure = 33;
        private const float k_MaxBatteryTime = 2.5f;

        public ElectricMotorcycle(string i_LicensePlate) :base(i_LicensePlate, k_WheelsNumber,
            k_MaxWheelAirPressure, k_MaxBatteryTime)
        {
            FillRequirements();
        }

        protected override void FillRequirements()
        {
            base.FillRequirements();
            m_Requirements.Add("License Type", null);
            m_Requirements.Add("Engine Volume", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setLicenseType(m_Requirements["License Type"]);
            setEngineVolume(m_Requirements["Engine Volume"]);
        }

        
    }
}
