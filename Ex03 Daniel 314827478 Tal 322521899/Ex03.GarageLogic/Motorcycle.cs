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
        private int r_EngineVolume;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 30f;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, EnergySource i_energySource, string i_ManufacturerName) : base(i_ModelName, i_LicenseNumber,
            createTiresList(i_ManufacturerName), i_energySource)
        {
        }

        public static List<Tire> createTiresList(string i_ManufacturerName)
        {
            List<Tire> tiresList = new List<Tire>();

            for (int i = 0; i < k_NumberOfWheels ; i++)
            {
                tiresList[i] = new Tire(k_MaxAirPressure, i_ManufacturerName);
            }

            return tiresList;
        }
    }
}
