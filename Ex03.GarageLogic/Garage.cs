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

        public void InsertNewVehicleToGarage()
        {

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
