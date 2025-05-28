using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrentEnergyLeft;
        private float m_MaxEnergyAmount;

        public float CurrentEnergyLeft
        {
            get 
            { 
                return m_CurrentEnergyLeft; 
            }
            set 
            {
                m_CurrentEnergyLeft = value;
            }
        }

        public float MaxEnergyAmount
        {
            get
            {
                return m_MaxEnergyAmount;
            }
            set
            {
                m_MaxEnergyAmount = value;
            }
        }

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

        public abstract void AddEnergyToVehicle(float i_EnergyToAdd);

        public abstract override string ToString();
    }

}
