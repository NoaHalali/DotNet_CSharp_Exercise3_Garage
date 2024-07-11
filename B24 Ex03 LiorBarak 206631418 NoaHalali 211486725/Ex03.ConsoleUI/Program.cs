using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//relevant to the entire solution:
// $G$ DSN-009 (-5) You should separate different classes/enums into different files.

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageUI userInterface = new GarageUI();

            userInterface.RunSystem();
            Console.ReadLine();
        }
    }
}
