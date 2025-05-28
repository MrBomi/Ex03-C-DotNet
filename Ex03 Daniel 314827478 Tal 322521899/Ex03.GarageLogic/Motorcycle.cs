using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseType? m_LicenseType;
        private int r_EngineVolume;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 30f;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, EnergySource i_energySource) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), i_energySource)
        { }

        public override void InitVehicle(string[] i_VehicleProperties)
        {
            string licenseType = i_VehicleProperties[k_SpecificVehiclePropertiesStartIndex];
            string engineVolume = i_VehicleProperties[k_SpecificVehiclePropertiesStartIndex + 1];

            if (Enum.TryParse(licenseType, out eLicenseType enumLicenseType))
            {
                m_LicenseType = enumLicenseType;
            }
            else
            {
                throw new ArgumentException("Invalid license type.");
            }

            if (int.TryParse(engineVolume, out int intEngineVolume))
            {
                if (intEngineVolume >= 0)
                {
                    r_EngineVolume = intEngineVolume;
                }
                else
                {
                    throw new ArgumentException("Engine volume should be positive number");
                }
            }
            else
            {
                throw new ArgumentException("Invalid engine volume.");
            }
        }

        public static List<Tire> createTiresList()
        {
            List<Tire> tiresList = new List<Tire>();

            for (int i = 0; i < k_NumberOfWheels ; i++)
            {
                tiresList.Add(new Tire(k_MaxAirPressure));
            }

            return tiresList;
        }

        public override string SpecifVehiclePropertiesInfo()
        {
            string specificCarProperties = string.Format(
                "License type: {0}\n" +
                "Engine volume: {1} liters\n",
                m_LicenseType,
                r_EngineVolume);

            return specificCarProperties;
        }
    }
}
