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
        private GarageSystem m_GarageSystem = new GarageSystem();
        private bool m_ProgramStillRunning = true;

        public void RunSystem()
        {
            Console.WriteLine("Welcome to garage management!");
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
                        displayLicensesPlatesList(); // Done
                        break;
                    }
                case eUserAction.ChangeVehicleGarageState:
                    {
                        changeVehicleGarageState();  // Done
                        break;
                    }
                case eUserAction.FillWheelsWithAir:
                    {
                        fillWheelsWithAir();         // Working
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
            try
            {
                string licensePlate = getLicensePlateFromUser();
                bool existingClient = m_GarageSystem.IsVehicleAlreadyExistsAtGarage(licensePlate);

                if (existingClient)
                {
                    Console.WriteLine("The vehicle already been at the garage before.");
                    m_GarageSystem.ChangeVehicleState(licensePlate, eVehicleGarageState.InRepair);
                }
                else
                {
                    string vehicleType = chooseVehicleType();
                    Vehicle newVehicle = VehicleFactory.CreateNewVehicle(vehicleType, licensePlate);
                    setVehicleState(newVehicle);
                    addClientToGarageSystem(newVehicle);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: {0}, try again.", ex.Message);
                insertNewVehicleToGarage();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: {0}, try again.", ex.Message);
                insertNewVehicleToGarage();
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine("Error: {0} need to be between {1} to {2}, try again.",
                    ex.Message, ex.MinValue, ex.MaxValue);
                insertNewVehicleToGarage();
            }
        }

        private void setVehicleState(Vehicle i_NewVehicle)
        {
            Dictionary<string, string> NewVehicleRequirements = i_NewVehicle.Requirements;
            string value;

            List<string> keys = new List<string>(NewVehicleRequirements.Keys);

            foreach (string requirement in keys)
            {
                Console.WriteLine("Please enter {0}:", requirement);
                value = Console.ReadLine();
                NewVehicleRequirements[requirement] = value;
            }

            i_NewVehicle.UpdateStateByRequirements();
        }

        private void addClientToGarageSystem(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please enter client name:");
            string clientName = Console.ReadLine();
            Console.WriteLine("Please enter client phone number:");
            string clientPhoneNumber = Console.ReadLine();
            m_GarageSystem.AddNewClientToGarageSystem(clientName, clientPhoneNumber, i_Vehicle);
        }

        private string getLicensePlateFromUser()
        {
            Console.WriteLine("Please enter vehicle license plate:");
            string licensePlate = Console.ReadLine();

            return licensePlate;
        }

        private string chooseVehicleType()
        {
            printVehiclesOptions();
            Console.Write("Your choice: ");
            string vehicleType = Console.ReadLine();

            return vehicleType;
        }

        private void printVehiclesOptions()
        {
            List<string> vehicleOptions = VehicleFactory.GetVehicleTypes();

            Console.WriteLine("Please enter the type of vehicle that will be entered to the garage from the list below:");
            foreach (string option in vehicleOptions)
            {
                Console.WriteLine(option);
            }
        }

        private bool IsVehicleTypeValid(string vehicleType)
        {
            List<string> vehicleOptions = VehicleFactory.GetVehicleTypes();
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
            List<string> LicensesPlatesList = null; //will alway be one of the cases here,
                                                    //filter validation is being checked before

            switch (filter)
            {
                case eGarageStateFilter.All:
                    {
                        LicensesPlatesList = m_GarageSystem.GetLicensePlatesList();
                        break;
                    }
                case eGarageStateFilter.InRepair:
                    {
                        LicensesPlatesList = m_GarageSystem.GetLicensePlatesListByGarageState(eVehicleGarageState.InRepair);
                        break;
                    }
                case eGarageStateFilter.Repaired:
                    {
                        LicensesPlatesList = m_GarageSystem.GetLicensePlatesListByGarageState(eVehicleGarageState.Repaired);
                        break;
                    }
                case eGarageStateFilter.Paid:
                    {
                        LicensesPlatesList = m_GarageSystem.GetLicensePlatesListByGarageState(eVehicleGarageState.Paid);
                        break;
                    }
                    //deafult: check validation????
            }

            return LicensesPlatesList;
        }

        private void changeVehicleGarageState()
        {
            string licensePlate = getLicensePlateOfExistsVehicle();
            eVehicleGarageState newState = getVehicleGarageStateOptionFromUser();

            m_GarageSystem.ChangeVehicleState(licensePlate, newState);
        }
        
        private string getLicensePlateOfExistsVehicle()
        {
            bool isVehicleExitsAtGarage = false;
            string licensePlate = null;

            while (!isVehicleExitsAtGarage)
            {
                licensePlate = getLicensePlateFromUser();
                isVehicleExitsAtGarage = m_GarageSystem.IsVehicleAlreadyExistsAtGarage(licensePlate);
                if (!isVehicleExitsAtGarage)
                {
                    Console.WriteLine("Vehicle with this license plate not exists at the garage, try again.");
                }
            }

            return licensePlate;
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
            string licensePlate = getLicensePlateOfExistsVehicle();

            m_GarageSystem.FillVehicleWheelsWithAir(licensePlate);
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
