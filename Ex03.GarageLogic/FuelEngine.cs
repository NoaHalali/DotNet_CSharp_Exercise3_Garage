using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        internal enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler,
        }

        private eFuelType m_FuelType;

        public FuelEngine(float i_MaxFuelAmount, eFuelType i_FuelType) : base(i_MaxFuelAmount)
        {
            m_FuelType = i_FuelType;
        }

        protected override void AddRequirements()
        {
            base.AddRequirements();
            m_Requirements.Add("Current Fuel Amount", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setCurrentFuelAmount(m_Requirements["Current Fuel Amount"]);
            EnergyPrecentage = (m_CurrentFuelAmount / m_MaxFuelAmount) * 100;
        }

        public void setCurrentFuelAmount(string i_CurrentFuelAmount)
        {
            if (float.TryParse(i_CurrentFuelAmount, out float currentFuelAmountFloat))
            {
                FuelCharging(currentFuelAmountFloat, m_FuelType);
            }
            else
            {
                throw new FormatException("Fuel amount need to be float number");
            }
        }
     
        public void AddFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (m_FuelType == i_FuelType)
            {
                base.Charge(i_FuelToAdd);
            }
            else
            {
                throw new ArgumentException("Wrong fuel type");
            }
        }
    }
}
