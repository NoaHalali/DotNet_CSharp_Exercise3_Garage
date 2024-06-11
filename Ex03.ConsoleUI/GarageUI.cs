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
                getOptionFromUser();


            }

        }

        private void printMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Insert new vehicle to the garage");
            Console.WriteLine("2) Display all license plates in the garage system");
            Console.WriteLine("3) Change vehicle garage state");
            Console.WriteLine("4) Fill vehicle wheels with maximum air");
            Console.WriteLine("5) Charge vehicle energy"); //2 options together, fuel and electric
            Console.WriteLine("6) Display client's data"); ;
        }
        private int getOptionFromUser()
        {
            int num = int.Parse(Console.ReadLine()); // TryParse + in range of the enum.

            eClientAction client = (eClientAction)num;

            return 0;
        }

        private void activateAction(eClientAction num)
        {
            switch (num)
            {
                case eClientAction.InsertNewVehicle:
                    {
                        InsertNewVehicleToGarage();
                        break;
                    }
                case eClientAction.something:
                    {

                        break;
                    }
            }
        }

        public void InsertNewVehicleToGarage()
        {
            //getInputFromUser
            string licensePlate;

            bool existingClient = m_GarageEngine.tryFindClient(licensePlate, out Client client);

            if (existingClient)
            {
                m_GarageEngine.ChangeVehicleState(client);
                
            }
            else
            {
                chooseVehicleType();

            }
        }
    }
}
