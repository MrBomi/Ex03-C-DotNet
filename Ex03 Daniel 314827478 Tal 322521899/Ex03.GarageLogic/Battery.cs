using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Battery : EnergySource
    {
        public Battery(float i_CurrentEnergyLeft, float i_MaxEnergyAmount) : base(i_CurrentEnergyLeft, i_MaxEnergyAmount) { }
        

        protected override void AddEnergyToVehicle(float i_EnergyToAdd)
        {
            chargeVehicle(i_EnergyToAdd);
        }

        public void chargeVehicle(float i_MinutesToAdd) 
        {
            float upadtedBatteryLeft = this.m_CurrentEnergyLeft + i_MinutesToAdd;

            if(upadtedBatteryLeft > this.m_MaxEnergyAmount)
            {
                throw new ValueRangeException(this.m_MaxEnergyAmount, 0,
                    string.Format($"The battery can contain up to {this.m_MaxEnergyAmount} energy (in minutes)"));
            }
            else
            {
                this.m_CurrentEnergyLeft = upadtedBatteryLeft;
            }
        }

        public override string ToString()
        {
            return string.Format("Battery: {0} hours left , max energy amount is {1} ", m_CurrentEnergyLeft, m_MaxEnergyAmount);
        }

    }
}
