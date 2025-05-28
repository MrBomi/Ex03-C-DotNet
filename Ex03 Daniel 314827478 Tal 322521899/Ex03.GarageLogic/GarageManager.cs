using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleInfo> r_GarageVehicles = new Dictionary<string, VehicleInfo>();
        private const int k_NumberOfRequiredVehicleProperties = 8;

        public void LoadVehiclesDataBase(List<string> io_invalidLinesInFile)
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
                    io_invalidLinesInFile.Add(line);
                }
                catch (NullReferenceException ex)
                {
                    io_invalidLinesInFile.Add(line);
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

                if (IsSelectedViehicleInGarage(licenseId))
                {
                    UpdateVehicleStatus(licenseId, eVehicleStatus.InProcess);
                }
                else
                {
                    Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleTypeStr, licenseId, modelName);

                    if(vehicle == null)
                    {
                        throw new ArgumentException("Invalid vehicle properties provided.");
                    }

                    vehicle.SetEnergyPrecentageLeft(energyPercentage);
                    vehicle.SetTiresData(tireModel, tirePressure);
                    vehicle.InitVehicle(i_VehicleProperties);
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
            if (IsSelectedViehicleInGarage(i_LicenseNumber))
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
            if (IsSelectedViehicleInGarage(i_LicenseNumber))
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
            if (!IsSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Cannot refuel: vehicle with license number {i_LicenseNumber} does not exist in the garage.");
            }

            EnergySource selectedVehicleEnergySource = r_GarageVehicles[i_LicenseNumber].Vehicle.EnergySource;

            if(!(selectedVehicleEnergySource is Fuel))
            {
                throw new ArgumentException("That vehicle is not fuel based");
            }
            else 
            { 
                (selectedVehicleEnergySource as Fuel).AddEnergyToVehicle(i_AmountToFill, i_FuelType); 
            }
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            if (!IsSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Cannot refuel: vehicle with license number {i_LicenseNumber} does not exist in the garage.");
            }

            EnergySource selectedVehicleEnergySource = r_GarageVehicles[i_LicenseNumber].Vehicle.EnergySource;

            if (!(selectedVehicleEnergySource is Battery))
            {
                throw new ArgumentException("Refueling failed: vehicle is not Electric-based.");
            }
            else
            {
                selectedVehicleEnergySource.AddEnergyToVehicle(i_MinutesToCharge);
            }
        }

        public string VehicleDetails(string i_LicenseNumber)
        {
            String vehicleDetails;

            if (!IsSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License '{i_LicenseNumber}' does not exist in the garage.");
            }
            else
            {
                vehicleDetails = r_GarageVehicles[i_LicenseNumber].ToString();
            }

            return vehicleDetails;
        }

        public bool IsSelectedViehicleInGarage(string i_LicenseNumber)
        {
            return r_GarageVehicles.ContainsKey(i_LicenseNumber);
        }
    }
}

