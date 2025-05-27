using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private readonly Vehicle r_Vehicle;  //add to diagram

        public VehicleInfo(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = eVehicleStatus.InProcess;
            r_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }
        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return r_OwnerPhoneNumber;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
        public override string ToString()
        {
            string vehicleInfoDetails = string.Format(
                "Owner Name: {0}\nOwner Phone Number: {1}\nVehicle Status: {2}\nVehicle Model: {3}\n"
                , r_OwnerName, r_OwnerPhoneNumber, m_VehicleStatus.ToString(), r_Vehicle.ToString());

            return vehicleInfoDetails;
        }
    }
}
