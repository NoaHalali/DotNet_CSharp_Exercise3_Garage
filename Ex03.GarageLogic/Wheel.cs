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

        public void FillWheelReqierments(Dictionary<string, string> i_VehicleRequirments)
        {
            i_VehicleRequirments.Add("Wheel Manufacturer Name", null);
            i_VehicleRequirments.Add("Wheel Current Air Pressure", null);
        }

        public void AddAir(float i_AirToAdd)
        {
            if (i_AirToAdd >= 0 && m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure - m_CurrentAirPressure, 0);
            }
        }
    }
}
