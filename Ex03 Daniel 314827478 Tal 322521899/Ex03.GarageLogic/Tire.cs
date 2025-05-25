using System;

namespace Ex03.GarageLogic
{
    internal class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        internal Tire(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        internal void InflateTire(float i_AirPressureToadd)
        {
            float PressureAfterUpdate = m_CurrentAirPressure + i_AirPressureToadd;

            if (PressureAfterUpdate > m_MaxAirPressure)
            {
                throw new ValueRangeException(m_MaxAirPressure, 0, 
                    string.Format($"The air pressure range of that tire is {0} - {m_MaxAirPressure}"));
            }
            else
            {
                m_CurrentAirPressure = PressureAfterUpdate;
            }
        }
    }
}
