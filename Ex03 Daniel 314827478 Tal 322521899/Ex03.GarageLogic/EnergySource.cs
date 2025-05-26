using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class EnergySource
    {
        public float m_CurrentEnergyLeft { get; set; }
        public float m_MaxEnergyAmount { get;}

        public EnergySource(float i_CurrentEnergyLeft, float i_MaxEnergyAmount)
        {
            m_CurrentEnergyLeft = i_CurrentEnergyLeft;
            m_MaxEnergyAmount = i_MaxEnergyAmount;
        }

        protected abstract void AddEnergyToVehicle(float i_EnergyToAdd);
        public abstract override string ToString();
    }

}
