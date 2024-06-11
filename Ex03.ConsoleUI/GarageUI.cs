using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageUI
    {
        private Garage m_GarageEngine;
        private bool m_ProgramStillRunning = true;

        public void RunSystem()
        {
            while (m_ProgramStillRunning)
            {
                printMenu();
                eClientAction clientOption = getOptionFromUser();
                activateAction(clientOption);


            }
        }

        private void printMenu()
        {
            Console.WriteLine("Choose a number of action to perform:");
            Console.WriteLine("1) Insert new vehicle to the garage");
            Console.WriteLine("2) Display all license plates in the garage system");
            Console.WriteLine("3) Change vehicle garage state");
            Console.WriteLine("4) Fill vehicle wheels with maximum air");
            Console.WriteLine("5) Charge fuel vehicle");
            Console.WriteLine("6) Charge electric vehicle");
            Console.WriteLine("7) Display client's data");
        }
        private eClientAction getOptionFromUser()
        {
            bool isValid = false;
            bool isNumber;
            int userInput = 0; // mybe change the = 0.

            while (!isValid)
            {
                isNumber = isUserOptionANumber(Console.ReadLine(), out userInput);
                isValid = isNumber && isUserOptionInRange(userInput);
            }

            return (eClientAction)userInput;
        }

        private bool isUserOptionANumber(string i_InputAsString, out int o_InputAsInteger)
        {
            bool isValid = int.TryParse(i_InputAsString, out o_InputAsInteger);

            if (!isValid)
            {
                Console.WriteLine("You not entered a number, try again.");
            }

            return isValid;
        }

        private bool isUserOptionInRange(int i_UserInput)
        {
            bool isValid = i_UserInput >= 1 && i_UserInput <= 7;

            if (!isValid)
            {
                Console.WriteLine("You not entered a number between 1 to 7, try again.");
            }

            return isValid;

        }

        private void activateAction(eClientAction i_ActionNumber)
        {

            switch (i_ActionNumber)
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
            string licensePlate = getLicenseFromUser();
            bool existingClient = m_GarageEngine.IsClientAlreadyExists(licensePlate);

            if (existingClient)
            {
                Console.WriteLine("The vehicle alreay been at the garage before.");
                m_GarageEngine.ChangeVehicleState(licensePlate, eVehicleGarageState.InRepair);
            }
            else
            {
                chooseVehicleType();

            }
        }

        private string getLicenseFromUser()
        {
            Console.WriteLine("Please enter vehicle license plate:");
            string licensePlate = Console.ReadLine();

            return licensePlate;
        }

        private string chooseVehicleType()
        {

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

    }
}
