namespace Ex03.GarageLogic
{
    internal class Battery : EnergySource
    {
        private const int k_MinutesInHour = 60;
        public Battery(float i_CurrentEnergyLeft, float i_MaxEnergyAmount) : base(i_CurrentEnergyLeft, i_MaxEnergyAmount) { }

        public override void AddEnergyToVehicle(float i_EnergyToAdd)
        {
            ChargeVehicle(i_EnergyToAdd);
        }

        public void ChargeVehicle(float i_MinutesToAdd) 
        {
            float upadtedBatteryLeft = this.CurrentEnergyLeft + i_MinutesToAdd / k_MinutesInHour;

            if(upadtedBatteryLeft > this.MaxEnergyAmount)
            {
                throw new ValueRangeException(this.MaxEnergyAmount, 0,
                    string.Format($"The battery can contain up to {this.MaxEnergyAmount} energy (in minutes)"));
            }
            else
            {
                this.CurrentEnergyLeft = upadtedBatteryLeft;
            }
        }

        public override string ToString()
        {
            return string.Format("Battery: {0} hours left , max energy amount is {1} ", this.CurrentEnergyLeft, this.MaxEnergyAmount);
        }
    }
}
