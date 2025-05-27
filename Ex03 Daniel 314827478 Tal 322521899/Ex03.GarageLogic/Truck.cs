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
        private float r_CargoVolume; //because cargo volume can be a decimal when im using dataload i need to change the cargovolume without using ctor
        private const int k_NumberOfWheels = 12;
        private const float k_MaxAirPressure = 27;
        private const float k_MaxFuelTank = 135;

        public Truck(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber,
            createTiresList(), new Fuel(0, k_MaxFuelTank, eFuelType.Soler))
        {
          //  r_CargoVolume = i_CargoVolume; //we will need to add to r_ishazardcargo to the ctor and change from readonly
        }

        public override void initVehicle(string i_IsHazardCargo, string i_CargoVolume)
        {
            if (bool.TryParse(i_IsHazardCargo, out bool IsHazardCargo))
            {
                r_IsHazardCargo = IsHazardCargo;
            }
            else
            {
                throw new ArgumentException("Invalid hazard cargo value.");
            }

            if (float.TryParse(i_CargoVolume, out float cargoVolume))
            {
                r_CargoVolume = cargoVolume;
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
