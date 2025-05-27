using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
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

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }
        public List<Tire> Tires
        {
            get
            {
                return m_VehicleTires;
            }
        }

        private float calculateEnergyPrecentage()
        {
            return m_EnergySource.m_CurrentEnergyLeft / m_EnergySource.m_MaxEnergyAmount;
        }

        public override string ToString()
        {
            string vehicleDetails = string.Format(
                "Model Name: {0}\nLicense Number: {1}\nEnergy Percentage Left: {2:P2}\nTires:\n",
                r_ModelName, r_LicenseNumber, m_EnergyPrecentageLeft.ToString());

            foreach (Tire tire in m_VehicleTires)
            {
                vehicleDetails += string.Format("Manufacturer: {0}",
                    tire.ToString());
            }

            vehicleDetails += string.Format("Energy Source: {0}\n", m_EnergySource.ToString());

            return vehicleDetails;
        }
    }
}
