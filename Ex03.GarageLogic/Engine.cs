using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {

        private float m_CurrentEnergyAmount;
        private float m_MaxEnergyAmount;

        public Engine(float i_MaxEnergyAmount) 
        {
            this.m_MaxEnergyAmount = i_MaxEnergyAmount;
        }

        protected void Charge(float i_EnergyAmountToAdd)
        {
            bool isValid = checkIfValidInput(i_EnergyAmountToAdd);

            if (isValid)
            {
                m_CurrentEnergyAmount += i_EnergyAmountToAdd;
            }
            else
            {
                float maxEnergyPossibleToAdd = m_MaxEnergyAmount - m_CurrentEnergyAmount;
                throw new ValueOutOfRangeException(maxEnergyPossibleToAdd, 0,
                    "Energy charging out of range");
            }
        }

        private bool checkIfValidInput(float i_EnergyAmountToAdd)
        {
            bool isValid;
            float newEnergyAmount = m_CurrentEnergyAmount + i_EnergyAmountToAdd;

            isValid = i_EnergyAmountToAdd >= 0 && newEnergyAmount <= m_MaxEnergyAmount;

            return isValid;
        }
    }
}
