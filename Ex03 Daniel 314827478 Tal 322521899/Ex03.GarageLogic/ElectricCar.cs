using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_MaxBatteryTimeInHours = 4.8f;

        public ElectricCar(string i_LicenseID, string i_ModelName) : 
            base(i_ModelName, i_LicenseID, new Battery(0, k_MaxBatteryTimeInHours)) { }
    }
}
