using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTime = 2.5f;

        public ElectricMotorcycle(string i_LicensePlate) : base(i_LicensePlate)
        {
            m_Engine = new ElectricEngine(k_MaxBatteryTime);
            AddRequirements();
        }

        protected override void AddRequirements()
        {
            base.AddRequirements();
            m_Requirements.Add("License Type", null);
            m_Requirements.Add("Engine Volume", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setLicenseType(m_Requirements["License Type"]);
            setEngineVolume(m_Requirements["Engine Volume"]);
        }

        private void setLicenseType(string i_LicenseType) // שכפול קוד בין שני האופנועים
        {
            if (i_LicenseType == "A")
            {
                m_LicenseType = eMotorcycleLicenseType.A;
            }
            else if (i_LicenseType == "A1")
            {
                m_LicenseType = eMotorcycleLicenseType.A1;
            }
            else if (i_LicenseType == "AA")
            {
                m_LicenseType = eMotorcycleLicenseType.AA;
            }
            else if (i_LicenseType == "B1")
            {
                m_LicenseType = eMotorcycleLicenseType.B1;
            }
            else
            {
                throw new ArgumentException("Incorrect license type (only A,A1,AA,B1 allowed)");
            }
        }

        private void setEngineVolume(string i_EngineVolume) // שכפול קוד בין שני האופנועים
        {
            if (int.TryParse(i_EngineVolume, out int EngineVolumeInt))
            {
                m_EngineVolume = EngineVolumeInt;
            }
            else
            {
                throw new FormatException("Engine volume need to be int number");
            }
        }
    }
}
