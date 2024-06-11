using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<Client> clients;
        private VehicleFactory m_Factory;

        public bool tryFindClient(string i_LicensePlate, out Client o_Client)
        {
            foreach(Client client in clients) 
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    o_Client = client;
                    break;
                }  
            }

            o_Client = new Client();

            return false;
        }

        public List<string> GetLicensePlates()
        {
            return null;
        }

        public void ChangeVehicleState()
        {
            client.State = eVehicleGarageState.InRepair;
        }

        public void FillWheelsWithAir()
        {

        }

        public void FillEnergy() 
        {
            //vechicle class function, will be virtual and inheriters will override it
        }

        public Client? GetClientData(string i_LicensePlate)
        {
            return null;
        }
    }
}
