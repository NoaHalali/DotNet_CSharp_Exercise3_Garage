﻿using System;
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


        public bool IsClientAlreadyExists(string i_LicensePlate)
        {
            bool exists = false;

            foreach (Client client in clients)
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        //public bool TryFindClient(string i_LicensePlate, out Client o_Client)
        //{
        //    foreach(Client client in clients) 
        //    {
        //        if (client.GetLicensePlate() == i_LicensePlate)
        //        {
        //            o_Client = client;
        //            break;
        //        }  
        //    }

        //    o_Client = new Client();

        //    return false;
        //}

        public List<string> GetLicensePlatesList()
        {
            List<string> licensePlatesList = new List<string>() ;
            string licenstePlate;

            foreach (Client client in clients)
            {
                licenstePlate = client.GetLicensePlate();
                licensePlatesList.Add(licenstePlate);
            }

            return licensePlatesList;
        }
        public List<string> GetLicensePlatesListByGarageState(eVehicleGarageState i_GarageState)
        {
            List<string> licensePlatesList = new List<string>() ;
            string licenstePlate;

            foreach (Client client in clients)
            {
                licenstePlate = client.GetLicensePlate();
                if (client.GarageState == i_GarageState)
                {
                    licensePlatesList.Add(licenstePlate);
                }
            }

            return licensePlatesList;
        }

        public void ChangeVehicleState(string i_LicensePlate, eVehicleGarageState i_NewState)
        {
            foreach (Client client in clients)
            {
                if (client.GetLicensePlate() == i_LicensePlate)
                {
                    client.State = i_NewState;
                    break;
                }
            }
        }

        public void FillWheelsWithAir()
        {

        }

        //public void FillEnergy() 
        //{
        //    //vechicle class function, will be virtual and inheriters will override it
        //}

        //public Client? GetClientData(string i_LicensePlate)
        //{
        //    return null;
        //}
    }
}
