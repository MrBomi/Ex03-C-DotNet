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
        private eNumberOfDoors r_NumberOfDoors; ///changed from readonly for the initvehivle
        public readonly eNumberOfDoors r_NumberOfDoorsAllowedInGarage = eNumberOfDoors.Five;
        private const int k_NumberOfWheels = 4;//changed from 5 to 4
        private const float k_MaxAirPressure = 32f;

        public Car(string i_ModelName, string i_LicenseNumber, EnergySource i_energySource, eNumberOfDoors i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), i_energySource)
        {
            r_NumberOfDoors = i_NumberOfDoors;
        }

        public override void ValidateGarageEntryConditions()
        {
            if (r_NumberOfDoors != r_NumberOfDoorsAllowedInGarage)
            {
                throw new ArgumentException($"The car must have {r_NumberOfDoorsAllowedInGarage} doors to enter the garage.");
            }
        }

        public override void initVehicle(string i_CarColor, string i_NumberOfDoors)
        {
            if (Enum.TryParse(i_CarColor, out eCarColor carColor))
            {
                m_CarColor = carColor;
            }
            else
            {
                throw new ArgumentException("Invalid car color.");
            }

            if (Enum.TryParse(i_NumberOfDoors, out eNumberOfDoors numberOfDoors))
            {
                r_NumberOfDoors = numberOfDoors;
            }
            else
            {
                throw new ArgumentException("Invalid number of doors.");
            }

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
