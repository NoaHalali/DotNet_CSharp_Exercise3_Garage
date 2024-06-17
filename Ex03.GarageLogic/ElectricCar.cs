using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_MaxBatteryTime = 3.5f;

        public ElectricCar(string i_LicensePlate) :base(i_LicensePlate)
        {
            m_Engine = new ElectricEngine(k_MaxBatteryTime);
            AddRequirements();
        }

        protected override void AddRequirements()
        {
            base.AddRequirements();
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
        }

        public override string ToString()
        {
            string stringToReturn = string.Format("vehicle type: electric car" + Environment.NewLine +
                "{0}"
                , base.ToString());

            return stringToReturn;
        }
    }
}
