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

        public Engine Engine
        {
            get 
            {
                return m_Engine;
            }
        }

        public Dictionary<string,string> Requirements
        {
            get
            {
                return m_Requirements;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
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

        public override string ToString()
        {
            string stringToReturn = string.Format("vehicle model: {0}" + Environment.NewLine +
                "license plate: {1}" + Environment.NewLine +
                "energy precentage: {2}" + Environment.NewLine +
                "wheels:" + Environment.NewLine +
                "{3}" +
                "engine:" + Environment.NewLine + 
                "{4}"
                , m_Model, m_LicensePlate, m_EnergyPrecentage, wheelsToString(), m_Engine.ToString());

            return stringToReturn;
        }

        private string wheelsToString()
        {
            StringBuilder wheelStr = new StringBuilder();

            int wheelCounter = 0;
            foreach (Wheel wheel in m_Wheels)
            {
                wheelCounter++;
                wheelStr.Append(string.Format("wheel number {0}:" + Environment.NewLine +
                    "{1}" + Environment.NewLine
                    , wheelCounter, wheel.ToString()));
            }

            return wheelStr.ToString();
        }
    }
}
