using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_EnergyPrecentageLeft;
        private List<Tire> m_VehiclesTiresList;
        protected EnergySource m_EnergySource { get; set; }


        public Vehicle(string i_ModelName, string i_LicenseNumber)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
        }
    }
}
