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



        public void BatteryCharger(int i_HoursToCharge)
        {
        }

    }
}
