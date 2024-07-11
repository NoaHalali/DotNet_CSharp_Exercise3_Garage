using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class MessagesUI
    {
        // $G$ NTT-001 (-5) You should have used string formatting.
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to garage management!" + Environment.NewLine);
        }

        // $G$ NTT-001 (-10) You should have used verbatim string here.
        public void MenuMessage()
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

        public void VehiclesOptionsMessage()
        {
            List<string> vehicleOptions = VehicleFactory.GetVehicleTypes();

            Console.WriteLine("Please enter the type of vehicle that will be entered to the garage from the list below:");
            foreach (string option in vehicleOptions)
            {
                Console.WriteLine(option);
            }
        }

        // $G$ NTT-001 (-0) You should have used verbatim string here.
        public void FilterOptionsMessage()
        {
            Console.WriteLine("Choose filter option by it's number:");
            Console.WriteLine("1) All");
            Console.WriteLine("2) InRepair");
            Console.WriteLine("3) Repaired");
            Console.WriteLine("4) Paid");
        }

        // $G$ NTT-001 (-0) You should have used verbatim string here.
        public void GarageStateOptionsMessage()
        {
            Console.WriteLine("Choose new vehicle state option:");
            Console.WriteLine("1) InRepair");
            Console.WriteLine("2) Repaired");
            Console.WriteLine("3) Paid");
        }
    }
}
