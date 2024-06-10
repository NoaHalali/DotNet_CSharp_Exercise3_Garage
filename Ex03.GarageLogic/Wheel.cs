using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_ManufacturerName;
        float m_CurrentAirPressure;
        float m_MaxAirPressure;

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
