using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
