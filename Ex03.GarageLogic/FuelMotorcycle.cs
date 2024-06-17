using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelAmount = 5.5f;

        public FuelMotorcycle(string i_LicensePlate) : base(i_LicensePlate)
        {
            m_Engine = new FuelEngine(k_MaxFuelAmount, FuelEngine.eFuelType.Octan98);
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
            string stringToReturn = string.Format("vehicle type: fuel motorcycle" + Environment.NewLine +
                "{0}"
                , base.ToString());

            return stringToReturn;
        }
    }
}