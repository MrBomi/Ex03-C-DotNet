namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelTank = 5.8f;

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) :
            base(i_ModelName, i_LicenseID, new Fuel(0, k_MaxFuelTank, eFuelType.Octan98))
        { }

        public override string SpecifVehiclePropertiesInfo()
        {
            string specificVehicleProperties = string.Format(
                "Fuel Type: {0}\n" +
                "Max Fuel Tank: {1} liters\n",
                ((Fuel)EnergySource).FuelType.ToString(),
                ((Fuel)EnergySource).MaxEnergyAmount);

            return specificVehicleProperties;
        }
    }
}
