using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Client currentClient = getClient(i_LicensePlate);

            currentClient.GarageState = i_NewState;
        }

        public void FillVehicleWheelsWithAir(string i_LicensePlate)
        {
            Client currentClient = getClient(i_LicensePlate);

            currentClient.ClientVehicle.FillWheelsAirToMax();
        }

        public List<string> GetFuelTypesList()
        {
            List<string> fuelTypes = new List<string>
            {
                "Octan95",
                "Octan96",
                "Octan98",
                "Soler",
            };

            return fuelTypes;
        }

        public void AddFuelToVehicle(string i_LicensePlate, float i_FuelAmountToAdd, string i_FuelType)
        {
            FuelEngine.eFuelType fuelTypeAsEnum = parseFuelType(i_FuelType);
            Client currentClient = getClient(i_LicensePlate);
            Vehicle currentVehicle = currentClient.ClientVehicle;

            FuelEngine vehicleFuelEngine = currentVehicle.Engine as FuelEngine;
            if (vehicleFuelEngine == null)
            {
                throw new ArgumentException("The vehicle you enterd not fuel type");
            }

            vehicleFuelEngine.FuelCharging(i_FuelAmountToAdd, fuelTypeAsEnum);
        }

        public void AddElectricityToVehicle(string i_LicensePlate, float i_ElectricityHoursToAdd)
        {
            Client currentClient = getClient(i_LicensePlate);
            Vehicle currentVehicle = currentClient.ClientVehicle;

            ElectricEngine vehicleElectricEngine = currentVehicle.Engine as ElectricEngine;
            if (vehicleElectricEngine == null)
            {
                throw new ArgumentException("The vehicle you enterd not electric type");
            }

            vehicleElectricEngine.BatteryCharger(i_ElectricityHoursToAdd);
        }

        private Client getClient(string i_LicensePlate)
        {
            Client currentClient = null;

            foreach (Client client in m_Clients)
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    currentClient = client;
                    break;
                }
            }

            if (currentClient == null)
            {
                throw new ArgumentException("No vehicle with this license plate");
            }

            return currentClient;
        }

        private FuelEngine.eFuelType parseFuelType(string i_FuelType)
        {
            bool valid = Enum.TryParse(i_FuelType, out FuelEngine.eFuelType fuelTypeAsEnum);

            if (!valid) 
            {
                throw new FormatException("Fuel type invalid");
            }

            return fuelTypeAsEnum;
        }

        public void FillEnergy()
        {
            //vechicle class function, will be virtual and inheriters will override it
        }

        public string GetClientData(string i_LicensePlate)
        {
            Client currentClient = getClient(i_LicensePlate);
            
            return currentClient.ToString();
        }



    }
}
