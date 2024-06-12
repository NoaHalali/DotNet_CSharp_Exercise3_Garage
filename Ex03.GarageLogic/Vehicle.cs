using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicensePlate;
        private float m_EnergyPrecentage;
        private List<Wheel> m_Wheels;

        public Vehicle(int i_NumOfWheels, int i_MaxWheelAirPressure)
        {
            m_Wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxWheelAirPressure));
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }
        
        public float EnergyPrecentage
        {
            get
            {
                return m_EnergyPrecentage;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            //set 
            //{
            //    m_Wheels = value;
            //}
        }

        public abstract void FillWheelsAirToMax();

    }
}
