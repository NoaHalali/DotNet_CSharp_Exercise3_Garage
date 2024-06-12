using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        private bool m_IsCarryDangarousMaterials;
        private float m_CargoVolume;
        private const int k_WheelsNumber = 12;
        private const int k_MaxWheelAirPressure = 28;
        private const float k_MaxFuelAmount = 120f;

        public Truck() : base(k_WheelsNumber, k_MaxWheelAirPressure,
            eFuelType.Soler, k_MaxFuelAmount)
        {

        }

        public override void FillWheelsAirToMax()
        {
            
        }
    }
}
