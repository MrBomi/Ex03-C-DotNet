using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool r_IsHazardCargo;
        private float m_CargoVolume; 
        private const int k_NumberOfWheels = 12;
        private const float k_MaxAirPressure = 27;
        private const float k_MaxFuelTank = 135;

        public Truck(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), new Fuel(0, k_MaxFuelTank, eFuelType.Soler)) {}

        public override void initVehicle(string[] i_VehicleProperties)
        {
            string isHazardCargo = i_VehicleProperties[0];
            string cargoVolume = i_VehicleProperties[1];

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
                m_CargoVolume = floatCargoVolume;
            }
            else
            {
                throw new ArgumentException("Invalid cargo volume.");
            }
        }

        private static List<Tire> createTiresList()
        {
            List<Tire> tiresList = new List<Tire>();

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                tiresList[i] = new Tire(k_MaxAirPressure);
            }

            return tiresList;
        }
    }
}
