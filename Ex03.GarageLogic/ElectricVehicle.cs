using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        public ElectricVehicle(string i_LicensePlate, int i_NumOfWheels, int i_MaxWheelAirPressure,
            float i_MaxBatteryTime): base(i_LicensePlate,i_NumOfWheels, i_MaxWheelAirPressure)
        {
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        protected override void AddRequirements()
        {
            base.AddRequirements();
            m_Requirements.Add("Battery Time Left", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setBatteryTimeLeft(m_Requirements["Battery Time Left"]);
            EnergyPrecentage = (m_BatteryTimeLeft / m_MaxBatteryTime) * 100;
        }

        private void setBatteryTimeLeft(string i_BatteryTimeLeft)
        {
            if (float.TryParse(i_BatteryTimeLeft, out float batteryTimeLeftFloat))
            {
                BatteryCharger(batteryTimeLeftFloat);
            }
            else
            {
                throw new FormatException("Battery time left need to be float number");
            }
        }

        public void BatteryCharger(float i_HoursToCharge)
        {
            bool isValid = checkIfValidInput(i_HoursToCharge);

            if (isValid)
            {
                m_BatteryTimeLeft += i_HoursToCharge;
            }
            else
            {
                float maxBatteryPossibleToAdd = m_MaxBatteryTime - m_BatteryTimeLeft;
                throw new ValueOutOfRangeException(maxBatteryPossibleToAdd, 0,
                    "Battery charging out of range");
            }
        }

        private bool checkIfValidInput(float i_HoursToCharge)
        {
            bool isValid;
            float newBatteryTime = m_BatteryTimeLeft + i_HoursToCharge;

            isValid = i_HoursToCharge >= 0 && newBatteryTime <= m_MaxBatteryTime;

            return isValid;
        }
    }
}
