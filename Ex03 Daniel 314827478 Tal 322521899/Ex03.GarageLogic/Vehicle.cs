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
        private List<Tire> m_VehicleTires;
        protected EnergySource m_EnergySource { get; set; }


        public Vehicle(string i_ModelName, string i_LicenseNumber,  List<Tire> i_VehiclesTires, EnergySource i_energySource)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyPrecentageLeft = calculateEnergyPrecentage();
            m_VehicleTires = i_VehiclesTires;
            m_EnergySource = i_energySource;
        }

        private float calculateEnergyPrecentage()
        {
            return m_EnergySource.m_CurrentEnergyLeft / m_EnergySource.m_MaxEnergyAmount;
        }
    }
}
