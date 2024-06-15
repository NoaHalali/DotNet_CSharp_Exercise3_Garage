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
        protected Dictionary<string, string> m_Requirements = new Dictionary<string, string>();

        public Vehicle(string i_LicensePlate, int i_NumOfWheels, int i_MaxWheelAirPressure)
        {
            m_LicensePlate = i_LicensePlate;
            m_Wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxWheelAirPressure));
            }
        }

        protected virtual void FillRequirements()
        {
            m_Requirements.Add("Vehicle Model", null);
            foreach(Wheel wheel in m_Wheels) 
            {
                wheel.FillWheelReqierments(m_Requirements);
            }
        }

        public virtual void UpdateStateByRequirements()
        {
            m_Model = m_Requirements["Vehicle Model"];
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.UpdateWheelStateByRequirements(m_Requirements);
            }
        }

        public Dictionary<string,string> Requirements
        {
            get
            {
                return m_Requirements;
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
            set 
            { 
                m_EnergyPrecentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public void FillWheelsAirToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                float airToAdd = wheel.MaxtAirPressure - wheel.CurrentAirPressure;
                wheel.AddAir(airToAdd);
            }
        }
    }
}
