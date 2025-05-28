using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_EnergyPrecentageLeft;
        private List<Tire> m_VehicleTires;
        public const int k_SpecificVehiclePropertiesStartIndex = 8 ;
        protected EnergySource m_EnergySource { get; set; }


        public Vehicle(string i_ModelName, string i_LicenseNumber, List<Tire> i_VehiclesTires, EnergySource i_energySource)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleTires = i_VehiclesTires;
            m_EnergySource = i_energySource;
            m_EnergyPrecentageLeft = calculateEnergyPrecentage();
        }

        public abstract void initVehicle(string[] i_VehicleProperties);

        public virtual void ValidateGarageEntryConditions()
        {
        }

        public void SetEnergyPrecentageLeft(string i_EnergyPrecentageLeft)
        {
            if (float.TryParse(i_EnergyPrecentageLeft, out float energyPercentage))
            {
                m_EnergySource.m_CurrentEnergyLeft = energyPercentage;
                    
            }
            else
            {
                throw new ArgumentException("Invalid energy percentage input.");
            }
        }
        public void SetTiresData(string manufacturerName, string airPressure)
        {
            if (!float.TryParse(airPressure, out float airPressureValue))
            {
                throw new ArgumentException("Invalid air pressure input.");
            }
            else
            {
                foreach (Tire tire in m_VehicleTires)
                {
                    tire.ManufacturerName = manufacturerName;
                    tire.CurrentAirPressure = airPressureValue;
                }
            }
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

        public virtual string SpecifVehiclePropertiesInfo()
        {
            return string.Empty;
        }


        public override string ToString()
        {
            string vehicleDetails = string.Format(
                "Model Name: {0}\nLicense Number: {1}\nEnergy Percentage Left: {2:P2}\nTires:\n",
                r_ModelName, r_LicenseNumber, m_EnergyPrecentageLeft.ToString());

            foreach (Tire tire in m_VehicleTires)
            {
                vehicleDetails += tire.ToString();
            }

            vehicleDetails += string.Format("Energy Source: {0}\n", m_EnergySource.ToString());
            vehicleDetails += SpecifVehiclePropertiesInfo();



            return vehicleDetails;
        }
    }
}
