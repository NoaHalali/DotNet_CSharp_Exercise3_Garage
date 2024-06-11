using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleFactory
    {
        List<string> m_VehicleTypes;

        public VehicleFactory()
        {
            m_VehicleTypes.Add("Motorcycle");
            m_VehicleTypes.Add("ElectricMotorcycle");
            m_VehicleTypes.Add("Car");
            m_VehicleTypes.Add("ElectricCar");
            m_VehicleTypes.Add("Truck");
        }

        public List<string> VehicleTypes
        {
            get 
            { 
                return m_VehicleTypes;
            }
        }

        public enum eVehicleType
        {
            Motorcycle,
            ElectricMotorcycle,
            Car,
            ElectricCar,
            Truck,
        }

        public Vehicle CreateNewVehicle(eVehicleType i_TypeToCreate)
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
