using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {

        public ElectricEngine(float i_MaxBatteryTime): base(i_MaxBatteryTime)
        {
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
            base.Charge(i_HoursToCharge);
        }
    }
}
