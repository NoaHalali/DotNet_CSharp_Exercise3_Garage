using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        public void BatteryCharger(int i_HoursToCharge, string o_ErrorMessage)
        {
            bool isValid = checkIfValidInput(i_HoursToCharge, o_ErrorMessage);

            if (isValid)
            {
                m_BatteryTimeLeft += i_HoursToCharge;
            }
        }

        private bool checkIfValidInput(int i_HoursToCharge, string o_ErrorMessage)
        {
            bool isValid;
            float newBatteryTime = m_BatteryTimeLeft + i_HoursToCharge;
            float maxBatteryPossibleToAdd = m_MaxBatteryTime - m_BatteryTimeLeft; //maybe change name, its to current time

            o_ErrorMessage = null;
            isValid = newBatteryTime <= m_MaxBatteryTime;
            if (!isValid)
            {
                o_ErrorMessage = string.Format("Exeeded maximum hours, maximum to add for now is {0}", maxBatteryPossibleToAdd);
            }

            return isValid;
        }
    }


}
