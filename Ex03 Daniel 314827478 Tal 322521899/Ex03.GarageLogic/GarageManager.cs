using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleInfo> r_GarageVehicles = new Dictionary<string, VehicleInfo>();

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

                string vehicleTypeStr = parts[0];
                string licenseId = parts[1];
                string modelName = parts[2];
                string energyPercentage = parts[3];
                string tireModel = parts[4];
                string tirePressure = parts[5];
                string ownerName = parts[6];
                string ownerPhone = parts[7];

                Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleTypeStr, licenseId, modelName);
                vehicle.SetEnergyPrecentageLeft(energyPercentage);
                vehicle.SetTiresData(tireModel, tirePressure);
                vehicle.initVehicle(parts[8], parts[9]);
                vehicle.ValidateGarageEntryConditions();

                VehicleInfo info = new VehicleInfo(ownerName, ownerPhone, vehicle);

                if (!r_GarageVehicles.ContainsKey(licenseId))
                {
                    r_GarageVehicles.Add(licenseId, info);
                }
            }
        }

        public void AddVehicleToGarage(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_NewVehicle)
        {
            if (isSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} already exists in the garage.");
            }
            else
            {
                VehicleInfo newVehicleInfo = new VehicleInfo(i_OwnerName, i_OwnerPhoneNumber, i_NewVehicle);
                r_GarageVehicles.Add(i_LicenseNumber, newVehicleInfo);
            }
        }

        public Dictionary<string, VehicleInfo> ShowVehiclesLicenses(eVehicleStatus? i_FilterStatus = null)
        {
            Dictionary<string, VehicleInfo> filteredVehicles = new Dictionary<string, VehicleInfo>();

            if (i_FilterStatus == null)
            {
                filteredVehicles = r_GarageVehicles;
            }
            else
            {
                foreach (KeyValuePair<string, VehicleInfo> Vehicle in r_GarageVehicles)
                {
                    if (Vehicle.Value.VehicleStatus == i_FilterStatus)
                    {
                        filteredVehicles.Add(Vehicle.Key, Vehicle.Value);
                    }
                }
            }

            return filteredVehicles;
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
        public string DisplayVehicleDetails(string i_LicenseNumber)
        {
            if (!isSelectedViehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"Cannot refuel: vehicle with license number {i_LicenseNumber} does not exist in the garage.");
            }
            else
            {
                return r_GarageVehicles[i_LicenseNumber].ToString();
            }

        }


        public bool isSelectedViehicleInGarage(string i_LicenseNumber)
        {
            return r_GarageVehicles.ContainsKey(i_LicenseNumber);
        }
    }
}

