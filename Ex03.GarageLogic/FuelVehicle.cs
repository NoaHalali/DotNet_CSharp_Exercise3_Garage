using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler,
        }

        private float m_FuelAmount;
        private float m_MaxFuelAmount;

        protected void FuelCharging(int i_FuelAmountLiter, eFuelType i_FuelType)
        {

        }

    }
}
