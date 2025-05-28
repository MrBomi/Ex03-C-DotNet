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

        public abstract void InitVehicle(string[] i_VehicleProperties);

        public void SetEnergyPrecentageLeft(string i_EnergyPrecentageLeft)
        {
            if (float.TryParse(i_EnergyPrecentageLeft, out float energyPercentage))
            {
                if (energyPercentage >= 0 && energyPercentage <= 100)
                {
                    m_EnergyPrecentageLeft = energyPercentage;
                    m_EnergySource.CurrentEnergyLeft = (energyPercentage * m_EnergySource.MaxEnergyAmount) / 100;
                }
                else
                {
                    throw new ValueRangeException(100, 0, "Energy input should be between 0 - 100.");
                }
            }
            else
            {
                throw new ArgumentException("Precentage should be float");
            }
        }

        public void SetTiresData(string i_ManufacturerName, string i_AirPressure)
        {
            if (!float.TryParse(i_AirPressure, out float airPressureValue))
            {
                throw new ArgumentException("Invalid air pressure input.");
            }
            else
            {
                foreach (Tire tire in m_VehicleTires)
                {
                    tire.ManufacturerName = i_ManufacturerName;
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
            return (m_EnergySource.CurrentEnergyLeft / m_EnergySource.MaxEnergyAmount) * 100;
        }

        public abstract string SpecifVehiclePropertiesInfo();
        
        public override string ToString()
        {
            ushort tireNumber = 1;
            string vehicleDetails;

            vehicleDetails = string.Format(
                "Model Name: {0}\nLicense Number: {1}\nEnergy Percentage Left: {2:P2}\nTires:\n",
                r_ModelName, r_LicenseNumber, m_EnergyPrecentageLeft.ToString());

            foreach (Tire tire in m_VehicleTires)
            {
                vehicleDetails += string.Format("Wheel {0}:", tireNumber++);
                vehicleDetails += tire.ToString();
            }

            vehicleDetails += string.Format("Energy Source: {0}\n", m_EnergySource.ToString());
            vehicleDetails += SpecifVehiclePropertiesInfo();

            return vehicleDetails;
        }
    }
}
