using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Client
    {
        private Vehicle m_ClientVehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNum;
        private eVehicleGarageState m_GarageState;

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

    }
}
