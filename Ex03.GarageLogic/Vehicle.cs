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
        protected Engine m_Engine;
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

        protected virtual void AddRequirements()
        {
            m_Requirements.Add("Vehicle Model", null);
            addWheelsRequirement();
            m_Engine.AddRequirements(m_Requirements);
        }

        private void addWheelsRequirement()
        {
            int wheelCounter = 0;

            foreach (Wheel wheel in m_Wheels)
            {
                wheelCounter++;
                wheel.AddWheelReqierments(m_Requirements, wheelCounter);
            }
        }

        public void SameWheelsStateAddRequirements()
        {
            int wheelCounter = 0;

            foreach (Wheel wheel in m_Wheels)
            {
                wheelCounter++;
                wheel.DeleteWheelReqierments(m_Requirements, wheelCounter);
            }

            m_Requirements.Add("All Wheels Manufacturer Name", null);
            m_Requirements.Add("All Wheels Current Air Pressure", null);
        }

        public virtual void UpdateStateByRequirements()
        {
            m_Model = m_Requirements["Vehicle Model"];
            if (m_Requirements.ContainsKey("All Wheels Manufacturer Name"))
            {
                updateWheelsRequirements();
            }

            int wheelCounter = 0;
            foreach (Wheel wheel in m_Wheels)
            {
                wheelCounter++;
                wheel.UpdateWheelStateByRequirements(m_Requirements, wheelCounter);
            }

            m_Engine.UpdateEngineStateByRequirements(m_Requirements);
            m_EnergyPrecentage = (m_Engine.CurrentEnergyAmount / m_Engine.MaxEnergyAmount) * 100f;
        }

        private void updateWheelsRequirements()
        {
            int wheelCounter = 0;

            foreach (Wheel wheel in m_Wheels)
            {
                wheelCounter++;
                wheel.AddWheelReqierments(m_Requirements, wheelCounter);
                wheel.SetWheelReqierments(m_Requirements, wheelCounter,
                    m_Requirements["All Wheels Manufacturer Name"], m_Requirements["All Wheels Current Air Pressure"]);
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
