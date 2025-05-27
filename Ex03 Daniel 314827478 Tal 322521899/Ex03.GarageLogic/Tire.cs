using System;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        internal Tire(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer name cannot be null or empty.");
                }
                else
                {
                    m_ManufacturerName = value;
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value < 0 || value > m_MaxAirPressure)
                {
                    throw new ValueRangeException(m_MaxAirPressure, 0,
                        string.Format($"The air pressure range of that tire is {0} - {m_MaxAirPressure}"));
                }
                else
                {
                    m_CurrentAirPressure = value;
                }
            }
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

        public override string ToString()
        {
            string tireDetails = string.Format("{Manufacturer: {0}, Current Air Pressure: {1}\n}",
                    m_ManufacturerName, m_CurrentAirPressure.ToString());
            return tireDetails;
        }
    }
}
