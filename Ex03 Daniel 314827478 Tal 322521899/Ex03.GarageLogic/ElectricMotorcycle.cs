using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber)
        {
            this.m_EnergySource = new Battery();
        }
    }
}
