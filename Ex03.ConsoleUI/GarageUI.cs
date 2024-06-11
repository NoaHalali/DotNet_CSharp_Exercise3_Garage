using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal partial class GarageUI
    {
        private Garage m_GarageEngine;
        private bool m_ProgramStillRunning = true;

        public void RunSystem()
        {
            while (m_ProgramStillRunning)
            {
                printMenu();
                getActionFromUser();


            }
        }

        private void printMenu()
        {
            Console.WriteLine("Choose an action to perform:");
            Console.WriteLine("1) Insert new vehicle to the garage");
            Console.WriteLine("2) Display all license plates in the garage system");
            Console.WriteLine("3) Change vehicle garage state");
            Console.WriteLine("4) Fill vehicle wheels with maximum air");
            Console.WriteLine("5) Charge vehicle energy"); //2 options together, fuel and electric
            Console.WriteLine("6) Display client's data"); ;
        }
        private int getActionFromUser()
        {   //no need to check the validation?
            int optionNumber = int.Parse(Console.ReadLine()); // TryParse + in range of the enum.

            eClientAction client = (eClientAction)optionNumber;

            return 0;
        }

        private void activateAction(eClientAction i_num)
        {
            switch (i_num)
            {
                case eClientAction.InsertNewVehicle:
                    {
                        insertNewVehicleToGarage();
                        break;
                    }
                case eClientAction.DisplayLicensesPlatesList:
                    {
                        displayLicensesPlatesList();
                        break;
                    }
                case eClientAction.ChangeVehicleGarageState:
                    {
                        changeVehicleGarageState();
                        break;
                    }
                case eClientAction.FillWheelsWithAir:
                    {
                        fillWheelsWithAir();
                        break;
                    }
                //case eClientAction.ChargeVehicleEnergy:
                //    {
                //        chargeVehicleEnergy();
                //        break;
                //    }
                case eClientAction.ChargeFuelVehicle:
                    {
                        chargeFuelVehicle();
                        break;
                    }
                case eClientAction.ChargeElectricVehicle:
                    {
                        chargeElectricVehicle();
                        break;
                    }
                case eClientAction.DisplayClientData:
                    {
                        displayClientData();
                        break;
                    }
            }
        }

        private void insertNewVehicleToGarage()
        {
            string licensePlate = getInputFromUser();

            bool existingClient = m_GarageEngine.tryFindClient(licensePlate, out Client client);

            if (existingClient)
            {
                Console.WriteLine("Vehicle with license plate {0} was found in the system!", licensePlate);
                Console.WriteLine("----- Changing it's status to 'In Repair' -----");
                client.GarageState = eVehicleGarageState.InRepair;
            }
            else //TO-DO
            {
                //insert new vehicle to the system

                //chooseVehicleType();

            }
        }

        private string getInputFromUser()
        {
            string input;
            //need validation checks??
            Console.WriteLine("Enter license plate to insert:");
            input = Console.ReadLine();

            return input;
        }
        private void displayLicensesPlatesList()
        {
            List<string> LicensesPlatesList;
            eFilterOption filter = chooseFilterOption();

            LicensesPlatesList = getLicensesPlatesListByFilterOption(filter);
            foreach (string licensePlate in LicensesPlatesList)
            {
                Console.WriteLine(licensePlate);
            } 
        }
        private eFilterOption chooseFilterOption()
        {
            eFilterOption filter; 

            printFilterOptions();
            filter = getFilterOptionFromUser();

            return filter;
        }

        private void printFilterOptions()
        {
            Console.WriteLine("Choose filter option:");
            Console.WriteLine("1) All");
            Console.WriteLine("2) InRepair");
            Console.WriteLine("3) Repaired");
            Console.WriteLine("4) Paid");
            Console.ReadLine();
        }
        private eFilterOption getFilterOptionFromUser()
        {
            //no need to check the validation?
            int optionNumber = int.Parse(Console.ReadLine()); // TryParse + in range of the enum.
            eFilterOption filter = (eFilterOption)optionNumber;

            return filter;
        }

        private List<string> getLicensesPlatesListByFilterOption(eFilterOption filter)
        {
            List<string> LicensesPlatesList =null; //will alway be one of the cases here,
                                                   //filter validation is being checked before

            switch(filter)
            {
                case eFilterOption.All:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesList();
                        break;
                    }
                case eFilterOption.InRepair:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesListByGarageState(eVehicleGarageState.InRepair);
                        break;
                    }
                case eFilterOption.Repaired:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesListByGarageState(eVehicleGarageState.Repaired);
                        break;
                    }
                case eFilterOption.Paid:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesListByGarageState(eVehicleGarageState.Paid);
                        break;
                    }
                    //deafult: check validation????
            }

            return LicensesPlatesList;
        }

        private void changeVehicleGarageState()
        {

        }   

        private void fillWheelsWithAir()
        {

        }
        //private void chargeVehicleEnergy()
        //{

        //}
          
        private void chargeFuelVehicle()
        {

        }

        private void chargeElectricVehicle()
        {
            
        }
        private void displayClientData()
        {
            
        }




    }
}
