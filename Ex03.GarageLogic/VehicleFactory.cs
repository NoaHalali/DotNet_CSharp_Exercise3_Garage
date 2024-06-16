using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static List<string> GetVehicleTypes()
        {
            List<string> vehicleTypes = new List<string>
            {
                "Motorcycle",
                "ElectricMotorcycle",
                "Car",
                "ElectricCar",
                "Truck"
            };

            return vehicleTypes;
        }

        public static Vehicle CreateNewVehicle(string i_TypeToCreate, string i_LicensePlate)
        {
            Vehicle newVehicle;

            if (i_TypeToCreate == "Motorcycle")
            {
                newVehicle = new FuelMotorcycle(i_LicensePlate);
            }
            else if (i_TypeToCreate == "ElectricMotorcycle")
            {
                newVehicle = new ElectricMotorcycle(i_LicensePlate);
            }
            else if (i_TypeToCreate == "Car")
            {
                newVehicle = new FuelCar(i_LicensePlate);
            }
            else if (i_TypeToCreate == "ElectricCar")
            {
                newVehicle = new ElectricCar(i_LicensePlate);
            }
            else if (i_TypeToCreate == "Truck")
            {
                newVehicle = new Truck(i_LicensePlate);
            }
            else
            {
                throw new ArgumentException("Incorrect vehicle type");
            }

            return newVehicle;
        }
    }
}
