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

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerPhoneNum
        {
            get
            {
                return m_OwnerPhoneNum;
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
            string stringToReturn = string.Format("Owner Name");
            base.ToString();


            return stringToReturn;
        }
    }
}
