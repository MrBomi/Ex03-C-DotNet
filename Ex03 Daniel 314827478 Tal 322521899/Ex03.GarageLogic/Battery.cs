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
        protected override void AddEnergyToVehicle(float i_EnergyToAdd)
        {
            chargeVehicle(i_EnergyToAdd);
        }

        private void chargeVehicle(float i_MinutesToAdd) 
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
    }
}
