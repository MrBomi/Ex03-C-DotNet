using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private readonly GarageManager r_Garage;

        public UserInterface()
        {
            r_Garage = new GarageManager();
        }
        public void RunGarage()
        {
            bool isGarageActive = true;
            eMenuOptions selctedOption;

            while (isGarageActive)
            {
                selctedOption = printMenu();

                if(selctedOption == eMenuOptions.ExitGarage)
                {
                    Console.WriteLine("Exiting garage...");
                    isGarageActive = false;
                }
                else
                {
                    performUserAction(selctedOption);
                }
            }
        }

        public void performUserAction(eMenuOptions i_selctedOption)
        {
            Console.Clear();
            switch (i_selctedOption)
            {
                case eMenuOptions.LoadDataBase:
                    LoadVehiclesFromFile();
                    break;
                case eMenuOptions.AddNewVehicle:
                    InsertNewVehicle();
                    break;
                case eMenuOptions.ShowLicensesList:
                    ShowAllLicenseNumbers();
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    ChangeVehicleStatus();
                    break;
                case eMenuOptions.InflateWheelsToMax:
                    InflateWheelsToMaximum();
                    break;
                case eMenuOptions.RefuelVehicle:
                    RefuelVehicle();
                    break;
                case eMenuOptions.RechargeVehicle:
                    RechargeVehicle();
                    break;
                case eMenuOptions.ShowVehicleData:
                    ShowFullVehicleDetails();
                    break;
                default:
                    Console.WriteLine("Unknown option.");
                    break;
            }
        }

        private void RechargeVehicle()
        {
            string licenseNumber;
            string amountOfTimeToRecharge;
            bool isValidFloat;

            Console.WriteLine("Please enter the license number of the vehicle you want to recharge:");
            licenseNumber = Console.ReadLine();
            if (!r_Garage.isSelectedViehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Vehicle not found in the garage. Going back to Menu.");
                printMenu();
            }
            else
            {
                Console.WriteLine("Please enter the amount of time in minutes to recharge the vehicle:");
                amountOfTimeToRecharge = Console.ReadLine();
                isValidFloat = float.TryParse(amountOfTimeToRecharge, out float rechargeTime) && rechargeTime >= 0;
                if (!isValidFloat)
                {
                    Console.WriteLine("Invalid input for recharge time. Going back to Menu.");
                    printMenu();
                }
                else
                {
                    Console.WriteLine("Recharging vehicle...");
                    r_Garage.RechargeVehicle(licenseNumber, rechargeTime);
                }
            }
        }

        private void LoadVehiclesFromFile()
        {
            r_Garage.LoadVehiclesDataBase();
            Console.WriteLine("Vehicles loaded successfully from the database.");
        }

        private void ShowFullVehicleDetails()
        {
            Console.WriteLine("Please enter the license number of the vehicle you want to view details for:");
            Console.WriteLine(r_Garage.VehicleDetails(Console.ReadLine()));
        }
 
        private void RefuelVehicle()
        {
            string licenseNumber;
            string fuelType;
            string AmoutTofill;
            bool isValidEnum;
            bool isValidAmoutTofill;

            Console.WriteLine("Please enter the license number of the vehicle you want to refuel:");
            licenseNumber = Console.ReadLine();

            if (!r_Garage.isSelectedViehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Vehicle not found in the garage. Going back to Menu.");
                printMenu();
            }
            else
            {
                Console.WriteLine("Please enter the fuel type:");
                fuelType = Console.ReadLine();
                isValidEnum = Enum.TryParse(fuelType, out eFuelType fuelTypeEnum) && Enum.IsDefined(typeof(eFuelType), fuelTypeEnum);
                if (!isValidEnum)
                {
                    Console.WriteLine("Invalid fuel type. Going back to Menu.");
                    printMenu();
                }
                else
                {
                    Console.WriteLine("Please enter the amount of fuel to fill:");
                    AmoutTofill = Console.ReadLine();
                    isValidAmoutTofill = float.TryParse(AmoutTofill, out float amountToFillFloat) || amountToFillFloat < 0;
                    if (isValidAmoutTofill)
                    {
                        Console.WriteLine("Invalid amount to fill. Going back to Menu.");
                        printMenu();
                    }
                    else
                    {
                        Console.WriteLine(" Refueling vehicle...");
                        r_Garage.RefuelVehicle(licenseNumber, fuelTypeEnum, amountToFillFloat);
                    }
                }
            }
        }

        private void InflateWheelsToMaximum()
        {
            string licenseNumber;

            Console.WriteLine("Please enter the license number of the vehicle you want to refuel:");
            licenseNumber = Console.ReadLine();

            if (!r_Garage.isSelectedViehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Vehicle not found in the garage. Going back to Menu.");
                printMenu();
            }
            else
            {
                Console.WriteLine("Inflating wheels to maximum pressure...");
                r_Garage.InflateTireToMax(licenseNumber);
            }
        }

        private void ChangeVehicleStatus()
        {
            string licenseNumber;
            string newStatus;
            bool isValidEnum;

            Console.WriteLine("Please enter the license number of the vehicle you want to refuel:");
            licenseNumber = Console.ReadLine();

            if (!r_Garage.isSelectedViehicleInGarage(licenseNumber))
            {
                Console.WriteLine("Vehicle not found in the garage. Going back to Menu.");
                printMenu();
            }
            else
            {
                Console.WriteLine("Please enter the new status for the vehicle (InProcess, Fixed, Paid):");
                newStatus = Console.ReadLine();
                isValidEnum = Enum.TryParse(newStatus, out eVehicleStatus vehicleStatusEnum)
                    && Enum.IsDefined(typeof(eVehicleStatus), vehicleStatusEnum);

                if (!isValidEnum)
                {
                    Console.WriteLine("Invalid status. Going back to Menu.");
                    printMenu();
                }
                else
                {
                    Console.WriteLine("Changing vehicle status...");
                    r_Garage.UpdateVehicleStatus(licenseNumber, vehicleStatusEnum);
                }
            }
        }

        private void ShowAllLicenseNumbers()
        {
            eVehicleStatus vehicleStatusToFilter;
            bool isValidEnum = false;
            List<string> filteredLicenseNumbers = null;

            Console.WriteLine("Please enter the desired status to filter - type 0 for InProcess, 1 for Fixed or 2 for Paid");
            isValidEnum = Enum.TryParse(Console.ReadLine(), out vehicleStatusToFilter)
                   && Enum.IsDefined(typeof(eVehicleStatus), vehicleStatusToFilter);

            if (!isValidEnum)
            {
                Console.WriteLine("Invalid input. Returning to menu...");
            }
            else
            {
                filteredLicenseNumbers = r_Garage.ShowVehiclesLicenses(vehicleStatusToFilter);
            }

            foreach (string licenseNumber in filteredLicenseNumbers)
            {
                Console.WriteLine($"{licenseNumber}");
            }
        }

        private void InsertNewVehicle() // to split
        {
            string licenseId;
            string vehicleType;
            string energyPrecentage;
            string modelName;
            string tireModel;
            string tirePressure;
            string ownerName;
            string ownerPhone;
            string specialParam1 = null;
            string specialParam2 = null;

            Console.WriteLine("Please enter the license id of the car you want to insert to garage");
            licenseId = Console.ReadLine();
            if(r_Garage.isSelectedViehicleInGarage(licenseId))
            {
                Console.WriteLine("Weve found your car in our system, we will fix it for you");
                r_Garage.UpdateVehicleStatus(licenseId, eVehicleStatus.InProcess);
            }
            else
            {
                Console.WriteLine("Please enter the vehicle type");
                vehicleType = Console.ReadLine();
                Console.WriteLine("Please enter the model name of the vehicle");
                modelName = Console.ReadLine();
                Console.WriteLine("Please enter the vehicle energy precentage");
                energyPrecentage = Console.ReadLine();
                Console.WriteLine("Please enter the tire model");
                tireModel = Console.ReadLine();
                Console.WriteLine("Please enter the current air pressure of your wheels");
                tirePressure = Console.ReadLine();
                Console.WriteLine("Please enter owner name");
                ownerName = Console.ReadLine();
                Console.WriteLine("Please enter owner phone");
                ownerPhone = Console.ReadLine();

                switch (vehicleType)
                {
                    case "FuelCar":
                    case "ElectricCar":
                        Console.WriteLine("Please the color of the car");
                        specialParam1 = Console.ReadLine();
                        Console.WriteLine("Please enter how many doors that car has");
                        specialParam2 = Console.ReadLine();
                        break;
                    case "FuelMotorcycle":                        
                    case "ElectricMotorcycle":
                        Console.WriteLine("Please the license type of the motorcycle");
                        specialParam1 = Console.ReadLine();
                        Console.WriteLine("Please enter the engine volume");
                        specialParam2 = Console.ReadLine();
                        break;
                    case "Truck":
                        Console.WriteLine("Please enter if carring hazardious stuff (true / false)");
                        specialParam1 = Console.ReadLine();
                        Console.WriteLine("Please enter the cargo volume");
                        specialParam2 = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("We are not support that vehicle type");
                        break;
                }

                string[] vehicleParams = {vehicleType, licenseId, modelName, energyPrecentage, tireModel,
                    tirePressure, ownerName, ownerPhone, specialParam1, specialParam2};
                r_Garage.AddVehicleToGarage(vehicleParams);
                Console.WriteLine("Vehicle added successfully to the garage.");
            }
        }

        //public eMenuOptions printMenu()
        //{
        //    bool isInputVaid = false;
        //    ushort inputToTest;
        //    eMenuOptions optionSelected = eMenuOptions.ExitGarage;

        //    Console.WriteLine("Please choose an option:");
        //    Console.WriteLine("1. Load vehicles from database");
        //    Console.WriteLine("2. Insert a new vehicle to the garage");
        //    Console.WriteLine("3. Show all license numbers");
        //    Console.WriteLine("4. Change vehicle status");
        //    Console.WriteLine("5. Inflate wheels to max");
        //    Console.WriteLine("6. Refuel a fuel-based vehicle");
        //    Console.WriteLine("7. Recharge an electric vehicle");
        //    Console.WriteLine("8. Show full vehicle details");
        //    Console.WriteLine("0. Exit");
        //    Console.WriteLine();
        //    Console.Write("Enter your choice (0-8): ");

        //    while (!isInputVaid)
        //    {
        //        try 
        //        {
        //            inputToTest = ushort.Parse(Console.ReadLine());
        //        }
        //        catch (FormatException)
        //        {
        //            Console.WriteLine("Invalid Input. Please enter number between 0-8");
        //            continue;
        //        }

        //        if(Enum.IsDefined(typeof(eMenuOptions), inputToTest) )
        //        {
        //            optionSelected = (eMenuOptions)inputToTest;
        //            isInputVaid = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("That option is out of range, Please enter number between 0-8");
        //        }
        //    }

        //    return optionSelected;
        //}

        public eMenuOptions printMenu()
        {
            bool isInputVaid = false;
            string inputToTest;
            eMenuOptions optionSelected = eMenuOptions.ExitGarage;

            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Load vehicles from database");
            Console.WriteLine("2. Insert a new vehicle to the garage");
            Console.WriteLine("3. Show all license numbers");
            Console.WriteLine("4. Change vehicle status");
            Console.WriteLine("5. Inflate wheels to max");
            Console.WriteLine("6. Refuel a fuel-based vehicle");
            Console.WriteLine("7. Recharge an electric vehicle");
            Console.WriteLine("8. Show full vehicle details");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice (0-8): ");

            while (!isInputVaid)
            {
                try
                {
                    inputToTest = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input. Please enter number between 0-8");
                    continue;
                }
                if (Enum.TryParse(inputToTest, out eMenuOptions enumToCheck) && Enum.IsDefined(typeof(eMenuOptions), enumToCheck))
                {
                    optionSelected = enumToCheck;
                    isInputVaid = true;
                }
                else
                {
                    Console.WriteLine("That option is out of range, Please enter number between 0-8");
                }
            }

            return optionSelected;
        }
    }
}

