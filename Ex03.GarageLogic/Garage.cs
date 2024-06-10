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

        public void InsertNewVehicleToGarage(string i_LicensePlate)
        {
            bool existingClient = tryFindClient(i_LicensePlate, out Client client);

            if(existingClient)
            {
                client.State = eVehicleGarageState.InRepair;
            }
            else
            {
                chooseVehicleType();

            }
        }
        private bool tryFindClient(string i_LicensePlate, out Client o_Client)
        {
            foreach(Client client in clients) 
            {
                if(client.GetLicensePlate() == i_LicensePlate)
                    
       
            }

        }

        public List<string> GetLicensePlates()
        {
            return null;
        }

        public void ChangeVehicleState()
        {

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
