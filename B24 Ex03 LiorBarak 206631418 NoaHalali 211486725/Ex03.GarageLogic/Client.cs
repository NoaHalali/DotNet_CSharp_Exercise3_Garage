using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNum;
        private Vehicle m_ClientVehicle;
        private eVehicleGarageState m_GarageState;

        public Client(string i_OwnerName, string i_OwnerPhoneNum, Vehicle i_Vehicle) 
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNum = i_OwnerPhoneNum;
            m_ClientVehicle = i_Vehicle;
            m_GarageState = eVehicleGarageState.InRepair;
        }

        public Vehicle ClientVehicle
        {
            get
            {
                return m_ClientVehicle;
            }
        }

        public eVehicleGarageState GarageState
        {
            get
            {
                return m_GarageState;
            }

            set
            {
                m_GarageState = value;
            }
        }

        public string GetLicensePlate()
        {
            return m_ClientVehicle.LicensePlate;
        }

        public override string ToString()
        {
            string stringToReturn = string.Format("Owner Name: {0}" + Environment.NewLine +
                "owner phone number: {1}" + Environment.NewLine +
                "vehicle garage state: {2}" + Environment.NewLine + "{3}"
                , m_OwnerName, m_OwnerPhoneNum, m_GarageState.ToString(), m_ClientVehicle.ToString());

            return stringToReturn;
        }
    }
}
