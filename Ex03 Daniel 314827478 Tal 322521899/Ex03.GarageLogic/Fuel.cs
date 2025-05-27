using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Fuel : EnergySource
    {
        private eFuelType m_FuelType;

        public Fuel(float i_CurrentEnergyLeft, float i_MaxEnergyAmount, eFuelType i_FuelType) : base(i_CurrentEnergyLeft, i_MaxEnergyAmount) 
        {
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        protected override void AddEnergyToVehicle(float i_EnergyToAdd)
        {
            throw new ArgumentException("Must specify fuel type for that request");
        }

        public void AddEnergyToVehicle(float i_EnergyToAdd, eFuelType? i_FuelType = null)
        {
            refuelCar(i_EnergyToAdd, i_FuelType);
        }

        private void refuelCar(float i_FuelAmount, eFuelType? i_FuelType = null)
        {

            float updatedFuelLevel = this.m_CurrentEnergyLeft + i_FuelAmount;

            if(!i_FuelType.HasValue)
            {
                throw new NullReferenceException("Null reference for i_FuelType input");
            }
            else if(updatedFuelLevel > this.m_MaxEnergyAmount)
            {
                throw new ValueRangeException(this.m_MaxEnergyAmount, 0,
                    string.Format($"The fuel tank can contain up to {this.m_MaxEnergyAmount} liter"));
            }
            else if(i_FuelType != m_FuelType)
            {
                {
                    throw new ArgumentException(string.Format($"Wrong fuel type requested. expected for {this.m_FuelType}"));
                }
            }
            else
            {
                this.m_CurrentEnergyLeft = updatedFuelLevel;
            }
        }

        public override string ToString()
        {
            return string.Format("Fuel: {0} liters left , max enregy amount is {1} liters and the fuel type is {2}", m_CurrentEnergyLeft, m_MaxEnergyAmount, m_FuelType.ToString());
        }
    }
}
