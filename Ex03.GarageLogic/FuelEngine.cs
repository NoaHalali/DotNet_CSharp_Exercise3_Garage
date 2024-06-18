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

        public override void AddRequirements(Dictionary<string,string> i_Requirements)
        {
            i_Requirements.Add("Current Fuel Amount", null);
        }

        public override void UpdateEngineStateByRequirements(Dictionary<string, string> i_Requirements)
        {
            setCurrentFuelAmount(i_Requirements["Current Fuel Amount"]);
        }

        private void setCurrentFuelAmount(string i_CurrentFuelAmount)
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
                base.Charge(i_FuelToAdd);
            }
            else
            {
                throw new ArgumentException("Wrong fuel type");
            }
        }

        public override string ToString()
        {
            string stringToReturn = string.Format("fuel type: {0}" + 
                Environment.NewLine + "{1}", 
                m_FuelType.ToString(), base.ToString());

            return stringToReturn;
        }
    }
}
