namespace Ex03.GarageLogic
{
    public class ElectricEngine : Energy
    {
        public ElectricEngine(float i_MaximumFuelCapacity) : base(i_MaximumFuelCapacity)
        {
        }

        public void HoursOfElectricityAddition(float i_HoursToAdd)
        {
            EnergyAddition(i_HoursToAdd);
        }

        public override string ToString()
        {
            string str = string.Format("The remaining hours of battery are {0}", remainingEnergy);
            return str;
        }
    }
}
