using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public float m_CurrentEnergyLeft { get; set; }
        public float m_MaxEnergyAmount { get;}

        public EnergySource(float i_CurrentEnergyLeft, float i_MaxEnergyAmount)
        {
            if (i_MaxEnergyAmount <= 0)
            {
                throw new ArgumentException("Max energy amount must be greater than zero.");
            }
            else
            {
                m_MaxEnergyAmount = i_MaxEnergyAmount;

                if (i_CurrentEnergyLeft < 0 || i_CurrentEnergyLeft > m_MaxEnergyAmount)
                {
                    throw new ArgumentException($"Current energy left must be between 0 and {m_MaxEnergyAmount}.");
                }
                else
                {
                    m_CurrentEnergyLeft = i_CurrentEnergyLeft;
                }
            }
        }

        protected abstract void AddEnergyToVehicle(float i_EnergyToAdd);

        public abstract override string ToString();
    }

}
