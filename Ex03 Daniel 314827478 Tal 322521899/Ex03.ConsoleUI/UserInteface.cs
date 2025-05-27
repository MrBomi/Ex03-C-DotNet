using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInteface
    {
        private readonly GarageManager r_Garage;

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

        private void performUserAction(eMenuOptions i_selctedOption)
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

        private void LoadVehiclesFromFile()
        {
            r_Garage.LoadVehiclesDataBase();
            Console.WriteLine("Vehicles loaded successfully from the database.");
            throw new NotImplementedException();
        }

        private void ShowFullVehicleDetails()
        {
            throw new NotImplementedException();
        }

        private void RechargeVehicle()
        {
            throw new NotImplementedException();
        }

        private void RefuelVehicle()
        {
            throw new NotImplementedException();
        }

        private void InflateWheelsToMaximum()
        {
            throw new NotImplementedException();
        }

        private void ChangeVehicleStatus()
        {
            throw new NotImplementedException();
        }

        private void ShowAllLicenseNumbers()
        {
            throw new NotImplementedException();
        }

        private void InsertNewVehicle()
        {
            throw new NotImplementedException();
        }

        private eMenuOptions printMenu()
        {
            bool isInputVaid = false;
            ushort inputToTest;
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
                    inputToTest = ushort.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input. Please enter number between 0-8");
                    continue;
                }

                if(Enum.IsDefined(typeof(eMenuOptions), inputToTest))
                {
                    optionSelected = (eMenuOptions)inputToTest;
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

