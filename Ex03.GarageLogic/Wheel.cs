using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(int i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }
        public float MaxtAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public void AddWheelReqierments(Dictionary<string, string> i_VehicleRequirements, int i_WheelNumber)
        {
            i_VehicleRequirements.Add($"Wheel {i_WheelNumber} Manufacturer Name", null);
            i_VehicleRequirements.Add($"Wheel {i_WheelNumber} Current Air Pressure", null);
        }

        public void DeleteWheelReqierments(Dictionary<string, string> i_VehicleRequirements, int i_WheelNumber)
        {
            i_VehicleRequirements.Remove($"Wheel {i_WheelNumber} Manufacturer Name");
            i_VehicleRequirements.Remove($"Wheel {i_WheelNumber} Current Air Pressure");
        }

        public void SetWheelReqierments(Dictionary<string, string> i_VehicleRequirements, int i_WheelNumber,
            string i_WheelManufactorName, string i_WheelCurrentAitPressure)
        {
            i_VehicleRequirements[$"Wheel {i_WheelNumber} Manufacturer Name"] = i_WheelManufactorName;
            i_VehicleRequirements[$"Wheel {i_WheelNumber} Current Air Pressure"] = i_WheelCurrentAitPressure;
        }

        public void UpdateWheelStateByRequirements(Dictionary<string, string> i_VehicleRequirements, int i_WheelNumber)
        {
            m_ManufacturerName = i_VehicleRequirements[$"Wheel {i_WheelNumber} Manufacturer Name"];
            setWheelCurrentAirPressure(i_VehicleRequirements[$"Wheel {i_WheelNumber} Current Air Pressure"]);
        }

        private void setWheelCurrentAirPressure(string i_WheelCurrentAirPressure)
        {
            if (float.TryParse(i_WheelCurrentAirPressure, out float wheelCurrentAirPressureFloat))
            {
                AddAir(wheelCurrentAirPressureFloat);
            }
            else
            {
                throw new FormatException("Wheel air pressure need to be float number");
            }
        }

        public void AddAir(float i_AirToAdd)
        {
            if (i_AirToAdd >= 0 && m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure - m_CurrentAirPressure, 0,
                    "Wheel air pressure out of range");
            }
        }
    }
}
