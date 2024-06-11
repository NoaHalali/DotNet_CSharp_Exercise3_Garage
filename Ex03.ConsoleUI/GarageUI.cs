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

        private enum eClientAction
        {
            InsertNewVehicle = 1,
            PrintVehiclesLicense = 2,
            ChangeVehicleState = 3,
            AddAirToVehicle = 4,
            AddFuelToVehicle = 5,
            AddElectricityToVehicle = 6,
            PrintFullDetails = 7,
        }

        public void RunSystem()
        {
            bool IsProgramRunning = true;

            while (IsProgramRunning)
            {
                printMenu();
                eClientAction clientOption = getOptionFromUser();
                activateAction(clientOption);


            }
        }

        private void printMenu()
        {
            Console.WriteLine("Welcome to the Garage!");
            Console.WriteLine("Pick one of the options below by thier number:");
            Console.WriteLine("1. Enter new vehicle to the garage.");
            Console.WriteLine("2. Print list of vehicles licenses at the garage.");
            Console.WriteLine("3. Change vehicle state at the garage");
            Console.WriteLine("4. Add air to wheels of a vehicle.");
            Console.WriteLine("5. Add fuel to a vehicle powered by fuel.");
            Console.WriteLine("6. Add electricity to a vehicle powered by electricity.");
            Console.WriteLine("7. Print full details of a vehicle.");
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

        private void activateAction(eClientAction i_ClientAction)
        {
            switch (i_ClientAction)
            {
                case eClientAction.InsertNewVehicle:
                    {
                        insertNewVehicleToGarage();
                        break;
                    }
                case eClientAction.PrintVehiclesLicense:
                    {
                        break;
                    }
                case eClientAction.ChangeVehicleState:
                    {
                        break;
                    }
                case eClientAction.AddAirToVehicle:
                    {
                        break;
                    }
                case eClientAction.AddFuelToVehicle:
                    {
                        break;
                    }
                case eClientAction.AddElectricityToVehicle:
                    {
                        break;
                    }
                case eClientAction.PrintFullDetails:
                    {
                        break;
                    }
            }
        }

        private void insertNewVehicleToGarage()
        {
            string licensePlate = getLicenseFromUser();
            bool existingClient = m_GarageEngine.IsClientAlreadyExists(licensePlate);
            //bool existingClient = m_GarageEngine.tryFindClient(licensePlate, out Client client);

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
    }
}
