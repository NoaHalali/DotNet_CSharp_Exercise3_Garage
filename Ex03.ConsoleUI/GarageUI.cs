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
                eUserAction userOption = getActionOptionFromUser();
                activateAction(userOption);

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
        private eUserAction getActionOptionFromUser()
        {
            const int k_MinOptionVal = 1;
            const int k_MaxOptionVal = 7;

            printMenu();
            int optionNumber = getValidEnumOptionNumber(k_MinOptionVal, k_MaxOptionVal);

            return (eUserAction)optionNumber;
        }
        private int getValidEnumOptionNumber(int i_MinVal, int i_MaxVal)
        {
            bool isValid = false;
            bool isNumber;
            int optionNumber = 0; // mybe change the = 0.
            string userInput;

            while (!isValid)
            {
                userInput = Console.ReadLine();
                isNumber = isUserOptionANumber(userInput, out optionNumber);
                isValid = isNumber && isUserOptionInRange(optionNumber, i_MinVal, i_MaxVal);
            }

            return optionNumber;
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

        private bool isUserOptionInRange(int i_UserInput, int i_MinVal, int i_MaxVal)
        {
            bool isValid = i_UserInput >= i_MinVal && i_UserInput <= i_MaxVal;

            if (!isValid)
            {
                Console.WriteLine("You not entered a number between {0} to {1}, try again.",
                    i_MinVal, i_MaxVal);
            }

            return isValid;
        }

        private void activateAction(eUserAction i_ActionNumber)
        {

            switch (i_ActionNumber)
            {
                case eUserAction.InsertNewVehicle:
                    {
                        insertNewVehicleToGarage();
                        break;
                    }
                case eUserAction.DisplayLicensesPlatesList:
                    {
                        displayLicensesPlatesList();
                        break;
                    }
                case eUserAction.ChangeVehicleGarageState:
                    {
                        changeVehicleGarageState();
                        break;
                    }
                case eUserAction.FillWheelsWithAir:
                    {
                        fillWheelsWithAir();
                        break;
                    }
                case eUserAction.ChargeFuelVehicle:
                    {
                        chargeFuelVehicle();
                        break;
                    }
                case eUserAction.ChargeElectricVehicle:
                    {
                        chargeElectricVehicle();
                        break;
                    }
                case eUserAction.DisplayClientData:
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
                string vehicleType = chooseVehicleType();


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
            bool isVehicleTypeValid = false;
            string vehicleType = null;

            while (!isVehicleTypeValid)
            {
                printVehiclesOptions();
                vehicleType = Console.ReadLine();
                isVehicleTypeValid = IsVehicleTypeValid(vehicleType);
            }

            return vehicleType;
        }

        private void printVehiclesOptions()
        {
            List<string> vehicleOptions = m_GarageEngine.GetVehicleTypesOptions();

            Console.WriteLine("Please enter the type of vehicle that will enter the garage:");
            foreach (string option in vehicleOptions)
            {
                Console.WriteLine(option);
            }
        }

        private bool IsVehicleTypeValid(string vehicleType)
        {
            List<string> vehicleOptions = m_GarageEngine.GetVehicleTypesOptions();
            bool isValid = false;

            foreach (string option in vehicleOptions)
            {
                if (option == vehicleType)
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Entered invalid option, try again.");
            }

            return isValid;
        }

        private void displayLicensesPlatesList()
        {
            List<string> LicensesPlatesList;
            eGarageStateFilter filter = getFilterOptionFromUser();

            LicensesPlatesList = getLicensesPlatesListByFilterOption(filter);
            foreach (string licensePlate in LicensesPlatesList)
            {
                Console.WriteLine(licensePlate);
            }
        }

        private void printFilterOptions()
        {
            Console.WriteLine("Choose filter option:");
            Console.WriteLine("1) All");
            Console.WriteLine("2) InRepair");
            Console.WriteLine("3) Repaired");
            Console.WriteLine("4) Paid");
       
        }
        private eGarageStateFilter getFilterOptionFromUser()
        {
            const int k_MinOptionVal = 1;
            const int k_MaxOptionVal = 4;

            printFilterOptions();
            int optionNumber = getValidEnumOptionNumber(k_MinOptionVal, k_MaxOptionVal);

            return (eGarageStateFilter)optionNumber;
        }

        private List<string> getLicensesPlatesListByFilterOption(eGarageStateFilter filter)
        {
            List<string> LicensesPlatesList =null; //will alway be one of the cases here,
                                                   //filter validation is being checked before

            switch(filter)
            {
                case eGarageStateFilter.All:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesList();
                        break;
                    }
                case eGarageStateFilter.InRepair:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesListByGarageState(eVehicleGarageState.InRepair);
                        break;
                    }
                case eGarageStateFilter.Repaired:
                    {
                        LicensesPlatesList = m_GarageEngine.GetLicensePlatesListByGarageState(eVehicleGarageState.Repaired);
                        break;
                    }
                case eGarageStateFilter.Paid:
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
            string licensePlate = getLicenseFromUser(); //change function to licenseplate
            eVehicleGarageState newState = getVehicleGarageStateOptionFromUser();

            m_GarageEngine.ChangeVehicleState(licensePlate, newState);
        }
        
        private eVehicleGarageState getVehicleGarageStateOptionFromUser()
        {
            const int k_MinOptionVal = 1;
            const int k_MaxOptionVal = 3;

            printGarageStateOptions();
            int optionNumber = getValidEnumOptionNumber(k_MinOptionVal, k_MaxOptionVal);

            return (eVehicleGarageState)optionNumber;
        }

        private void printGarageStateOptions()
        {
            Console.WriteLine("Choose new vehicle state option:");
            Console.WriteLine("1) InRepair");
            Console.WriteLine("2) Repaired");
            Console.WriteLine("3) Paid");
        }

        private void fillWheelsWithAir()
        {
            string licensePlate = getLicenseFromUser(); //change function to licenseplate

            m_GarageEngine.FillVehicleWheelsWithAir(licensePlate);
        }

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
