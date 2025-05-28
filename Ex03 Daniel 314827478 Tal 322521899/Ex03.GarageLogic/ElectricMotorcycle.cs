using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTimeInHours = 3.2f;

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) :
            base(i_ModelName, i_LicenseID, new Battery(0, k_MaxBatteryTimeInHours))
        { }
        public virtual string SpecifVehiclePropertiesInfo()
        {
            string specificVehicleProperties = string.Format(
                "Max Battery Time: {0} hours\n",
                ((Battery)EnergySource).m_MaxEnergyAmount);

            return specificVehicleProperties;
        }
    }

}
