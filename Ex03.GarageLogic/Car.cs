using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        internal enum eCarColor
        {
            Yello,
            White,
            Red,
            Black
        }

        internal enum eCarNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private eCarColor m_CarColor;
        private eCarNumberOfDoors m_CarDoorsNumber;
        private const int k_WheelsNumber = 5;
        private const int k_MaxWheelAirPressure = 31;

        public Car(string i_LicensePlate) 
            : base(i_LicensePlate, k_WheelsNumber, k_MaxWheelAirPressure)
        {}

        protected override void AddRequirements()
        {
            base.AddRequirements();
            m_Requirements.Add("Car Color", null);
            m_Requirements.Add("Car Doors Number", null);
        }

        public override void UpdateStateByRequirements()
        {
            base.UpdateStateByRequirements();
            setCarColor(m_Requirements["Car Color"]);
            setCarDoorsAmount(m_Requirements["Car Doors Number"]);
        }

        private void setCarColor(string i_CarColor)
        {
            if (i_CarColor == "Yellow")
            {
                m_CarColor = eCarColor.Yello;
            }
            else if (i_CarColor == "White")
            {
                m_CarColor = eCarColor.White;
            }
            else if (i_CarColor == "Black")
            {
                m_CarColor = eCarColor.Black;
            }
            else if (i_CarColor == "Red")
            {
                m_CarColor = eCarColor.Red;
            }
            else
            {
                throw new ArgumentException("Incorrect car color (only Yellow,White,Black,Red allowed)");
            }
        }

        private void setCarDoorsAmount(string i_CarDoorsNumber)
        {
            if (i_CarDoorsNumber == "2")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Two;
            }
            else if (i_CarDoorsNumber == "3")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Three;
            }
            else if (i_CarDoorsNumber == "4")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Four;
            }
            else if (i_CarDoorsNumber == "5")
            {
                m_CarDoorsNumber = eCarNumberOfDoors.Five;
            }
            else
            {
                throw new ArgumentException("Incorrect car doors number (only 2,3,4,5 allowed)");
            }
        }

        public override string ToString()
        {
            string stringToReturn = string.Format("car color: {0}" + Environment.NewLine +
                "car doors number: {1}" + Environment.NewLine +
                "{2}"
                , m_CarColor.ToString(), m_CarDoorsNumber.ToString(), base.ToString());

            return stringToReturn;
        }

    }
}
