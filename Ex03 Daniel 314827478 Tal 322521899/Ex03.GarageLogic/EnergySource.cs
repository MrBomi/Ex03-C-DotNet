using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class EnergySource
    {
        protected float m_CurrentEnergyLeft { get; set; }
        protected float m_MaxEnergyAmount { get;}

        protected abstract void AddEnergyToVehicle(float i_EnergyToAdd);
    }

}
