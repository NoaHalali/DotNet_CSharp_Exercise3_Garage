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
        }




    }
}
