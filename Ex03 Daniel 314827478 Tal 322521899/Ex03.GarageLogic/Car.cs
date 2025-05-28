using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor? m_CarColor;
        private eNumberOfDoors? m_NumberOfDoors;
        private const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressure = 32f;

        public eNumberOfDoors? NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }     

        public Car(string i_ModelName, string i_LicenseNumber, EnergySource i_energySource, eNumberOfDoors i_NumberOfDoors) 
            : base(i_ModelName, i_LicenseNumber, createTiresList(), i_energySource)
        {
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public override void InitVehicle(string[] i_VehicleProperties)
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

        public override string SpecifVehiclePropertiesInfo()
        {
            string specificCarProperties = string.Format(
                "Color: {0}\n" +
                "Number of doors: {1}\n",
                m_CarColor,
                m_NumberOfDoors);

            return specificCarProperties;
        }
    }
}
