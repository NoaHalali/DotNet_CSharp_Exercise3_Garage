using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public FuelVehicle(string i_LicensePlate, int i_NumOfWheels, int i_MaxWheelAirPressure,
            eFuelType i_FuelType, float i_MaxFuelAmount)
            : base(i_LicensePlate, i_NumOfWheels, i_MaxWheelAirPressure)
        {
            m_FuelType = i_FuelType;
            m_MaxFuelAmount = i_MaxFuelAmount;
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

        public void FuelCharging(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (m_FuelType == i_FuelType)
            {
                if (i_FuelToAdd >= 0 && m_CurrentFuelAmount + i_FuelToAdd <= m_MaxFuelAmount)
                {
                    m_CurrentFuelAmount += i_FuelToAdd;
                }
                else
                {
                    float maxFuelPossibleToAdd = m_MaxFuelAmount - m_CurrentFuelAmount;
                    throw new ValueOutOfRangeException(maxFuelPossibleToAdd, 0,
                        "Fuel amount out of range");
                }
            }
            else
            {
                throw new ArgumentException("Wrong fuel type");
            }
        }

    }
}
