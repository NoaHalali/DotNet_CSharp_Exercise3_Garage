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

        public Truck(string i_LicensePlate) : base(i_LicensePlate, k_WheelsNumber, k_MaxWheelAirPressure,
            eFuelType.Soler, k_MaxFuelAmount)
        {
            AddRequirements();
        }

        protected override void AddRequirements()
        {
            base.AddRequirements();
            m_Requirements.Add("Is Carry Dangarous Materials", null);
            m_Requirements.Add("Cargo Volume", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setIsCarryDangarousMaterials(m_Requirements["Is Carry Dangarous Materials"]);
            setCargoVolume(m_Requirements["Cargo Volum"]);
        }

        private void setIsCarryDangarousMaterials(string i_IsCarryDangarousMaterials)
        {
            if (bool.TryParse(i_IsCarryDangarousMaterials, out bool isCarryDangarousMaterialsBool))
            {
                m_IsCarryDangarousMaterials = isCarryDangarousMaterialsBool;
            }
            else
            {
                throw new FormatException("Is carry dangarous materials need to be bool (true/false)");
            }
        }

        private void setCargoVolume(string i_CargoVolume)
        {
            if (float.TryParse(i_CargoVolume, out float cargoVolumeFloat))
            {
                m_CargoVolume = cargoVolumeFloat;
            }
            else
            {
                throw new FormatException("Cargo volume need to be float number");
            }
        }
    }
}
