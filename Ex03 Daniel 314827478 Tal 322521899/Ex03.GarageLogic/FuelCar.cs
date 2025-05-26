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

        public FuelCar(string i_LicenseID, string i_ModelName, string i_ManufacturerName) :
        base(i_ModelName, i_LicenseID, new Fuel(0, k_MaxFuelTank, eFuelType.Octan95), i_ManufacturerName)
        {
        }

    }
}
