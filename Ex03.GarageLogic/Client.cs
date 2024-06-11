using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public struct Client
    {
        private Vehicle m_ClientVehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNum;
        private eVehicleGarageState m_State;

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

        public eVehicleGarageState State
        {
            get
            {
                return m_State;
            }

            set
            {
                m_State = value;
            }
        }

        public string GetLicensePlate()
        {
            return m_clientVehicle.LicensePlate;
        }
    }
}
