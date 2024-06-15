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

        private void setCarColor(string i_CarColor) // שכפול קוד בין 2 המכוניות
        {
            if (i_CarColor == "Yellow")
            {
                m_CarColor = eCarColor.Yello;
            }
            else if (i_CarColor == "White")
            {
                m_CarColor = eCarColor.White;
            }
            else if (i_CarColor == "Black")
            {
                m_CarColor = eCarColor.Black;
            }
            else if (i_CarColor == "Red")
            {
                m_CarColor = eCarColor.Red;
            }
            else
            {
                throw new ArgumentException("Incorrect car color (only Yellow,White,Black,Red allowed)");
            }
        }

        private void setCarDoorsAmount(string i_CarDoorsNumber) // שכפול קוד בין 2 המכוניות
        {
            if (i_CarDoorsNumber == "2")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Two;
            }
            else if (i_CarDoorsNumber == "3")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Three;
            }
            else if (i_CarDoorsNumber == "4")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Four;
            }
            else if (i_CarDoorsNumber == "5")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Five;
            }
            else
            {
                throw new ArgumentException("Incorrect car doors number (only 2,3,4,5 allowed)");
            }
        }
    }
}
