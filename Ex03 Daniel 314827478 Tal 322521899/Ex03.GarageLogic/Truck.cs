using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_IsHazardCargo;
        private readonly float r_CargoVolume;

        public Truck(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber)
        {
        }
    }
}
