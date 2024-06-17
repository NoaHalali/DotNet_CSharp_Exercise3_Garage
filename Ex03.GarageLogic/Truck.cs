using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsCarryDangarousMaterials;
        private float m_CargoVolume;
        private const int k_WheelsNumber = 12;
        private const int k_MaxWheelAirPressure = 28;
        private const float k_MaxFuelAmount = 120f;

        public Truck(string i_LicensePlate) : base(i_LicensePlate, k_WheelsNumber, k_MaxWheelAirPressure)
        {
            m_Engine = new FuelEngine(k_MaxFuelAmount, FuelEngine.eFuelType.Soler);
            AddRequirements();
        }

        protected override void AddRequirements()
        {
            base.AddRequirements();
            m_Requirements.Add("Is Carry Dangarous Materials (yes/no)", null);
            m_Requirements.Add("Cargo Volume", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setIsCarryDangarousMaterials(m_Requirements["Is Carry Dangarous Materials (yes/no)"]);
            setCargoVolume(m_Requirements["Cargo Volume"]);
        }

        private void setIsCarryDangarousMaterials(string i_IsCarryDangarousMaterials)
        {
            if (i_IsCarryDangarousMaterials == "yes" || i_IsCarryDangarousMaterials == "no")
            {
                m_IsCarryDangarousMaterials = i_IsCarryDangarousMaterials == "yes";
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

        public override string ToString()
        {
            string stringToReturn = string.Format("vehicle type: truck" + Environment.NewLine +
                "is carry dangarous materials: {0}" + Environment.NewLine +
                "cargo volume: {1}" + Environment.NewLine +
                "{2}"
                , m_IsCarryDangarousMaterials.ToString(), m_CargoVolume, base.ToString());

            return stringToReturn;
        }
    }
}
