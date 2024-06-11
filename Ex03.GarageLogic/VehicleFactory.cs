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

        public enum eVehicleType
        {
            Motorcycle,
            ElectricMotorcycle,
            Car,
            ElectricCar,
            Truck,
        }

        public static Vehicle CreateNewVehicle(eVehicleType i_TypeToCreate)
        {
            Vehicle newVehicle;

            switch (i_TypeToCreate)
            {
                case eVehicleType.Motorcycle:
                    {
                        newVehicle = new FuelMotorcycle();
                        break;
                    }
                case eVehicleType.ElectricMotorcycle:
                    {
                        newVehicle = new ElectricMotorcycle();
                        break;
                    }
                case eVehicleType.Car:
                    {
                        newVehicle = new FuelCar();
                        break;
                    }
                case eVehicleType.ElectricCar:
                    {
                        newVehicle = new ElectricCar();
                        break;
                    }
                default: // Equal to case eVehicleType.Truck:
                    {
                        newVehicle = new Truck();
                        break;
                    }
            }

            return newVehicle;
        }
    }
}
