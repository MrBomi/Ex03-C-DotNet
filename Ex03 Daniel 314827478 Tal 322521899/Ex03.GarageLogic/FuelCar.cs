using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        private const float k_MaxFuelTank = 48f;

        public FuelCar(string i_LicenseID, string i_ModelName) :
            base(i_ModelName, i_LicenseID, new Fuel(0, k_MaxFuelTank, eFuelType.Octan95), eNumberOfDoors.Five) { }

        public virtual string SpecifVehiclePropertiesInfo()
        {
            string specificVehicleProperties = string.Format(
                "Fuel Type: {0}\n" +
                "Max Fuel Tank: {1} liters\n",
                ((Fuel)EnergySource).FuelType.ToString(),
                ((Fuel)EnergySource).m_MaxEnergyAmount);

            return specificVehicleProperties;
        }

    }
}
