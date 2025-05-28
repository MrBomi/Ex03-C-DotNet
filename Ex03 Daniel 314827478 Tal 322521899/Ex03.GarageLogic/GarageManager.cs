using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleInfo> r_GarageVehicles = new Dictionary<string, VehicleInfo>();
        private const int k_NumberOfRequiredVehicleProperties = 8; // Adjusted to match the expected number of properties

        public void LoadVehiclesDataBase()
        {
            string fileName = "Vehicles.db";

            if (!File.Exists(fileName))
            {
                throw new ArgumentException("The specified data file 'Vehicles.db' does not exist.");
            }

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
              
                string[] rawParts = line.Split(',');
                string[] parts = rawParts.Select(p => p.Trim()).ToArray();
                try
                {
                    AddVehicleToGarage(parts);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error adding vehicle with license {parts[1]}: {ex.Message}");
                }
            }
        }

        public void AddVehicleToGarage(string[] i_VehicleProperties)
        {
            if (i_VehicleProperties == null || i_VehicleProperties.Length < k_NumberOfRequiredVehicleProperties)
            {
               throw new ArgumentException("Invalid vehicle properties provided.");
            }
            else
            {
                string vehicleTypeStr = i_VehicleProperties[0];
                string licenseId = i_VehicleProperties[1];
                string modelName = i_VehicleProperties[2];
                string energyPercentage = i_VehicleProperties[3];
                string tireModel = i_VehicleProperties[4];
                string tirePressure = i_VehicleProperties[5];
                string ownerName = i_VehicleProperties[6];
                string ownerPhone = i_VehicleProperties[7];

                if (isSelectedViehicleInGarage(licenseId))
                {
                    UpdateVehicleStatus(licenseId, eVehicleStatus.InProcess);
                }
                else
                {
                    Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleTypeStr, licenseId, modelName);

                    vehicle.SetEnergyPrecentageLeft(energyPercentage);
                    vehicle.SetTiresData(tireModel, tirePressure);
                    vehicle.initVehicle(i_VehicleProperties);
                    vehicle.ValidateGarageEntryConditions();

                    VehicleInfo info = new VehicleInfo(ownerName, ownerPhone, vehicle);

                    if (!r_GarageVehicles.ContainsKey(licenseId))
                    {
                        r_GarageVehicles.Add(licenseId, info);
                    }
                }
            }
        }

        public List<string> ShowVehiclesLicenses(eVehicleStatus? i_FilterStatus = null)
        {
            List<string> filteredVehiclesInGarage = new List<string>();

            foreach (KeyValuePair<string, VehicleInfo> Vehicle in r_GarageVehicles)
            {
                if (Vehicle.Value.VehicleStatus == i_FilterStatus)
                {
                    filteredVehiclesInGarage.Add(Vehicle.Key);
                }
            }

            return filteredVehiclesInGarage;
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            if (isSelectedViehicleInGarage(i_LicenseNumber))
            {
                r_GarageVehicles[i_LicenseNumber].VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} was not found in the garage.");
            }
        }


        public void InflateTireToMax(string i_LicenseNumber)
        {
            if (isSelectedViehicleInGarage(i_LicenseNumber))
            {
                foreach (Tire tire in r_GarageVehicles[i_LicenseNumber].Vehicle.Tires)
                {
                    tire.InflateTire(tire.MaxAirPressure - tire.CurrentAirPressure);
                }
            }
            else
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} was not found in the garage.");
            }
        }
        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            if (!isSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Cannot refuel: vehicle with license number {i_LicenseNumber} does not exist in the garage.");
            }

            EnergySource selectedVehicleEnergySource = r_GarageVehicles[i_LicenseNumber].Vehicle.EnergySource;

            if (selectedVehicleEnergySource is Fuel)
            {
                Fuel vehicleFuelTank = selectedVehicleEnergySource as Fuel;

                if (vehicleFuelTank.FuelType == i_FuelType)
                {
                    vehicleFuelTank.AddEnergyToVehicle(i_AmountToFill);
                }
                else
                {
                    throw new ArgumentException($"Fuel type mismatch: vehicle requires {vehicleFuelTank.FuelType}, but received {i_FuelType}.");
                }
            }
            else
            {
                throw new ArgumentException("Refueling failed: vehicle is not fuel-based.");
            }
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            if (!isSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Cannot refuel: vehicle with license number {i_LicenseNumber} does not exist in the garage.");
            }

            EnergySource selectedVehicleEnergySource = r_GarageVehicles[i_LicenseNumber].Vehicle.EnergySource;

            if (selectedVehicleEnergySource is Battery)
            {
                Battery vehicleBattery = selectedVehicleEnergySource as Battery;
                vehicleBattery.ChargeVehicle(i_MinutesToCharge);
            }
            else
            {
                throw new ArgumentException("Refueling failed: vehicle is not Electric-based.");
            }
        }
        public string VehicleDetails(string i_LicenseNumber)
        {
            String vehicleDetails;
            String specificVehicleProperties;

            if (!isSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Cannot refuel: vehicle with license number {i_LicenseNumber} does not exist in the garage.");
            }
            else
            {
                specificVehicleProperties = r_GarageVehicles[i_LicenseNumber].Vehicle.SpecifVehiclePropertiesInfo();
                vehicleDetails =  r_GarageVehicles[i_LicenseNumber].ToString() + specificVehicleProperties;
            }

            return vehicleDetails;
        }


        public bool isSelectedViehicleInGarage(string i_LicenseNumber)
        {
            return r_GarageVehicles.ContainsKey(i_LicenseNumber);
        }
    }
}

