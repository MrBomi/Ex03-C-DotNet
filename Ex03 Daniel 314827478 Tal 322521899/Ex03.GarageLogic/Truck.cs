using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool r_IsHazardCargo;
        private float m_CargoVolume; 
        private const int k_NumberOfWheels = 12;
        private const float k_MaxAirPressure = 27;
        private const float k_MaxFuelTank = 135;

        public Truck(string i_LicenseNumber , string i_ModelName) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), new Fuel(0, k_MaxFuelTank, eFuelType.Soler)) {}

        public override void InitVehicle(string[] i_VehicleProperties)
        {
            string isHazardCargo = i_VehicleProperties[k_SpecificVehiclePropertiesStartIndex];
            string cargoVolume = i_VehicleProperties[k_SpecificVehiclePropertiesStartIndex + 1];

            if (bool.TryParse(isHazardCargo, out bool isHazardCargoBool))
            {
                r_IsHazardCargo = isHazardCargoBool;
            }
            else
            {
                throw new ArgumentException("Invalid hazard cargo value.");
            }

            if (float.TryParse(cargoVolume, out float floatCargoVolume))
            {
                if (floatCargoVolume >= 0)
                {
                    m_CargoVolume = floatCargoVolume;
                }
                else
                {
                    throw new ArgumentException("Cargo volume should be positive.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid cargo volume.");
            }
        }

        public override string SpecifVehiclePropertiesInfo()
        {
            string specificVehicleProperties;

            specificVehicleProperties = string.Format(
                "Is Hazard Cargo: {0}\n" +
                "Cargo Volume: {1} cubic meters\n",
                r_IsHazardCargo ,
                m_CargoVolume);

            return specificVehicleProperties;
        }

        private static List<Tire> createTiresList()
        {
            List<Tire> tiresList = new List<Tire>();

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                tiresList.Add(new Tire(k_MaxAirPressure));
            }

            return tiresList;
        }
    }
}
