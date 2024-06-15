using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        private eCarColor m_CarColor;
        private eCarNumberOfDoors m_CarDoorsNumber;
        private const int k_WheelsNumber = 5;
        private const int k_MaxWheelAirPressure = 31;
        private const float k_MaxBatteryTime = 3.5f;

        public ElectricCar(string i_LicensePlate) :base(i_LicensePlate, k_WheelsNumber,
            k_MaxWheelAirPressure, k_MaxBatteryTime)
        {
            FillRequirements();
        }

        protected override void FillRequirements()
        {
            base.FillRequirements();
            m_Requirements.Add("Car Color", null);
            m_Requirements.Add("Car Doors Number", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setCarColor(m_Requirements["Car Color"]);
            setCarDoorsAmount(m_Requirements["Car Doors Number"]);
        }
    }
}
