using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor? m_CarColor;
        private const int k_NumberOfDoors = 5;
        private const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressure = 32f;

        public Car(string i_ModelName, string i_LicenseNumber, EnergySource i_energySource) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), i_energySource)
        {
        }


        private static List<Tire> createTiresList()
        {
            List<Tire> tiresList = new List<Tire>();

            for(int i = 0 ;  i < k_NumberOfWheels; i++)
            {
                tiresList[i] = new Tire(k_MaxAirPressure);
            }

            return tiresList;
        }
    }
}
