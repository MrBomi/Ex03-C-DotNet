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
        private eNumberOfDoors? m_NumberOfDoors;
        public readonly eNumberOfDoors r_NumberOfDoorsAllowedInGarage = eNumberOfDoors.Five;
        private const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressure = 32f;

        public Car(string i_ModelName, string i_LicenseNumber, EnergySource i_energySource, eNumberOfDoors i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), i_energySource)
        {
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public override void ValidateGarageEntryConditions()
        {
            if (m_NumberOfDoors != r_NumberOfDoorsAllowedInGarage)
            {
                throw new ArgumentException($"The car must have {r_NumberOfDoorsAllowedInGarage} doors to enter the garage.");
            }
        }

        public override void initVehicle(string[] i_VehicleProperties)
        {
            string carColor = i_VehicleProperties[k_SpecificVehiclePropertiesStartIndex];
            string numberOfDoors = i_VehicleProperties[k_SpecificVehiclePropertiesStartIndex + 1];

            if (Enum.TryParse(carColor, out eCarColor enumCarColor) && Enum.IsDefined(typeof(eCarColor), enumCarColor) )
            {
                m_CarColor = enumCarColor;
            }
            else
            {
                throw new ArgumentException("Invalid car color.");
            }

            if (Enum.TryParse(numberOfDoors, out eNumberOfDoors enumNumberOfDoors) && Enum.IsDefined(typeof(eNumberOfDoors), enumNumberOfDoors))
            {
                m_NumberOfDoors = enumNumberOfDoors;
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
                tiresList.Add(new Tire(k_MaxAirPressure));

            }

            return tiresList;
        }
    }
}
