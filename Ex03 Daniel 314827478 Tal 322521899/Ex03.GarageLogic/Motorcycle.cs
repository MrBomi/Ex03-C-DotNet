using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseType? m_LicenseType;
        private readonly int r_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber)
        {
        }
    }
}
