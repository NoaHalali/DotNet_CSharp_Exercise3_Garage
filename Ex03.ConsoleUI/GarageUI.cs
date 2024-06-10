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


        public void RunSystem()
        {

            while (true) // change to IsProgramRunning.
            {
                printMenu();
                getOptionFromUser();


            }


        }

        private void printMenu()
        {


        }

        private enum eClientAction
        {
            InsertNewVehicle,
            something
            //.......

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
                        m_GarageEngine.InsertNewVehicleToGarage();
                        break;
                    }
                case eClientAction.something:
                    {

                        break;
                    }
            }
        }
    }
}
