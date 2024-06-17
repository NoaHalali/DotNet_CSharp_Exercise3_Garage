using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        internal enum eMotorcycleLicenseType
        {
            A,
            A1,
            AA,
            B1
        }

        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const int k_WheelsNumber = 2;
        private const int k_MaxWheelAirPressure = 33;

        public Motorcycle(string i_LicensePlate) 
            : base(i_LicensePlate, k_WheelsNumber, k_MaxWheelAirPressure)
        {}

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
        private void setLicenseType(string i_LicenseType)
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

        private void setEngineVolume(string i_EngineVolume)
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

        public override string ToString()
        {
            string stringToReturn = string.Format("license type: {0}" + Environment.NewLine +
                "engine volume: {1}" + Environment.NewLine +
                "{2}"
                , m_LicenseType.ToString(), m_EngineVolume, base.ToString());

            return stringToReturn;
        }
    }
}
