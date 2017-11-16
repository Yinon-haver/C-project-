using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Energy
    {
        private eFuelType m_FuelType;

        public eFuelType fuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public FuelEngine(eFuelType i_FuelType, float i_MaximumFuelCapacity) : base(i_MaximumFuelCapacity)
        {
            m_FuelType = i_FuelType;
        }

        /// <summary>
        /// receives the quantity of fuel
        /// to add to the tank without exceeding
        /// from maximum fuel capacity and checking
        /// if the fuel type fits the car's type
        /// </summary>
        /// <param name="i_energyToAdd"></param>
        /// <param name="i_Fueltype"></param>
        public void FuelAddition(eFuelType i_Fueltype, float i_EnergyToAdd)
        {
            if (!i_Fueltype.Equals(m_FuelType))
            {
                throw new ArgumentException();
            }

            EnergyAddition(i_EnergyToAdd);
        }

        public override string ToString()
        {
            string str = string.Format("The fuel type is {0} and the remaining quantity of fuel is {1}", m_FuelType, remainingEnergy);
            return str;
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }
    }
}
