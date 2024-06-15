using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.VehicleFactory;

namespace Ex03.GarageLogic
{
    public class GarageSystem
    {
        private List<Client> m_Clients = new List<Client>();

        public bool IsVehicleAlreadyExistsAtGarage(string i_LicensePlate)
        {
            bool exists = false;

            foreach (Client client in m_Clients)
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        public void AddNewClientToGarageSystem(string i_OwnerName, string i_OwnerPhoneNum, Vehicle i_Vehicle)
        {
            Client newClient = new Client(i_OwnerName, i_OwnerPhoneNum, i_Vehicle);
            m_Clients.Add(newClient);
        }

        public List<string> GetLicensePlatesList()
        {
            List<string> licensePlatesList = new List<string>();
            string licenstePlate;

            foreach (Client client in m_Clients)
            {
                licenstePlate = client.GetLicensePlate();
                licensePlatesList.Add(licenstePlate);
            }

            return licensePlatesList;
        }

        public List<string> GetLicensePlatesListByGarageState(eVehicleGarageState i_GarageState)
        {
            List<string> licensePlatesList = new List<string>();
            string licenstePlate;

            foreach (Client client in m_Clients)
            {
                if (client.GarageState == i_GarageState)
                {
                    licenstePlate = client.GetLicensePlate();
                    licensePlatesList.Add(licenstePlate);
                }
            }

            return licensePlatesList;
        }

        public void ChangeVehicleState(string i_LicensePlate, eVehicleGarageState i_NewState)
        {
            foreach (Client client in m_Clients)
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    client.GarageState = i_NewState;
                    break;
                }
            }
        }

        public void FillVehicleWheelsWithAir(string i_LicensePlate)
        {
            foreach (Client client in m_Clients)
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    client.ClientVehicle.FillWheelsAirToMax();
                }
            }
        }

        public void FillEnergy()
        {
            //vechicle class function, will be virtual and inheriters will override it
        }

        //public Client? GetClientData(string i_LicensePlate)
        //{
        //    return null;
        //}



    }
}
